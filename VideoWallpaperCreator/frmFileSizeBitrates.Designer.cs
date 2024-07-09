namespace VideoWallpaperCreator
{
    partial class frmFileSizeBitrates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileSizeBitrates));
            this.label7 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCalculateBitrates = new System.Windows.Forms.Button();
            this.cmbFormats = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudAudioBitrate = new System.Windows.Forms.NumericUpDown();
            this.nudVideoBitrate = new System.Windows.Forms.NumericUpDown();
            this.chkAudioBitrate = new System.Windows.Forms.CheckBox();
            this.chkVideoBitrate = new System.Windows.Forms.CheckBox();
            this.cmbSizeType = new System.Windows.Forms.ComboBox();
            this.nudFileSize = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSetBitrates = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAudioBitrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVideoBitrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Name = "label7";
            // 
            // lblDuration
            // 
            this.lblDuration.BackColor = System.Drawing.Color.LightGray;
            this.lblDuration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblDuration, "lblDuration");
            this.lblDuration.ForeColor = System.Drawing.Color.Black;
            this.lblDuration.Name = "lblDuration";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Name = "label5";
            // 
            // btnCalculateBitrates
            // 
            this.btnCalculateBitrates.Image = global::VideoWallpaperCreator.Properties.Resources.flash;
            resources.ApplyResources(this.btnCalculateBitrates, "btnCalculateBitrates");
            this.btnCalculateBitrates.Name = "btnCalculateBitrates";
            this.btnCalculateBitrates.UseVisualStyleBackColor = true;
            this.btnCalculateBitrates.Click += new System.EventHandler(this.btnCalculateBitrates_Click);
            // 
            // cmbFormats
            // 
            resources.ApplyResources(this.cmbFormats, "cmbFormats");
            this.cmbFormats.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbFormats.FormattingEnabled = true;
            this.cmbFormats.Name = "cmbFormats";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // nudAudioBitrate
            // 
            resources.ApplyResources(this.nudAudioBitrate, "nudAudioBitrate");
            this.nudAudioBitrate.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudAudioBitrate.Maximum = new decimal(new int[] {
            -1593835520,
            466537709,
            54210,
            0});
            this.nudAudioBitrate.Name = "nudAudioBitrate";
            this.nudAudioBitrate.Value = new decimal(new int[] {
            192,
            0,
            0,
            0});
            // 
            // nudVideoBitrate
            // 
            resources.ApplyResources(this.nudVideoBitrate, "nudVideoBitrate");
            this.nudVideoBitrate.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudVideoBitrate.Maximum = new decimal(new int[] {
            -1593835520,
            466537709,
            54210,
            0});
            this.nudVideoBitrate.Name = "nudVideoBitrate";
            // 
            // chkAudioBitrate
            // 
            resources.ApplyResources(this.chkAudioBitrate, "chkAudioBitrate");
            this.chkAudioBitrate.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkAudioBitrate.Name = "chkAudioBitrate";
            this.chkAudioBitrate.UseVisualStyleBackColor = true;
            this.chkAudioBitrate.CheckedChanged += new System.EventHandler(this.chkAudioBitrate_CheckedChanged);
            // 
            // chkVideoBitrate
            // 
            resources.ApplyResources(this.chkVideoBitrate, "chkVideoBitrate");
            this.chkVideoBitrate.Checked = true;
            this.chkVideoBitrate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVideoBitrate.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkVideoBitrate.Name = "chkVideoBitrate";
            this.chkVideoBitrate.UseVisualStyleBackColor = true;
            this.chkVideoBitrate.CheckedChanged += new System.EventHandler(this.chkVideoBitrate_CheckedChanged);
            // 
            // cmbSizeType
            // 
            resources.ApplyResources(this.cmbSizeType, "cmbSizeType");
            this.cmbSizeType.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbSizeType.FormattingEnabled = true;
            this.cmbSizeType.Items.AddRange(new object[] {
            resources.GetString("cmbSizeType.Items"),
            resources.GetString("cmbSizeType.Items1"),
            resources.GetString("cmbSizeType.Items2")});
            this.cmbSizeType.Name = "cmbSizeType";
            // 
            // nudFileSize
            // 
            this.nudFileSize.DecimalPlaces = 1;
            resources.ApplyResources(this.nudFileSize, "nudFileSize");
            this.nudFileSize.Maximum = new decimal(new int[] {
            -1593835520,
            466537709,
            54210,
            0});
            this.nudFileSize.Name = "nudFileSize";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::VideoWallpaperCreator.Properties.Resources.exit;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSetBitrates
            // 
            resources.ApplyResources(this.btnSetBitrates, "btnSetBitrates");
            this.btnSetBitrates.Image = global::VideoWallpaperCreator.Properties.Resources.check;
            this.btnSetBitrates.Name = "btnSetBitrates";
            this.btnSetBitrates.UseVisualStyleBackColor = true;
            this.btnSetBitrates.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Name = "label6";
            // 
            // frmFileSizeBitrates
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCalculateBitrates);
            this.Controls.Add(this.cmbFormats);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudAudioBitrate);
            this.Controls.Add(this.nudVideoBitrate);
            this.Controls.Add(this.chkAudioBitrate);
            this.Controls.Add(this.chkVideoBitrate);
            this.Controls.Add(this.cmbSizeType);
            this.Controls.Add(this.nudFileSize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSetBitrates);
            this.Controls.Add(this.label6);
            this.Name = "frmFileSizeBitrates";
            this.Load += new System.EventHandler(this.frmFileSizeBitrates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAudioBitrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVideoBitrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSetBitrates;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudFileSize;
        private System.Windows.Forms.ComboBox cmbSizeType;
        private System.Windows.Forms.CheckBox chkVideoBitrate;
        private System.Windows.Forms.CheckBox chkAudioBitrate;
        private System.Windows.Forms.NumericUpDown nudVideoBitrate;
        private System.Windows.Forms.NumericUpDown nudAudioBitrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFormats;
        private System.Windows.Forms.Button btnCalculateBitrates;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label label7;
    }
}
