namespace VideoWallpaperCreator
{
    partial class frmFadeInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFadeInOut));
            this.chkFadeSeparate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkFadeOutFrames = new System.Windows.Forms.CheckBox();
            this.nudFadeOutFrames = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkFadeOutSeconds = new System.Windows.Forms.CheckBox();
            this.chkFadeOut = new System.Windows.Forms.CheckBox();
            this.nudFadeOutSeconds = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkFadeInFrames = new System.Windows.Forms.CheckBox();
            this.nudFadeInFrames = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkFadeInSecs = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkFadeIn = new System.Windows.Forms.CheckBox();
            this.nudFadeInSeconds = new System.Windows.Forms.NumericUpDown();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudFadeOutFrames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFadeOutSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFadeInFrames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFadeInSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // chkFadeSeparate
            // 
            resources.ApplyResources(this.chkFadeSeparate, "chkFadeSeparate");
            this.chkFadeSeparate.BackColor = System.Drawing.Color.Transparent;
            this.chkFadeSeparate.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkFadeSeparate.Name = "chkFadeSeparate";
            this.chkFadeSeparate.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // chkFadeOutFrames
            // 
            resources.ApplyResources(this.chkFadeOutFrames, "chkFadeOutFrames");
            this.chkFadeOutFrames.BackColor = System.Drawing.Color.Transparent;
            this.chkFadeOutFrames.Name = "chkFadeOutFrames";
            this.chkFadeOutFrames.UseVisualStyleBackColor = false;
            this.chkFadeOutFrames.CheckedChanged += new System.EventHandler(this.chkFadeOutFrames_CheckedChanged);
            // 
            // nudFadeOutFrames
            // 
            resources.ApplyResources(this.nudFadeOutFrames, "nudFadeOutFrames");
            this.nudFadeOutFrames.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudFadeOutFrames.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudFadeOutFrames.Name = "nudFadeOutFrames";
            this.nudFadeOutFrames.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Name = "label6";
            // 
            // chkFadeOutSeconds
            // 
            resources.ApplyResources(this.chkFadeOutSeconds, "chkFadeOutSeconds");
            this.chkFadeOutSeconds.BackColor = System.Drawing.Color.Transparent;
            this.chkFadeOutSeconds.Checked = true;
            this.chkFadeOutSeconds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFadeOutSeconds.Name = "chkFadeOutSeconds";
            this.chkFadeOutSeconds.UseVisualStyleBackColor = false;
            this.chkFadeOutSeconds.CheckedChanged += new System.EventHandler(this.chkFadeOutSeconds_CheckedChanged);
            // 
            // chkFadeOut
            // 
            resources.ApplyResources(this.chkFadeOut, "chkFadeOut");
            this.chkFadeOut.BackColor = System.Drawing.Color.Transparent;
            this.chkFadeOut.Checked = true;
            this.chkFadeOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFadeOut.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkFadeOut.Name = "chkFadeOut";
            this.chkFadeOut.UseVisualStyleBackColor = false;
            this.chkFadeOut.CheckedChanged += new System.EventHandler(this.chkFadeOut_CheckedChanged);
            // 
            // nudFadeOutSeconds
            // 
            this.nudFadeOutSeconds.DecimalPlaces = 1;
            resources.ApplyResources(this.nudFadeOutSeconds, "nudFadeOutSeconds");
            this.nudFadeOutSeconds.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudFadeOutSeconds.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudFadeOutSeconds.Name = "nudFadeOutSeconds";
            this.nudFadeOutSeconds.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // chkFadeInFrames
            // 
            resources.ApplyResources(this.chkFadeInFrames, "chkFadeInFrames");
            this.chkFadeInFrames.BackColor = System.Drawing.Color.Transparent;
            this.chkFadeInFrames.Name = "chkFadeInFrames";
            this.chkFadeInFrames.UseVisualStyleBackColor = false;
            this.chkFadeInFrames.CheckedChanged += new System.EventHandler(this.chkFadeInFrames_CheckedChanged);
            // 
            // nudFadeInFrames
            // 
            resources.ApplyResources(this.nudFadeInFrames, "nudFadeInFrames");
            this.nudFadeInFrames.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudFadeInFrames.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudFadeInFrames.Name = "nudFadeInFrames";
            this.nudFadeInFrames.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
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
            // chkFadeInSecs
            // 
            resources.ApplyResources(this.chkFadeInSecs, "chkFadeInSecs");
            this.chkFadeInSecs.BackColor = System.Drawing.Color.Transparent;
            this.chkFadeInSecs.Checked = true;
            this.chkFadeInSecs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFadeInSecs.Name = "chkFadeInSecs";
            this.chkFadeInSecs.UseVisualStyleBackColor = false;
            this.chkFadeInSecs.CheckedChanged += new System.EventHandler(this.chkFadeInSecs_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::VideoWallpaperCreator.Properties.Resources.exit;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::VideoWallpaperCreator.Properties.Resources.check;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkFadeIn
            // 
            resources.ApplyResources(this.chkFadeIn, "chkFadeIn");
            this.chkFadeIn.BackColor = System.Drawing.Color.Transparent;
            this.chkFadeIn.Checked = true;
            this.chkFadeIn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFadeIn.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkFadeIn.Name = "chkFadeIn";
            this.chkFadeIn.UseVisualStyleBackColor = false;
            this.chkFadeIn.CheckedChanged += new System.EventHandler(this.chkFadeIn_CheckedChanged);
            // 
            // nudFadeInSeconds
            // 
            this.nudFadeInSeconds.DecimalPlaces = 1;
            resources.ApplyResources(this.nudFadeInSeconds, "nudFadeInSeconds");
            this.nudFadeInSeconds.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudFadeInSeconds.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudFadeInSeconds.Name = "nudFadeInSeconds";
            this.nudFadeInSeconds.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnReset
            // 
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Name = "btnReset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmFadeInOut
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.chkFadeSeparate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkFadeOutFrames);
            this.Controls.Add(this.nudFadeOutFrames);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkFadeOutSeconds);
            this.Controls.Add(this.chkFadeOut);
            this.Controls.Add(this.nudFadeOutSeconds);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkFadeInFrames);
            this.Controls.Add(this.nudFadeInFrames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkFadeInSecs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkFadeIn);
            this.Controls.Add(this.nudFadeInSeconds);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFadeInOut";
            this.Load += new System.EventHandler(this.frmFadeInOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudFadeOutFrames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFadeOutSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFadeInFrames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFadeInSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.CheckBox chkFadeIn;
        public System.Windows.Forms.NumericUpDown nudFadeInSeconds;
        public System.Windows.Forms.CheckBox chkFadeInSecs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox chkFadeInFrames;
        public System.Windows.Forms.NumericUpDown nudFadeInFrames;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox chkFadeOutFrames;
        public System.Windows.Forms.NumericUpDown nudFadeOutFrames;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox chkFadeOutSeconds;
        public System.Windows.Forms.CheckBox chkFadeOut;
        public System.Windows.Forms.NumericUpDown nudFadeOutSeconds;
        public System.Windows.Forms.CheckBox chkFadeSeparate;
        private System.Windows.Forms.Button btnReset;
    }
}
