namespace MoneyBunny
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnImportFile = new System.Windows.Forms.Button();
            this.TxtFilePath = new System.Windows.Forms.TextBox();
            this.BtnSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtInput = new System.Windows.Forms.TextBox();
            this.BtnProcessInput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnImportFile
            // 
            this.BtnImportFile.Location = new System.Drawing.Point(713, 39);
            this.BtnImportFile.Name = "BtnImportFile";
            this.BtnImportFile.Size = new System.Drawing.Size(75, 23);
            this.BtnImportFile.TabIndex = 1;
            this.BtnImportFile.Text = "Import File";
            this.BtnImportFile.UseVisualStyleBackColor = true;
            this.BtnImportFile.Click += new System.EventHandler(this.BtnImportFile_Click);
            // 
            // TxtFilePath
            // 
            this.TxtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFilePath.Location = new System.Drawing.Point(90, 13);
            this.TxtFilePath.Name = "TxtFilePath";
            this.TxtFilePath.Size = new System.Drawing.Size(667, 20);
            this.TxtFilePath.TabIndex = 1;
            this.TxtFilePath.Text = "D:\\Eigene Dateien\\Repos\\MoneyBunny\\MoneyBunny\\bin\\Debug\\332565019_2020_Nr.004_Kon" +
    "toauszug_vom_30.04.2020_20200604171629.pdf";
            // 
            // BtnSelectFile
            // 
            this.BtnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelectFile.Location = new System.Drawing.Point(763, 11);
            this.BtnSelectFile.Name = "BtnSelectFile";
            this.BtnSelectFile.Size = new System.Drawing.Size(25, 23);
            this.BtnSelectFile.TabIndex = 2;
            this.BtnSelectFile.Text = "...";
            this.BtnSelectFile.UseVisualStyleBackColor = true;
            this.BtnSelectFile.Click += new System.EventHandler(this.BtnSelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kontoauszug:";
            // 
            // TxtInput
            // 
            this.TxtInput.Location = new System.Drawing.Point(15, 70);
            this.TxtInput.Multiline = true;
            this.TxtInput.Name = "TxtInput";
            this.TxtInput.Size = new System.Drawing.Size(387, 328);
            this.TxtInput.TabIndex = 4;
            this.TxtInput.Text = resources.GetString("TxtInput.Text");
            // 
            // BtnProcessInput
            // 
            this.BtnProcessInput.Location = new System.Drawing.Point(409, 374);
            this.BtnProcessInput.Name = "BtnProcessInput";
            this.BtnProcessInput.Size = new System.Drawing.Size(75, 23);
            this.BtnProcessInput.TabIndex = 0;
            this.BtnProcessInput.Text = "Process Input";
            this.BtnProcessInput.UseVisualStyleBackColor = true;
            this.BtnProcessInput.Click += new System.EventHandler(this.BtnProcessInput_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnProcessInput);
            this.Controls.Add(this.TxtInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSelectFile);
            this.Controls.Add(this.TxtFilePath);
            this.Controls.Add(this.BtnImportFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnImportFile;
        private System.Windows.Forms.TextBox TxtFilePath;
        private System.Windows.Forms.Button BtnSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtInput;
        private System.Windows.Forms.Button BtnProcessInput;
    }
}

