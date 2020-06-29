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

namespace MoneyBunny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string GetTextFromPdfUsingToxy(string file_path)
        {
            var context = new ParserContext(file_path);
            var parser = new PDFTextParser(context);
            var content = parser.Parse();
            return content.Replace("\n", "\r\n");
        }

        private string GetTextFromPdfUsingTika(string file_path)
        {
            var content = new TextExtractor().Extract(file_path).Text;
            return content.Replace("\r\n\r\n", "\r\n");
        }

        private string GetTextFromPdfUsingDocNet(string file_path)
        {
            string text = "";
            using (var library = DocLib.Instance)
            using (var docReader = library.GetDocReader(file_path, new PageDimensions(1, 1)))
            {
                foreach (var page_index in Enumerable.Range(0, docReader.GetPageCount()))
                {
                    using (var pageReader = docReader.GetPageReader(page_index))
                    {
                        text += pageReader.GetText();
                    }
                }
            }
            return text;
        }

        private void BtnImportFile_Click(object sender, EventArgs args)
        {
            var file_path = TxtFilePath.Text;
            var file_content = GetTextFromPdfUsingToxy(file_path);
            TxtInput.Text = file_content;
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "PDF|*.pdf";
                dlg.InitialDirectory = Directory.GetCurrentDirectory();
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                TxtFilePath.Text = dlg.FileName;
            }
        }

        private void BtnProcessInput_Click(object sender, EventArgs e)
        {
            var parser = new MvbParser(TxtInput.Text);
            if (!parser.Parse())
            {
                Debug.Print("Error parsing file");
            }
            Debug.Print("Found " + parser.Transactions.Count.ToString() + " Transaction");
        }

        private void BtnImportAndProcess_Click(object sender, EventArgs e)
        {
            BtnImportFile.PerformClick();
            BtnProcessInput.PerformClick();
        }
    }
}
