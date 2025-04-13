namespace MoneyBunny
{
    using MoneyBunny.DataStore;
    using MoneyBunny.Rules;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Point = System.Drawing.Point;

    public partial class ManageCategories : Form
    {
        public List<Category> DeletedCategories { get; set; } = [];

        public ManageCategories()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            DisplayCategories();
            base.OnLoad(e);
        }

        private void BtnOkay_Click(object sender, EventArgs e)
        {
            UpdateCategories();
            DialogResult = DialogResult.OK;
        }

        private void UpdateCategories()
        {
            foreach (DataGridViewRow row in DgvCategories.Rows)
            {
                var name = row.Cells["DgcName"].Value as string;

                if (name == null && row.Tag == null)
                {
                    continue;
                }

                // Remove categories without name
                if (name == null)
                {
                    DeletedCategories.Add(row.Tag as Category);
                    continue;
                }

                // Add categories that didn't exist previously
                if (row.Tag == null)
                {
                    DataBase.InsertCategories(
                        [Category.NewCategory(name)]);
                    // Store rules to DB (inserting)
                    continue;
                }

                var category = row.Tag as Category;

                // Add categories that didn't exist previously
                // but got created by adding rules to it.
                if (!category.CategoryId.HasValue)
                {
                    DataBase.InsertCategories([category]);
                }

                // Override category name if necessary
                if (category.Name != name)
                {
                    category.Name = name;
                    DataBase.UpdateCategoryName([category]);
                }
            }

            // Actually remove the categories that either
            // - Had existed before and got their name removed
            // - Had been removed using the remove button
            DataBase.DeleteCategories(DeletedCategories);
        }

        private void DisplayCategories()
        {
            DgvCategories.Rows.Clear();

            foreach (var category in DataBase.GetCategories())
            {
                var row = new DataGridViewRow()
                {
                    Tag = category
                };

                var name = new DataGridViewTextBoxCell()
                {
                    Value = category.Name
                };
                _ = row.Cells.Add(name);

                _ = DgvCategories.Rows.Add(row);
            }
        }

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        private void DgvCategories_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = DgvCategories.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                var dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(
                    new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)),
                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void DgvCategories_DragOver(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Move;

        private void DgvCategories_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            var clientPoint = DgvCategories.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop =
                DgvCategories.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                var rowToMove = e.Data.GetData(
                    typeof(DataGridViewRow)) as DataGridViewRow;
                DgvCategories.Rows.RemoveAt(rowIndexFromMouseDown);
                DgvCategories.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
            }
        }

        private void DgvCategories_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                    
                    var dropEffect = DgvCategories.DoDragDrop(
                    DgvCategories.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            var row = new DataGridViewRow();
            _ = row.Cells.Add(new DataGridViewTextBoxCell());
            _ = DgvCategories.Rows.Add(row);
        }

        private void BtnRemoveCategory_Click(object sender, EventArgs e)
        {
            if (DgvCategories.SelectedRows.Count != 1)
            {
                return;
            }

            var row = DgvCategories.SelectedRows[0];
            var category = row.Tag as Category;

            if (category != null)
            {
                DeletedCategories.Add(category);
            }
            DgvCategories.Rows.Remove(row);
        }

        private void BtnRules_Click(object sender, EventArgs e)
        {
            if (DgvCategories.SelectedRows.Count != 1)
            {
                return;
            }

            var row = DgvCategories.SelectedRows[0];


            using var dlg = new ConfigureRules();
            if (row.Tag == null)
            {
                var cell = row.Cells["DgcName"] as DataGridViewTextBoxCell;
                row.Tag = Category.NewCategory(cell.Value.ToString());
            }

            var category = row.Tag as Category;
            if (category.Rules == null
                && category.CategoryId.HasValue)
            {
                category.Rules = DataBase.GetRules(
                    DbFilter.WhereCategoryId,
                    [category.CategoryId.Value]);
            }

            dlg.Rules = category.Rules;

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            category.Rules = [.. dlg.Rules];
            if (category.CategoryId.HasValue)
            {
                // Store rules to DB (updating)
                DataBase.UpdateCategoryRules([category]);
            }
        }
    }
}
