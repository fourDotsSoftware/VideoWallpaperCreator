namespace VideoWallpaperCreator
{
    partial class frmBatchCut
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsdbAddFile = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsdbAddFolder = new System.Windows.Forms.ToolStripSplitButton();
            this.tsdbImportList = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgFiles
            // 
            this.dgFiles.AllowDrop = true;
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.AllowUserToDeleteRows = false;
            this.dgFiles.AllowUserToResizeRows = false;
            this.dgFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilename,
            this.colSize,
            this.colFileDate,
            this.colFullFilePath});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFiles.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgFiles.GridColor = System.Drawing.Color.Black;
            this.dgFiles.Location = new System.Drawing.Point(0, 65);
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.RowHeadersVisible = false;
            this.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgFiles.Size = new System.Drawing.Size(769, 227);
            this.dgFiles.TabIndex = 34;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdbAddFile,
            this.tsbRemove,
            this.tsbClear,
            this.toolStripSeparator3,
            this.tsdbAddFolder,
            this.tsdbImportList,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(769, 62);
            this.toolStrip1.TabIndex = 53;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsdbAddFile
            // 
            this.tsdbAddFile.AutoSize = false;
            this.tsdbAddFile.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsdbAddFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsdbAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdbAddFile.Name = "tsdbAddFile";
            this.tsdbAddFile.Size = new System.Drawing.Size(80, 59);
            this.tsdbAddFile.Text = "Add File(s)";
            this.tsdbAddFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbRemove
            // 
            this.tsbRemove.AutoSize = false;
            this.tsbRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Size = new System.Drawing.Size(70, 59);
            this.tsbRemove.Text = "Remove";
            this.tsbRemove.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbClear
            // 
            this.tsbClear.AutoSize = false;
            this.tsbClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(70, 59);
            this.tsbClear.Text = "Clear";
            this.tsbClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 62);
            // 
            // tsdbAddFolder
            // 
            this.tsdbAddFolder.AutoSize = false;
            this.tsdbAddFolder.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsdbAddFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsdbAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdbAddFolder.Name = "tsdbAddFolder";
            this.tsdbAddFolder.Size = new System.Drawing.Size(80, 59);
            this.tsdbAddFolder.Text = "Add Folder";
            this.tsdbAddFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsdbImportList
            // 
            this.tsdbImportList.AutoSize = false;
            this.tsdbImportList.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsdbImportList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsdbImportList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdbImportList.Name = "tsdbImportList";
            this.tsdbImportList.Size = new System.Drawing.Size(80, 59);
            this.tsdbImportList.Text = "Import List";
            this.tsdbImportList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 62);
            // 
            // colFilename
            // 
            this.colFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFilename.DataPropertyName = "filename";
            this.colFilename.HeaderText = "Filename";
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            this.colFilename.Width = 74;
            // 
            // colSize
            // 
            this.colSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSize.DataPropertyName = "sizekb";
            this.colSize.HeaderText = "Size (KB)";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            this.colSize.Width = 75;
            // 
            // colFileDate
            // 
            this.colFileDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFileDate.DataPropertyName = "filedate";
            this.colFileDate.HeaderText = "File Date";
            this.colFileDate.Name = "colFileDate";
            this.colFileDate.ReadOnly = true;
            this.colFileDate.Width = 74;
            // 
            // colFullFilePath
            // 
            this.colFullFilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFullFilePath.DataPropertyName = "fullfilepath";
            this.colFullFilePath.HeaderText = "Full File Path";
            this.colFullFilePath.Name = "colFullFilePath";
            this.colFullFilePath.ReadOnly = true;
            this.colFullFilePath.Width = 92;
            // 
            // frmBatchCut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(769, 352);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgFiles);
            this.Name = "frmBatchCut";
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullFilePath;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFile;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFolder;
        public System.Windows.Forms.ToolStripSplitButton tsdbImportList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
