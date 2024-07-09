namespace VideoCutterJoinerExpert
{
    partial class StoryboardThumbnail
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
            this.picThumbnail = new System.Windows.Forms.PictureBox();
            this.cmsThumb = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomIntoFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.setClipStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setClipEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).BeginInit();
            this.cmsThumb.SuspendLayout();
            this.SuspendLayout();
            // 
            // picThumbnail
            // 
            this.picThumbnail.ContextMenuStrip = this.cmsThumb;
            this.picThumbnail.Location = new System.Drawing.Point(0, 0);
            this.picThumbnail.Margin = new System.Windows.Forms.Padding(0);
            this.picThumbnail.Name = "picThumbnail";
            this.picThumbnail.Size = new System.Drawing.Size(94, 52);
            this.picThumbnail.TabIndex = 0;
            this.picThumbnail.TabStop = false;
            // 
            // cmsThumb
            // 
            this.cmsThumb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomIntoFrameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.setClipStartToolStripMenuItem,
            this.setClipEndToolStripMenuItem});
            this.cmsThumb.Name = "cmsThumb";
            this.cmsThumb.Size = new System.Drawing.Size(167, 76);
            
            // 
            // zoomIntoFrameToolStripMenuItem
            // 
            this.zoomIntoFrameToolStripMenuItem.Name = "zoomIntoFrameToolStripMenuItem";
            this.zoomIntoFrameToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.zoomIntoFrameToolStripMenuItem.Text = "&Zoom into Frame";
            
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // setClipStartToolStripMenuItem
            // 
            this.setClipStartToolStripMenuItem.Name = "setClipStartToolStripMenuItem";
            this.setClipStartToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.setClipStartToolStripMenuItem.Text = "Set Clip &Start";
            this.setClipStartToolStripMenuItem.Click += new System.EventHandler(this.setClipStartToolStripMenuItem_Click);
            // 
            // setClipEndToolStripMenuItem
            // 
            this.setClipEndToolStripMenuItem.Name = "setClipEndToolStripMenuItem";
            this.setClipEndToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.setClipEndToolStripMenuItem.Text = "Set Clip &End";
            this.setClipEndToolStripMenuItem.Click += new System.EventHandler(this.setClipEndToolStripMenuItem_Click);
            // 
            // lblPos
            // 
            this.lblPos.BackColor = System.Drawing.Color.Silver;
            this.lblPos.Location = new System.Drawing.Point(3, 54);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(88, 13);
            this.lblPos.TabIndex = 1;
            this.lblPos.Text = "00:00:00.00";
            this.lblPos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StoryboardThumbnail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.lblPos);
            this.Controls.Add(this.picThumbnail);
            this.Name = "StoryboardThumbnail";
            this.Size = new System.Drawing.Size(94, 68);
            this.Load += new System.EventHandler(this.StoryboardThumbnail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).EndInit();
            this.cmsThumb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picThumbnail;
        public System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.ContextMenuStrip cmsThumb;
        private System.Windows.Forms.ToolStripMenuItem zoomIntoFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setClipStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setClipEndToolStripMenuItem;

    }
}
