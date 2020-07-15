using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Docnet.Core;
using Docnet.Core.Models;
using Docnet.Core.Readers;
using System.Runtime.InteropServices;
using TikaOnDotNet.TextExtraction;
using Toxy;
using Toxy.Parsers;
using java.rmi.dgc;
using MoneyBunny.Properties;
using net.arnx.jsonic;
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
            Transactions = LoadStoredTransaction();
            if (Transactions == null)
            {
                Transactions = new HashSet<Transaction>();
            }
            DisplayTransactions(Transactions);
        }

        private string GetTextFromPdfUsingToxy(string file_path)
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
                var file_content = GetTextFromPdfUsingToxy(file_path);

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

            foreach (var transaction in transactions)
            {
                var row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewCheckBoxCell());

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
                    Value = transaction.Value.ToString()
                };
                row.Cells.Add(value);

                DgvTransaction.Rows.Add(row);
            }
        }
    }
}
