namespace VideoWallpaperCreator
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmsVideos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFullPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timJoinVideos = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnMute = new GlowButton.GlowButton();
            this.btnStop = new GlowButton.GlowButton();
            this.btnPlay = new GlowButton.GlowButton();
            this.btnFastForward = new GlowButton.GlowButton();
            this.btnRewind = new GlowButton.GlowButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.picVideoPlayer = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.msVolume = new MediaSlider.MediaSlider();
            this.msPosition = new MediaSlider.MediaSlider();
            this.lblTime = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblTotalVideos = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblTotalDuration = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCut = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveDown = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.tsbPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbTest = new System.Windows.Forms.ToolStripButton();
            this.tsbCreateWallpaper = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCloudsSampleVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importVideosFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importVideosFromCSVFIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterListOfVideosToJoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveJoinArgsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.whenFinishedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.useFFMPEG64bitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useFFMPEG32bitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.minimizeToSystemTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loopVideosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiToolsPlayOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiCreateVideoWallpaper = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadSoftwareToolStripMenuItem = new com.softpcapps.download_software.DownloadSoftwareToolStripMenuItem();
            this.pleaseShareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnFacebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnGooglePlusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnLinkedinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareWithEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpUsersManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.pleaseDonateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebpageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForNewVersionEachWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgVideo = new System.Windows.Forms.DataGridView();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVideo = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudFps = new System.Windows.Forms.NumericUpDown();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.rdSlowComputer = new System.Windows.Forms.RadioButton();
            this.rdFastComputer = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.timWallpaper = new System.Windows.Forms.Timer(this.components);
            this.timTest = new System.Windows.Forms.Timer(this.components);
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.notMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsVideos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoPlayer)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tsCut.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.cmsNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmsVideos
            // 
            this.cmsVideos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.copyFullPathToolStripMenuItem,
            this.videoInfoToolStripMenuItem});
            this.cmsVideos.Name = "cmsVideos";
            resources.ApplyResources(this.cmsVideos, "cmsVideos");
            this.cmsVideos.Opening += new System.ComponentModel.CancelEventHandler(this.cmsVideos_Opening);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.media_play;
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            resources.ApplyResources(this.playToolStripMenuItem, "playToolStripMenuItem");
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
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
            // timJoinVideos
            // 
            this.timJoinVideos.Interval = 1000;
            this.timJoinVideos.Tick += new System.EventHandler(this.timJoinVideos_Tick);
            // 
            // btnMute
            // 
            resources.ApplyResources(this.btnMute, "btnMute");
            this.btnMute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnMute.Checked = false;
            this.btnMute.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnMute.CheckStyle = GlowButton.GlowButton.CheckedStyle.ColorChange;
            this.btnMute.ContextMenuStrip = null;
            this.btnMute.FocusedMask = false;
            this.btnMute.FocusOnHover = false;
            this.btnMute.Image = global::VideoWallpaperCreator.Properties.Resources.mute;
            this.btnMute.ImageCheckedColor = System.Drawing.Color.Firebrick;
            this.btnMute.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnMute.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnMute.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnMute.ImageGlowFactor = 2;
            this.btnMute.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnMute.ImageMirror = true;
            this.btnMute.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnMute.Name = "btnMute";
            this.btnMute.Tag = "Mute";
            this.toolTip1.SetToolTip(this.btnMute, resources.GetString("btnMute.ToolTip"));
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnStop.Checked = false;
            this.btnStop.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnStop.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnStop.ContextMenuStrip = null;
            this.btnStop.FocusedMask = false;
            this.btnStop.FocusOnHover = false;
            this.btnStop.Image = global::VideoWallpaperCreator.Properties.Resources.stop;
            this.btnStop.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnStop.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnStop.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnStop.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnStop.ImageGlowFactor = 2;
            this.btnStop.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnStop.ImageMirror = true;
            this.btnStop.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnStop.Name = "btnStop";
            this.btnStop.Tag = "Stop";
            this.toolTip1.SetToolTip(this.btnStop, resources.GetString("btnStop.ToolTip"));
            // 
            // btnPlay
            // 
            resources.ApplyResources(this.btnPlay, "btnPlay");
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnPlay.Checked = false;
            this.btnPlay.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnPlay.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnPlay.ContextMenuStrip = null;
            this.btnPlay.FocusedMask = false;
            this.btnPlay.FocusOnHover = false;
            this.btnPlay.Image = global::VideoWallpaperCreator.Properties.Resources.play;
            this.btnPlay.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnPlay.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnPlay.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnPlay.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnPlay.ImageGlowFactor = 2;
            this.btnPlay.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnPlay.ImageMirror = true;
            this.btnPlay.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Tag = "Play/Pause";
            this.toolTip1.SetToolTip(this.btnPlay, resources.GetString("btnPlay.ToolTip"));
            // 
            // btnFastForward
            // 
            resources.ApplyResources(this.btnFastForward, "btnFastForward");
            this.btnFastForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnFastForward.Checked = false;
            this.btnFastForward.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnFastForward.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnFastForward.ContextMenuStrip = null;
            this.btnFastForward.FocusedMask = false;
            this.btnFastForward.FocusOnHover = false;
            this.btnFastForward.Image = global::VideoWallpaperCreator.Properties.Resources.ff;
            this.btnFastForward.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnFastForward.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnFastForward.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnFastForward.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnFastForward.ImageGlowFactor = 2;
            this.btnFastForward.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnFastForward.ImageMirror = true;
            this.btnFastForward.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnFastForward.Name = "btnFastForward";
            this.btnFastForward.Tag = "Fast Forward";
            this.toolTip1.SetToolTip(this.btnFastForward, resources.GetString("btnFastForward.ToolTip"));
            // 
            // btnRewind
            // 
            resources.ApplyResources(this.btnRewind, "btnRewind");
            this.btnRewind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnRewind.Checked = false;
            this.btnRewind.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnRewind.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnRewind.ContextMenuStrip = null;
            this.btnRewind.FocusedMask = false;
            this.btnRewind.FocusOnHover = false;
            this.btnRewind.Image = global::VideoWallpaperCreator.Properties.Resources.fr;
            this.btnRewind.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnRewind.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnRewind.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnRewind.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnRewind.ImageGlowFactor = 2;
            this.btnRewind.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnRewind.ImageMirror = true;
            this.btnRewind.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnRewind.Name = "btnRewind";
            this.btnRewind.Tag = "Reverse";
            this.toolTip1.SetToolTip(this.btnRewind, resources.GetString("btnRewind.ToolTip"));
            // 
            // picVideoPlayer
            // 
            resources.ApplyResources(this.picVideoPlayer, "picVideoPlayer");
            this.picVideoPlayer.BackColor = System.Drawing.Color.LightGray;
            this.picVideoPlayer.Name = "picVideoPlayer";
            this.picVideoPlayer.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.msVolume);
            this.panel1.Controls.Add(this.btnMute);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Controls.Add(this.btnFastForward);
            this.panel1.Controls.Add(this.btnRewind);
            this.panel1.Controls.Add(this.msPosition);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Name = "panel1";
            // 
            // msVolume
            // 
            this.msVolume.Animated = false;
            this.msVolume.AnimationSize = 0.2F;
            this.msVolume.AnimationSpeed = MediaSlider.MediaSlider.AnimateSpeed.Normal;
            resources.ApplyResources(this.msVolume, "msVolume");
            this.msVolume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msVolume.BackGroundImage = null;
            this.msVolume.ButtonAccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.msVolume.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.msVolume.ButtonColor = System.Drawing.Color.Black;
            this.msVolume.ButtonCornerRadius = ((uint)(4u));
            this.msVolume.ButtonSize = new System.Drawing.Size(12, 12);
            this.msVolume.ButtonStyle = MediaSlider.MediaSlider.ButtonType.Round;
            this.msVolume.ContextMenuStrip = null;
            this.msVolume.IsForRangeSelect = false;
            this.msVolume.IsForShowMeter = false;
            this.msVolume.IsForShowSegment = false;
            this.msVolume.LargeChange = 2;
            this.msVolume.Maximum = 255;
            this.msVolume.Minimum = 0;
            this.msVolume.Name = "msVolume";
            this.msVolume.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.msVolume.RangeEndPixels = 1;
            this.msVolume.RangeStartPixels = 0;
            this.msVolume.ShowButtonOnHover = false;
            this.msVolume.SliderFlyOut = MediaSlider.MediaSlider.FlyOutStyle.None;
            this.msVolume.SmallChange = 1;
            this.msVolume.SmoothScrolling = true;
            this.msVolume.TickColor = System.Drawing.Color.DarkGray;
            this.msVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.msVolume.TickType = MediaSlider.MediaSlider.TickMode.Standard;
            this.msVolume.TrackBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msVolume.TrackDepth = 4;
            this.msVolume.TrackFillColor = System.Drawing.Color.Transparent;
            this.msVolume.TrackProgressColor = System.Drawing.Color.LightSkyBlue;
            this.msVolume.TrackShadow = true;
            this.msVolume.TrackShadowColor = System.Drawing.Color.DarkGray;
            this.msVolume.TrackStyle = MediaSlider.MediaSlider.TrackType.Progress;
            this.msVolume.Value = 127;
            // 
            // msPosition
            // 
            this.msPosition.Animated = false;
            this.msPosition.AnimationSize = 0.2F;
            this.msPosition.AnimationSpeed = MediaSlider.MediaSlider.AnimateSpeed.Normal;
            resources.ApplyResources(this.msPosition, "msPosition");
            this.msPosition.BackColor = System.Drawing.Color.Transparent;
            this.msPosition.BackGroundImage = null;
            this.msPosition.ButtonAccentColor = System.Drawing.Color.LightSkyBlue;
            this.msPosition.ButtonBorderColor = System.Drawing.Color.SteelBlue;
            this.msPosition.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(131)))), ((int)(((byte)(235)))));
            this.msPosition.ButtonCornerRadius = ((uint)(6u));
            this.msPosition.ButtonSize = new System.Drawing.Size(14, 8);
            this.msPosition.ButtonStyle = MediaSlider.MediaSlider.ButtonType.RoundedRectInline;
            this.msPosition.ContextMenuStrip = null;
            this.msPosition.IsForRangeSelect = false;
            this.msPosition.IsForShowMeter = false;
            this.msPosition.IsForShowSegment = false;
            this.msPosition.LargeChange = 2;
            this.msPosition.Maximum = 10;
            this.msPosition.Minimum = 0;
            this.msPosition.Name = "msPosition";
            this.msPosition.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.msPosition.RangeEndPixels = 1;
            this.msPosition.RangeStartPixels = 0;
            this.msPosition.ShowButtonOnHover = false;
            this.msPosition.SliderFlyOut = MediaSlider.MediaSlider.FlyOutStyle.None;
            this.msPosition.SmallChange = 1;
            this.msPosition.SmoothScrolling = true;
            this.msPosition.TickColor = System.Drawing.Color.DarkGray;
            this.msPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.msPosition.TickType = MediaSlider.MediaSlider.TickMode.Standard;
            this.msPosition.TrackBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msPosition.TrackDepth = 4;
            this.msPosition.TrackFillColor = System.Drawing.Color.Transparent;
            this.msPosition.TrackProgressColor = System.Drawing.Color.LightSkyBlue;
            this.msPosition.TrackShadow = true;
            this.msPosition.TrackShadowColor = System.Drawing.Color.DarkGray;
            this.msPosition.TrackStyle = MediaSlider.MediaSlider.TrackType.Progress;
            this.msPosition.Value = 0;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblTime, "lblTime");
            this.lblTime.ForeColor = System.Drawing.Color.LightGray;
            this.lblTime.Name = "lblTime";
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
            // tsCut
            // 
            resources.ApplyResources(this.tsCut, "tsCut");
            this.tsCut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbRemove,
            this.toolStripSeparator6,
            this.tsbMoveUp,
            this.tsbMoveDown,
            this.tsbCopy,
            this.tsbPaste,
            this.tsbPlay,
            this.toolStripSeparator1,
            this.tsbStop,
            this.tsbTest,
            this.tsbCreateWallpaper});
            this.tsCut.Name = "tsCut";
            // 
            // tsbAdd
            // 
            resources.ApplyResources(this.tsbAdd, "tsbAdd");
            this.tsbAdd.Image = global::VideoWallpaperCreator.Properties.Resources.add1;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.ButtonClick += new System.EventHandler(this.tsbAdd_ButtonClick);
            this.tsbAdd.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbAdd_DropDownItemClicked);
            // 
            // tsbRemove
            // 
            resources.ApplyResources(this.tsbRemove, "tsbRemove");
            this.tsbRemove.Image = global::VideoWallpaperCreator.Properties.Resources.delete1;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // tsbMoveUp
            // 
            resources.ApplyResources(this.tsbMoveUp, "tsbMoveUp");
            this.tsbMoveUp.Image = global::VideoWallpaperCreator.Properties.Resources.arrow_up_green1;
            this.tsbMoveUp.Name = "tsbMoveUp";
            this.tsbMoveUp.Click += new System.EventHandler(this.tsbMoveUp_Click);
            // 
            // tsbMoveDown
            // 
            resources.ApplyResources(this.tsbMoveDown, "tsbMoveDown");
            this.tsbMoveDown.Image = global::VideoWallpaperCreator.Properties.Resources.arrow_down_green1;
            this.tsbMoveDown.Name = "tsbMoveDown";
            this.tsbMoveDown.Click += new System.EventHandler(this.tsbMoveDown_Click);
            // 
            // tsbCopy
            // 
            resources.ApplyResources(this.tsbCopy, "tsbCopy");
            this.tsbCopy.Image = global::VideoWallpaperCreator.Properties.Resources.copy1;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbPaste
            // 
            resources.ApplyResources(this.tsbPaste, "tsbPaste");
            this.tsbPaste.Image = global::VideoWallpaperCreator.Properties.Resources.paste;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Click += new System.EventHandler(this.tsbPaste_Click);
            // 
            // tsbPlay
            // 
            resources.ApplyResources(this.tsbPlay, "tsbPlay");
            this.tsbPlay.Image = global::VideoWallpaperCreator.Properties.Resources.media_play;
            this.tsbPlay.Name = "tsbPlay";
            this.tsbPlay.Click += new System.EventHandler(this.tsbPlay_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsbStop
            // 
            resources.ApplyResources(this.tsbStop, "tsbStop");
            this.tsbStop.Image = global::VideoWallpaperCreator.Properties.Resources.media_stop;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tsbTest
            // 
            resources.ApplyResources(this.tsbTest, "tsbTest");
            this.tsbTest.Image = global::VideoWallpaperCreator.Properties.Resources.information1;
            this.tsbTest.Name = "tsbTest";
            this.tsbTest.Click += new System.EventHandler(this.tsbTest_Click);
            // 
            // tsbCreateWallpaper
            // 
            resources.ApplyResources(this.tsbCreateWallpaper, "tsbCreateWallpaper");
            this.tsbCreateWallpaper.ForeColor = System.Drawing.Color.DarkBlue;
            this.tsbCreateWallpaper.Image = global::VideoWallpaperCreator.Properties.Resources.merge_24;
            this.tsbCreateWallpaper.Name = "tsbCreateWallpaper";
            this.tsbCreateWallpaper.Click += new System.EventHandler(this.tsbCreateWallpaper_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem1,
            this.tiToolsPlayOutput,
            this.languageToolStripMenuItem,
            this.downloadSoftwareToolStripMenuItem,
            this.pleaseShareToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.addCloudsSampleVideoToolStripMenuItem,
            this.importVideosFromTextFileToolStripMenuItem,
            this.importVideosFromCSVFIleToolStripMenuItem,
            this.enterListOfVideosToJoinToolStripMenuItem,
            this.saveCurrentSelectionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem,
            this.saveJoinArgsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.add;
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            resources.ApplyResources(this.addFileToolStripMenuItem, "addFileToolStripMenuItem");
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.tsbAdd_ButtonClick);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            resources.ApplyResources(this.addFolderToolStripMenuItem, "addFolderToolStripMenuItem");
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.tsbAddFolder_ButtonClick);
            // 
            // addCloudsSampleVideoToolStripMenuItem
            // 
            this.addCloudsSampleVideoToolStripMenuItem.Name = "addCloudsSampleVideoToolStripMenuItem";
            resources.ApplyResources(this.addCloudsSampleVideoToolStripMenuItem, "addCloudsSampleVideoToolStripMenuItem");
            this.addCloudsSampleVideoToolStripMenuItem.Click += new System.EventHandler(this.addCloudsSampleVideoToolStripMenuItem_Click);
            // 
            // importVideosFromTextFileToolStripMenuItem
            // 
            this.importVideosFromTextFileToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.import1;
            this.importVideosFromTextFileToolStripMenuItem.Name = "importVideosFromTextFileToolStripMenuItem";
            resources.ApplyResources(this.importVideosFromTextFileToolStripMenuItem, "importVideosFromTextFileToolStripMenuItem");
            this.importVideosFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.importVideosFromTextFileToolStripMenuItem_Click);
            // 
            // importVideosFromCSVFIleToolStripMenuItem
            // 
            this.importVideosFromCSVFIleToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.import1;
            this.importVideosFromCSVFIleToolStripMenuItem.Name = "importVideosFromCSVFIleToolStripMenuItem";
            resources.ApplyResources(this.importVideosFromCSVFIleToolStripMenuItem, "importVideosFromCSVFIleToolStripMenuItem");
            this.importVideosFromCSVFIleToolStripMenuItem.Click += new System.EventHandler(this.importVideosFromCSVFIleToolStripMenuItem_Click);
            // 
            // enterListOfVideosToJoinToolStripMenuItem
            // 
            this.enterListOfVideosToJoinToolStripMenuItem.Name = "enterListOfVideosToJoinToolStripMenuItem";
            resources.ApplyResources(this.enterListOfVideosToJoinToolStripMenuItem, "enterListOfVideosToJoinToolStripMenuItem");
            this.enterListOfVideosToJoinToolStripMenuItem.Click += new System.EventHandler(this.enterListOfVideosToJoinToolStripMenuItem_Click);
            // 
            // saveCurrentSelectionToolStripMenuItem
            // 
            this.saveCurrentSelectionToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.disk_blue;
            this.saveCurrentSelectionToolStripMenuItem.Name = "saveCurrentSelectionToolStripMenuItem";
            resources.ApplyResources(this.saveCurrentSelectionToolStripMenuItem, "saveCurrentSelectionToolStripMenuItem");
            this.saveCurrentSelectionToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentSelectionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // saveJoinArgsToolStripMenuItem
            // 
            this.saveJoinArgsToolStripMenuItem.Name = "saveJoinArgsToolStripMenuItem";
            resources.ApplyResources(this.saveJoinArgsToolStripMenuItem, "saveJoinArgsToolStripMenuItem");
            this.saveJoinArgsToolStripMenuItem.Click += new System.EventHandler(this.saveJoinArgsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.toolStripSeparator2,
            this.selectAllToolStripMenuItem,
            this.unselectAllToolStripMenuItem,
            this.invertSelectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.delete;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.brush2;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.arrow_up_green;
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            resources.ApplyResources(this.moveUpToolStripMenuItem, "moveUpToolStripMenuItem");
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveUp_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.arrow_down_green;
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            resources.ApplyResources(this.moveDownToolStripMenuItem, "moveDownToolStripMenuItem");
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
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
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whenFinishedToolStripMenuItem,
            this.toolStripMenuItem3,
            this.useFFMPEG64bitToolStripMenuItem,
            this.useFFMPEG32bitToolStripMenuItem,
            this.toolStripSeparator3,
            this.minimizeToSystemTrayToolStripMenuItem,
            this.loopVideosToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            resources.ApplyResources(this.optionsToolStripMenuItem1, "optionsToolStripMenuItem1");
            // 
            // whenFinishedToolStripMenuItem
            // 
            this.whenFinishedToolStripMenuItem.Name = "whenFinishedToolStripMenuItem";
            resources.ApplyResources(this.whenFinishedToolStripMenuItem, "whenFinishedToolStripMenuItem");
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // useFFMPEG64bitToolStripMenuItem
            // 
            this.useFFMPEG64bitToolStripMenuItem.Name = "useFFMPEG64bitToolStripMenuItem";
            resources.ApplyResources(this.useFFMPEG64bitToolStripMenuItem, "useFFMPEG64bitToolStripMenuItem");
            this.useFFMPEG64bitToolStripMenuItem.Click += new System.EventHandler(this.useFFMPEG64bitToolStripMenuItem_Click);
            // 
            // useFFMPEG32bitToolStripMenuItem
            // 
            this.useFFMPEG32bitToolStripMenuItem.Name = "useFFMPEG32bitToolStripMenuItem";
            resources.ApplyResources(this.useFFMPEG32bitToolStripMenuItem, "useFFMPEG32bitToolStripMenuItem");
            this.useFFMPEG32bitToolStripMenuItem.Click += new System.EventHandler(this.useFFMPEG32bitToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // minimizeToSystemTrayToolStripMenuItem
            // 
            this.minimizeToSystemTrayToolStripMenuItem.CheckOnClick = true;
            this.minimizeToSystemTrayToolStripMenuItem.Name = "minimizeToSystemTrayToolStripMenuItem";
            resources.ApplyResources(this.minimizeToSystemTrayToolStripMenuItem, "minimizeToSystemTrayToolStripMenuItem");
            this.minimizeToSystemTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToSystemTrayToolStripMenuItem_Click);
            // 
            // loopVideosToolStripMenuItem
            // 
            this.loopVideosToolStripMenuItem.CheckOnClick = true;
            this.loopVideosToolStripMenuItem.Name = "loopVideosToolStripMenuItem";
            resources.ApplyResources(this.loopVideosToolStripMenuItem, "loopVideosToolStripMenuItem");
            this.loopVideosToolStripMenuItem.Click += new System.EventHandler(this.loopVideosToolStripMenuItem_Click);
            // 
            // tiToolsPlayOutput
            // 
            this.tiToolsPlayOutput.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiCreateVideoWallpaper,
            this.tsiTest,
            this.toolStripMenuItem2});
            this.tiToolsPlayOutput.Name = "tiToolsPlayOutput";
            resources.ApplyResources(this.tiToolsPlayOutput, "tiToolsPlayOutput");
            // 
            // tsiCreateVideoWallpaper
            // 
            this.tsiCreateVideoWallpaper.Image = global::VideoWallpaperCreator.Properties.Resources.merge_24;
            this.tsiCreateVideoWallpaper.Name = "tsiCreateVideoWallpaper";
            resources.ApplyResources(this.tsiCreateVideoWallpaper, "tsiCreateVideoWallpaper");
            this.tsiCreateVideoWallpaper.Click += new System.EventHandler(this.tsbCreateWallpaper_Click);
            // 
            // tsiTest
            // 
            this.tsiTest.Name = "tsiTest";
            resources.ApplyResources(this.tsiTest, "tsiTest");
            this.tsiTest.Click += new System.EventHandler(this.batchJoinToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languages1ToolStripMenuItem,
            this.languages2ToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // languages1ToolStripMenuItem
            // 
            this.languages1ToolStripMenuItem.Name = "languages1ToolStripMenuItem";
            resources.ApplyResources(this.languages1ToolStripMenuItem, "languages1ToolStripMenuItem");
            // 
            // languages2ToolStripMenuItem
            // 
            this.languages2ToolStripMenuItem.Name = "languages2ToolStripMenuItem";
            resources.ApplyResources(this.languages2ToolStripMenuItem, "languages2ToolStripMenuItem");
            // 
            // downloadSoftwareToolStripMenuItem
            // 
            this.downloadSoftwareToolStripMenuItem.Name = "downloadSoftwareToolStripMenuItem";
            resources.ApplyResources(this.downloadSoftwareToolStripMenuItem, "downloadSoftwareToolStripMenuItem");
            // 
            // pleaseShareToolStripMenuItem
            // 
            this.pleaseShareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shareOnFacebookToolStripMenuItem,
            this.shareOnTwitterToolStripMenuItem,
            this.shareOnGooglePlusToolStripMenuItem,
            this.shareOnLinkedinToolStripMenuItem,
            this.shareWithEmailToolStripMenuItem});
            this.pleaseShareToolStripMenuItem.Name = "pleaseShareToolStripMenuItem";
            resources.ApplyResources(this.pleaseShareToolStripMenuItem, "pleaseShareToolStripMenuItem");
            // 
            // shareOnFacebookToolStripMenuItem
            // 
            this.shareOnFacebookToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.facebook_24;
            this.shareOnFacebookToolStripMenuItem.Name = "shareOnFacebookToolStripMenuItem";
            resources.ApplyResources(this.shareOnFacebookToolStripMenuItem, "shareOnFacebookToolStripMenuItem");
            this.shareOnFacebookToolStripMenuItem.Click += new System.EventHandler(this.shareOnFacebookToolStripMenuItem_Click);
            // 
            // shareOnTwitterToolStripMenuItem
            // 
            this.shareOnTwitterToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.twitter_24;
            this.shareOnTwitterToolStripMenuItem.Name = "shareOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.shareOnTwitterToolStripMenuItem, "shareOnTwitterToolStripMenuItem");
            this.shareOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.shareOnTwitterToolStripMenuItem_Click);
            // 
            // shareOnGooglePlusToolStripMenuItem
            // 
            this.shareOnGooglePlusToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.googleplus_24;
            this.shareOnGooglePlusToolStripMenuItem.Name = "shareOnGooglePlusToolStripMenuItem";
            resources.ApplyResources(this.shareOnGooglePlusToolStripMenuItem, "shareOnGooglePlusToolStripMenuItem");
            this.shareOnGooglePlusToolStripMenuItem.Click += new System.EventHandler(this.shareOnGooglePlusToolStripMenuItem_Click);
            // 
            // shareOnLinkedinToolStripMenuItem
            // 
            this.shareOnLinkedinToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.linkedin_24;
            this.shareOnLinkedinToolStripMenuItem.Name = "shareOnLinkedinToolStripMenuItem";
            resources.ApplyResources(this.shareOnLinkedinToolStripMenuItem, "shareOnLinkedinToolStripMenuItem");
            this.shareOnLinkedinToolStripMenuItem.Click += new System.EventHandler(this.shareOnLinkedinToolStripMenuItem_Click);
            // 
            // shareWithEmailToolStripMenuItem
            // 
            this.shareWithEmailToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.mail;
            this.shareWithEmailToolStripMenuItem.Name = "shareWithEmailToolStripMenuItem";
            resources.ApplyResources(this.shareWithEmailToolStripMenuItem, "shareWithEmailToolStripMenuItem");
            this.shareWithEmailToolStripMenuItem.Click += new System.EventHandler(this.shareWithEmailToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpUsersManualToolStripMenuItem,
            this.toolStripMenuItem4,
            this.pleaseDonateToolStripMenuItem1,
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem,
            this.followUsOnTwitterToolStripMenuItem,
            this.visit4dotsSoftwareWebpageToolStripMenuItem,
            this.toolStripMenuItem9,
            this.checkForNewVersionEachWeekToolStripMenuItem,
            this.feedbackToolStripMenuItem,
            this.checkForNewVersionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpUsersManualToolStripMenuItem
            // 
            this.helpUsersManualToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.help2;
            this.helpUsersManualToolStripMenuItem.Name = "helpUsersManualToolStripMenuItem";
            resources.ApplyResources(this.helpUsersManualToolStripMenuItem, "helpUsersManualToolStripMenuItem");
            this.helpUsersManualToolStripMenuItem.Click += new System.EventHandler(this.helpUsersManualToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // pleaseDonateToolStripMenuItem1
            // 
            this.pleaseDonateToolStripMenuItem1.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.pleaseDonateToolStripMenuItem1, "pleaseDonateToolStripMenuItem1");
            this.pleaseDonateToolStripMenuItem1.Name = "pleaseDonateToolStripMenuItem1";
            this.pleaseDonateToolStripMenuItem1.Click += new System.EventHandler(this.pleaseDonateToolStripMenuItem_Click);
            // 
            // dotsSoftwarePRODUCTCATALOGToolStripMenuItem
            // 
            resources.ApplyResources(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem, "dotsSoftwarePRODUCTCATALOGToolStripMenuItem");
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Name = "dotsSoftwarePRODUCTCATALOGToolStripMenuItem";
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Click += new System.EventHandler(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click);
            // 
            // followUsOnTwitterToolStripMenuItem
            // 
            this.followUsOnTwitterToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.social_twitter_box_white_icon_24;
            this.followUsOnTwitterToolStripMenuItem.Name = "followUsOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.followUsOnTwitterToolStripMenuItem, "followUsOnTwitterToolStripMenuItem");
            this.followUsOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.followUsOnTwitterToolStripMenuItem_Click);
            // 
            // visit4dotsSoftwareWebpageToolStripMenuItem
            // 
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.earth;
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Name = "visit4dotsSoftwareWebpageToolStripMenuItem";
            resources.ApplyResources(this.visit4dotsSoftwareWebpageToolStripMenuItem, "visit4dotsSoftwareWebpageToolStripMenuItem");
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Click += new System.EventHandler(this.visit4dotsSoftwareWebpageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            // 
            // checkForNewVersionEachWeekToolStripMenuItem
            // 
            this.checkForNewVersionEachWeekToolStripMenuItem.CheckOnClick = true;
            this.checkForNewVersionEachWeekToolStripMenuItem.Name = "checkForNewVersionEachWeekToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionEachWeekToolStripMenuItem, "checkForNewVersionEachWeekToolStripMenuItem");
            // 
            // feedbackToolStripMenuItem
            // 
            this.feedbackToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.edit;
            this.feedbackToolStripMenuItem.Name = "feedbackToolStripMenuItem";
            resources.ApplyResources(this.feedbackToolStripMenuItem, "feedbackToolStripMenuItem");
            this.feedbackToolStripMenuItem.Click += new System.EventHandler(this.feedbackToolStripMenuItem_Click);
            // 
            // checkForNewVersionToolStripMenuItem
            // 
            this.checkForNewVersionToolStripMenuItem.Name = "checkForNewVersionToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionToolStripMenuItem, "checkForNewVersionToolStripMenuItem");
            this.checkForNewVersionToolStripMenuItem.Click += new System.EventHandler(this.checkForNewVersionToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // dgVideo
            // 
            this.dgVideo.AllowDrop = true;
            this.dgVideo.AllowUserToAddRows = false;
            this.dgVideo.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgVideo, "dgVideo");
            this.dgVideo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgVideo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgVideo.BackgroundColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVideo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVideo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVideo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colVideo});
            this.dgVideo.ContextMenuStrip = this.cmsVideos;
            this.dgVideo.Name = "dgVideo";
            this.dgVideo.RowHeadersVisible = false;
            this.dgVideo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVideo.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgVideo_DragDrop);
            this.dgVideo.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgVideo_DragEnter);
            this.dgVideo.DragOver += new System.Windows.Forms.DragEventHandler(this.dgVideo_DragOver);
            // 
            // colIndex
            // 
            this.colIndex.DataPropertyName = "ind";
            resources.ApplyResources(this.colIndex, "colIndex");
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            // 
            // colVideo
            // 
            this.colVideo.DataPropertyName = "videoimg";
            resources.ApplyResources(this.colVideo, "colVideo");
            this.colVideo.Name = "colVideo";
            this.colVideo.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ind";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "videoimg";
            resources.ApplyResources(this.dataGridViewImageColumn1, "dataGridViewImageColumn1");
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 40000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 30000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // nudFps
            // 
            resources.ApplyResources(this.nudFps, "nudFps");
            this.nudFps.Maximum = new decimal(new int[] {
            -1981284352,
            -1966660860,
            0,
            0});
            this.nudFps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFps.Name = "nudFps";
            this.nudFps.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudInterval
            // 
            resources.ApplyResources(this.nudInterval, "nudInterval");
            this.nudInterval.Maximum = new decimal(new int[] {
            -1486618624,
            232830643,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudWidth
            // 
            resources.ApplyResources(this.nudWidth, "nudWidth");
            this.nudWidth.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rdSlowComputer
            // 
            resources.ApplyResources(this.rdSlowComputer, "rdSlowComputer");
            this.rdSlowComputer.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdSlowComputer.Name = "rdSlowComputer";
            this.rdSlowComputer.TabStop = true;
            this.rdSlowComputer.UseVisualStyleBackColor = true;
            this.rdSlowComputer.Click += new System.EventHandler(this.rdSlowComputer_Click);
            // 
            // rdFastComputer
            // 
            resources.ApplyResources(this.rdFastComputer, "rdFastComputer");
            this.rdFastComputer.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdFastComputer.Name = "rdFastComputer";
            this.rdFastComputer.TabStop = true;
            this.rdFastComputer.UseVisualStyleBackColor = true;
            this.rdFastComputer.Click += new System.EventHandler(this.rdFastComputer_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // timWallpaper
            // 
            this.timWallpaper.Tick += new System.EventHandler(this.timWallpaper_Tick);
            // 
            // timTest
            // 
            this.timTest.Interval = 60000;
            this.timTest.Tick += new System.EventHandler(this.timTest_Tick);
            // 
            // chkStartup
            // 
            resources.ApplyResources(this.chkStartup, "chkStartup");
            this.chkStartup.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.UseVisualStyleBackColor = true;
            this.chkStartup.Click += new System.EventHandler(this.chkStartup_Click);
            // 
            // notMain
            // 
            this.notMain.ContextMenuStrip = this.cmsNotify;
            resources.ApplyResources(this.notMain, "notMain");
            this.notMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notMain_MouseDoubleClick);
            // 
            // cmsNotify
            // 
            this.cmsNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem1});
            this.cmsNotify.Name = "cmsNotify";
            resources.ApplyResources(this.cmsNotify, "cmsNotify");
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.media_play;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            resources.ApplyResources(this.startToolStripMenuItem, "startToolStripMenuItem");
            this.startToolStripMenuItem.Click += new System.EventHandler(this.tsbPlay_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.media_stop;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            resources.ApplyResources(this.stopToolStripMenuItem, "stopToolStripMenuItem");
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            resources.ApplyResources(this.showToolStripMenuItem, "showToolStripMenuItem");
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Image = global::VideoWallpaperCreator.Properties.Resources.exit;
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.chkStartup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdFastComputer);
            this.Controls.Add(this.rdSlowComputer);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.nudInterval);
            this.Controls.Add(this.nudFps);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picVideoPlayer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsCut);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgVideo);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.ShowInTaskbar = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVideoJoin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVideoJoin_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.cmsVideos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picVideoPlayer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tsCut.ResumeLayout(false);
            this.tsCut.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.cmsNotify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsCut;
        public System.Windows.Forms.ToolStripSplitButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbPlay;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.ToolStripButton tsbCreateWallpaper;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ToolStripButton tsbMoveUp;
        private System.Windows.Forms.ToolStripButton tsbMoveDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewImageColumn colVideo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel slblTotalVideos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripStatusLabel slblTotalDuration;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timJoinVideos;
        private System.Windows.Forms.ToolStripStatusLabel lblElapsedTime;
        private System.Windows.Forms.ContextMenuStrip cmsVideos;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFullPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoInfoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpUsersManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwarePRODUCTCATALOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followUsOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visit4dotsSoftwareWebpageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem feedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pleaseShareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnFacebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnGooglePlusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnLinkedinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareWithEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem languages1ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem languages2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiToolsPlayOutput;
        private System.Windows.Forms.Panel panel1;
        private MediaSlider.MediaSlider msVolume;
        private GlowButton.GlowButton btnMute;
        private GlowButton.GlowButton btnStop;
        private GlowButton.GlowButton btnPlay;
        private GlowButton.GlowButton btnFastForward;
        private GlowButton.GlowButton btnRewind;
        private MediaSlider.MediaSlider msPosition;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.PictureBox picVideoPlayer;
        public System.Windows.Forms.DataGridView dgVideo;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem importVideosFromTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importVideosFromCSVFIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem enterListOfVideosToJoinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentSelectionToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveJoinArgsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiCreateVideoWallpaper;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ToolStripMenuItem pleaseDonateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudFps;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.RadioButton rdSlowComputer;
        private System.Windows.Forms.RadioButton rdFastComputer;
        private System.Windows.Forms.ToolStripButton tsbTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem whenFinishedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem useFFMPEG64bitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useFFMPEG32bitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Timer timWallpaper;
        private System.Windows.Forms.Timer timTest;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.NotifyIcon notMain;
        private System.Windows.Forms.ContextMenuStrip cmsNotify;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToSystemTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loopVideosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addCloudsSampleVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionEachWeekToolStripMenuItem;
        private com.softpcapps.download_software.DownloadSoftwareToolStripMenuItem downloadSoftwareToolStripMenuItem;
    }
}
