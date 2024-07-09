namespace VideoWallpaperCreator
{
    partial class frmBatchJoin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchJoin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.setOutputFormatForSelectedRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importBatchListFromTextFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importBatchListFromCSVFileMenuItem_Click = new System.Windows.Forms.ToolStripMenuItem();
            this.importBatchListFromExcelFileMenuItem_Click = new System.Windows.Forms.ToolStripMenuItem();
            this.enterBatchListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchJoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeBatchJoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgBatchJoin = new System.Windows.Forms.DataGridView();
            this.colJoinNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrowseJoinVideos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colOutputFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrowseOutputFile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colOutputFormat = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblTotalVideos = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblTotalDuration = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tsCut = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbJoinVideos = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBatchJoin)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tsCut.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.importToolStripMenuItem,
            this.batchJoinToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.exit;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem1,
            this.selectAllToolStripMenuItem,
            this.unselectAllToolStripMenuItem,
            this.invertSelectionToolStripMenuItem,
            this.toolStripMenuItem2,
            this.setOutputFormatForSelectedRowsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.delete;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.brush2;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            resources.ApplyResources(this.unselectAllToolStripMenuItem, "unselectAllToolStripMenuItem");
            this.unselectAllToolStripMenuItem.Click += new System.EventHandler(this.unselectAllToolStripMenuItem_Click);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            resources.ApplyResources(this.invertSelectionToolStripMenuItem, "invertSelectionToolStripMenuItem");
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.invertSelectionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // setOutputFormatForSelectedRowsToolStripMenuItem
            // 
            this.setOutputFormatForSelectedRowsToolStripMenuItem.Name = "setOutputFormatForSelectedRowsToolStripMenuItem";
            resources.ApplyResources(this.setOutputFormatForSelectedRowsToolStripMenuItem, "setOutputFormatForSelectedRowsToolStripMenuItem");
            this.setOutputFormatForSelectedRowsToolStripMenuItem.Click += new System.EventHandler(this.setOutputFormatForSelectedRowsToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importBatchListFromTextFileMenuItem,
            this.importBatchListFromCSVFileMenuItem_Click,
            this.importBatchListFromExcelFileMenuItem_Click,
            this.enterBatchListMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            // 
            // importBatchListFromTextFileMenuItem
            // 
            this.importBatchListFromTextFileMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.import1;
            this.importBatchListFromTextFileMenuItem.Name = "importBatchListFromTextFileMenuItem";
            resources.ApplyResources(this.importBatchListFromTextFileMenuItem, "importBatchListFromTextFileMenuItem");
            this.importBatchListFromTextFileMenuItem.Click += new System.EventHandler(this.importBatchListFromTextFileMenuItem_Click);
            // 
            // importBatchListFromCSVFileMenuItem_Click
            // 
            this.importBatchListFromCSVFileMenuItem_Click.Image = global::VideoWallpaperCreator.Properties.Resources.import1;
            this.importBatchListFromCSVFileMenuItem_Click.Name = "importBatchListFromCSVFileMenuItem_Click";
            resources.ApplyResources(this.importBatchListFromCSVFileMenuItem_Click, "importBatchListFromCSVFileMenuItem_Click");
            this.importBatchListFromCSVFileMenuItem_Click.Click += new System.EventHandler(this.importBatchListFromCSVFileMenuItem_Click_Click);
            // 
            // importBatchListFromExcelFileMenuItem_Click
            // 
            this.importBatchListFromExcelFileMenuItem_Click.Image = global::VideoWallpaperCreator.Properties.Resources.import1;
            this.importBatchListFromExcelFileMenuItem_Click.Name = "importBatchListFromExcelFileMenuItem_Click";
            resources.ApplyResources(this.importBatchListFromExcelFileMenuItem_Click, "importBatchListFromExcelFileMenuItem_Click");
            this.importBatchListFromExcelFileMenuItem_Click.Click += new System.EventHandler(this.importBatchListFromExcelFileMenuItem_Click_Click);
            // 
            // enterBatchListMenuItem
            // 
            this.enterBatchListMenuItem.Name = "enterBatchListMenuItem";
            resources.ApplyResources(this.enterBatchListMenuItem, "enterBatchListMenuItem");
            this.enterBatchListMenuItem.Click += new System.EventHandler(this.enterBatchListMenuItem_Click);
            // 
            // batchJoinToolStripMenuItem
            // 
            this.batchJoinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeBatchJoinToolStripMenuItem});
            this.batchJoinToolStripMenuItem.Name = "batchJoinToolStripMenuItem";
            resources.ApplyResources(this.batchJoinToolStripMenuItem, "batchJoinToolStripMenuItem");
            // 
            // executeBatchJoinToolStripMenuItem
            // 
            this.executeBatchJoinToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.flash;
            this.executeBatchJoinToolStripMenuItem.Name = "executeBatchJoinToolStripMenuItem";
            resources.ApplyResources(this.executeBatchJoinToolStripMenuItem, "executeBatchJoinToolStripMenuItem");
            this.executeBatchJoinToolStripMenuItem.Click += new System.EventHandler(this.executeBatchJoinToolStripMenuItem_Click);
            // 
            // dgBatchJoin
            // 
            this.dgBatchJoin.AllowDrop = true;
            resources.ApplyResources(this.dgBatchJoin, "dgBatchJoin");
            this.dgBatchJoin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgBatchJoin.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgBatchJoin.BackgroundColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBatchJoin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgBatchJoin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBatchJoin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colJoinNumber,
            this.colBrowseJoinVideos,
            this.colOutputFile,
            this.colBrowseOutputFile,
            this.colOutputFormat});
            this.dgBatchJoin.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgBatchJoin.Name = "dgBatchJoin";
            this.dgBatchJoin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBatchJoin_CellContentClick);
            this.dgBatchJoin.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBatchJoin_CellEndEdit);
            // 
            // colJoinNumber
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.colJoinNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.colJoinNumber.Frozen = true;
            resources.ApplyResources(this.colJoinNumber, "colJoinNumber");
            this.colJoinNumber.Name = "colJoinNumber";
            this.colJoinNumber.ReadOnly = true;
            // 
            // colBrowseJoinVideos
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "Browse";
            this.colBrowseJoinVideos.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.colBrowseJoinVideos, "colBrowseJoinVideos");
            this.colBrowseJoinVideos.Name = "colBrowseJoinVideos";
            this.colBrowseJoinVideos.ReadOnly = true;
            // 
            // colOutputFile
            // 
            resources.ApplyResources(this.colOutputFile, "colOutputFile");
            this.colOutputFile.Name = "colOutputFile";
            // 
            // colBrowseOutputFile
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "Browse";
            this.colBrowseOutputFile.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.colBrowseOutputFile, "colBrowseOutputFile");
            this.colBrowseOutputFile.Name = "colBrowseOutputFile";
            this.colBrowseOutputFile.ReadOnly = true;
            // 
            // colOutputFormat
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "...";
            this.colOutputFormat.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.colOutputFormat, "colOutputFormat");
            this.colOutputFormat.Name = "colOutputFormat";
            this.colOutputFormat.ReadOnly = true;
            this.colOutputFormat.Text = "...";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.slblTotalVideos,
            this.slblTotalDuration,
            this.lblElapsedTime});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Spring = true;
            // 
            // slblTotalVideos
            // 
            this.slblTotalVideos.ForeColor = System.Drawing.Color.DimGray;
            this.slblTotalVideos.Name = "slblTotalVideos";
            resources.ApplyResources(this.slblTotalVideos, "slblTotalVideos");
            // 
            // slblTotalDuration
            // 
            this.slblTotalDuration.ForeColor = System.Drawing.Color.DimGray;
            this.slblTotalDuration.Name = "slblTotalDuration";
            resources.ApplyResources(this.slblTotalDuration, "slblTotalDuration");
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.Name = "lblElapsedTime";
            resources.ApplyResources(this.lblElapsedTime, "lblElapsedTime");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tsCut
            // 
            resources.ApplyResources(this.tsCut, "tsCut");
            this.tsCut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbRemove,
            this.tsbClear,
            this.toolStripSeparator6,
            this.tsbJoinVideos});
            this.tsCut.Name = "tsCut";
            this.tsCut.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsCut_ItemClicked);
            // 
            // tsbAdd
            // 
            resources.ApplyResources(this.tsbAdd, "tsbAdd");
            this.tsbAdd.Image = global::VideoWallpaperCreator.Properties.Resources.add1;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // tsbRemove
            // 
            resources.ApplyResources(this.tsbRemove, "tsbRemove");
            this.tsbRemove.Image = global::VideoWallpaperCreator.Properties.Resources.delete1;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // tsbClear
            // 
            resources.ApplyResources(this.tsbClear, "tsbClear");
            this.tsbClear.Image = global::VideoWallpaperCreator.Properties.Resources.brush21;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // tsbJoinVideos
            // 
            resources.ApplyResources(this.tsbJoinVideos, "tsbJoinVideos");
            this.tsbJoinVideos.Image = global::VideoWallpaperCreator.Properties.Resources.flash1;
            this.tsbJoinVideos.Name = "tsbJoinVideos";
            this.tsbJoinVideos.Click += new System.EventHandler(this.executeBatchJoinToolStripMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.NullValue = "Browse";
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.dataGridViewButtonColumn1, "dataGridViewButtonColumn1");
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewButtonColumn2
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = "Browse";
            this.dataGridViewButtonColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.dataGridViewButtonColumn2, "dataGridViewButtonColumn2");
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            // 
            // dataGridViewButtonColumn3
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = "...";
            this.dataGridViewButtonColumn3.DefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(this.dataGridViewButtonColumn3, "dataGridViewButtonColumn3");
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.ReadOnly = true;
            this.dataGridViewButtonColumn3.Text = "...";
            // 
            // frmBatchJoin
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tsCut);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgBatchJoin);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmBatchJoin";
            this.Load += new System.EventHandler(this.frmBatchJoin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBatchJoin)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tsCut.ResumeLayout(false);
            this.tsCut.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView dgBatchJoin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchJoinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeBatchJoinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importBatchListFromTextFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importBatchListFromCSVFileMenuItem_Click;
        private System.Windows.Forms.ToolStripMenuItem importBatchListFromExcelFileMenuItem_Click;
        private System.Windows.Forms.ToolStripMenuItem enterBatchListMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel slblTotalVideos;
        private System.Windows.Forms.ToolStripStatusLabel slblTotalDuration;
        private System.Windows.Forms.ToolStripStatusLabel lblElapsedTime;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJoinNumber;
        private System.Windows.Forms.DataGridViewButtonColumn colBrowseJoinVideos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutputFile;
        private System.Windows.Forms.DataGridViewButtonColumn colBrowseOutputFile;
        private System.Windows.Forms.DataGridViewButtonColumn colOutputFormat;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStrip tsCut;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbJoinVideos;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem setOutputFormatForSelectedRowsToolStripMenuItem;
    }
}
