using Cyotek.GhostScript;
using Cyotek.GhostScript.PdfConversion;
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

namespace MoneyBunny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string OcrTiffFile(string file)
        {
            using (var engine = new Tesseract.TesseractEngine(@"./tessdata", "deu", Tesseract.EngineMode.Default))
            using (var img = Tesseract.Pix.LoadFromFile(file))
            using (var page = engine.Process(img))
            {
                return page.GetText();
            }
        }

        IEnumerable<string> ConvertPdfToTiffGhostScript(string file)
        {
            var parent_folder = Path.GetDirectoryName(file);
            var target = Path.Combine(parent_folder, Guid.NewGuid().ToString());
            Directory.CreateDirectory(target);

            var file_name = Path.GetFileNameWithoutExtension(file);

            var settings = new Pdf2ImageSettings
            {
                // High anti aliasing seems to be the best for OCR
                // Surprisingly no anti aliasing performs really bad
                AntiAliasMode = AntiAliasMode.High,
                // 250 seems to be the absolut sweet spot 
                // Less or more reduces OCR quality significantly
                Dpi = 250,
                // Doesn't seem to impact the OCR quality
                GridFitMode = GridFitMode.None,
                // ImageFormats have not been tested
                // But TiffMono should suffice
                ImageFormat = Cyotek.GhostScript.ImageFormat.TiffMono,
                // CropBox seems to be just as good
                TrimMode = PdfTrimMode.TrimBox,
            };
            var converter = new Pdf2Image(file, settings);

            return Enumerable.Range(0, converter.PageCount).Select(index =>
            {
                var output_file = Path.Combine(target, file_name + " (" + index.ToString("D5") + ").tiff");
                converter.ConvertPdfPageToImage(output_file, index + 1);
                return output_file;
            });
        }

        private void BtnImportFile_Click(object sender, EventArgs args)
        {
            var file_path = TxtFilePath.Text;

            var file_contents = ConvertPdfToTiffGhostScript(file_path)
                .AsParallel()
                .AsOrdered()
                .Select(file => OcrTiffFile(file));

            foreach (var page in file_contents)
            {
                Debug.Print(page);
            }
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
            parser.Parse();
        }
    }
}
