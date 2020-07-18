using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Toxy;
using Toxy.Parsers;
using MoneyBunny.Properties;
using Newtonsoft.Json;

namespace MoneyBunny
{
    public partial class Form1 : Form
    {
        public string BankStatementFolder
        {
            get
            { return Settings.Default.BankStatementFolder; }
            set
            {
                Settings.Default.BankStatementFolder = value; Settings.Default.Save();
            }
        }

        public ICollection<Category> Categories { get; set; }

        private OrderedSet<Category> LoadCategories()
        {
            return JsonConvert.DeserializeObject<OrderedSet<Category>>(Settings.Default.Categories);
        }

        private void StoreCategories(IEnumerable<Category> categories)
        {
            Settings.Default.Categories = JsonConvert.SerializeObject(categories);
            Settings.Default.Save();
        }

        public HashSet<Transaction> Transactions { get; set; }

        private HashSet<Transaction> LoadStoredTransaction()
        {
            return JsonConvert.DeserializeObject<HashSet<Transaction>>(
                Settings.Default.StoredTransactions);
        }

        private void StoreTransactions(IEnumerable<Transaction> transactions)
        {
            Settings.Default.StoredTransactions = JsonConvert.SerializeObject(transactions);
            Settings.Default.Save();
        }

        public Form1()
        {
            InitializeComponent();

            Categories = LoadCategories();
            if (Categories == null)
            {
                Categories = new OrderedSet<Category>();
            }

            UpdateCategories(Categories);

            Transactions = LoadStoredTransaction();
            if (Transactions == null)
            {
                Transactions = new HashSet<Transaction>();
            }

            DisplayTransactions(Transactions);
        }

        private string GetTextFromPdf(string file_path)
        {
            var context = new ParserContext(file_path);
            var parser = new PDFTextParser(context);
            var content = parser.Parse();
            return content.Replace("\n", "\r\n");
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = BankStatementFolder;
                dlg.Filter = "PDF|*.pdf";
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                TxtFilePath.Text = dlg.FileName;
                BankStatementFolder = Path.GetDirectoryName(dlg.FileName);
            }
        }

        private void BtnImportAndProcess_Click(object sender, EventArgs e)
        {
            string[] file_paths;
            using (var dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = BankStatementFolder;
                dlg.Filter = "PDF|*.pdf";
                dlg.Multiselect = true;
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                BankStatementFolder = Path.GetDirectoryName(dlg.FileName);
                file_paths = dlg.FileNames;
            }

            foreach (var file_path in file_paths)
            {
                var file_content = GetTextFromPdf(file_path);

                var parser = new MvbParser(file_content);
                if (!parser.Parse())
                {
                    Debug.Print("Error parsing file");
                }
                Debug.Print("Found " + parser.Transactions.Count.ToString() + " Transaction");

                Transactions.UnionWith(parser.Transactions);
            }

            StoreTransactions(Transactions);
            DisplayTransactions(Transactions);
        }

        private void DisplayTransactions(IEnumerable<Transaction> transactions)
        {
            DgvTransaction.Rows.Clear();

            if (transactions == null)
            {
                return;
            }

            var category_filter_id = CmbCategoryFilter.SelectedItem.ToString();
            if (category_filter_id != "Any")
            {
                // Category filter "Uncategorized" will translate to null.
                // Which in turn will show uncategorized transactions,
                // because those have null as their category_id.
                category_filter_id = Categories
                    .FirstOrDefault(c => c.Name == category_filter_id)
                    ?.Id;
            }

            foreach (var transaction in transactions
                .Where(t => category_filter_id == "Any" || t.CategoryId == category_filter_id)
                .OrderBy(t => t.Date))
            {
                var row = new DataGridViewRow();

                var selection = new DataGridViewCheckBoxCell();
                row.Cells.Add(selection);

                var date = new DataGridViewTextBoxCell()
                {
                    Value = transaction.Date.ToString("d")
                };
                row.Cells.Add(date);

                var type = new DataGridViewTextBoxCell()
                {
                    Value = transaction.Type
                };
                row.Cells.Add(type);

                var reference = new DataGridViewTextBoxCell()
                {
                    Value = transaction.Reference
                };
                row.Cells.Add(reference);

                var value = new DataGridViewTextBoxCell()
                {
                    Value = transaction.Value.ToValueString()
                };
                row.Cells.Add(value);

                var cat = Categories.FirstOrDefault(c => c.Id == transaction.CategoryId);
                var category = new DataGridViewTextBoxCell()
                {
                    Value = cat?.Name
                };
                row.Cells.Add(category);

                row.Tag = transaction;

                DgvTransaction.Rows.Add(row);
            }
        }

        private void BtnManageCategories_Click(object sender, EventArgs e)
        {
            using (var dlg = new ManageCategories())
            {
                dlg.Categories = Categories;
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                Categories = dlg.Categories;

                StoreCategories(Categories);
                UpdateCategories(Categories);
            }
        }

        private void UpdateCategories(IEnumerable<Category> categories)
        {
            CmbCategorySelection.Items.Clear();
            CmbCategorySelection.Items.AddRange(categories.Select(c => c.Name).ToArray());
            if (CmbCategorySelection.Items.Count > 0)
            {
                CmbCategorySelection.SelectedIndex = 0;
            }

            CmbCategoryFilter.Items.Clear();
            CmbCategoryFilter.Items.Add("Any");
            CmbCategoryFilter.Items.Add("Uncategorized");
            CmbCategoryFilter.Items.AddRange(categories.Select(c => c.Name).ToArray());
            CmbCategoryFilter.SelectedIndex = 0;
        }

        private void BtnApplyCategory_Click(object sender, EventArgs e)
        {
            var category = Categories.First(c => c.Name == CmbCategorySelection.SelectedItem.ToString());

            foreach (DataGridViewRow row in DgvTransaction.Rows)
            {
                var cell = row.Cells["DgcSelection"] as DataGridViewCheckBoxCell;
                if (cell.Value == null || !(bool)cell.Value)
                {
                    continue;
                }

                var transaction = row.Tag as Transaction;
                transaction.CategoryId = category.Id;
            }

            StoreTransactions(Transactions);
            DisplayTransactions(Transactions);
        }

        private void DgvTransaction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var cell = DgvTransaction.Rows[e.RowIndex].Cells["DgcSelection"];

            var prev = cell.Value != null && (bool)cell.Value;
            DgvTransaction.Rows[e.RowIndex].Cells["DgcSelection"].Value = !prev;
        }

        private void CmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTransactions(Transactions);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearAllTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.Clear();
            StoreTransactions(Transactions);
            DisplayTransactions(Transactions);
        }

        private void BtnStatistics_Click(object sender, EventArgs e)
        {
            using (var dlg = new Statistics())
            {
                dlg.Transactions = Transactions;
                dlg.Categories = Categories;
                dlg.ShowDialog();
            }
        }

        private void BtnToDoList_Click(object sender, EventArgs e)
        {
            using (var dlg = new ToDoManager.ToDoManager())
            {
                dlg.ShowDialog();
            }
        }

        private void removeCategoriesFromTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var transaction in Transactions)
            {
                transaction.CategoryId = null;
            }
        }
    }
}
