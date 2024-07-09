namespace VideoWallpaperCreator
{
    partial class MediaSegment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaSegment));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSegment = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picThumbnailEnd = new System.Windows.Forms.PictureBox();
            this.picThumbnailStart = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.mskStart = new VideoWallpaperCreator.TimeUpDownControl();
            this.mskDuration = new VideoWallpaperCreator.TimeUpDownControl();
            this.mskEnd = new VideoWallpaperCreator.TimeUpDownControl();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnailEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnailStart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Name = "label2";
            // 
            // lblSegment
            // 
            resources.ApplyResources(this.lblSegment, "lblSegment");
            this.lblSegment.ForeColor = System.Drawing.Color.DimGray;
            this.lblSegment.Name = "lblSegment";
            // 
            // lblDuration
            // 
            resources.ApplyResources(this.lblDuration, "lblDuration");
            this.lblDuration.ForeColor = System.Drawing.Color.DimGray;
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Click += new System.EventHandler(this.lblDuration_Click);
            // 
            // picThumbnailEnd
            // 
            this.picThumbnailEnd.BackColor = System.Drawing.Color.DimGray;
            this.picThumbnailEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picThumbnailEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.picThumbnailEnd, "picThumbnailEnd");
            this.picThumbnailEnd.Name = "picThumbnailEnd";
            this.picThumbnailEnd.TabStop = false;
            this.toolTip1.SetToolTip(this.picThumbnailEnd, resources.GetString("picThumbnailEnd.ToolTip"));
            this.picThumbnailEnd.Click += new System.EventHandler(this.picThumbnailEnd_Click);
            this.picThumbnailEnd.MouseLeave += new System.EventHandler(this.picThumbnailEnd_MouseLeave);
            this.picThumbnailEnd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picThumbnailEnd_MouseMove);
            // 
            // picThumbnailStart
            // 
            this.picThumbnailStart.BackColor = System.Drawing.Color.DimGray;
            this.picThumbnailStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picThumbnailStart.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.picThumbnailStart, "picThumbnailStart");
            this.picThumbnailStart.Name = "picThumbnailStart";
            this.picThumbnailStart.TabStop = false;
            this.toolTip1.SetToolTip(this.picThumbnailStart, resources.GetString("picThumbnailStart.ToolTip"));
            this.picThumbnailStart.Click += new System.EventHandler(this.picThumbnailStart_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Image = global::VideoWallpaperCreator.Properties.Resources.media_play;
            resources.ApplyResources(this.btnPlay, "btnPlay");
            this.btnPlay.Name = "btnPlay";
            this.toolTip1.SetToolTip(this.btnPlay, resources.GetString("btnPlay.ToolTip"));
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Name = "label3";
            // 
            // mskStart
            // 
            this.mskStart.BackColor = System.Drawing.Color.Transparent;
            this.mskStart.ForeColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.mskStart, "mskStart");
            this.mskStart.Name = "mskStart";
            this.mskStart.Time = System.TimeSpan.Parse("00:00:00");
            // 
            // mskDuration
            // 
            this.mskDuration.BackColor = System.Drawing.Color.Transparent;
            this.mskDuration.ForeColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.mskDuration, "mskDuration");
            this.mskDuration.Name = "mskDuration";
            this.mskDuration.Time = System.TimeSpan.Parse("00:00:00");
            // 
            // mskEnd
            // 
            this.mskEnd.BackColor = System.Drawing.Color.Transparent;
            this.mskEnd.ForeColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.mskEnd, "mskEnd");
            this.mskEnd.Name = "mskEnd";
            this.mskEnd.Time = System.TimeSpan.Parse("00:00:00");
            // 
            // MediaSegment
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.mskStart);
            this.Controls.Add(this.mskDuration);
            this.Controls.Add(this.mskEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picThumbnailEnd);
            this.Controls.Add(this.picThumbnailStart);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblSegment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "MediaSegment";
            this.Load += new System.EventHandler(this.MediaSegment_Load);
            this.Click += new System.EventHandler(this.MediaSegment_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnailEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnailStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblSegment;
        public System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btnPlay;
        public System.Windows.Forms.PictureBox picThumbnailStart;
        public System.Windows.Forms.PictureBox picThumbnailEnd;
        private System.Windows.Forms.Label label3;
        public TimeUpDownControl mskEnd;
        public TimeUpDownControl mskDuration;
        public TimeUpDownControl mskStart;


    }
}
