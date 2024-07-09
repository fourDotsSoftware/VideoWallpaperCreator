namespace VideoWallpaperCreator
{
    partial class frmSplitByParts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplitByParts));
            this.label1 = new System.Windows.Forms.Label();
            this.nudEqualParts = new System.Windows.Forms.NumericUpDown();
            this.chkEqualParts = new System.Windows.Forms.CheckBox();
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.chkFileSize = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbFilesize = new System.Windows.Forms.ComboBox();
            this.txtFilesize = new VideoWallpaperCreator.IntegerTextBox(this.components);
            this.mskTime = new VideoWallpaperCreator.TimeUpDownControl();
            ((System.ComponentModel.ISupportInitialize)(this.nudEqualParts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // nudEqualParts
            // 
            resources.ApplyResources(this.nudEqualParts, "nudEqualParts");
            this.nudEqualParts.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudEqualParts.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudEqualParts.Name = "nudEqualParts";
            this.nudEqualParts.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudEqualParts.Enter += new System.EventHandler(this.nudEqualParts_Enter);
            // 
            // chkEqualParts
            // 
            resources.ApplyResources(this.chkEqualParts, "chkEqualParts");
            this.chkEqualParts.BackColor = System.Drawing.Color.Transparent;
            this.chkEqualParts.Checked = true;
            this.chkEqualParts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEqualParts.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkEqualParts.Name = "chkEqualParts";
            this.chkEqualParts.UseVisualStyleBackColor = false;
            this.chkEqualParts.CheckedChanged += new System.EventHandler(this.chkEqualParts_CheckedChanged);
            // 
            // chkTime
            // 
            resources.ApplyResources(this.chkTime, "chkTime");
            this.chkTime.BackColor = System.Drawing.Color.Transparent;
            this.chkTime.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkTime.Name = "chkTime";
            this.chkTime.UseVisualStyleBackColor = false;
            this.chkTime.CheckedChanged += new System.EventHandler(this.chkTime_CheckedChanged);
            // 
            // chkFileSize
            // 
            resources.ApplyResources(this.chkFileSize, "chkFileSize");
            this.chkFileSize.BackColor = System.Drawing.Color.Transparent;
            this.chkFileSize.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkFileSize.Name = "chkFileSize";
            this.chkFileSize.UseVisualStyleBackColor = false;
            this.chkFileSize.CheckedChanged += new System.EventHandler(this.chkFileSize_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::VideoWallpaperCreator.Properties.Resources.check;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::VideoWallpaperCreator.Properties.Resources.exit;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbFilesize
            // 
            this.cmbFilesize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilesize.FormattingEnabled = true;
            this.cmbFilesize.Items.AddRange(new object[] {
            resources.GetString("cmbFilesize.Items"),
            resources.GetString("cmbFilesize.Items1"),
            resources.GetString("cmbFilesize.Items2")});
            resources.ApplyResources(this.cmbFilesize, "cmbFilesize");
            this.cmbFilesize.Name = "cmbFilesize";
            // 
            // txtFilesize
            // 
            resources.ApplyResources(this.txtFilesize, "txtFilesize");
            this.txtFilesize.Name = "txtFilesize";
            this.txtFilesize.Enter += new System.EventHandler(this.txtFilesize_Enter);
            // 
            // mskTime
            // 
            this.mskTime.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mskTime, "mskTime");
            this.mskTime.Name = "mskTime";
            this.mskTime.Time = System.TimeSpan.Parse("00:00:00");
            // 
            // frmSplitByParts
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.mskTime);
            this.Controls.Add(this.txtFilesize);
            this.Controls.Add(this.cmbFilesize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkFileSize);
            this.Controls.Add(this.chkTime);
            this.Controls.Add(this.chkEqualParts);
            this.Controls.Add(this.nudEqualParts);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplitByParts";
            this.Load += new System.EventHandler(this.frmSplitByParts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudEqualParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown nudEqualParts;
        public System.Windows.Forms.CheckBox chkEqualParts;
        public System.Windows.Forms.CheckBox chkTime;
        public System.Windows.Forms.CheckBox chkFileSize;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ComboBox cmbFilesize;
        public IntegerTextBox txtFilesize;
        public TimeUpDownControl mskTime;
    }
}
