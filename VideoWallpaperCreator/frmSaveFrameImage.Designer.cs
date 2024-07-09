namespace VideoWallpaperCreator
{
    partial class frmSaveFrameImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaveFrameImage));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rdOriginalSize = new System.Windows.Forms.RadioButton();
            this.rdCustomSize = new System.Windows.Forms.RadioButton();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.chkWidth = new System.Windows.Forms.CheckBox();
            this.chkHeight = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::VideoWallpaperCreator.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(268, 197);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 29);
            this.btnCancel.TabIndex = 141;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::VideoWallpaperCreator.Properties.Resources.check;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(108, 197);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(135, 29);
            this.btnOK.TabIndex = 140;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rdOriginalSize
            // 
            this.rdOriginalSize.AutoSize = true;
            this.rdOriginalSize.Checked = true;
            this.rdOriginalSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.rdOriginalSize.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdOriginalSize.Location = new System.Drawing.Point(119, 32);
            this.rdOriginalSize.Name = "rdOriginalSize";
            this.rdOriginalSize.Size = new System.Drawing.Size(114, 20);
            this.rdOriginalSize.TabIndex = 142;
            this.rdOriginalSize.TabStop = true;
            this.rdOriginalSize.Text = "Original Size";
            this.rdOriginalSize.UseVisualStyleBackColor = true;
            this.rdOriginalSize.CheckedChanged += new System.EventHandler(this.rdOriginalSize_CheckedChanged);
            // 
            // rdCustomSize
            // 
            this.rdCustomSize.AutoSize = true;
            this.rdCustomSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.rdCustomSize.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdCustomSize.Location = new System.Drawing.Point(119, 68);
            this.rdCustomSize.Name = "rdCustomSize";
            this.rdCustomSize.Size = new System.Drawing.Size(149, 20);
            this.rdCustomSize.TabIndex = 143;
            this.rdCustomSize.Text = "User defined Size";
            this.rdCustomSize.UseVisualStyleBackColor = true;
            this.rdCustomSize.CheckedChanged += new System.EventHandler(this.rdCustomSize_CheckedChanged);
            // 
            // nudWidth
            // 
            this.nudWidth.Enabled = false;
            this.nudWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.nudWidth.Location = new System.Drawing.Point(258, 104);
            this.nudWidth.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(80, 22);
            this.nudWidth.TabIndex = 144;
            this.nudWidth.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // nudHeight
            // 
            this.nudHeight.Enabled = false;
            this.nudHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.nudHeight.Location = new System.Drawing.Point(258, 132);
            this.nudHeight.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(80, 22);
            this.nudHeight.TabIndex = 146;
            this.nudHeight.Value = new decimal(new int[] {
            768,
            0,
            0,
            0});
            // 
            // chkWidth
            // 
            this.chkWidth.AutoSize = true;
            this.chkWidth.Enabled = false;
            this.chkWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkWidth.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkWidth.Location = new System.Drawing.Point(176, 105);
            this.chkWidth.Name = "chkWidth";
            this.chkWidth.Size = new System.Drawing.Size(74, 20);
            this.chkWidth.TabIndex = 148;
            this.chkWidth.Text = "Width :";
            this.chkWidth.UseVisualStyleBackColor = true;
            this.chkWidth.CheckedChanged += new System.EventHandler(this.chkWidth_CheckedChanged);
            // 
            // chkHeight
            // 
            this.chkHeight.AutoSize = true;
            this.chkHeight.Enabled = false;
            this.chkHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkHeight.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkHeight.Location = new System.Drawing.Point(176, 132);
            this.chkHeight.Name = "chkHeight";
            this.chkHeight.Size = new System.Drawing.Size(80, 20);
            this.chkHeight.TabIndex = 149;
            this.chkHeight.Text = "Height :";
            this.chkHeight.UseVisualStyleBackColor = true;
            this.chkHeight.CheckedChanged += new System.EventHandler(this.chkHeight_CheckedChanged);
            // 
            // frmSaveFrameImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(527, 237);
            this.Controls.Add(this.chkHeight);
            this.Controls.Add(this.chkWidth);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.rdCustomSize);
            this.Controls.Add(this.rdOriginalSize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaveFrameImage";
            this.Text = "Save Frame as Image";
            this.Load += new System.EventHandler(this.frmSaveFrameImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.RadioButton rdOriginalSize;
        public System.Windows.Forms.RadioButton rdCustomSize;
        public System.Windows.Forms.NumericUpDown nudWidth;
        public System.Windows.Forms.NumericUpDown nudHeight;
        public System.Windows.Forms.CheckBox chkWidth;
        public System.Windows.Forms.CheckBox chkHeight;
    }
}
