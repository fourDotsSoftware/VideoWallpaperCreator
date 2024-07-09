namespace VideoWallpaperCreator
{
    partial class frmBatchResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchResult));
            this.cmsVideos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFullPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tvFailed = new System.Windows.Forms.TreeView();
            this.tvSuccess = new System.Windows.Forms.TreeView();
            this.niceLine2 = new VideoWallpaperCreator.NiceLine();
            this.cmsVideos.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsVideos
            // 
            this.cmsVideos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.copyFullPathToolStripMenuItem,
            this.videoInfoToolStripMenuItem});
            this.cmsVideos.Name = "cmsVideos";
            resources.ApplyResources(this.cmsVideos, "cmsVideos");
            this.cmsVideos.Opening += new System.ComponentModel.CancelEventHandler(this.cmsVideos_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.flash;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.folder;
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            resources.ApplyResources(this.exploreToolStripMenuItem, "exploreToolStripMenuItem");
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.exploreToolStripMenuItem_Click);
            // 
            // copyFullPathToolStripMenuItem
            // 
            this.copyFullPathToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.copy;
            this.copyFullPathToolStripMenuItem.Name = "copyFullPathToolStripMenuItem";
            resources.ApplyResources(this.copyFullPathToolStripMenuItem, "copyFullPathToolStripMenuItem");
            this.copyFullPathToolStripMenuItem.Click += new System.EventHandler(this.copyFullPathToolStripMenuItem_Click);
            // 
            // videoInfoToolStripMenuItem
            // 
            this.videoInfoToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.information;
            this.videoInfoToolStripMenuItem.Name = "videoInfoToolStripMenuItem";
            resources.ApplyResources(this.videoInfoToolStripMenuItem, "videoInfoToolStripMenuItem");
            this.videoInfoToolStripMenuItem.Click += new System.EventHandler(this.videoInfoToolStripMenuItem_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // lblError
            // 
            resources.ApplyResources(this.lblError, "lblError");
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblError.Name = "lblError";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Image = global::VideoWallpaperCreator.Properties.Resources.exit;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tvFailed
            // 
            resources.ApplyResources(this.tvFailed, "tvFailed");
            this.tvFailed.Name = "tvFailed";
            // 
            // tvSuccess
            // 
            resources.ApplyResources(this.tvSuccess, "tvSuccess");
            this.tvSuccess.ContextMenuStrip = this.cmsVideos;
            this.tvSuccess.Name = "tvSuccess";
            this.tvSuccess.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvSuccess_NodeMouseClick);
            this.tvSuccess.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvSuccess_NodeMouseDoubleClick);
            this.tvSuccess.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvSuccess_MouseDown);
            // 
            // niceLine2
            // 
            resources.ApplyResources(this.niceLine2, "niceLine2");
            this.niceLine2.BackColor = System.Drawing.Color.Transparent;
            this.niceLine2.Name = "niceLine2";
            // 
            // frmBatchResult
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.niceLine2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tvFailed);
            this.Controls.Add(this.tvSuccess);
            this.Name = "frmBatchResult";
            this.cmsVideos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private NiceLine niceLine2;
        public System.Windows.Forms.Label lblError;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TreeView tvSuccess;
        public System.Windows.Forms.TreeView tvFailed;
        private System.Windows.Forms.ContextMenuStrip cmsVideos;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFullPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoInfoToolStripMenuItem;
    }
}
