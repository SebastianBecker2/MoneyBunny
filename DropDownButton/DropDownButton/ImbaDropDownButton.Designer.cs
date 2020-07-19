namespace ImbaControls.DropDownButton
{
	partial class ImbaDropDownButton {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.btnMain = new System.Windows.Forms.Button();
      this.btnDrop = new System.Windows.Forms.Button();
      this.dgvDrop = new ImbaControls.GridView();
      this.clmIcon = new System.Windows.Forms.DataGridViewImageColumn();
      this.clmText = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dgvDrop)).BeginInit();
      this.SuspendLayout();
      // 
      // btnMain
      // 
      this.btnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMain.Location = new System.Drawing.Point(0, 0);
      this.btnMain.Name = "btnMain";
      this.btnMain.Size = new System.Drawing.Size(145, 21);
      this.btnMain.TabIndex = 0;
      this.btnMain.UseVisualStyleBackColor = true;
      // 
      // btnDrop
      // 
      this.btnDrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDrop.Location = new System.Drawing.Point(142, 0);
      this.btnDrop.Name = "btnDrop";
      this.btnDrop.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
      this.btnDrop.Size = new System.Drawing.Size(21, 21);
      this.btnDrop.TabIndex = 2;
      this.btnDrop.Text = "▼";
      this.btnDrop.UseVisualStyleBackColor = true;
      // 
      // dgvDrop
      // 
      this.dgvDrop.AllowUserToAddRows = false;
      this.dgvDrop.AllowUserToDeleteRows = false;
      this.dgvDrop.AllowUserToResizeColumns = false;
      this.dgvDrop.AllowUserToResizeRows = false;
      this.dgvDrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvDrop.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.dgvDrop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvDrop.ColumnHeadersVisible = false;
      this.dgvDrop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIcon,
            this.clmText});
      this.dgvDrop.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.dgvDrop.Location = new System.Drawing.Point(0, 20);
      this.dgvDrop.MultiSelect = false;
      this.dgvDrop.Name = "dgvDrop";
      this.dgvDrop.ReadOnly = true;
      this.dgvDrop.RowHeadersVisible = false;
      this.dgvDrop.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dgvDrop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvDrop.ShowCellErrors = false;
      this.dgvDrop.ShowEditingIcon = false;
      this.dgvDrop.ShowRowErrors = false;
      this.dgvDrop.Size = new System.Drawing.Size(162, 150);
      this.dgvDrop.TabIndex = 3;
      this.dgvDrop.VerticalDragScroll = true;
      this.dgvDrop.Visible = false;
      // 
      // clmIcon
      // 
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.NullValue = "System.Drawing.Bitmap";
      this.clmIcon.DefaultCellStyle = dataGridViewCellStyle1;
      this.clmIcon.HeaderText = "Icon";
      this.clmIcon.MinimumWidth = 2;
      this.clmIcon.Name = "clmIcon";
      this.clmIcon.ReadOnly = true;
      this.clmIcon.Width = 2;
      // 
      // clmText
      // 
      this.clmText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.clmText.HeaderText = "Text";
      this.clmText.Name = "clmText";
      this.clmText.ReadOnly = true;
      this.clmText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // ImbaDropDownButton
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.dgvDrop);
      this.Controls.Add(this.btnDrop);
      this.Controls.Add(this.btnMain);
      this.Name = "ImbaDropDownButton";
      this.Size = new System.Drawing.Size(162, 21);
      ((System.ComponentModel.ISupportInitialize)(this.dgvDrop)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion


    private System.Windows.Forms.Button btnMain;
    private System.Windows.Forms.Button btnDrop;
    private GridView dgvDrop;
    private System.Windows.Forms.DataGridViewImageColumn clmIcon;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmText;
  }
}
