namespace VideoWallpaperCreator
{
    partial class frmClip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClip));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.msVolume = new MediaSlider.MediaSlider();
            this.btnMute = new GlowButton.GlowButton();
            this.chkShowStoryboard = new System.Windows.Forms.CheckBox();
            this.chkShowStoryboardAudioWaveform = new System.Windows.Forms.CheckBox();
            this.mskTotalDuration = new VideoWallpaperCreator.TimeUpDownControl();
            this.mskDuration = new VideoWallpaperCreator.TimeUpDownControl();
            this.mskCutEnd = new VideoWallpaperCreator.TimeUpDownControl();
            this.mskCutStart = new VideoWallpaperCreator.TimeUpDownControl();
            this.mskPos = new VideoWallpaperCreator.TimeUpDownControl();
            this.timPlayerPosition = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timPlayPositionJ = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timCut = new System.Windows.Forms.Timer(this.components);
            this.bwConvert = new System.ComponentModel.BackgroundWorker();
            this.timDebug = new System.Windows.Forms.Timer(this.components);
            this.cmsZoom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ti30Seconds = new System.Windows.Forms.ToolStripMenuItem();
            this.ti10Seconds = new System.Windows.Forms.ToolStripMenuItem();
            this.ti5Seconds = new System.Windows.Forms.ToolStripMenuItem();
            this.tiSecond = new System.Windows.Forms.ToolStripMenuItem();
            this.ti100Msecs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiFacebook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTwitter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiGooglePlus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiLinkedIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.lblOutputFormat = new System.Windows.Forms.Label();
            this.lbl3min = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblVideoFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMovieLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMovieLengthValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbtnInfo = new System.Windows.Forms.ToolStripDropDownButton();
            this.ts3min = new System.Windows.Forms.ToolStrip();
            this.tsbMoveBack3Min = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveForward3Min = new System.Windows.Forms.ToolStripButton();
            this.fplSegments = new System.Windows.Forms.FlowLayoutPanel();
            this.tsCut = new System.Windows.Forms.ToolStrip();
            this.tsbCutOpenVideo = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPlay = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbSetStart = new System.Windows.Forms.ToolStripButton();
            this.tsbSetEnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCutAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbCutRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCutPlayPreview = new System.Windows.Forms.ToolStripButton();
            this.tsbStopPreview = new System.Windows.Forms.ToolStripButton();
            this.tsbCutVideo = new System.Windows.Forms.ToolStripButton();
            this.lbl30sec = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFrameAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiThreadPriority = new System.Windows.Forms.ToolStripMenuItem();
            this.highToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboveNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.belowNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.playPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.addClipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeClipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.setClipStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setClipEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.selectNextCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectPreviousCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.cutVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.showStoryboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStoryboardAudioWaveformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storyboardZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiM30Secs = new System.Windows.Forms.ToolStripMenuItem();
            this.tiM10Secs = new System.Windows.Forms.ToolStripMenuItem();
            this.tiM5Secs = new System.Windows.Forms.ToolStripMenuItem();
            this.tiM1Sec = new System.Windows.Forms.ToolStripMenuItem();
            this.tiM100MSec = new System.Windows.Forms.ToolStripMenuItem();
            this.navigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.move01SecForwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.move01SecBackwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.move1SecForwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.move1SecBackwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.move30SecForwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.move30SecBackwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.move3MinForwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.move3MinBackwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToNextKeyFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToPreviousKeyFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.jumpToMovieEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpToMovieStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.jumpToCutEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpToCutStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiIncludeMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiExcludeMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiSilenceMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsiSplitInParts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiSplitBlackDetect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOutputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCutVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOriginalVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fadeInFadeOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinClipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.whenFinishedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoJoinerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnFacebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnGooglePlusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnLinkedinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareWithEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpUsersManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.pleaseDonateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebpageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.feedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts30sec = new System.Windows.Forms.ToolStrip();
            this.tsbMoveBack30Sec = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveForward30Sec = new System.Windows.Forms.ToolStripButton();
            this.ts01sec = new System.Windows.Forms.ToolStrip();
            this.tsbMoveBackMsec = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveForwardMsec = new System.Windows.Forms.ToolStripButton();
            this.lbl1sec = new System.Windows.Forms.Label();
            this.picMovie = new System.Windows.Forms.PictureBox();
            this.ts1sec = new System.Windows.Forms.ToolStrip();
            this.tsbMoveBack1Sec = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveForward1Sec = new System.Windows.Forms.ToolStripButton();
            this.plMedia = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScrollPos = new System.Windows.Forms.Label();
            this.lbl01sec = new System.Windows.Forms.Label();
            this.cmbOutputFormat = new VideoWallpaperCreator.OwnerDrawnComboBox();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picScreenshot = new System.Windows.Forms.PictureBox();
            this.vthPreview = new VideoWallpaperCreator.VideoThumbnailControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.HScrollbar = new System.Windows.Forms.HScrollBar();
            this.picMain = new VideoWallpaperCreator.PicStoryboardWave();
            this.lblKFrames = new System.Windows.Forms.Label();
            this.tsKeyFrame = new System.Windows.Forms.ToolStrip();
            this.tsbMoveBackKFrame = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveForwardKFrame = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsZoom.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.ts3min.SuspendLayout();
            this.tsCut.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.ts30sec.SuspendLayout();
            this.ts01sec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMovie)).BeginInit();
            this.ts1sec.SuspendLayout();
            this.plMedia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScreenshot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.tsKeyFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnZoomOut
            // 
            resources.ApplyResources(this.btnZoomOut, "btnZoomOut");
            this.btnZoomOut.BackColor = System.Drawing.Color.LightGray;
            this.btnZoomOut.Image = global::VideoWallpaperCreator.Properties.Resources.zoom_out;
            this.btnZoomOut.Name = "btnZoomOut";
            this.toolTip1.SetToolTip(this.btnZoomOut, resources.GetString("btnZoomOut.ToolTip"));
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            resources.ApplyResources(this.btnZoomIn, "btnZoomIn");
            this.btnZoomIn.BackColor = System.Drawing.Color.LightGray;
            this.btnZoomIn.Image = global::VideoWallpaperCreator.Properties.Resources.zoom_in;
            this.btnZoomIn.Name = "btnZoomIn";
            this.toolTip1.SetToolTip(this.btnZoomIn, resources.GetString("btnZoomIn.ToolTip"));
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // msVolume
            // 
            this.msVolume.Animated = false;
            this.msVolume.AnimationSize = 0.2F;
            this.msVolume.AnimationSpeed = MediaSlider.MediaSlider.AnimateSpeed.Normal;
            resources.ApplyResources(this.msVolume, "msVolume");
            this.msVolume.BackColor = System.Drawing.Color.DimGray;
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
            this.msVolume.Maximum = 10;
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
            this.toolTip1.SetToolTip(this.msVolume, resources.GetString("msVolume.ToolTip"));
            this.msVolume.TrackBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msVolume.TrackDepth = 4;
            this.msVolume.TrackFillColor = System.Drawing.Color.Transparent;
            this.msVolume.TrackProgressColor = System.Drawing.Color.LightSkyBlue;
            this.msVolume.TrackShadow = true;
            this.msVolume.TrackShadowColor = System.Drawing.Color.DarkGray;
            this.msVolume.TrackStyle = MediaSlider.MediaSlider.TrackType.Progress;
            this.msVolume.Value = 10;
            this.msVolume.ValueChanged += new MediaSlider.MediaSlider.ValueChangedDelegate(this.msVolume_ValueChanged);
            // 
            // btnMute
            // 
            resources.ApplyResources(this.btnMute, "btnMute");
            this.btnMute.BackColor = System.Drawing.Color.DimGray;
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
            this.btnMute.Tag = "Mute On / Off";
            this.toolTip1.SetToolTip(this.btnMute, resources.GetString("btnMute.ToolTip"));
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // chkShowStoryboard
            // 
            resources.ApplyResources(this.chkShowStoryboard, "chkShowStoryboard");
            this.chkShowStoryboard.BackColor = System.Drawing.Color.LightGray;
            this.chkShowStoryboard.Image = global::VideoWallpaperCreator.Properties.Resources.photo_scenery;
            this.chkShowStoryboard.Name = "chkShowStoryboard";
            this.toolTip1.SetToolTip(this.chkShowStoryboard, resources.GetString("chkShowStoryboard.ToolTip"));
            this.chkShowStoryboard.UseVisualStyleBackColor = false;
            this.chkShowStoryboard.CheckedChanged += new System.EventHandler(this.chkShowStoryboard_CheckedChanged);
            
            // 
            // chkShowStoryboardAudioWaveform
            // 
            resources.ApplyResources(this.chkShowStoryboardAudioWaveform, "chkShowStoryboardAudioWaveform");
            this.chkShowStoryboardAudioWaveform.BackColor = System.Drawing.Color.LightGray;
            this.chkShowStoryboardAudioWaveform.Image = global::VideoWallpaperCreator.Properties.Resources.audio_waveform_16;
            this.chkShowStoryboardAudioWaveform.Name = "chkShowStoryboardAudioWaveform";
            this.toolTip1.SetToolTip(this.chkShowStoryboardAudioWaveform, resources.GetString("chkShowStoryboardAudioWaveform.ToolTip"));
            this.chkShowStoryboardAudioWaveform.UseVisualStyleBackColor = false;
            this.chkShowStoryboardAudioWaveform.CheckedChanged += new System.EventHandler(this.chkShowStoryboardAudioWaveform_CheckedChanged);
            
            // 
            // mskTotalDuration
            // 
            resources.ApplyResources(this.mskTotalDuration, "mskTotalDuration");
            this.mskTotalDuration.BackColor = System.Drawing.Color.Transparent;
            this.mskTotalDuration.ForeColor = System.Drawing.Color.DimGray;
            this.mskTotalDuration.Name = "mskTotalDuration";
            this.mskTotalDuration.Time = System.TimeSpan.Parse("00:00:00");
            this.toolTip1.SetToolTip(this.mskTotalDuration, resources.GetString("mskTotalDuration.ToolTip"));
            // 
            // mskDuration
            // 
            resources.ApplyResources(this.mskDuration, "mskDuration");
            this.mskDuration.BackColor = System.Drawing.Color.Transparent;
            this.mskDuration.ForeColor = System.Drawing.Color.DimGray;
            this.mskDuration.Name = "mskDuration";
            this.mskDuration.Time = System.TimeSpan.Parse("00:00:00");
            this.toolTip1.SetToolTip(this.mskDuration, resources.GetString("mskDuration.ToolTip"));
            // 
            // mskCutEnd
            // 
            resources.ApplyResources(this.mskCutEnd, "mskCutEnd");
            this.mskCutEnd.BackColor = System.Drawing.Color.Transparent;
            this.mskCutEnd.ForeColor = System.Drawing.Color.DimGray;
            this.mskCutEnd.Name = "mskCutEnd";
            this.mskCutEnd.Time = System.TimeSpan.Parse("00:00:00");
            this.toolTip1.SetToolTip(this.mskCutEnd, resources.GetString("mskCutEnd.ToolTip"));
            // 
            // mskCutStart
            // 
            resources.ApplyResources(this.mskCutStart, "mskCutStart");
            this.mskCutStart.BackColor = System.Drawing.Color.Transparent;
            this.mskCutStart.ForeColor = System.Drawing.Color.DimGray;
            this.mskCutStart.Name = "mskCutStart";
            this.mskCutStart.Time = System.TimeSpan.Parse("00:00:00");
            this.toolTip1.SetToolTip(this.mskCutStart, resources.GetString("mskCutStart.ToolTip"));
            // 
            // mskPos
            // 
            resources.ApplyResources(this.mskPos, "mskPos");
            this.mskPos.BackColor = System.Drawing.Color.Transparent;
            this.mskPos.ForeColor = System.Drawing.Color.DimGray;
            this.mskPos.Name = "mskPos";
            this.mskPos.Time = System.TimeSpan.Parse("00:00:00");
            this.toolTip1.SetToolTip(this.mskPos, resources.GetString("mskPos.ToolTip"));
            // 
            // timPlayerPosition
            // 
            this.timPlayerPosition.Enabled = true;
            this.timPlayerPosition.Tick += new System.EventHandler(this.timPlayerPosition_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timPlayPositionJ
            // 
            this.timPlayPositionJ.Enabled = true;
            this.timPlayPositionJ.Interval = 1000;
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // timCut
            // 
            this.timCut.Interval = 1000;
            this.timCut.Tick += new System.EventHandler(this.timCut_Tick);
            // 
            // bwConvert
            // 
            this.bwConvert.WorkerReportsProgress = true;
            this.bwConvert.WorkerSupportsCancellation = true;
            this.bwConvert.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwConvert_DoWork);
            this.bwConvert.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwConvert_ProgressChanged);
            this.bwConvert.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwConvert_RunWorkerCompleted);
            // 
            // timDebug
            // 
            this.timDebug.Tick += new System.EventHandler(this.timDebug_Tick);
            // 
            // cmsZoom
            // 
            this.cmsZoom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ti30Seconds,
            this.ti10Seconds,
            this.ti5Seconds,
            this.tiSecond,
            this.ti100Msecs});
            this.cmsZoom.Name = "cmsZoom";
            resources.ApplyResources(this.cmsZoom, "cmsZoom");
            // 
            // ti30Seconds
            // 
            this.ti30Seconds.Name = "ti30Seconds";
            resources.ApplyResources(this.ti30Seconds, "ti30Seconds");
            this.ti30Seconds.Click += new System.EventHandler(this.ti30Seconds_Click);
            // 
            // ti10Seconds
            // 
            this.ti10Seconds.Checked = true;
            this.ti10Seconds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ti10Seconds.Name = "ti10Seconds";
            resources.ApplyResources(this.ti10Seconds, "ti10Seconds");
            this.ti10Seconds.Click += new System.EventHandler(this.ti10Seconds_Click);
            // 
            // ti5Seconds
            // 
            this.ti5Seconds.Name = "ti5Seconds";
            resources.ApplyResources(this.ti5Seconds, "ti5Seconds");
            this.ti5Seconds.Click += new System.EventHandler(this.ti5Seconds_Click);
            // 
            // tiSecond
            // 
            this.tiSecond.Name = "tiSecond";
            resources.ApplyResources(this.tiSecond, "tiSecond");
            this.tiSecond.Click += new System.EventHandler(this.tiSecond_Click);
            // 
            // ti100Msecs
            // 
            this.ti100Msecs.Name = "ti100Msecs";
            resources.ApplyResources(this.ti100Msecs, "ti100Msecs");
            this.ti100Msecs.Click += new System.EventHandler(this.ti100Msecs_Click);
            // 
            // tsiFacebook
            // 
            this.tsiFacebook.Image = global::VideoWallpaperCreator.Properties.Resources.facebook_24;
            this.tsiFacebook.Name = "tsiFacebook";
            resources.ApplyResources(this.tsiFacebook, "tsiFacebook");
            this.tsiFacebook.Click += new System.EventHandler(this.tsiFacebook_Click);
            // 
            // tsiTwitter
            // 
            this.tsiTwitter.Image = global::VideoWallpaperCreator.Properties.Resources.twitter_24;
            this.tsiTwitter.Name = "tsiTwitter";
            resources.ApplyResources(this.tsiTwitter, "tsiTwitter");
            this.tsiTwitter.Click += new System.EventHandler(this.tsiTwitter_Click);
            // 
            // tsiGooglePlus
            // 
            this.tsiGooglePlus.Image = global::VideoWallpaperCreator.Properties.Resources.googleplus_24;
            this.tsiGooglePlus.Name = "tsiGooglePlus";
            resources.ApplyResources(this.tsiGooglePlus, "tsiGooglePlus");
            this.tsiGooglePlus.Click += new System.EventHandler(this.tsiGooglePlus_Click);
            // 
            // tsiLinkedIn
            // 
            this.tsiLinkedIn.Image = global::VideoWallpaperCreator.Properties.Resources.linkedin_24;
            this.tsiLinkedIn.Name = "tsiLinkedIn";
            resources.ApplyResources(this.tsiLinkedIn, "tsiLinkedIn");
            this.tsiLinkedIn.Click += new System.EventHandler(this.tsiLinkedIn_Click);
            // 
            // tsiEmail
            // 
            this.tsiEmail.Image = global::VideoWallpaperCreator.Properties.Resources.mail;
            this.tsiEmail.Name = "tsiEmail";
            resources.ApplyResources(this.tsiEmail, "tsiEmail");
            this.tsiEmail.Click += new System.EventHandler(this.tsiEmail_Click);
            // 
            // lblOutputFormat
            // 
            resources.ApplyResources(this.lblOutputFormat, "lblOutputFormat");
            this.lblOutputFormat.BackColor = System.Drawing.Color.Transparent;
            this.lblOutputFormat.ForeColor = System.Drawing.Color.DimGray;
            this.lblOutputFormat.Name = "lblOutputFormat";
            // 
            // lbl3min
            // 
            resources.ApplyResources(this.lbl3min, "lbl3min");
            this.lbl3min.BackColor = System.Drawing.Color.Transparent;
            this.lbl3min.ForeColor = System.Drawing.Color.DimGray;
            this.lbl3min.Name = "lbl3min";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblVideoFile,
            this.lblElapsedTime,
            this.lblMovieLength,
            this.lblMovieLengthValue,
            this.sbtnInfo});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // tlblVideoFile
            // 
            resources.ApplyResources(this.tlblVideoFile, "tlblVideoFile");
            this.tlblVideoFile.ForeColor = System.Drawing.Color.DimGray;
            this.tlblVideoFile.Name = "tlblVideoFile";
            this.tlblVideoFile.Spring = true;
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.Name = "lblElapsedTime";
            resources.ApplyResources(this.lblElapsedTime, "lblElapsedTime");
            // 
            // lblMovieLength
            // 
            resources.ApplyResources(this.lblMovieLength, "lblMovieLength");
            this.lblMovieLength.ForeColor = System.Drawing.Color.DimGray;
            this.lblMovieLength.Name = "lblMovieLength";
            // 
            // lblMovieLengthValue
            // 
            resources.ApplyResources(this.lblMovieLengthValue, "lblMovieLengthValue");
            this.lblMovieLengthValue.ForeColor = System.Drawing.Color.DimGray;
            this.lblMovieLengthValue.Name = "lblMovieLengthValue";
            // 
            // sbtnInfo
            // 
            this.sbtnInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sbtnInfo.Image = global::VideoWallpaperCreator.Properties.Resources.information;
            resources.ApplyResources(this.sbtnInfo, "sbtnInfo");
            this.sbtnInfo.Name = "sbtnInfo";
            this.sbtnInfo.ShowDropDownArrow = false;
            this.sbtnInfo.Click += new System.EventHandler(this.sbtnInfo_Click);
            // 
            // ts3min
            // 
            resources.ApplyResources(this.ts3min, "ts3min");
            this.ts3min.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMoveBack3Min,
            this.tsbMoveForward3Min});
            this.ts3min.Name = "ts3min";
            // 
            // tsbMoveBack3Min
            // 
            resources.ApplyResources(this.tsbMoveBack3Min, "tsbMoveBack3Min");
            this.tsbMoveBack3Min.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveBack3Min.Image = global::VideoWallpaperCreator.Properties.Resources.navigate_left2;
            this.tsbMoveBack3Min.Name = "tsbMoveBack3Min";
            this.tsbMoveBack3Min.Click += new System.EventHandler(this.tsbMoveBack3Min_Click);
            // 
            // tsbMoveForward3Min
            // 
            resources.ApplyResources(this.tsbMoveForward3Min, "tsbMoveForward3Min");
            this.tsbMoveForward3Min.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveForward3Min.Image = global::VideoWallpaperCreator.Properties.Resources.navigate_right1;
            this.tsbMoveForward3Min.Name = "tsbMoveForward3Min";
            this.tsbMoveForward3Min.Click += new System.EventHandler(this.tsbMoveForward3Min_Click);
            // 
            // fplSegments
            // 
            resources.ApplyResources(this.fplSegments, "fplSegments");
            this.fplSegments.Name = "fplSegments";
            // 
            // tsCut
            // 
            resources.ApplyResources(this.tsCut, "tsCut");
            this.tsCut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCutOpenVideo,
            this.toolStripSeparator3,
            this.tsbPlay,
            this.tsbStop,
            this.tsbSetStart,
            this.tsbSetEnd,
            this.toolStripSeparator5,
            this.tsbCutAdd,
            this.tsbCutRemove,
            this.toolStripSeparator6,
            this.tsbCutPlayPreview,
            this.tsbStopPreview,
            this.tsbCutVideo});
            this.tsCut.Name = "tsCut";
            // 
            // tsbCutOpenVideo
            // 
            resources.ApplyResources(this.tsbCutOpenVideo, "tsbCutOpenVideo");
            this.tsbCutOpenVideo.Image = global::VideoWallpaperCreator.Properties.Resources.folder2;
            this.tsbCutOpenVideo.Name = "tsbCutOpenVideo";
            this.tsbCutOpenVideo.ButtonClick += new System.EventHandler(this.btnOpenVideo_Click);
            this.tsbCutOpenVideo.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbCutOpenVideo_DropDownItemClicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tsbPlay
            // 
            resources.ApplyResources(this.tsbPlay, "tsbPlay");
            this.tsbPlay.Image = global::VideoWallpaperCreator.Properties.Resources.media_play_green1;
            this.tsbPlay.Name = "tsbPlay";
            this.tsbPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // tsbStop
            // 
            resources.ApplyResources(this.tsbStop, "tsbStop");
            this.tsbStop.Image = global::VideoWallpaperCreator.Properties.Resources.media_stop1;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tsbSetStart
            // 
            resources.ApplyResources(this.tsbSetStart, "tsbSetStart");
            this.tsbSetStart.Image = global::VideoWallpaperCreator.Properties.Resources.setstart_24;
            this.tsbSetStart.Name = "tsbSetStart";
            this.tsbSetStart.Click += new System.EventHandler(this.btnSetClipStart_Click);
            // 
            // tsbSetEnd
            // 
            resources.ApplyResources(this.tsbSetEnd, "tsbSetEnd");
            this.tsbSetEnd.Image = global::VideoWallpaperCreator.Properties.Resources.setend_24;
            this.tsbSetEnd.Name = "tsbSetEnd";
            this.tsbSetEnd.Click += new System.EventHandler(this.btnSetEnd_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // tsbCutAdd
            // 
            resources.ApplyResources(this.tsbCutAdd, "tsbCutAdd");
            this.tsbCutAdd.Image = global::VideoWallpaperCreator.Properties.Resources.add1;
            this.tsbCutAdd.Name = "tsbCutAdd";
            this.tsbCutAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tsbCutRemove
            // 
            resources.ApplyResources(this.tsbCutRemove, "tsbCutRemove");
            this.tsbCutRemove.Image = global::VideoWallpaperCreator.Properties.Resources.delete1;
            this.tsbCutRemove.Name = "tsbCutRemove";
            this.tsbCutRemove.Click += new System.EventHandler(this.btnDeleteSegment_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // tsbCutPlayPreview
            // 
            resources.ApplyResources(this.tsbCutPlayPreview, "tsbCutPlayPreview");
            this.tsbCutPlayPreview.Image = global::VideoWallpaperCreator.Properties.Resources.media_play1;
            this.tsbCutPlayPreview.Name = "tsbCutPlayPreview";
            this.tsbCutPlayPreview.Click += new System.EventHandler(this.btnPlayAll_Click);
            // 
            // tsbStopPreview
            // 
            resources.ApplyResources(this.tsbStopPreview, "tsbStopPreview");
            this.tsbStopPreview.Image = global::VideoWallpaperCreator.Properties.Resources.media_stop1;
            this.tsbStopPreview.Name = "tsbStopPreview";
            this.tsbStopPreview.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tsbCutVideo
            // 
            resources.ApplyResources(this.tsbCutVideo, "tsbCutVideo");
            this.tsbCutVideo.Image = global::VideoWallpaperCreator.Properties.Resources.cut1;
            this.tsbCutVideo.Name = "tsbCutVideo";
            this.tsbCutVideo.Click += new System.EventHandler(this.tsbCutVideo_Click);
            // 
            // lbl30sec
            // 
            resources.ApplyResources(this.lbl30sec, "lbl30sec");
            this.lbl30sec.BackColor = System.Drawing.Color.Transparent;
            this.lbl30sec.ForeColor = System.Drawing.Color.DimGray;
            this.lbl30sec.Name = "lbl30sec";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.navigationToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.tsiDownload,
            this.languageToolStripMenuItem,
            this.shareToolStripMenuItem,
            this.toolStripMenuItem1});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveFrameAsImageToolStripMenuItem,
            this.toolStripMenuItem13,
            this.minimizeToTrayToolStripMenuItem,
            this.tsiThreadPriority,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.btnOpenVideo_Click);
            // 
            // saveFrameAsImageToolStripMenuItem
            // 
            this.saveFrameAsImageToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.disk_blue;
            this.saveFrameAsImageToolStripMenuItem.Name = "saveFrameAsImageToolStripMenuItem";
            resources.ApplyResources(this.saveFrameAsImageToolStripMenuItem, "saveFrameAsImageToolStripMenuItem");
            this.saveFrameAsImageToolStripMenuItem.Click += new System.EventHandler(this.saveFrameAsImageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            resources.ApplyResources(this.toolStripMenuItem13, "toolStripMenuItem13");
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            resources.ApplyResources(this.minimizeToTrayToolStripMenuItem, "minimizeToTrayToolStripMenuItem");
            this.minimizeToTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToTrayToolStripMenuItem_Click);
            // 
            // tsiThreadPriority
            // 
            this.tsiThreadPriority.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highToolStripMenuItem,
            this.aboveNormalToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.belowNormalToolStripMenuItem,
            this.idleToolStripMenuItem});
            this.tsiThreadPriority.Name = "tsiThreadPriority";
            resources.ApplyResources(this.tsiThreadPriority, "tsiThreadPriority");
            // 
            // highToolStripMenuItem
            // 
            this.highToolStripMenuItem.Name = "highToolStripMenuItem";
            resources.ApplyResources(this.highToolStripMenuItem, "highToolStripMenuItem");
            this.highToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // aboveNormalToolStripMenuItem
            // 
            this.aboveNormalToolStripMenuItem.Name = "aboveNormalToolStripMenuItem";
            resources.ApplyResources(this.aboveNormalToolStripMenuItem, "aboveNormalToolStripMenuItem");
            this.aboveNormalToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            resources.ApplyResources(this.normalToolStripMenuItem, "normalToolStripMenuItem");
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // belowNormalToolStripMenuItem
            // 
            this.belowNormalToolStripMenuItem.Name = "belowNormalToolStripMenuItem";
            resources.ApplyResources(this.belowNormalToolStripMenuItem, "belowNormalToolStripMenuItem");
            this.belowNormalToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // idleToolStripMenuItem
            // 
            this.idleToolStripMenuItem.Name = "idleToolStripMenuItem";
            resources.ApplyResources(this.idleToolStripMenuItem, "idleToolStripMenuItem");
            this.idleToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopToolStripMenuItem,
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.toolStripMenuItem3,
            this.playPreviewToolStripMenuItem,
            this.toolStripMenuItem5,
            this.addClipToolStripMenuItem,
            this.removeClipToolStripMenuItem,
            this.toolStripMenuItem7,
            this.setClipStartToolStripMenuItem,
            this.setClipEndToolStripMenuItem,
            this.toolStripMenuItem6,
            this.selectNextCutToolStripMenuItem,
            this.selectPreviousCutToolStripMenuItem,
            this.toolStripMenuItem11,
            this.cutVideoToolStripMenuItem,
            this.pauseCutToolStripMenuItem,
            this.stopCutToolStripMenuItem,
            this.toolStripMenuItem12});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            resources.ApplyResources(this.stopToolStripMenuItem, "stopToolStripMenuItem");
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            resources.ApplyResources(this.playToolStripMenuItem, "playToolStripMenuItem");
            this.playToolStripMenuItem.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            resources.ApplyResources(this.pauseToolStripMenuItem, "pauseToolStripMenuItem");
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // playPreviewToolStripMenuItem
            // 
            this.playPreviewToolStripMenuItem.Name = "playPreviewToolStripMenuItem";
            resources.ApplyResources(this.playPreviewToolStripMenuItem, "playPreviewToolStripMenuItem");
            this.playPreviewToolStripMenuItem.Click += new System.EventHandler(this.btnPlayAll_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // addClipToolStripMenuItem
            // 
            this.addClipToolStripMenuItem.Name = "addClipToolStripMenuItem";
            resources.ApplyResources(this.addClipToolStripMenuItem, "addClipToolStripMenuItem");
            this.addClipToolStripMenuItem.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // removeClipToolStripMenuItem
            // 
            this.removeClipToolStripMenuItem.Name = "removeClipToolStripMenuItem";
            resources.ApplyResources(this.removeClipToolStripMenuItem, "removeClipToolStripMenuItem");
            this.removeClipToolStripMenuItem.Click += new System.EventHandler(this.btnDeleteSegment_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            // 
            // setClipStartToolStripMenuItem
            // 
            this.setClipStartToolStripMenuItem.Name = "setClipStartToolStripMenuItem";
            resources.ApplyResources(this.setClipStartToolStripMenuItem, "setClipStartToolStripMenuItem");
            this.setClipStartToolStripMenuItem.Click += new System.EventHandler(this.btnSetClipStart_Click);
            // 
            // setClipEndToolStripMenuItem
            // 
            this.setClipEndToolStripMenuItem.Name = "setClipEndToolStripMenuItem";
            resources.ApplyResources(this.setClipEndToolStripMenuItem, "setClipEndToolStripMenuItem");
            this.setClipEndToolStripMenuItem.Click += new System.EventHandler(this.btnSetEnd_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            // 
            // selectNextCutToolStripMenuItem
            // 
            this.selectNextCutToolStripMenuItem.Name = "selectNextCutToolStripMenuItem";
            resources.ApplyResources(this.selectNextCutToolStripMenuItem, "selectNextCutToolStripMenuItem");
            this.selectNextCutToolStripMenuItem.Click += new System.EventHandler(this.selectNextCutToolStripMenuItem_Click);
            // 
            // selectPreviousCutToolStripMenuItem
            // 
            this.selectPreviousCutToolStripMenuItem.Name = "selectPreviousCutToolStripMenuItem";
            resources.ApplyResources(this.selectPreviousCutToolStripMenuItem, "selectPreviousCutToolStripMenuItem");
            this.selectPreviousCutToolStripMenuItem.Click += new System.EventHandler(this.selectPreviousCutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
            // 
            // cutVideoToolStripMenuItem
            // 
            this.cutVideoToolStripMenuItem.Name = "cutVideoToolStripMenuItem";
            resources.ApplyResources(this.cutVideoToolStripMenuItem, "cutVideoToolStripMenuItem");
            this.cutVideoToolStripMenuItem.Click += new System.EventHandler(this.tsbCutVideo_Click);
            // 
            // pauseCutToolStripMenuItem
            // 
            this.pauseCutToolStripMenuItem.Name = "pauseCutToolStripMenuItem";
            resources.ApplyResources(this.pauseCutToolStripMenuItem, "pauseCutToolStripMenuItem");
            this.pauseCutToolStripMenuItem.Click += new System.EventHandler(this.tsbCutVideo_Click);
            // 
            // stopCutToolStripMenuItem
            // 
            this.stopCutToolStripMenuItem.Name = "stopCutToolStripMenuItem";
            resources.ApplyResources(this.stopCutToolStripMenuItem, "stopCutToolStripMenuItem");
            this.stopCutToolStripMenuItem.Click += new System.EventHandler(this.tsbStopCut_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            resources.ApplyResources(this.toolStripMenuItem12, "toolStripMenuItem12");
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volumeUpToolStripMenuItem,
            this.volumeDownToolStripMenuItem,
            this.muteToolStripMenuItem,
            this.toolStripMenuItem8,
            this.showStoryboardToolStripMenuItem,
            this.showStoryboardAudioWaveformToolStripMenuItem,
            this.storyboardZoomToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // volumeUpToolStripMenuItem
            // 
            this.volumeUpToolStripMenuItem.Name = "volumeUpToolStripMenuItem";
            resources.ApplyResources(this.volumeUpToolStripMenuItem, "volumeUpToolStripMenuItem");
            this.volumeUpToolStripMenuItem.Click += new System.EventHandler(this.volumeUpToolStripMenuItem_Click);
            // 
            // volumeDownToolStripMenuItem
            // 
            this.volumeDownToolStripMenuItem.Name = "volumeDownToolStripMenuItem";
            resources.ApplyResources(this.volumeDownToolStripMenuItem, "volumeDownToolStripMenuItem");
            this.volumeDownToolStripMenuItem.Click += new System.EventHandler(this.volumeDownToolStripMenuItem_Click);
            // 
            // muteToolStripMenuItem
            // 
            this.muteToolStripMenuItem.Name = "muteToolStripMenuItem";
            resources.ApplyResources(this.muteToolStripMenuItem, "muteToolStripMenuItem");
            this.muteToolStripMenuItem.Click += new System.EventHandler(this.muteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
            // 
            // showStoryboardToolStripMenuItem
            // 
            this.showStoryboardToolStripMenuItem.Name = "showStoryboardToolStripMenuItem";
            resources.ApplyResources(this.showStoryboardToolStripMenuItem, "showStoryboardToolStripMenuItem");
            this.showStoryboardToolStripMenuItem.Click += new System.EventHandler(this.showStoryboardToolStripMenuItem_Click);
            // 
            // showStoryboardAudioWaveformToolStripMenuItem
            // 
            this.showStoryboardAudioWaveformToolStripMenuItem.Name = "showStoryboardAudioWaveformToolStripMenuItem";
            resources.ApplyResources(this.showStoryboardAudioWaveformToolStripMenuItem, "showStoryboardAudioWaveformToolStripMenuItem");
            this.showStoryboardAudioWaveformToolStripMenuItem.Click += new System.EventHandler(this.showStoryboardAudioWaveformToolStripMenuItem_Click);
            // 
            // storyboardZoomToolStripMenuItem
            // 
            this.storyboardZoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiM30Secs,
            this.tiM10Secs,
            this.tiM5Secs,
            this.tiM1Sec,
            this.tiM100MSec});
            this.storyboardZoomToolStripMenuItem.Name = "storyboardZoomToolStripMenuItem";
            resources.ApplyResources(this.storyboardZoomToolStripMenuItem, "storyboardZoomToolStripMenuItem");
            // 
            // tiM30Secs
            // 
            this.tiM30Secs.Name = "tiM30Secs";
            resources.ApplyResources(this.tiM30Secs, "tiM30Secs");
            this.tiM30Secs.Click += new System.EventHandler(this.ti30Seconds_Click);
            // 
            // tiM10Secs
            // 
            this.tiM10Secs.Checked = true;
            this.tiM10Secs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tiM10Secs.Name = "tiM10Secs";
            resources.ApplyResources(this.tiM10Secs, "tiM10Secs");
            this.tiM10Secs.Click += new System.EventHandler(this.ti10Seconds_Click);
            // 
            // tiM5Secs
            // 
            this.tiM5Secs.Name = "tiM5Secs";
            resources.ApplyResources(this.tiM5Secs, "tiM5Secs");
            this.tiM5Secs.Click += new System.EventHandler(this.ti5Seconds_Click);
            // 
            // tiM1Sec
            // 
            this.tiM1Sec.Name = "tiM1Sec";
            resources.ApplyResources(this.tiM1Sec, "tiM1Sec");
            this.tiM1Sec.Click += new System.EventHandler(this.tiSecond_Click);
            // 
            // tiM100MSec
            // 
            this.tiM100MSec.Name = "tiM100MSec";
            resources.ApplyResources(this.tiM100MSec, "tiM100MSec");
            this.tiM100MSec.Click += new System.EventHandler(this.ti100Msecs_Click);
            // 
            // navigationToolStripMenuItem
            // 
            this.navigationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.move01SecForwardsToolStripMenuItem,
            this.move01SecBackwardsToolStripMenuItem,
            this.move1SecForwardsToolStripMenuItem,
            this.move1SecBackwardsToolStripMenuItem,
            this.move30SecForwardsToolStripMenuItem,
            this.move30SecBackwardsToolStripMenuItem,
            this.move3MinForwardsToolStripMenuItem,
            this.move3MinBackwardsToolStripMenuItem,
            this.moveToNextKeyFrameToolStripMenuItem,
            this.moveToPreviousKeyFrameToolStripMenuItem,
            this.toolStripMenuItem2,
            this.jumpToMovieEndToolStripMenuItem,
            this.jumpToMovieStartToolStripMenuItem,
            this.toolStripSeparator7,
            this.jumpToCutEndToolStripMenuItem,
            this.jumpToCutStartToolStripMenuItem});
            this.navigationToolStripMenuItem.Name = "navigationToolStripMenuItem";
            resources.ApplyResources(this.navigationToolStripMenuItem, "navigationToolStripMenuItem");
            // 
            // move01SecForwardsToolStripMenuItem
            // 
            this.move01SecForwardsToolStripMenuItem.Name = "move01SecForwardsToolStripMenuItem";
            resources.ApplyResources(this.move01SecForwardsToolStripMenuItem, "move01SecForwardsToolStripMenuItem");
            this.move01SecForwardsToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveForwardMsec_Click);
            // 
            // move01SecBackwardsToolStripMenuItem
            // 
            this.move01SecBackwardsToolStripMenuItem.Name = "move01SecBackwardsToolStripMenuItem";
            resources.ApplyResources(this.move01SecBackwardsToolStripMenuItem, "move01SecBackwardsToolStripMenuItem");
            this.move01SecBackwardsToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveBackMsec_Click);
            // 
            // move1SecForwardsToolStripMenuItem
            // 
            this.move1SecForwardsToolStripMenuItem.Name = "move1SecForwardsToolStripMenuItem";
            resources.ApplyResources(this.move1SecForwardsToolStripMenuItem, "move1SecForwardsToolStripMenuItem");
            this.move1SecForwardsToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveForward1Sec_Click);
            // 
            // move1SecBackwardsToolStripMenuItem
            // 
            this.move1SecBackwardsToolStripMenuItem.Name = "move1SecBackwardsToolStripMenuItem";
            resources.ApplyResources(this.move1SecBackwardsToolStripMenuItem, "move1SecBackwardsToolStripMenuItem");
            this.move1SecBackwardsToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveBack1Sec_Click);
            // 
            // move30SecForwardsToolStripMenuItem
            // 
            this.move30SecForwardsToolStripMenuItem.Name = "move30SecForwardsToolStripMenuItem";
            resources.ApplyResources(this.move30SecForwardsToolStripMenuItem, "move30SecForwardsToolStripMenuItem");
            this.move30SecForwardsToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveForward30Sec_Click);
            // 
            // move30SecBackwardsToolStripMenuItem
            // 
            this.move30SecBackwardsToolStripMenuItem.Name = "move30SecBackwardsToolStripMenuItem";
            resources.ApplyResources(this.move30SecBackwardsToolStripMenuItem, "move30SecBackwardsToolStripMenuItem");
            this.move30SecBackwardsToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveBack30Sec_Click);
            // 
            // move3MinForwardsToolStripMenuItem
            // 
            this.move3MinForwardsToolStripMenuItem.Name = "move3MinForwardsToolStripMenuItem";
            resources.ApplyResources(this.move3MinForwardsToolStripMenuItem, "move3MinForwardsToolStripMenuItem");
            this.move3MinForwardsToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveForward3Min_Click);
            // 
            // move3MinBackwardsToolStripMenuItem
            // 
            this.move3MinBackwardsToolStripMenuItem.Name = "move3MinBackwardsToolStripMenuItem";
            resources.ApplyResources(this.move3MinBackwardsToolStripMenuItem, "move3MinBackwardsToolStripMenuItem");
            this.move3MinBackwardsToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveBack3Min_Click);
            // 
            // moveToNextKeyFrameToolStripMenuItem
            // 
            this.moveToNextKeyFrameToolStripMenuItem.Name = "moveToNextKeyFrameToolStripMenuItem";
            resources.ApplyResources(this.moveToNextKeyFrameToolStripMenuItem, "moveToNextKeyFrameToolStripMenuItem");
            this.moveToNextKeyFrameToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveForwardKFrame_Click);
            // 
            // moveToPreviousKeyFrameToolStripMenuItem
            // 
            this.moveToPreviousKeyFrameToolStripMenuItem.Name = "moveToPreviousKeyFrameToolStripMenuItem";
            resources.ApplyResources(this.moveToPreviousKeyFrameToolStripMenuItem, "moveToPreviousKeyFrameToolStripMenuItem");
            this.moveToPreviousKeyFrameToolStripMenuItem.Click += new System.EventHandler(this.tsbMoveBackKFrame_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // jumpToMovieEndToolStripMenuItem
            // 
            this.jumpToMovieEndToolStripMenuItem.Name = "jumpToMovieEndToolStripMenuItem";
            resources.ApplyResources(this.jumpToMovieEndToolStripMenuItem, "jumpToMovieEndToolStripMenuItem");
            this.jumpToMovieEndToolStripMenuItem.Click += new System.EventHandler(this.jumpToMovieEndToolStripMenuItem_Click);
            // 
            // jumpToMovieStartToolStripMenuItem
            // 
            this.jumpToMovieStartToolStripMenuItem.Name = "jumpToMovieStartToolStripMenuItem";
            resources.ApplyResources(this.jumpToMovieStartToolStripMenuItem, "jumpToMovieStartToolStripMenuItem");
            this.jumpToMovieStartToolStripMenuItem.Click += new System.EventHandler(this.jumpToMovieStartToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // jumpToCutEndToolStripMenuItem
            // 
            this.jumpToCutEndToolStripMenuItem.Name = "jumpToCutEndToolStripMenuItem";
            resources.ApplyResources(this.jumpToCutEndToolStripMenuItem, "jumpToCutEndToolStripMenuItem");
            this.jumpToCutEndToolStripMenuItem.Click += new System.EventHandler(this.jumpToCutEndToolStripMenuItem_Click);
            // 
            // jumpToCutStartToolStripMenuItem
            // 
            this.jumpToCutStartToolStripMenuItem.Name = "jumpToCutStartToolStripMenuItem";
            resources.ApplyResources(this.jumpToCutStartToolStripMenuItem, "jumpToCutStartToolStripMenuItem");
            this.jumpToCutStartToolStripMenuItem.Click += new System.EventHandler(this.jumpToCutStartToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiIncludeMode,
            this.tsiExcludeMode,
            this.tsiSilenceMode,
            this.toolStripSeparator1,
            this.tsiSplitInParts,
            this.tsiSplitBlackDetect});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            resources.ApplyResources(this.modeToolStripMenuItem, "modeToolStripMenuItem");
            // 
            // tsiIncludeMode
            // 
            this.tsiIncludeMode.Checked = true;
            this.tsiIncludeMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsiIncludeMode.Image = global::VideoWallpaperCreator.Properties.Resources.movie_add;
            this.tsiIncludeMode.Name = "tsiIncludeMode";
            resources.ApplyResources(this.tsiIncludeMode, "tsiIncludeMode");
            this.tsiIncludeMode.Click += new System.EventHandler(this.tsiIncludeMode_Click);
            // 
            // tsiExcludeMode
            // 
            this.tsiExcludeMode.Image = global::VideoWallpaperCreator.Properties.Resources.movie_remove;
            this.tsiExcludeMode.Name = "tsiExcludeMode";
            resources.ApplyResources(this.tsiExcludeMode, "tsiExcludeMode");
            this.tsiExcludeMode.Click += new System.EventHandler(this.tsiExcludeMode_Click);
            // 
            // tsiSilenceMode
            // 
            this.tsiSilenceMode.Image = global::VideoWallpaperCreator.Properties.Resources.movie_mute;
            this.tsiSilenceMode.Name = "tsiSilenceMode";
            resources.ApplyResources(this.tsiSilenceMode, "tsiSilenceMode");
            this.tsiSilenceMode.Click += new System.EventHandler(this.tsiSilenceMode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsiSplitInParts
            // 
            this.tsiSplitInParts.Image = global::VideoWallpaperCreator.Properties.Resources.movie_preferences;
            this.tsiSplitInParts.Name = "tsiSplitInParts";
            resources.ApplyResources(this.tsiSplitInParts, "tsiSplitInParts");
            this.tsiSplitInParts.Click += new System.EventHandler(this.tsbSplitParts_Click);
            // 
            // tsiSplitBlackDetect
            // 
            this.tsiSplitBlackDetect.Name = "tsiSplitBlackDetect";
            resources.ApplyResources(this.tsiSplitBlackDetect, "tsiSplitBlackDetect");
            this.tsiSplitBlackDetect.Click += new System.EventHandler(this.tsiSplitBlackDetect_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openOutputFolderToolStripMenuItem,
            this.openCutVideoToolStripMenuItem,
            this.openOriginalVideoToolStripMenuItem,
            this.videoInfoToolStripMenuItem,
            this.toolStripSeparator2,
            this.videoJoinerToolStripMenuItem,
            this.toolStripSeparator8,
            this.fadeInFadeOutToolStripMenuItem,
            this.joinClipsToolStripMenuItem,
            this.toolStripSeparator4,
            this.whenFinishedToolStripMenuItem,
            this.toolStripMenuItem10,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // openOutputFolderToolStripMenuItem
            // 
            this.openOutputFolderToolStripMenuItem.Name = "openOutputFolderToolStripMenuItem";
            resources.ApplyResources(this.openOutputFolderToolStripMenuItem, "openOutputFolderToolStripMenuItem");
            this.openOutputFolderToolStripMenuItem.Click += new System.EventHandler(this.openOutputFolderToolStripMenuItem_Click);
            // 
            // openCutVideoToolStripMenuItem
            // 
            this.openCutVideoToolStripMenuItem.Name = "openCutVideoToolStripMenuItem";
            resources.ApplyResources(this.openCutVideoToolStripMenuItem, "openCutVideoToolStripMenuItem");
            this.openCutVideoToolStripMenuItem.Click += new System.EventHandler(this.openCutVideoToolStripMenuItem_Click);
            // 
            // openOriginalVideoToolStripMenuItem
            // 
            this.openOriginalVideoToolStripMenuItem.Name = "openOriginalVideoToolStripMenuItem";
            resources.ApplyResources(this.openOriginalVideoToolStripMenuItem, "openOriginalVideoToolStripMenuItem");
            this.openOriginalVideoToolStripMenuItem.Click += new System.EventHandler(this.openOriginalVideoToolStripMenuItem_Click);
            // 
            // videoInfoToolStripMenuItem
            // 
            this.videoInfoToolStripMenuItem.Name = "videoInfoToolStripMenuItem";
            resources.ApplyResources(this.videoInfoToolStripMenuItem, "videoInfoToolStripMenuItem");
            this.videoInfoToolStripMenuItem.Click += new System.EventHandler(this.sbtnInfo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // fadeInFadeOutToolStripMenuItem
            // 
            this.fadeInFadeOutToolStripMenuItem.CheckOnClick = true;
            this.fadeInFadeOutToolStripMenuItem.Name = "fadeInFadeOutToolStripMenuItem";
            resources.ApplyResources(this.fadeInFadeOutToolStripMenuItem, "fadeInFadeOutToolStripMenuItem");
            this.fadeInFadeOutToolStripMenuItem.Click += new System.EventHandler(this.fadeInFadeOutToolStripMenuItem_Click);
            // 
            // joinClipsToolStripMenuItem
            // 
            this.joinClipsToolStripMenuItem.CheckOnClick = true;
            this.joinClipsToolStripMenuItem.Name = "joinClipsToolStripMenuItem";
            resources.ApplyResources(this.joinClipsToolStripMenuItem, "joinClipsToolStripMenuItem");
            this.joinClipsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.joinClipsToolStripMenuItem_CheckedChanged);
            this.joinClipsToolStripMenuItem.Click += new System.EventHandler(this.joinClipsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // whenFinishedToolStripMenuItem
            // 
            this.whenFinishedToolStripMenuItem.Name = "whenFinishedToolStripMenuItem";
            resources.ApplyResources(this.whenFinishedToolStripMenuItem, "whenFinishedToolStripMenuItem");
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // videoJoinerToolStripMenuItem
            // 
            this.videoJoinerToolStripMenuItem.Name = "videoJoinerToolStripMenuItem";
            resources.ApplyResources(this.videoJoinerToolStripMenuItem, "videoJoinerToolStripMenuItem");
            this.videoJoinerToolStripMenuItem.Click += new System.EventHandler(this.videoJoinerToolStripMenuItem_Click);
            // 
            // tsiDownload
            // 
            this.tsiDownload.Name = "tsiDownload";
            resources.ApplyResources(this.tsiDownload, "tsiDownload");
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
            // shareToolStripMenuItem
            // 
            this.shareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shareOnFacebookToolStripMenuItem,
            this.shareOnTwitterToolStripMenuItem,
            this.shareOnGooglePlusToolStripMenuItem,
            this.shareOnLinkedinToolStripMenuItem,
            this.shareWithEmailToolStripMenuItem});
            this.shareToolStripMenuItem.Name = "shareToolStripMenuItem";
            resources.ApplyResources(this.shareToolStripMenuItem, "shareToolStripMenuItem");
            // 
            // shareOnFacebookToolStripMenuItem
            // 
            this.shareOnFacebookToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.facebook_24;
            this.shareOnFacebookToolStripMenuItem.Name = "shareOnFacebookToolStripMenuItem";
            resources.ApplyResources(this.shareOnFacebookToolStripMenuItem, "shareOnFacebookToolStripMenuItem");
            this.shareOnFacebookToolStripMenuItem.Click += new System.EventHandler(this.tsiFacebook_Click);
            // 
            // shareOnTwitterToolStripMenuItem
            // 
            this.shareOnTwitterToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.twitter_24;
            this.shareOnTwitterToolStripMenuItem.Name = "shareOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.shareOnTwitterToolStripMenuItem, "shareOnTwitterToolStripMenuItem");
            this.shareOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.tsiTwitter_Click);
            // 
            // shareOnGooglePlusToolStripMenuItem
            // 
            this.shareOnGooglePlusToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.googleplus_24;
            this.shareOnGooglePlusToolStripMenuItem.Name = "shareOnGooglePlusToolStripMenuItem";
            resources.ApplyResources(this.shareOnGooglePlusToolStripMenuItem, "shareOnGooglePlusToolStripMenuItem");
            this.shareOnGooglePlusToolStripMenuItem.Click += new System.EventHandler(this.tsiGooglePlus_Click);
            // 
            // shareOnLinkedinToolStripMenuItem
            // 
            this.shareOnLinkedinToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.linkedin_24;
            this.shareOnLinkedinToolStripMenuItem.Name = "shareOnLinkedinToolStripMenuItem";
            resources.ApplyResources(this.shareOnLinkedinToolStripMenuItem, "shareOnLinkedinToolStripMenuItem");
            this.shareOnLinkedinToolStripMenuItem.Click += new System.EventHandler(this.tsiLinkedIn_Click);
            // 
            // shareWithEmailToolStripMenuItem
            // 
            this.shareWithEmailToolStripMenuItem.Image = global::VideoWallpaperCreator.Properties.Resources.mail;
            this.shareWithEmailToolStripMenuItem.Name = "shareWithEmailToolStripMenuItem";
            resources.ApplyResources(this.shareWithEmailToolStripMenuItem, "shareWithEmailToolStripMenuItem");
            this.shareWithEmailToolStripMenuItem.Click += new System.EventHandler(this.tsiEmail_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpUsersManualToolStripMenuItem,
            this.toolStripMenuItem4,
            this.pleaseDonateToolStripMenuItem,
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem,
            this.followUsOnTwitterToolStripMenuItem,
            this.visit4dotsSoftwareWebpageToolStripMenuItem,
            this.toolStripMenuItem9,
            this.feedbackToolStripMenuItem,
            this.checkForNewVersionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
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
            // pleaseDonateToolStripMenuItem
            // 
            resources.ApplyResources(this.pleaseDonateToolStripMenuItem, "pleaseDonateToolStripMenuItem");
            this.pleaseDonateToolStripMenuItem.ForeColor = System.Drawing.Color.ForestGreen;
            this.pleaseDonateToolStripMenuItem.Name = "pleaseDonateToolStripMenuItem";
            this.pleaseDonateToolStripMenuItem.Click += new System.EventHandler(this.pleaseDonateToolStripMenuItem_Click);
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
            // ts30sec
            // 
            resources.ApplyResources(this.ts30sec, "ts30sec");
            this.ts30sec.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMoveBack30Sec,
            this.tsbMoveForward30Sec});
            this.ts30sec.Name = "ts30sec";
            // 
            // tsbMoveBack30Sec
            // 
            resources.ApplyResources(this.tsbMoveBack30Sec, "tsbMoveBack30Sec");
            this.tsbMoveBack30Sec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveBack30Sec.Image = global::VideoWallpaperCreator.Properties.Resources.navigate_left_green;
            this.tsbMoveBack30Sec.Name = "tsbMoveBack30Sec";
            this.tsbMoveBack30Sec.Click += new System.EventHandler(this.tsbMoveBack30Sec_Click);
            // 
            // tsbMoveForward30Sec
            // 
            resources.ApplyResources(this.tsbMoveForward30Sec, "tsbMoveForward30Sec");
            this.tsbMoveForward30Sec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveForward30Sec.Image = global::VideoWallpaperCreator.Properties.Resources.navigate_right_green;
            this.tsbMoveForward30Sec.Name = "tsbMoveForward30Sec";
            this.tsbMoveForward30Sec.Click += new System.EventHandler(this.tsbMoveForward30Sec_Click);
            // 
            // ts01sec
            // 
            resources.ApplyResources(this.ts01sec, "ts01sec");
            this.ts01sec.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMoveBackMsec,
            this.tsbMoveForwardMsec});
            this.ts01sec.Name = "ts01sec";
            // 
            // tsbMoveBackMsec
            // 
            resources.ApplyResources(this.tsbMoveBackMsec, "tsbMoveBackMsec");
            this.tsbMoveBackMsec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveBackMsec.Image = global::VideoWallpaperCreator.Properties.Resources.navigate_left_green;
            this.tsbMoveBackMsec.Name = "tsbMoveBackMsec";
            this.tsbMoveBackMsec.Click += new System.EventHandler(this.tsbMoveBackMsec_Click);
            // 
            // tsbMoveForwardMsec
            // 
            resources.ApplyResources(this.tsbMoveForwardMsec, "tsbMoveForwardMsec");
            this.tsbMoveForwardMsec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveForwardMsec.Image = global::VideoWallpaperCreator.Properties.Resources.navigate_right_green;
            this.tsbMoveForwardMsec.Name = "tsbMoveForwardMsec";
            this.tsbMoveForwardMsec.Click += new System.EventHandler(this.tsbMoveForwardMsec_Click);
            // 
            // lbl1sec
            // 
            resources.ApplyResources(this.lbl1sec, "lbl1sec");
            this.lbl1sec.BackColor = System.Drawing.Color.Transparent;
            this.lbl1sec.ForeColor = System.Drawing.Color.DimGray;
            this.lbl1sec.Name = "lbl1sec";
            // 
            // picMovie
            // 
            resources.ApplyResources(this.picMovie, "picMovie");
            this.picMovie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.picMovie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMovie.Name = "picMovie";
            this.picMovie.TabStop = false;
            this.picMovie.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmClip_DragDrop);
            this.picMovie.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmClip_DragEnter);
            this.picMovie.DragOver += new System.Windows.Forms.DragEventHandler(this.frmClip_DragOver);
            this.picMovie.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picMovie_MouseMove);
            // 
            // ts1sec
            // 
            resources.ApplyResources(this.ts1sec, "ts1sec");
            this.ts1sec.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMoveBack1Sec,
            this.tsbMoveForward1Sec});
            this.ts1sec.Name = "ts1sec";
            // 
            // tsbMoveBack1Sec
            // 
            resources.ApplyResources(this.tsbMoveBack1Sec, "tsbMoveBack1Sec");
            this.tsbMoveBack1Sec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveBack1Sec.Image = global::VideoWallpaperCreator.Properties.Resources.navigate_left2;
            this.tsbMoveBack1Sec.Name = "tsbMoveBack1Sec";
            this.tsbMoveBack1Sec.Click += new System.EventHandler(this.tsbMoveBack1Sec_Click);
            // 
            // tsbMoveForward1Sec
            // 
            resources.ApplyResources(this.tsbMoveForward1Sec, "tsbMoveForward1Sec");
            this.tsbMoveForward1Sec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveForward1Sec.Image = global::VideoWallpaperCreator.Properties.Resources.navigate_right1;
            this.tsbMoveForward1Sec.Name = "tsbMoveForward1Sec";
            this.tsbMoveForward1Sec.Click += new System.EventHandler(this.tsbMoveForward1Sec_Click);
            // 
            // plMedia
            // 
            resources.ApplyResources(this.plMedia, "plMedia");
            this.plMedia.BackColor = System.Drawing.Color.DimGray;
            this.plMedia.Controls.Add(this.mskTotalDuration);
            this.plMedia.Controls.Add(this.mskDuration);
            this.plMedia.Controls.Add(this.label5);
            this.plMedia.Controls.Add(this.mskCutEnd);
            this.plMedia.Controls.Add(this.label4);
            this.plMedia.Controls.Add(this.mskCutStart);
            this.plMedia.Controls.Add(this.label3);
            this.plMedia.Controls.Add(this.label2);
            this.plMedia.Controls.Add(this.label1);
            this.plMedia.Controls.Add(this.lblScrollPos);
            this.plMedia.Controls.Add(this.chkShowStoryboardAudioWaveform);
            this.plMedia.Controls.Add(this.mskPos);
            this.plMedia.Controls.Add(this.msVolume);
            this.plMedia.Controls.Add(this.btnMute);
            this.plMedia.Controls.Add(this.chkShowStoryboard);
            this.plMedia.Controls.Add(this.btnZoomOut);
            this.plMedia.Controls.Add(this.btnZoomIn);
            this.plMedia.Name = "plMedia";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.LightGray;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Name = "label1";
            // 
            // lblScrollPos
            // 
            resources.ApplyResources(this.lblScrollPos, "lblScrollPos");
            this.lblScrollPos.BackColor = System.Drawing.Color.LightGray;
            this.lblScrollPos.ForeColor = System.Drawing.Color.DimGray;
            this.lblScrollPos.Name = "lblScrollPos";
            // 
            // lbl01sec
            // 
            resources.ApplyResources(this.lbl01sec, "lbl01sec");
            this.lbl01sec.BackColor = System.Drawing.Color.Transparent;
            this.lbl01sec.ForeColor = System.Drawing.Color.DimGray;
            this.lbl01sec.Name = "lbl01sec";
            // 
            // cmbOutputFormat
            // 
            resources.ApplyResources(this.cmbOutputFormat, "cmbOutputFormat");
            this.cmbOutputFormat.BackColor = System.Drawing.SystemColors.Control;
            this.cmbOutputFormat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbOutputFormat.DropDownBackColor = System.Drawing.SystemColors.Control;
            this.cmbOutputFormat.DropDownBorderColor = System.Drawing.Color.Black;
            this.cmbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputFormat.FormattingEnabled = true;
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cmbOutputFormat_SelectedIndexChanged);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "cselect";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.NullValue = false;
            this.dataGridViewCheckBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCheckBoxColumn1.Frozen = true;
            resources.ApplyResources(this.dataGridViewCheckBoxColumn1, "dataGridViewCheckBoxColumn1");
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "cname";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "clength";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "cformat";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "caudioformat";
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "caudiosamplingrate";
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "cwidth";
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "cheight";
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "cvideofps";
            resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "cvideobitrate";
            resources.ApplyResources(this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "cvideocolordepth";
            resources.ApplyResources(this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "cvideoaspect";
            resources.ApplyResources(this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "caudiobitrate";
            resources.ApplyResources(this.dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "caudionch";
            resources.ApplyResources(this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "csize";
            resources.ApplyResources(this.dataGridViewTextBoxColumn14, "dataGridViewTextBoxColumn14");
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "cprofile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn15, "dataGridViewTextBoxColumn15");
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "cinputfile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn16, "dataGridViewTextBoxColumn16");
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "coutputfile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn17, "dataGridViewTextBoxColumn17");
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "ccreationdate";
            resources.ApplyResources(this.dataGridViewTextBoxColumn18, "dataGridViewTextBoxColumn18");
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "clastmodified";
            resources.ApplyResources(this.dataGridViewTextBoxColumn19, "dataGridViewTextBoxColumn19");
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "clengthsecs";
            resources.ApplyResources(this.dataGridViewTextBoxColumn20, "dataGridViewTextBoxColumn20");
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // picScreenshot
            // 
            resources.ApplyResources(this.picScreenshot, "picScreenshot");
            this.picScreenshot.BackColor = System.Drawing.Color.Black;
            this.picScreenshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picScreenshot.Name = "picScreenshot";
            this.picScreenshot.TabStop = false;
            // 
            // vthPreview
            // 
            resources.ApplyResources(this.vthPreview, "vthPreview");
            this.vthPreview.Name = "vthPreview";
            this.vthPreview.VisibleChanged += new System.EventHandler(this.vthPreview_VisibleChanged);
            // 
            // HScrollbar
            // 
            resources.ApplyResources(this.HScrollbar, "HScrollbar");
            this.HScrollbar.Name = "HScrollbar";
            this.HScrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollbar_Scroll);
            // 
            // picMain
            // 
            resources.ApplyResources(this.picMain, "picMain");
            this.picMain.BackColor = System.Drawing.Color.LightGray;
            this.picMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMain.Name = "picMain";
            this.picMain.StoryboardTimeFrameLengthMsecs = 5000;
            this.picMain.TabStop = false;
            this.picMain.TimeSpan = System.TimeSpan.Parse("00:00:00");
            this.picMain.MouseLeave += new System.EventHandler(this.picMain_MouseLeave);
            // 
            // lblKFrames
            // 
            resources.ApplyResources(this.lblKFrames, "lblKFrames");
            this.lblKFrames.BackColor = System.Drawing.Color.Transparent;
            this.lblKFrames.ForeColor = System.Drawing.Color.DimGray;
            this.lblKFrames.Name = "lblKFrames";
            // 
            // tsKeyFrame
            // 
            resources.ApplyResources(this.tsKeyFrame, "tsKeyFrame");
            this.tsKeyFrame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMoveBackKFrame,
            this.tsbMoveForwardKFrame});
            this.tsKeyFrame.Name = "tsKeyFrame";
            // 
            // tsbMoveBackKFrame
            // 
            resources.ApplyResources(this.tsbMoveBackKFrame, "tsbMoveBackKFrame");
            this.tsbMoveBackKFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveBackKFrame.Image = global::VideoWallpaperCreator.Properties.Resources.navigate_left_green;
            this.tsbMoveBackKFrame.Name = "tsbMoveBackKFrame";
            this.tsbMoveBackKFrame.Click += new System.EventHandler(this.tsbMoveBackKFrame_Click);
            // 
            // tsbMoveForwardKFrame
            // 
            resources.ApplyResources(this.tsbMoveForwardKFrame, "tsbMoveForwardKFrame");
            this.tsbMoveForwardKFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveForwardKFrame.Image = global::VideoWallpaperCreator.Properties.Resources.navigate_right_green;
            this.tsbMoveForwardKFrame.Name = "tsbMoveForwardKFrame";
            this.tsbMoveForwardKFrame.Click += new System.EventHandler(this.tsbMoveForwardKFrame_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // frmClip
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblKFrames);
            this.Controls.Add(this.tsKeyFrame);
            this.Controls.Add(this.vthPreview);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.HScrollbar);
            this.Controls.Add(this.picScreenshot);
            this.Controls.Add(this.cmbOutputFormat);
            this.Controls.Add(this.lblOutputFormat);
            this.Controls.Add(this.lbl3min);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ts3min);
            this.Controls.Add(this.fplSegments);
            this.Controls.Add(this.lbl30sec);
            this.Controls.Add(this.lbl1sec);
            this.Controls.Add(this.picMovie);
            this.Controls.Add(this.plMedia);
            this.Controls.Add(this.lbl01sec);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tsCut);
            this.Controls.Add(this.ts30sec);
            this.Controls.Add(this.ts01sec);
            this.Controls.Add(this.ts1sec);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmClip";
            this.ShowInTaskbar = true;
            
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClip_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClip_FormClosed);
            this.Load += new System.EventHandler(this.frmClip_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmClip_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmClip_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.frmClip_DragOver);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmClip_MouseMove);
            this.Resize += new System.EventHandler(this.frmClip_Resize);
            this.cmsZoom.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ts3min.ResumeLayout(false);
            this.ts3min.PerformLayout();
            this.tsCut.ResumeLayout(false);
            this.tsCut.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ts30sec.ResumeLayout(false);
            this.ts30sec.PerformLayout();
            this.ts01sec.ResumeLayout(false);
            this.ts01sec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMovie)).EndInit();
            this.ts1sec.ResumeLayout(false);
            this.ts1sec.PerformLayout();
            this.plMedia.ResumeLayout(false);
            this.plMedia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScreenshot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.tsKeyFrame.ResumeLayout(false);
            this.tsKeyFrame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timPlayerPosition;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpUsersManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visit4dotsSoftwareWebpageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followUsOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.FlowLayoutPanel fplSegments;
        private System.Windows.Forms.PictureBox picMovie;
        private System.Windows.Forms.Panel plMedia;
        private MediaSlider.MediaSlider msVolume;
        private GlowButton.GlowButton btnMute;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStrip tsCut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbCutPlayPreview;
        private System.Windows.Forms.ToolStripButton tsbCutAdd;
        private System.Windows.Forms.ToolStripButton tsbCutRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timPlayPositionJ;
        private System.Windows.Forms.ToolStripMenuItem tsiDownload;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiThreadPriority;
        private System.Windows.Forms.ToolStripMenuItem highToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboveNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem belowNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idleToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripButton tsbCutVideo;
        private System.Windows.Forms.ToolStripButton tsbSetStart;
        private System.Windows.Forms.ToolStripButton tsbSetEnd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblVideoFile;
        private System.Windows.Forms.ToolStrip ts01sec;
        private System.Windows.Forms.ToolStripButton tsbMoveBackMsec;
        private System.Windows.Forms.ToolStripButton tsbMoveForwardMsec;
        private System.Windows.Forms.Label lbl3min;
        private System.Windows.Forms.ToolStrip ts3min;
        private System.Windows.Forms.ToolStripButton tsbMoveBack3Min;
        private System.Windows.Forms.ToolStripButton tsbMoveForward3Min;
        private System.Windows.Forms.Label lbl30sec;
        private System.Windows.Forms.ToolStrip ts30sec;
        private System.Windows.Forms.ToolStripButton tsbMoveBack30Sec;
        private System.Windows.Forms.ToolStripButton tsbMoveForward30Sec;
        private System.Windows.Forms.Label lbl1sec;
        private System.Windows.Forms.ToolStrip ts1sec;
        private System.Windows.Forms.ToolStripButton tsbMoveBack1Sec;
        private System.Windows.Forms.ToolStripButton tsbMoveForward1Sec;
        private System.Windows.Forms.Label lbl01sec;
        private System.Windows.Forms.Label lblOutputFormat;
        private System.Windows.Forms.ToolStripStatusLabel lblElapsedTime;
        public System.ComponentModel.BackgroundWorker bwConvert;
        private System.Windows.Forms.Timer timDebug;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.ContextMenuStrip cmsZoom;
        private System.Windows.Forms.ToolStripMenuItem ti5Seconds;
        private System.Windows.Forms.ToolStripMenuItem tiSecond;
        private System.Windows.Forms.ToolStripMenuItem ti100Msecs;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.ToolStripMenuItem ti10Seconds;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.ToolStripMenuItem ti30Seconds;
        private System.Windows.Forms.ToolStripMenuItem navigationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem move01SecForwardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem move01SecBackwardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem move1SecForwardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem move1SecBackwardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem move30SecForwardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem move30SecBackwardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem move3MinForwardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem move3MinBackwardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem jumpToMovieEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jumpToMovieStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem playPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem cutVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setClipEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setClipStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem stopCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeClipToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volumeUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volumeDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem storyboardZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiM30Secs;
        private System.Windows.Forms.ToolStripMenuItem tiM10Secs;
        private System.Windows.Forms.ToolStripMenuItem tiM5Secs;
        private System.Windows.Forms.ToolStripMenuItem tiM1Sec;
        private System.Windows.Forms.ToolStripMenuItem tiM100MSec;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOutputFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOriginalVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCutVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsbShare;
        private System.Windows.Forms.ToolStripMenuItem tsiFacebook;
        private System.Windows.Forms.ToolStripMenuItem tsiTwitter;
        private System.Windows.Forms.ToolStripMenuItem tsiGooglePlus;
        private System.Windows.Forms.ToolStripMenuItem tsiLinkedIn;
        private System.Windows.Forms.ToolStripMenuItem tsiEmail;
        public System.Windows.Forms.ToolStripSplitButton tsbCutOpenVideo;
        private System.Windows.Forms.ToolStripMenuItem shareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnFacebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnGooglePlusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnLinkedinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareWithEmailToolStripMenuItem;
        public OwnerDrawnComboBox cmbOutputFormat;
        private System.Windows.Forms.CheckBox chkShowStoryboard;
        private System.Windows.Forms.ToolStripMenuItem showStoryboardToolStripMenuItem;
        public TimeUpDownControl mskPos;
        private System.Windows.Forms.ToolStripButton tsbPlay;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.ToolStripButton tsbStopPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        public System.Windows.Forms.Timer timCut;
        
        public System.Windows.Forms.ToolStripMenuItem languages1ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem languages2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiIncludeMode;
        private System.Windows.Forms.ToolStripMenuItem tsiExcludeMode;
        private System.Windows.Forms.ToolStripMenuItem tsiSilenceMode;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsiSplitInParts;
        private System.Windows.Forms.ToolStripMenuItem tsiSplitBlackDetect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fadeInFadeOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joinClipsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem pleaseDonateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwarePRODUCTCATALOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem selectNextCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectPreviousCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        public System.Windows.Forms.Label lblScrollPos;
        private System.Windows.Forms.PictureBox picScreenshot;
        private System.Windows.Forms.ToolStripMenuItem saveFrameAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.HScrollBar HScrollbar;
        public VideoThumbnailControl vthPreview;
        public PicStoryboardWave picMain;
        private System.Windows.Forms.ToolStripMenuItem showStoryboardAudioWaveformToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkShowStoryboardAudioWaveform;
        private System.Windows.Forms.Label label1;
        public TimeUpDownControl mskCutEnd;
        private System.Windows.Forms.Label label4;
        public TimeUpDownControl mskCutStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        public TimeUpDownControl mskTotalDuration;
        public TimeUpDownControl mskDuration;
        private System.Windows.Forms.ToolStripStatusLabel lblMovieLength;
        private System.Windows.Forms.ToolStripStatusLabel lblMovieLengthValue;
        private System.Windows.Forms.Label lblKFrames;
        private System.Windows.Forms.ToolStrip tsKeyFrame;
        private System.Windows.Forms.ToolStripButton tsbMoveBackKFrame;
        private System.Windows.Forms.ToolStripButton tsbMoveForwardKFrame;
        private System.Windows.Forms.ToolStripMenuItem moveToNextKeyFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToPreviousKeyFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton sbtnInfo;
        private System.Windows.Forms.ToolStripMenuItem videoInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoJoinerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem jumpToCutEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jumpToCutStartToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem whenFinishedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        
        
        
    }
}
