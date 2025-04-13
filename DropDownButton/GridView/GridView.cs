namespace ImbaControls
{
	public class GridView : System.Windows.Forms.DataGridView
	{
		private const bool DefaultVerticalDragScroll = false;

		private const System.Windows.Forms.DataGridViewColumnSortMode DefaultColumnSortMode =
			System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

		private System.Windows.Forms.DataGridViewColumnSortMode m_column_sort_mode;
		private bool MouseDownOnCell { get; set; }
		private int MouseDownPosition { get; set; }
		private int MouseDownFirstDisplayedRow { get; set; }

		public new int FirstDisplayedScrollingRowIndex
        {
            get => base.FirstDisplayedScrollingRowIndex;
            set
            {
                if (value < 0)
                {
                    base.FirstDisplayedScrollingRowIndex = 0;
                }
                else if (value > (this.RowCount - 1))
                {
                    base.FirstDisplayedScrollingRowIndex = this.RowCount - 1;
                }
                else
                {
                    base.FirstDisplayedScrollingRowIndex = value;
                }
            }
        }

        [System.ComponentModel.Browsable(true)]
		[System.ComponentModel.DefaultValue(DefaultVerticalDragScroll)]
		[System.ComponentModel.Category("Layout")]
		[System.ComponentModel.Description("Determines if the content should scroll" +
			" vertically when dragging a row up or down.")]
		[System.ComponentModel.Localizable(false)]
		public bool VerticalDragScroll { get; set; }

		[System.ComponentModel.Browsable(true)]
		[System.ComponentModel.DefaultValue(DefaultColumnSortMode)]
		[System.ComponentModel.Category("Behavior")]
		[System.ComponentModel.Description("Sets or gets the current column sort mode.")]
		[System.ComponentModel.Localizable(false)]
		public System.Windows.Forms.DataGridViewColumnSortMode ColumnSortMode
        {
            get => m_column_sort_mode;
            set
            {
                m_column_sort_mode = value;
                foreach (System.Windows.Forms.DataGridViewColumn column in this.Columns)
                {
                    column.SortMode = m_column_sort_mode;
                }
            }
        }

        public GridView()
		{
			this.MouseDownOnCell = false;
			this.VerticalDragScroll = DefaultVerticalDragScroll;
			this.ColumnSortMode = DefaultColumnSortMode;

			ColumnAdded += ColumnAddedHandler;
			CellMouseDown += CellMouseDownHandler;
			MouseUp += MouseUpHandler;
			MouseMove += MouseMoveHandler;
		}

        private void ColumnAddedHandler(object sender, System.Windows.Forms.DataGridViewColumnEventArgs e) => e.Column.SortMode = this.ColumnSortMode;

        private void CellMouseDownHandler(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
		{
			if (!this.VerticalDragScroll) return;

			this.MouseDownOnCell = true;
			this.MouseDownPosition = e.Y + this.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Y;
			this.MouseDownFirstDisplayedRow = this.FirstDisplayedScrollingRowIndex;
		}

        private void MouseUpHandler(object sender, System.Windows.Forms.MouseEventArgs e) => this.MouseDownOnCell = false;

        private void MouseMoveHandler(object sneder, System.Windows.Forms.MouseEventArgs e)
		{
			if (!this.MouseDownOnCell) return;

			var scroll_offset = MouseDownPosition - e.Y;
			var column_offset = scroll_offset / this.Rows[0].Height;
			this.FirstDisplayedScrollingRowIndex = MouseDownFirstDisplayedRow + column_offset;
		}

		public void DeselectAll()
		{
			ClearSelection();
			CurrentCell = null;
		}

        public bool HasRowSelected() => SelectedRows.Count > 0;

        public System.Windows.Forms.DataGridViewRow SelectedRow => SelectedRows[0];

        public void SelectLastRow() => Rows[Rows.Count - 1].Selected = true;

        public void SelectFirstRow() => Rows[0].Selected = true;

        public void SelectRow(int index) => Rows[index].Selected = true;
    }
}