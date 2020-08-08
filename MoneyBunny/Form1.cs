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
using MoneyBunny.ExtensionMethods;
using MoneyBunny.DataStore;
using DocumentFormat.OpenXml.Drawing.Charts;

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

        public Form1()
        {
            InitializeComponent();

            UpdateCategories();
            UpdateTransactions();
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

                var current_transactions = DataBase.GetTransactions().ToHashSet();
                var new_transactions = parser.Transactions
                    .Where(t => !current_transactions.Contains(t));

                // ToList() to force the evaluation of the returned IEnumerable
                ApplyRules(new_transactions).ToList();
                DataBase.InsertTransactions(new_transactions);
            }

            UpdateTransactions();
        }

        private void UpdateTransactions()
        {
            DgvTransactions.Rows.Clear();

            (var filter, var category) = GetCategoryFilter();

            IEnumerable<long> ids = new[] { category?.CategoryId }
                .Where(id => id != null)
                .Cast<long>();

            var order = DbOrder.ByDateDescending;
            foreach (var transaction in DataBase.GetTransactions(filter, ids, order))
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

                var category_cell = new DataGridViewTextBoxCell();
                if (filter == DbFilter.WhereCategoryId)
                {
                    category_cell.Value = category.Name;
                }
                else if (filter == DbFilter.All &&
                    transaction.CategoryId.HasValue)
                {
                    category_cell.Value = DataBase.GetCategories(
                        DbFilter.WhereCategoryId,
                        new[] { transaction.CategoryId.Value }
                        ).FirstOrDefault()?.Name;
                };
                row.Cells.Add(category_cell);

                row.Tag = transaction;

                DgvTransactions.Rows.Add(row);
            }
        }

        private void BtnManageCategories_Click(object sender, EventArgs e)
        {
            using (var dlg = new ManageCategories())
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                UpdateCategories();
            }
        }

        private Category GetCategorySelection()
        {
            if (CmbCategoryFilter.Items.Count == 0)
            {
                return null;
            }

            var index = CmbCategorySelection.SelectedIndex;
            var categories = CmbCategorySelection.Tag as List<Category>;
            return categories[index];
        }

        private (DbFilter, Category) GetCategoryFilter()
        {
            var index = CmbCategoryFilter.SelectedIndex;

            if (index == 0)
            {
                return (DbFilter.All, null);
            }
            else if (index == 1)
            {
                return (DbFilter.WhereNoCategory, null);
            }
            else
            {
                var categories = CmbCategoryFilter.Tag as List<Category>;
                return (DbFilter.WhereCategoryId, categories[index - 2]);
            }
        }

        private void UpdateCategories()
        {
            var categories = DataBase.GetCategories().ToList();

            CmbCategorySelection.Items.Clear();
            CmbCategorySelection.Items.AddRange(categories.Select(c => c.Name).ToArray());
            CmbCategorySelection.Tag = categories;
            if (CmbCategorySelection.Items.Count > 0)
            {
                CmbCategorySelection.SelectedIndex = 0;
            }

            CmbCategoryFilter.Items.Clear();
            CmbCategoryFilter.Items.Add("Any");
            CmbCategoryFilter.Items.Add("Uncategorized");
            CmbCategoryFilter.Items.AddRange(categories.Select(c => c.Name).ToArray());
            CmbCategoryFilter.Tag = categories;
            CmbCategoryFilter.SelectedIndex = 0;
        }

        private void BtnApplyCategory_Click(object sender, EventArgs e)
        {
            var category = GetCategorySelection();

            var categorized_transactions = DgvTransactions.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r =>
                {
                    var transaction = r.Tag as Transaction;
                    transaction.CategoryId = category.CategoryId;
                    return transaction;
                });

            DataBase.UpdateTransactionCategories(categorized_transactions);
            UpdateTransactions();
        }

        private void DgvTransaction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex != 0)
            {
                return;
            }

            var cell = DgvTransactions.Rows[e.RowIndex].Cells["DgcSelection"];

            var prev = cell.Value != null && (bool)cell.Value;
            DgvTransactions.Rows[e.RowIndex].Cells["DgcSelection"].Value = !prev;
        }

        private void CmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTransactions();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearAllTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBase.ClearTransactions();
        }

        private void BtnStatistics_Click(object sender, EventArgs e)
        {
            using (var dlg = new Statistics())
            {
                dlg.Transactions = DataBase.GetTransactions();
                dlg.Categories = DataBase.GetCategories();
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
            var transactions = DataBase.GetTransactions()
                .Select(t =>
                {
                    t.CategoryId = null;
                    return t;
                });

            DataBase.UpdateTransactionCategories(transactions);
        }

        private IEnumerable<Transaction> ApplyRules(IEnumerable<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                foreach (var category in DataBase.GetCategories())
                {
                    category.Rules = DataBase.GetRules(
                        DbFilter.WhereCategoryId,
                        new[] { category.CategoryId.Value });

                    if (category.Rules == null)
                    {
                        continue;
                    }

                    if (category.ApplyRules(transaction))
                    {
                        transaction.CategoryId = category.CategoryId;
                        yield return transaction;
                    }
                }
            }
        }

        private void applyRulesToUncategorizedTransactionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var transactions = ApplyRules(DataBase.GetTransactions(DbFilter.WhereNoCategory));
            DataBase.UpdateTransactionCategories(transactions);
            UpdateTransactions();
        }

        private void applyRulesToAllTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var transactions = ApplyRules(DataBase.GetTransactions());
            DataBase.UpdateTransactionCategories(transactions);
            UpdateTransactions();
        }
    }
}
