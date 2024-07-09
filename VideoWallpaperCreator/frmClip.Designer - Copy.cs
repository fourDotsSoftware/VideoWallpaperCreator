namespace VideoCutterJoinerExpert
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnOpenOutputFolder = new System.Windows.Forms.Button();
            this.btnBrowseOutputFolder = new System.Windows.Forms.Button();
            this.msVolume = new MediaSlider.MediaSlider();
            this.btnMute = new GlowButton.GlowButton();
            this.btnStop = new GlowButton.GlowButton();
            this.btnPlay = new GlowButton.GlowButton();
            this.btnFastForward = new GlowButton.GlowButton();
            this.btnRewind = new GlowButton.GlowButton();
            this.msVolumeJ = new MediaSlider.MediaSlider();
            this.btnMuteJ = new GlowButton.GlowButton();
            this.btnStopJ = new GlowButton.GlowButton();
            this.btnPlayJ = new GlowButton.GlowButton();
            this.btnFastForwardJ = new GlowButton.GlowButton();
            this.btnRewindJ = new GlowButton.GlowButton();
            this.timPlayerPosition = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timPlayPositionJ = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timCut = new System.Windows.Forms.Timer(this.components);
            this.bwConvert = new System.ComponentModel.BackgroundWorker();
            this.timDebug = new System.Windows.Forms.Timer(this.components);
            this.cmsZoom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ti10Seconds = new System.Windows.Forms.ToolStripMenuItem();
            this.ti5Seconds = new System.Windows.Forms.ToolStripMenuItem();
            this.tiSecond = new System.Windows.Forms.ToolStripMenuItem();
            this.ti100Msecs = new System.Windows.Forms.ToolStripMenuItem();
            this.ti10Msecs = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblVideoFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbarCut = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tsCut = new System.Windows.Forms.ToolStrip();
            this.tsbCutOpenVideo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCutAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbCutRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCutPlayPreview = new System.Windows.Forms.ToolStripButton();
            this.tsbSetStart = new System.Windows.Forms.ToolStripButton();
            this.tsbSetEnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbIncludeMode = new System.Windows.Forms.ToolStripButton();
            this.tsbExcludeMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCutVideo = new System.Windows.Forms.ToolStripButton();
            this.tsbStopCut = new System.Windows.Forms.ToolStripButton();
            this.fplSegments = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbOutputFormat = new VideoCutterJoinerExpert.OwnerDrawnComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbOutputFolder = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkJoinParts = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.tsbMoveBack3Min = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveForward3Min = new System.Windows.Forms.ToolStripButton();
            this.lblTotalDuration = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.tsbMoveBack30Sec = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveForward30Sec = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbMoveBack1Sec = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveForward1Sec = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbMoveBackMsec = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveForwardMsec = new System.Windows.Forms.ToolStripButton();
            this.plMedia = new System.Windows.Forms.Panel();
            this.mskPos = new System.Windows.Forms.MaskedTextBox();
            this.msPosition = new MediaSlider.MediaSlider();
            this.lblTime = new System.Windows.Forms.Label();
            this.picMovie = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtJoinTotalDuration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbJoinAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbJoinAddFolder = new System.Windows.Forms.ToolStripButton();
            this.tsbJoinRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbJoinPlayPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbJoinVideos = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.plMediaJ = new System.Windows.Forms.Panel();
            this.msPositionJ = new MediaSlider.MediaSlider();
            this.lblTimeJ = new System.Windows.Forms.Label();
            this.picJoin = new System.Windows.Forms.PictureBox();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAudioFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSamplingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVideoFPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVideoBitrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorDepth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVideoAspect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBitrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChannels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInputFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutputFIle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLengthSecs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiThreadPriority = new System.Windows.Forms.ToolStripMenuItem();
            this.realTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboveNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.belowNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whenFinishedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpUsersManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebpageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cmsZoom.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tsCut.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.plMedia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMovie)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.plMediaJ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Image = global::VideoCutterJoinerExpert.Properties.Resources.zoom_out;
            this.btnZoomOut.Location = new System.Drawing.Point(924, 397);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(32, 32);
            this.btnZoomOut.TabIndex = 126;
            this.toolTip1.SetToolTip(this.btnZoomOut, "Zoom Out Story Board");
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Image = global::VideoCutterJoinerExpert.Properties.Resources.zoom_in;
            this.btnZoomIn.Location = new System.Drawing.Point(962, 397);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(32, 32);
            this.btnZoomIn.TabIndex = 125;
            this.toolTip1.SetToolTip(this.btnZoomIn, "Zoom In Story Board");
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnOpenOutputFolder
            // 
            this.btnOpenOutputFolder.Image = global::VideoCutterJoinerExpert.Properties.Resources.folder;
            this.btnOpenOutputFolder.Location = new System.Drawing.Point(371, 12);
            this.btnOpenOutputFolder.Name = "btnOpenOutputFolder";
            this.btnOpenOutputFolder.Size = new System.Drawing.Size(40, 23);
            this.btnOpenOutputFolder.TabIndex = 121;
            this.toolTip1.SetToolTip(this.btnOpenOutputFolder, "Open Output Folder");
            this.btnOpenOutputFolder.UseVisualStyleBackColor = true;
            this.btnOpenOutputFolder.Click += new System.EventHandler(this.btnOpenOutputFolder_Click);
            // 
            // btnBrowseOutputFolder
            // 
            this.btnBrowseOutputFolder.Location = new System.Drawing.Point(328, 12);
            this.btnBrowseOutputFolder.Name = "btnBrowseOutputFolder";
            this.btnBrowseOutputFolder.Size = new System.Drawing.Size(40, 23);
            this.btnBrowseOutputFolder.TabIndex = 120;
            this.btnBrowseOutputFolder.Text = "...";
            this.toolTip1.SetToolTip(this.btnBrowseOutputFolder, "Browse Output Folder");
            this.btnBrowseOutputFolder.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFolder.Click += new System.EventHandler(this.btnBrowseOutputFolder_Click);
            // 
            // msVolume
            // 
            this.msVolume.Animated = false;
            this.msVolume.AnimationSize = 0.2F;
            this.msVolume.AnimationSpeed = MediaSlider.MediaSlider.AnimateSpeed.Normal;
            this.msVolume.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.msVolume.AutoScrollMinSize = new System.Drawing.Size(0, 0);
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
            this.msVolume.Location = new System.Drawing.Point(220, 46);
            this.msVolume.Margin = new System.Windows.Forms.Padding(0);
            this.msVolume.Maximum = 255;
            this.msVolume.Minimum = 0;
            this.msVolume.Name = "msVolume";
            this.msVolume.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.msVolume.RangeEndPixels = 1;
            this.msVolume.RangeStartPixels = 0;
            this.msVolume.ShowButtonOnHover = false;
            this.msVolume.Size = new System.Drawing.Size(75, 24);
            this.msVolume.SliderFlyOut = MediaSlider.MediaSlider.FlyOutStyle.None;
            this.msVolume.SmallChange = 1;
            this.msVolume.SmoothScrolling = true;
            this.msVolume.TabIndex = 74;
            this.msVolume.TickColor = System.Drawing.Color.DarkGray;
            this.msVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.msVolume.TickType = MediaSlider.MediaSlider.TickMode.Standard;
            this.toolTip1.SetToolTip(this.msVolume, "Volume");
            this.msVolume.TrackBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msVolume.TrackDepth = 4;
            this.msVolume.TrackFillColor = System.Drawing.Color.Transparent;
            this.msVolume.TrackProgressColor = System.Drawing.Color.LightSkyBlue;
            this.msVolume.TrackShadow = true;
            this.msVolume.TrackShadowColor = System.Drawing.Color.DarkGray;
            this.msVolume.TrackStyle = MediaSlider.MediaSlider.TrackType.Progress;
            this.msVolume.Value = 127;
            this.msVolume.ValueChanged += new MediaSlider.MediaSlider.ValueChangedDelegate(this.msVolume_ValueChanged);
            // 
            // btnMute
            // 
            this.btnMute.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.btnMute.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.btnMute.AutoSize = true;
            this.btnMute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnMute.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMute.BackgroundImage")));
            this.btnMute.Checked = false;
            this.btnMute.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnMute.CheckStyle = GlowButton.GlowButton.CheckedStyle.ColorChange;
            this.btnMute.ContextMenuStrip = null;
            this.btnMute.FocusedMask = false;
            this.btnMute.FocusOnHover = false;
            this.btnMute.Image = global::VideoCutterJoinerExpert.Properties.Resources.mute;
            this.btnMute.ImageCheckedColor = System.Drawing.Color.Firebrick;
            this.btnMute.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnMute.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnMute.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnMute.ImageGlowFactor = 2;
            this.btnMute.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnMute.ImageMirror = true;
            this.btnMute.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnMute.Location = new System.Drawing.Point(200, 45);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(20, 31);
            this.btnMute.TabIndex = 81;
            this.btnMute.Tag = "Mute";
            this.toolTip1.SetToolTip(this.btnMute, "Mute");
            this.btnMute.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMute_MouseClick);
            // 
            // btnStop
            // 
            this.btnStop.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.btnStop.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.btnStop.AutoSize = true;
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.Checked = false;
            this.btnStop.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnStop.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnStop.ContextMenuStrip = null;
            this.btnStop.Enabled = false;
            this.btnStop.FocusedMask = false;
            this.btnStop.FocusOnHover = false;
            this.btnStop.Image = global::VideoCutterJoinerExpert.Properties.Resources.stop;
            this.btnStop.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnStop.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnStop.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnStop.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnStop.ImageGlowFactor = 2;
            this.btnStop.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnStop.ImageMirror = true;
            this.btnStop.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnStop.Location = new System.Drawing.Point(101, 49);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(18, 27);
            this.btnStop.TabIndex = 80;
            this.btnStop.Tag = "Stop";
            this.toolTip1.SetToolTip(this.btnStop, "Stop");
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click_1);
            // 
            // btnPlay
            // 
            this.btnPlay.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.btnPlay.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.btnPlay.AutoSize = true;
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlay.BackgroundImage")));
            this.btnPlay.Checked = false;
            this.btnPlay.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnPlay.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnPlay.ContextMenuStrip = null;
            this.btnPlay.Enabled = false;
            this.btnPlay.FocusedMask = false;
            this.btnPlay.FocusOnHover = false;
            this.btnPlay.Image = global::VideoCutterJoinerExpert.Properties.Resources.play;
            this.btnPlay.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnPlay.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnPlay.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnPlay.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnPlay.ImageGlowFactor = 2;
            this.btnPlay.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnPlay.ImageMirror = true;
            this.btnPlay.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnPlay.Location = new System.Drawing.Point(42, 46);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(20, 31);
            this.btnPlay.TabIndex = 79;
            this.btnPlay.Tag = "Play/Pause";
            this.toolTip1.SetToolTip(this.btnPlay, "Play / Pause");
            this.btnPlay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPlay_MouseClick);
            // 
            // btnFastForward
            // 
            this.btnFastForward.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.btnFastForward.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.btnFastForward.AutoSize = true;
            this.btnFastForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnFastForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFastForward.BackgroundImage")));
            this.btnFastForward.Checked = false;
            this.btnFastForward.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnFastForward.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnFastForward.ContextMenuStrip = null;
            this.btnFastForward.Enabled = false;
            this.btnFastForward.FocusedMask = false;
            this.btnFastForward.FocusOnHover = false;
            this.btnFastForward.Image = global::VideoCutterJoinerExpert.Properties.Resources.ff;
            this.btnFastForward.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnFastForward.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnFastForward.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnFastForward.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnFastForward.ImageGlowFactor = 2;
            this.btnFastForward.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnFastForward.ImageMirror = true;
            this.btnFastForward.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnFastForward.Location = new System.Drawing.Point(70, 47);
            this.btnFastForward.Name = "btnFastForward";
            this.btnFastForward.Size = new System.Drawing.Size(19, 29);
            this.btnFastForward.TabIndex = 77;
            this.btnFastForward.Tag = "Fast Forward";
            this.toolTip1.SetToolTip(this.btnFastForward, "Fast Forward");
            this.btnFastForward.Click += new System.EventHandler(this.btnFastForward_Click);
            // 
            // btnRewind
            // 
            this.btnRewind.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.btnRewind.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.btnRewind.AutoSize = true;
            this.btnRewind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnRewind.Checked = false;
            this.btnRewind.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnRewind.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnRewind.ContextMenuStrip = null;
            this.btnRewind.Enabled = false;
            this.btnRewind.FocusedMask = false;
            this.btnRewind.FocusOnHover = false;
            this.btnRewind.Image = global::VideoCutterJoinerExpert.Properties.Resources.fr;
            this.btnRewind.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnRewind.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnRewind.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnRewind.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnRewind.ImageGlowFactor = 2;
            this.btnRewind.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnRewind.ImageMirror = true;
            this.btnRewind.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnRewind.Location = new System.Drawing.Point(15, 47);
            this.btnRewind.Name = "btnRewind";
            this.btnRewind.Size = new System.Drawing.Size(19, 29);
            this.btnRewind.TabIndex = 76;
            this.btnRewind.Tag = "Reverse";
            this.toolTip1.SetToolTip(this.btnRewind, "Reverse");
            this.btnRewind.Click += new System.EventHandler(this.btnRewind_Click);
            // 
            // msVolumeJ
            // 
            this.msVolumeJ.Animated = false;
            this.msVolumeJ.AnimationSize = 0.2F;
            this.msVolumeJ.AnimationSpeed = MediaSlider.MediaSlider.AnimateSpeed.Normal;
            this.msVolumeJ.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.msVolumeJ.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.msVolumeJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msVolumeJ.BackGroundImage = null;
            this.msVolumeJ.ButtonAccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.msVolumeJ.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.msVolumeJ.ButtonColor = System.Drawing.Color.Black;
            this.msVolumeJ.ButtonCornerRadius = ((uint)(4u));
            this.msVolumeJ.ButtonSize = new System.Drawing.Size(12, 12);
            this.msVolumeJ.ButtonStyle = MediaSlider.MediaSlider.ButtonType.Round;
            this.msVolumeJ.ContextMenuStrip = null;
            this.msVolumeJ.IsForRangeSelect = false;
            this.msVolumeJ.IsForShowMeter = false;
            this.msVolumeJ.IsForShowSegment = false;
            this.msVolumeJ.LargeChange = 2;
            this.msVolumeJ.Location = new System.Drawing.Point(162, 43);
            this.msVolumeJ.Margin = new System.Windows.Forms.Padding(0);
            this.msVolumeJ.Maximum = 255;
            this.msVolumeJ.Minimum = 0;
            this.msVolumeJ.Name = "msVolumeJ";
            this.msVolumeJ.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.msVolumeJ.RangeEndPixels = 1;
            this.msVolumeJ.RangeStartPixels = 0;
            this.msVolumeJ.ShowButtonOnHover = false;
            this.msVolumeJ.Size = new System.Drawing.Size(75, 24);
            this.msVolumeJ.SliderFlyOut = MediaSlider.MediaSlider.FlyOutStyle.None;
            this.msVolumeJ.SmallChange = 1;
            this.msVolumeJ.SmoothScrolling = true;
            this.msVolumeJ.TabIndex = 74;
            this.msVolumeJ.TickColor = System.Drawing.Color.DarkGray;
            this.msVolumeJ.TickStyle = System.Windows.Forms.TickStyle.None;
            this.msVolumeJ.TickType = MediaSlider.MediaSlider.TickMode.Standard;
            this.toolTip1.SetToolTip(this.msVolumeJ, "Volume");
            this.msVolumeJ.TrackBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msVolumeJ.TrackDepth = 4;
            this.msVolumeJ.TrackFillColor = System.Drawing.Color.Transparent;
            this.msVolumeJ.TrackProgressColor = System.Drawing.Color.LightSkyBlue;
            this.msVolumeJ.TrackShadow = true;
            this.msVolumeJ.TrackShadowColor = System.Drawing.Color.DarkGray;
            this.msVolumeJ.TrackStyle = MediaSlider.MediaSlider.TrackType.Progress;
            this.msVolumeJ.Value = 127;
            this.msVolumeJ.ValueChanged += new MediaSlider.MediaSlider.ValueChangedDelegate(this.msVolumeJ_ValueChanged);
            // 
            // btnMuteJ
            // 
            this.btnMuteJ.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.btnMuteJ.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.btnMuteJ.AutoSize = true;
            this.btnMuteJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnMuteJ.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMuteJ.BackgroundImage")));
            this.btnMuteJ.Checked = false;
            this.btnMuteJ.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnMuteJ.CheckStyle = GlowButton.GlowButton.CheckedStyle.ColorChange;
            this.btnMuteJ.ContextMenuStrip = null;
            this.btnMuteJ.FocusedMask = false;
            this.btnMuteJ.FocusOnHover = false;
            this.btnMuteJ.Image = global::VideoCutterJoinerExpert.Properties.Resources.mute;
            this.btnMuteJ.ImageCheckedColor = System.Drawing.Color.Firebrick;
            this.btnMuteJ.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnMuteJ.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnMuteJ.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnMuteJ.ImageGlowFactor = 2;
            this.btnMuteJ.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnMuteJ.ImageMirror = true;
            this.btnMuteJ.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnMuteJ.Location = new System.Drawing.Point(139, 42);
            this.btnMuteJ.Name = "btnMuteJ";
            this.btnMuteJ.Size = new System.Drawing.Size(20, 31);
            this.btnMuteJ.TabIndex = 81;
            this.btnMuteJ.Tag = "Mute";
            this.toolTip1.SetToolTip(this.btnMuteJ, "Mute");
            this.btnMuteJ.Click += new System.EventHandler(this.btnMuteJ_Click);
            // 
            // btnStopJ
            // 
            this.btnStopJ.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.btnStopJ.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.btnStopJ.AutoSize = true;
            this.btnStopJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnStopJ.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStopJ.BackgroundImage")));
            this.btnStopJ.Checked = false;
            this.btnStopJ.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnStopJ.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnStopJ.ContextMenuStrip = null;
            this.btnStopJ.Enabled = false;
            this.btnStopJ.FocusedMask = false;
            this.btnStopJ.FocusOnHover = false;
            this.btnStopJ.Image = global::VideoCutterJoinerExpert.Properties.Resources.stop;
            this.btnStopJ.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnStopJ.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnStopJ.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnStopJ.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnStopJ.ImageGlowFactor = 2;
            this.btnStopJ.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnStopJ.ImageMirror = true;
            this.btnStopJ.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnStopJ.Location = new System.Drawing.Point(101, 45);
            this.btnStopJ.Name = "btnStopJ";
            this.btnStopJ.Size = new System.Drawing.Size(18, 27);
            this.btnStopJ.TabIndex = 80;
            this.btnStopJ.Tag = "Stop";
            this.toolTip1.SetToolTip(this.btnStopJ, "Stop");
            this.btnStopJ.Click += new System.EventHandler(this.btnStopJ_Click);
            // 
            // btnPlayJ
            // 
            this.btnPlayJ.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.btnPlayJ.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.btnPlayJ.AutoSize = true;
            this.btnPlayJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnPlayJ.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlayJ.BackgroundImage")));
            this.btnPlayJ.Checked = false;
            this.btnPlayJ.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnPlayJ.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnPlayJ.ContextMenuStrip = null;
            this.btnPlayJ.Enabled = false;
            this.btnPlayJ.FocusedMask = false;
            this.btnPlayJ.FocusOnHover = false;
            this.btnPlayJ.Image = global::VideoCutterJoinerExpert.Properties.Resources.play;
            this.btnPlayJ.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnPlayJ.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnPlayJ.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnPlayJ.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnPlayJ.ImageGlowFactor = 2;
            this.btnPlayJ.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnPlayJ.ImageMirror = true;
            this.btnPlayJ.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnPlayJ.Location = new System.Drawing.Point(42, 42);
            this.btnPlayJ.Name = "btnPlayJ";
            this.btnPlayJ.Size = new System.Drawing.Size(20, 31);
            this.btnPlayJ.TabIndex = 79;
            this.btnPlayJ.Tag = "Play/Pause";
            this.toolTip1.SetToolTip(this.btnPlayJ, "Play / Pause");
            this.btnPlayJ.Click += new System.EventHandler(this.btnPlayJ_Click);
            // 
            // btnFastForwardJ
            // 
            this.btnFastForwardJ.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.btnFastForwardJ.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.btnFastForwardJ.AutoSize = true;
            this.btnFastForwardJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnFastForwardJ.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFastForwardJ.BackgroundImage")));
            this.btnFastForwardJ.Checked = false;
            this.btnFastForwardJ.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnFastForwardJ.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnFastForwardJ.ContextMenuStrip = null;
            this.btnFastForwardJ.Enabled = false;
            this.btnFastForwardJ.FocusedMask = false;
            this.btnFastForwardJ.FocusOnHover = false;
            this.btnFastForwardJ.Image = global::VideoCutterJoinerExpert.Properties.Resources.ff;
            this.btnFastForwardJ.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnFastForwardJ.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnFastForwardJ.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnFastForwardJ.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnFastForwardJ.ImageGlowFactor = 2;
            this.btnFastForwardJ.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnFastForwardJ.ImageMirror = true;
            this.btnFastForwardJ.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnFastForwardJ.Location = new System.Drawing.Point(70, 43);
            this.btnFastForwardJ.Name = "btnFastForwardJ";
            this.btnFastForwardJ.Size = new System.Drawing.Size(19, 29);
            this.btnFastForwardJ.TabIndex = 77;
            this.btnFastForwardJ.Tag = "Fast Forward";
            this.toolTip1.SetToolTip(this.btnFastForwardJ, "Fast Forward");
            this.btnFastForwardJ.Click += new System.EventHandler(this.btnFastForwardJ_Click);
            // 
            // btnRewindJ
            // 
            this.btnRewindJ.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.btnRewindJ.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.btnRewindJ.AutoSize = true;
            this.btnRewindJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnRewindJ.Checked = false;
            this.btnRewindJ.CheckedBorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnRewindJ.CheckStyle = GlowButton.GlowButton.CheckedStyle.None;
            this.btnRewindJ.ContextMenuStrip = null;
            this.btnRewindJ.Enabled = false;
            this.btnRewindJ.FocusedMask = false;
            this.btnRewindJ.FocusOnHover = false;
            this.btnRewindJ.Image = global::VideoCutterJoinerExpert.Properties.Resources.fr;
            this.btnRewindJ.ImageCheckedColor = System.Drawing.Color.SteelBlue;
            this.btnRewindJ.ImageDisabledColor = System.Drawing.Color.Transparent;
            this.btnRewindJ.ImageFocusedColor = System.Drawing.Color.SkyBlue;
            this.btnRewindJ.ImageGlowColor = System.Drawing.Color.SteelBlue;
            this.btnRewindJ.ImageGlowFactor = 2;
            this.btnRewindJ.ImageHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnRewindJ.ImageMirror = true;
            this.btnRewindJ.ImagePressedColor = System.Drawing.Color.SteelBlue;
            this.btnRewindJ.Location = new System.Drawing.Point(15, 43);
            this.btnRewindJ.Name = "btnRewindJ";
            this.btnRewindJ.Size = new System.Drawing.Size(19, 29);
            this.btnRewindJ.TabIndex = 76;
            this.btnRewindJ.Tag = "Reverse";
            this.toolTip1.SetToolTip(this.btnRewindJ, "Reverse");
            this.btnRewindJ.Click += new System.EventHandler(this.btnRewindJ_Click);
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
            this.timPlayPositionJ.Tick += new System.EventHandler(this.timPlayerPositionJ_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Video Cutter Expert";
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
            this.ti10Seconds,
            this.ti5Seconds,
            this.tiSecond,
            this.ti100Msecs,
            this.ti10Msecs});
            this.cmsZoom.Name = "cmsZoom";
            this.cmsZoom.Size = new System.Drawing.Size(162, 114);
            // 
            // ti10Seconds
            // 
            this.ti10Seconds.Checked = true;
            this.ti10Seconds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ti10Seconds.Name = "ti10Seconds";
            this.ti10Seconds.Size = new System.Drawing.Size(161, 22);
            this.ti10Seconds.Text = "10 S&econds";
            // 
            // ti5Seconds
            // 
            this.ti5Seconds.Name = "ti5Seconds";
            this.ti5Seconds.Size = new System.Drawing.Size(161, 22);
            this.ti5Seconds.Text = "&5 Seconds";
            // 
            // tiSecond
            // 
            this.tiSecond.Name = "tiSecond";
            this.tiSecond.Size = new System.Drawing.Size(161, 22);
            this.tiSecond.Text = "&1 Second";
            // 
            // ti100Msecs
            // 
            this.ti100Msecs.Name = "ti100Msecs";
            this.ti100Msecs.Size = new System.Drawing.Size(161, 22);
            this.ti100Msecs.Text = "1&00 Milliseconds";
            // 
            // ti10Msecs
            // 
            this.ti10Msecs.Name = "ti10Msecs";
            this.ti10Msecs.Size = new System.Drawing.Size(161, 22);
            this.ti10Msecs.Text = "10 &Milliseconds";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblVideoFile,
            this.lblElapsedTime,
            this.pbarCut});
            this.statusStrip1.Location = new System.Drawing.Point(0, 669);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 114;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblVideoFile
            // 
            this.tlblVideoFile.ForeColor = System.Drawing.Color.DimGray;
            this.tlblVideoFile.Name = "tlblVideoFile";
            this.tlblVideoFile.Size = new System.Drawing.Size(891, 17);
            this.tlblVideoFile.Spring = true;
            this.tlblVideoFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(0, 17);
            // 
            // pbarCut
            // 
            this.pbarCut.Name = "pbarCut";
            this.pbarCut.Size = new System.Drawing.Size(100, 16);
            this.pbarCut.Step = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 659);
            this.tabControl1.TabIndex = 101;
            // 
            // tabPage1
            // 
            this.tabPage1.AllowDrop = true;
            this.tabPage1.Controls.Add(this.btnZoomOut);
            this.tabPage1.Controls.Add(this.btnZoomIn);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.tsCut);
            this.tabPage1.Controls.Add(this.fplSegments);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 633);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cut Videos";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            this.tabPage1.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmClip_DragDrop);
            this.tabPage1.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmClip_DragEnter);
            this.tabPage1.DragOver += new System.Windows.Forms.DragEventHandler(this.frmClip_DragOver);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 432);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(993, 68);
            this.flowLayoutPanel1.TabIndex = 110;
            // 
            // tsCut
            // 
            this.tsCut.AutoSize = false;
            this.tsCut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCutOpenVideo,
            this.toolStripSeparator3,
            this.tsbCutAdd,
            this.tsbCutRemove,
            this.toolStripSeparator5,
            this.tsbCutPlayPreview,
            this.tsbSetStart,
            this.tsbSetEnd,
            this.toolStripSeparator6,
            this.tsbIncludeMode,
            this.tsbExcludeMode,
            this.toolStripSeparator4,
            this.tsbCutVideo,
            this.tsbStopCut});
            this.tsCut.Location = new System.Drawing.Point(3, 3);
            this.tsCut.Name = "tsCut";
            this.tsCut.Size = new System.Drawing.Size(994, 58);
            this.tsCut.TabIndex = 112;
            this.tsCut.Text = "toolStrip1";
            // 
            // tsbCutOpenVideo
            // 
            this.tsbCutOpenVideo.AutoSize = false;
            this.tsbCutOpenVideo.Image = global::VideoCutterJoinerExpert.Properties.Resources.folder2;
            this.tsbCutOpenVideo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCutOpenVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCutOpenVideo.Name = "tsbCutOpenVideo";
            this.tsbCutOpenVideo.Size = new System.Drawing.Size(73, 53);
            this.tsbCutOpenVideo.Text = "Open Video";
            this.tsbCutOpenVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCutOpenVideo.Click += new System.EventHandler(this.btnOpenVideo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 58);
            // 
            // tsbCutAdd
            // 
            this.tsbCutAdd.AutoSize = false;
            this.tsbCutAdd.Image = global::VideoCutterJoinerExpert.Properties.Resources.add1;
            this.tsbCutAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCutAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCutAdd.Name = "tsbCutAdd";
            this.tsbCutAdd.Size = new System.Drawing.Size(83, 53);
            this.tsbCutAdd.Text = "&Add Clip";
            this.tsbCutAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCutAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tsbCutRemove
            // 
            this.tsbCutRemove.AutoSize = false;
            this.tsbCutRemove.Image = global::VideoCutterJoinerExpert.Properties.Resources.delete1;
            this.tsbCutRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCutRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCutRemove.Name = "tsbCutRemove";
            this.tsbCutRemove.Size = new System.Drawing.Size(103, 53);
            this.tsbCutRemove.Text = "Remove Clip";
            this.tsbCutRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCutRemove.Click += new System.EventHandler(this.btnDeleteSegment_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 58);
            // 
            // tsbCutPlayPreview
            // 
            this.tsbCutPlayPreview.AutoSize = false;
            this.tsbCutPlayPreview.Image = global::VideoCutterJoinerExpert.Properties.Resources.media_play1;
            this.tsbCutPlayPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCutPlayPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCutPlayPreview.Name = "tsbCutPlayPreview";
            this.tsbCutPlayPreview.Size = new System.Drawing.Size(73, 53);
            this.tsbCutPlayPreview.Text = "Play Preview";
            this.tsbCutPlayPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCutPlayPreview.Click += new System.EventHandler(this.btnPlayAll_Click);
            // 
            // tsbSetStart
            // 
            this.tsbSetStart.AutoSize = false;
            this.tsbSetStart.Image = global::VideoCutterJoinerExpert.Properties.Resources.setstart_24;
            this.tsbSetStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSetStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetStart.Name = "tsbSetStart";
            this.tsbSetStart.Size = new System.Drawing.Size(73, 53);
            this.tsbSetStart.Text = "&Set Clip Start";
            this.tsbSetStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSetStart.Click += new System.EventHandler(this.btnSetClipStart_Click);
            // 
            // tsbSetEnd
            // 
            this.tsbSetEnd.AutoSize = false;
            this.tsbSetEnd.Image = global::VideoCutterJoinerExpert.Properties.Resources.setend_24;
            this.tsbSetEnd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSetEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetEnd.Name = "tsbSetEnd";
            this.tsbSetEnd.Size = new System.Drawing.Size(73, 53);
            this.tsbSetEnd.Text = "&Set Clip End";
            this.tsbSetEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSetEnd.Click += new System.EventHandler(this.btnSetEnd_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 58);
            // 
            // tsbIncludeMode
            // 
            this.tsbIncludeMode.AutoSize = false;
            this.tsbIncludeMode.Image = global::VideoCutterJoinerExpert.Properties.Resources.movie_add;
            this.tsbIncludeMode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbIncludeMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIncludeMode.Name = "tsbIncludeMode";
            this.tsbIncludeMode.Size = new System.Drawing.Size(83, 53);
            this.tsbIncludeMode.Text = "Include Mode";
            this.tsbIncludeMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbIncludeMode.ToolTipText = "Include Mode - Specify which Parts to include";
            this.tsbIncludeMode.Click += new System.EventHandler(this.tsbIncludeMode_Click);
            // 
            // tsbExcludeMode
            // 
            this.tsbExcludeMode.AutoSize = false;
            this.tsbExcludeMode.BackColor = System.Drawing.Color.Transparent;
            this.tsbExcludeMode.Image = global::VideoCutterJoinerExpert.Properties.Resources.movie_remove;
            this.tsbExcludeMode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbExcludeMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcludeMode.Name = "tsbExcludeMode";
            this.tsbExcludeMode.Size = new System.Drawing.Size(83, 53);
            this.tsbExcludeMode.Text = "Exclude Mode";
            this.tsbExcludeMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExcludeMode.ToolTipText = "Exclude Mode - Specify which Parts to Exclude";
            this.tsbExcludeMode.Click += new System.EventHandler(this.tsbExclude_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 58);
            // 
            // tsbCutVideo
            // 
            this.tsbCutVideo.AutoSize = false;
            this.tsbCutVideo.Image = global::VideoCutterJoinerExpert.Properties.Resources.cut1;
            this.tsbCutVideo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCutVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCutVideo.Name = "tsbCutVideo";
            this.tsbCutVideo.Size = new System.Drawing.Size(73, 53);
            this.tsbCutVideo.Text = "&Cut Video";
            this.tsbCutVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCutVideo.Click += new System.EventHandler(this.tsbCutVideo_Click);
            // 
            // tsbStopCut
            // 
            this.tsbStopCut.AutoSize = false;
            this.tsbStopCut.Enabled = false;
            this.tsbStopCut.Image = global::VideoCutterJoinerExpert.Properties.Resources.media_stop1;
            this.tsbStopCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbStopCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStopCut.Name = "tsbStopCut";
            this.tsbStopCut.Size = new System.Drawing.Size(73, 53);
            this.tsbStopCut.Text = "&Stop";
            this.tsbStopCut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbStopCut.Visible = false;
            this.tsbStopCut.Click += new System.EventHandler(this.tsbStopCut_Click);
            // 
            // fplSegments
            // 
            this.fplSegments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fplSegments.AutoScroll = true;
            this.fplSegments.Location = new System.Drawing.Point(5, 506);
            this.fplSegments.Name = "fplSegments";
            this.fplSegments.Size = new System.Drawing.Size(871, 111);
            this.fplSegments.TabIndex = 109;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.toolStrip4);
            this.groupBox2.Controls.Add(this.lblTotalDuration);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.toolStrip5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.toolStrip3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Controls.Add(this.plMedia);
            this.groupBox2.Controls.Add(this.picMovie);
            this.groupBox2.Location = new System.Drawing.Point(3, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(915, 366);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmClip_DragDrop);
            this.groupBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmClip_DragEnter);
            this.groupBox2.DragOver += new System.Windows.Forms.DragEventHandler(this.frmClip_DragOver);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbOutputFormat);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btnOpenOutputFolder);
            this.groupBox3.Controls.Add(this.btnBrowseOutputFolder);
            this.groupBox3.Controls.Add(this.cmbOutputFolder);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.chkJoinParts);
            this.groupBox3.Location = new System.Drawing.Point(456, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(453, 113);
            this.groupBox3.TabIndex = 124;
            this.groupBox3.TabStop = false;
            // 
            // cmbOutputFormat
            // 
            this.cmbOutputFormat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbOutputFormat.DropDownBackColor = System.Drawing.Color.White;
            this.cmbOutputFormat.DropDownBorderColor = System.Drawing.Color.Black;
            this.cmbOutputFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutputFormat.FormattingEnabled = true;
            this.cmbOutputFormat.Location = new System.Drawing.Point(116, 53);
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.Size = new System.Drawing.Size(291, 23);
            this.cmbOutputFormat.TabIndex = 124;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 122;
            this.label8.Text = "Output Format :";
            // 
            // cmbOutputFolder
            // 
            this.cmbOutputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutputFolder.FormattingEnabled = true;
            this.cmbOutputFolder.Location = new System.Drawing.Point(116, 13);
            this.cmbOutputFolder.Name = "cmbOutputFolder";
            this.cmbOutputFolder.Size = new System.Drawing.Size(210, 24);
            this.cmbOutputFolder.TabIndex = 119;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 16);
            this.label7.TabIndex = 118;
            this.label7.Text = "Output Folder :";
            // 
            // chkJoinParts
            // 
            this.chkJoinParts.AutoSize = true;
            this.chkJoinParts.BackColor = System.Drawing.Color.Transparent;
            this.chkJoinParts.Checked = true;
            this.chkJoinParts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJoinParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkJoinParts.Location = new System.Drawing.Point(122, 82);
            this.chkJoinParts.Name = "chkJoinParts";
            this.chkJoinParts.Size = new System.Drawing.Size(95, 20);
            this.chkJoinParts.TabIndex = 107;
            this.chkJoinParts.Text = "Join Clips";
            this.chkJoinParts.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(497, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 117;
            this.label5.Text = "3 min";
            // 
            // toolStrip4
            // 
            this.toolStrip4.AutoSize = false;
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMoveBack3Min,
            this.tsbMoveForward3Min});
            this.toolStrip4.Location = new System.Drawing.Point(543, 256);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(92, 36);
            this.toolStrip4.TabIndex = 116;
            // 
            // tsbMoveBack3Min
            // 
            this.tsbMoveBack3Min.AutoSize = false;
            this.tsbMoveBack3Min.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveBack3Min.Image = global::VideoCutterJoinerExpert.Properties.Resources.navigate_left2;
            this.tsbMoveBack3Min.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveBack3Min.Name = "tsbMoveBack3Min";
            this.tsbMoveBack3Min.Size = new System.Drawing.Size(30, 30);
            this.tsbMoveBack3Min.Text = "Move Back 3 min";
            this.tsbMoveBack3Min.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMoveBack3Min.Click += new System.EventHandler(this.tsbMoveBack3Min_Click);
            // 
            // tsbMoveForward3Min
            // 
            this.tsbMoveForward3Min.AutoSize = false;
            this.tsbMoveForward3Min.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveForward3Min.Image = global::VideoCutterJoinerExpert.Properties.Resources.navigate_right1;
            this.tsbMoveForward3Min.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveForward3Min.Name = "tsbMoveForward3Min";
            this.tsbMoveForward3Min.Size = new System.Drawing.Size(30, 30);
            this.tsbMoveForward3Min.Text = "Move Forward 3 min";
            this.tsbMoveForward3Min.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMoveForward3Min.Click += new System.EventHandler(this.tsbMoveForward3Min_Click);
            // 
            // lblTotalDuration
            // 
            this.lblTotalDuration.AutoSize = true;
            this.lblTotalDuration.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDuration.Location = new System.Drawing.Point(458, 225);
            this.lblTotalDuration.Name = "lblTotalDuration";
            this.lblTotalDuration.Size = new System.Drawing.Size(114, 16);
            this.lblTotalDuration.TabIndex = 106;
            this.lblTotalDuration.Text = "Total Duration :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(330, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 115;
            this.label6.Text = "30 sec";
            // 
            // toolStrip5
            // 
            this.toolStrip5.AutoSize = false;
            this.toolStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMoveBack30Sec,
            this.tsbMoveForward30Sec});
            this.toolStrip5.Location = new System.Drawing.Point(392, 256);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(87, 36);
            this.toolStrip5.TabIndex = 114;
            // 
            // tsbMoveBack30Sec
            // 
            this.tsbMoveBack30Sec.AutoSize = false;
            this.tsbMoveBack30Sec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveBack30Sec.Image = global::VideoCutterJoinerExpert.Properties.Resources.navigate_left_green;
            this.tsbMoveBack30Sec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveBack30Sec.Name = "tsbMoveBack30Sec";
            this.tsbMoveBack30Sec.Size = new System.Drawing.Size(30, 30);
            this.tsbMoveBack30Sec.Text = "Move Back 30 sec";
            this.tsbMoveBack30Sec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMoveBack30Sec.Click += new System.EventHandler(this.tsbMoveBack30Sec_Click);
            // 
            // tsbMoveForward30Sec
            // 
            this.tsbMoveForward30Sec.AutoSize = false;
            this.tsbMoveForward30Sec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveForward30Sec.Image = global::VideoCutterJoinerExpert.Properties.Resources.navigate_right_green;
            this.tsbMoveForward30Sec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveForward30Sec.Name = "tsbMoveForward30Sec";
            this.tsbMoveForward30Sec.Size = new System.Drawing.Size(30, 30);
            this.tsbMoveForward30Sec.Text = "Move Forward 30 sec";
            this.tsbMoveForward30Sec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMoveForward30Sec.Click += new System.EventHandler(this.tsbMoveForward30Sec_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(177, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 113;
            this.label4.Text = "1 sec";
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMoveBack1Sec,
            this.tsbMoveForward1Sec});
            this.toolStrip3.Location = new System.Drawing.Point(223, 256);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(92, 36);
            this.toolStrip3.TabIndex = 112;
            // 
            // tsbMoveBack1Sec
            // 
            this.tsbMoveBack1Sec.AutoSize = false;
            this.tsbMoveBack1Sec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveBack1Sec.Image = global::VideoCutterJoinerExpert.Properties.Resources.navigate_left2;
            this.tsbMoveBack1Sec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveBack1Sec.Name = "tsbMoveBack1Sec";
            this.tsbMoveBack1Sec.Size = new System.Drawing.Size(30, 30);
            this.tsbMoveBack1Sec.Text = "Move Back 1 sec";
            this.tsbMoveBack1Sec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMoveBack1Sec.Click += new System.EventHandler(this.tsbMoveBack1Sec_Click);
            // 
            // tsbMoveForward1Sec
            // 
            this.tsbMoveForward1Sec.AutoSize = false;
            this.tsbMoveForward1Sec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveForward1Sec.Image = global::VideoCutterJoinerExpert.Properties.Resources.navigate_right1;
            this.tsbMoveForward1Sec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveForward1Sec.Name = "tsbMoveForward1Sec";
            this.tsbMoveForward1Sec.Size = new System.Drawing.Size(30, 30);
            this.tsbMoveForward1Sec.Text = "Move Forward 1 sec";
            this.tsbMoveForward1Sec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMoveForward1Sec.Click += new System.EventHandler(this.tsbMoveForward1Sec_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 111;
            this.label3.Text = "0.1 sec";
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMoveBackMsec,
            this.tsbMoveForwardMsec});
            this.toolStrip2.Location = new System.Drawing.Point(72, 256);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(87, 36);
            this.toolStrip2.TabIndex = 110;
            // 
            // tsbMoveBackMsec
            // 
            this.tsbMoveBackMsec.AutoSize = false;
            this.tsbMoveBackMsec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveBackMsec.Image = global::VideoCutterJoinerExpert.Properties.Resources.navigate_left_green;
            this.tsbMoveBackMsec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveBackMsec.Name = "tsbMoveBackMsec";
            this.tsbMoveBackMsec.Size = new System.Drawing.Size(30, 40);
            this.tsbMoveBackMsec.Text = "Move Back 0.1 sec";
            this.tsbMoveBackMsec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMoveBackMsec.Click += new System.EventHandler(this.tsbMoveBackMsec_Click);
            // 
            // tsbMoveForwardMsec
            // 
            this.tsbMoveForwardMsec.AutoSize = false;
            this.tsbMoveForwardMsec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveForwardMsec.Image = global::VideoCutterJoinerExpert.Properties.Resources.navigate_right_green;
            this.tsbMoveForwardMsec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveForwardMsec.Name = "tsbMoveForwardMsec";
            this.tsbMoveForwardMsec.Size = new System.Drawing.Size(30, 30);
            this.tsbMoveForwardMsec.Text = "Move Forward 0.1 sec";
            this.tsbMoveForwardMsec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMoveForwardMsec.Click += new System.EventHandler(this.tsbMoveForwardMsec_Click);
            // 
            // plMedia
            // 
            this.plMedia.BackColor = System.Drawing.Color.Black;
            this.plMedia.Controls.Add(this.mskPos);
            this.plMedia.Controls.Add(this.msVolume);
            this.plMedia.Controls.Add(this.btnMute);
            this.plMedia.Controls.Add(this.btnStop);
            this.plMedia.Controls.Add(this.btnPlay);
            this.plMedia.Controls.Add(this.btnFastForward);
            this.plMedia.Controls.Add(this.btnRewind);
            this.plMedia.Controls.Add(this.msPosition);
            this.plMedia.Controls.Add(this.lblTime);
            this.plMedia.Location = new System.Drawing.Point(3, 295);
            this.plMedia.Name = "plMedia";
            this.plMedia.Size = new System.Drawing.Size(799, 77);
            this.plMedia.TabIndex = 83;
            // 
            // mskPos
            // 
            this.mskPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskPos.HidePromptOnLeave = true;
            this.mskPos.Location = new System.Drawing.Point(389, 43);
            this.mskPos.Mask = "00:00:00.0";
            this.mskPos.Name = "mskPos";
            this.mskPos.Size = new System.Drawing.Size(81, 22);
            this.mskPos.TabIndex = 109;
            this.mskPos.TextChanged += new System.EventHandler(this.mskPos_TextChanged);
            this.mskPos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskPos_KeyDown);
            this.mskPos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mskPos_KeyUp);
            // 
            // msPosition
            // 
            this.msPosition.Animated = false;
            this.msPosition.AnimationSize = 0.2F;
            this.msPosition.AnimationSpeed = MediaSlider.MediaSlider.AnimateSpeed.Normal;
            this.msPosition.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.msPosition.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.msPosition.BackColor = System.Drawing.Color.Transparent;
            this.msPosition.BackGroundImage = null;
            this.msPosition.ButtonAccentColor = System.Drawing.Color.LightSkyBlue;
            this.msPosition.ButtonBorderColor = System.Drawing.Color.SteelBlue;
            this.msPosition.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(131)))), ((int)(((byte)(235)))));
            this.msPosition.ButtonCornerRadius = ((uint)(2u));
            this.msPosition.ButtonSize = new System.Drawing.Size(7, 20);
            this.msPosition.ButtonStyle = MediaSlider.MediaSlider.ButtonType.PointerDownLeft;
            this.msPosition.ContextMenuStrip = null;
            this.msPosition.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.msPosition.IsForRangeSelect = true;
            this.msPosition.IsForShowMeter = true;
            this.msPosition.IsForShowSegment = false;
            this.msPosition.LargeChange = 100;
            this.msPosition.Location = new System.Drawing.Point(4, 4);
            this.msPosition.Margin = new System.Windows.Forms.Padding(0);
            this.msPosition.Maximum = 10;
            this.msPosition.Minimum = 0;
            this.msPosition.Name = "msPosition";
            this.msPosition.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.msPosition.RangeEndPixels = 11;
            this.msPosition.RangeStartPixels = 8;
            this.msPosition.ShowButtonOnHover = false;
            this.msPosition.Size = new System.Drawing.Size(795, 42);
            this.msPosition.SliderFlyOut = MediaSlider.MediaSlider.FlyOutStyle.None;
            this.msPosition.SmallChange = 1;
            this.msPosition.SmoothScrolling = false;
            this.msPosition.TabIndex = 75;
            this.msPosition.TickColor = System.Drawing.Color.DarkGray;
            this.msPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.msPosition.TickType = MediaSlider.MediaSlider.TickMode.Precision;
            this.msPosition.TrackBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msPosition.TrackDepth = 10;
            this.msPosition.TrackFillColor = System.Drawing.Color.Transparent;
            this.msPosition.TrackProgressColor = System.Drawing.Color.LightSkyBlue;
            this.msPosition.TrackShadow = true;
            this.msPosition.TrackShadowColor = System.Drawing.Color.DarkGray;
            this.msPosition.TrackStyle = MediaSlider.MediaSlider.TrackType.Value;
            this.msPosition.Value = 0;
            this.msPosition.ValueChanged += new MediaSlider.MediaSlider.ValueChangedDelegate(this.msPosition_ValueChanged);
            this.msPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.msPosition_MouseDown);
            this.msPosition.MouseMove += new System.Windows.Forms.MouseEventHandler(this.msPosition_MouseMove);
            this.msPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.msPosition_MouseUp);
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblTime.Location = new System.Drawing.Point(462, 33);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(101, 39);
            this.lblTime.TabIndex = 63;
            this.lblTime.Text = " / 00:00:00.0";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picMovie
            // 
            this.picMovie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.picMovie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMovie.Location = new System.Drawing.Point(72, 12);
            this.picMovie.Name = "picMovie";
            this.picMovie.Size = new System.Drawing.Size(369, 235);
            this.picMovie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMovie.TabIndex = 1;
            this.picMovie.TabStop = false;
            this.picMovie.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmClip_DragDrop);
            this.picMovie.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmClip_DragEnter);
            this.picMovie.DragOver += new System.Windows.Forms.DragEventHandler(this.frmClip_DragOver);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtJoinTotalDuration);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.toolStrip1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.dgFiles);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 633);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Join Videos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtJoinTotalDuration
            // 
            this.txtJoinTotalDuration.Location = new System.Drawing.Point(482, 343);
            this.txtJoinTotalDuration.Name = "txtJoinTotalDuration";
            this.txtJoinTotalDuration.ReadOnly = true;
            this.txtJoinTotalDuration.Size = new System.Drawing.Size(157, 20);
            this.txtJoinTotalDuration.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "Total Duration :";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbJoinAdd,
            this.tsbJoinAddFolder,
            this.tsbJoinRemove,
            this.toolStripSeparator1,
            this.tsbJoinPlayPreview,
            this.toolStripSeparator2,
            this.tsbJoinVideos});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(994, 50);
            this.toolStrip1.TabIndex = 113;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbJoinAdd
            // 
            this.tsbJoinAdd.AutoSize = false;
            this.tsbJoinAdd.Image = global::VideoCutterJoinerExpert.Properties.Resources.add1;
            this.tsbJoinAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbJoinAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJoinAdd.Name = "tsbJoinAdd";
            this.tsbJoinAdd.Size = new System.Drawing.Size(73, 43);
            this.tsbJoinAdd.Text = "Add Video";
            this.tsbJoinAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbJoinAdd.Click += new System.EventHandler(this.tsbJoinAdd_Click);
            // 
            // tsbJoinAddFolder
            // 
            this.tsbJoinAddFolder.AutoSize = false;
            this.tsbJoinAddFolder.Image = global::VideoCutterJoinerExpert.Properties.Resources.folder_add1;
            this.tsbJoinAddFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbJoinAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJoinAddFolder.Name = "tsbJoinAddFolder";
            this.tsbJoinAddFolder.Size = new System.Drawing.Size(73, 43);
            this.tsbJoinAddFolder.Text = "Add Folder";
            this.tsbJoinAddFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbJoinAddFolder.Click += new System.EventHandler(this.tsbAddFolder_Click);
            // 
            // tsbJoinRemove
            // 
            this.tsbJoinRemove.AutoSize = false;
            this.tsbJoinRemove.Enabled = false;
            this.tsbJoinRemove.Image = global::VideoCutterJoinerExpert.Properties.Resources.delete1;
            this.tsbJoinRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbJoinRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJoinRemove.Name = "tsbJoinRemove";
            this.tsbJoinRemove.Size = new System.Drawing.Size(93, 43);
            this.tsbJoinRemove.Text = "Remove Video";
            this.tsbJoinRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbJoinRemove.Click += new System.EventHandler(this.tsbJoinRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // tsbJoinPlayPreview
            // 
            this.tsbJoinPlayPreview.AutoSize = false;
            this.tsbJoinPlayPreview.Enabled = false;
            this.tsbJoinPlayPreview.Image = global::VideoCutterJoinerExpert.Properties.Resources.media_play1;
            this.tsbJoinPlayPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbJoinPlayPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJoinPlayPreview.Name = "tsbJoinPlayPreview";
            this.tsbJoinPlayPreview.Size = new System.Drawing.Size(73, 43);
            this.tsbJoinPlayPreview.Text = "Play Preview";
            this.tsbJoinPlayPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbJoinPlayPreview.Click += new System.EventHandler(this.tsbJoinPlayPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // tsbJoinVideos
            // 
            this.tsbJoinVideos.AutoSize = false;
            this.tsbJoinVideos.Enabled = false;
            this.tsbJoinVideos.Image = global::VideoCutterJoinerExpert.Properties.Resources.join_movie_24c;
            this.tsbJoinVideos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbJoinVideos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJoinVideos.Name = "tsbJoinVideos";
            this.tsbJoinVideos.Size = new System.Drawing.Size(73, 43);
            this.tsbJoinVideos.Text = "Join Videos";
            this.tsbJoinVideos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbJoinVideos.Click += new System.EventHandler(this.tsbJoinVideos_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.plMediaJ);
            this.groupBox1.Controls.Add(this.picJoin);
            this.groupBox1.Location = new System.Drawing.Point(3, 313);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 289);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            // 
            // plMediaJ
            // 
            this.plMediaJ.BackColor = System.Drawing.Color.Black;
            this.plMediaJ.Controls.Add(this.msVolumeJ);
            this.plMediaJ.Controls.Add(this.btnMuteJ);
            this.plMediaJ.Controls.Add(this.btnStopJ);
            this.plMediaJ.Controls.Add(this.btnPlayJ);
            this.plMediaJ.Controls.Add(this.btnFastForwardJ);
            this.plMediaJ.Controls.Add(this.btnRewindJ);
            this.plMediaJ.Controls.Add(this.msPositionJ);
            this.plMediaJ.Controls.Add(this.lblTimeJ);
            this.plMediaJ.Location = new System.Drawing.Point(-1, 203);
            this.plMediaJ.Name = "plMediaJ";
            this.plMediaJ.Size = new System.Drawing.Size(352, 77);
            this.plMediaJ.TabIndex = 83;
            // 
            // msPositionJ
            // 
            this.msPositionJ.Animated = false;
            this.msPositionJ.AnimationSize = 0.2F;
            this.msPositionJ.AnimationSpeed = MediaSlider.MediaSlider.AnimateSpeed.Normal;
            this.msPositionJ.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.msPositionJ.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.msPositionJ.BackColor = System.Drawing.Color.Transparent;
            this.msPositionJ.BackGroundImage = null;
            this.msPositionJ.ButtonAccentColor = System.Drawing.Color.LightSkyBlue;
            this.msPositionJ.ButtonBorderColor = System.Drawing.Color.SteelBlue;
            this.msPositionJ.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(131)))), ((int)(((byte)(235)))));
            this.msPositionJ.ButtonCornerRadius = ((uint)(2u));
            this.msPositionJ.ButtonSize = new System.Drawing.Size(7, 20);
            this.msPositionJ.ButtonStyle = MediaSlider.MediaSlider.ButtonType.PointerDownLeft;
            this.msPositionJ.ContextMenuStrip = null;
            this.msPositionJ.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.msPositionJ.IsForRangeSelect = false;
            this.msPositionJ.IsForShowMeter = false;
            this.msPositionJ.IsForShowSegment = false;
            this.msPositionJ.LargeChange = 2;
            this.msPositionJ.Location = new System.Drawing.Point(5, -4);
            this.msPositionJ.Margin = new System.Windows.Forms.Padding(0);
            this.msPositionJ.Maximum = 10;
            this.msPositionJ.Minimum = 0;
            this.msPositionJ.Name = "msPositionJ";
            this.msPositionJ.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.msPositionJ.RangeEndPixels = 1;
            this.msPositionJ.RangeStartPixels = 0;
            this.msPositionJ.ShowButtonOnHover = false;
            this.msPositionJ.Size = new System.Drawing.Size(346, 42);
            this.msPositionJ.SliderFlyOut = MediaSlider.MediaSlider.FlyOutStyle.None;
            this.msPositionJ.SmallChange = 1;
            this.msPositionJ.SmoothScrolling = true;
            this.msPositionJ.TabIndex = 75;
            this.msPositionJ.TickColor = System.Drawing.Color.DarkGray;
            this.msPositionJ.TickStyle = System.Windows.Forms.TickStyle.None;
            this.msPositionJ.TickType = MediaSlider.MediaSlider.TickMode.Standard;
            this.msPositionJ.TrackBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msPositionJ.TrackDepth = 10;
            this.msPositionJ.TrackFillColor = System.Drawing.Color.Transparent;
            this.msPositionJ.TrackProgressColor = System.Drawing.Color.LightSkyBlue;
            this.msPositionJ.TrackShadow = true;
            this.msPositionJ.TrackShadowColor = System.Drawing.Color.DarkGray;
            this.msPositionJ.TrackStyle = MediaSlider.MediaSlider.TrackType.Value;
            this.msPositionJ.Value = 0;
            this.msPositionJ.ValueChanged += new MediaSlider.MediaSlider.ValueChangedDelegate(this.msPositionJ_ValueChanged);
            this.msPositionJ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.msPositionJ_MouseDown);
            this.msPositionJ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.msPositionJ_MouseUp);
            // 
            // lblTimeJ
            // 
            this.lblTimeJ.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeJ.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeJ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblTimeJ.Location = new System.Drawing.Point(220, 36);
            this.lblTimeJ.Name = "lblTimeJ";
            this.lblTimeJ.Size = new System.Drawing.Size(151, 39);
            this.lblTimeJ.TabIndex = 63;
            this.lblTimeJ.Text = "00:00:00 / 00:00:00";
            this.lblTimeJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picJoin
            // 
            this.picJoin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.picJoin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picJoin.Location = new System.Drawing.Point(3, 10);
            this.picJoin.Name = "picJoin";
            this.picJoin.Size = new System.Drawing.Size(346, 187);
            this.picJoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picJoin.TabIndex = 1;
            this.picJoin.TabStop = false;
            // 
            // dgFiles
            // 
            this.dgFiles.AllowDrop = true;
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.AllowUserToDeleteRows = false;
            this.dgFiles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgFiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgFiles.ColumnHeadersHeight = 22;
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colName,
            this.colLength,
            this.colFormat,
            this.colAudioFormat,
            this.colSamplingRate,
            this.colWidth,
            this.colHeight,
            this.colVideoFPS,
            this.colVideoBitrate,
            this.colColorDepth,
            this.colVideoAspect,
            this.colBitrate,
            this.colChannels,
            this.colSize,
            this.colProfile,
            this.colInputFile,
            this.colOutputFIle,
            this.colCreationDate,
            this.colModified,
            this.colLengthSecs});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFiles.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgFiles.EnableHeadersVisualStyles = false;
            this.dgFiles.Location = new System.Drawing.Point(0, 55);
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.ReadOnly = true;
            this.dgFiles.RowHeadersVisible = false;
            this.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFiles.Size = new System.Drawing.Size(766, 253);
            this.dgFiles.TabIndex = 4;
            this.dgFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFiles_CellContentClick);
            this.dgFiles.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFiles_CellContentDoubleClick);
            this.dgFiles.CurrentCellChanged += new System.EventHandler(this.dgFiles_CurrentCellChanged);
            this.dgFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragDrop);
            this.dgFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragEnter);
            // 
            // colSelect
            // 
            this.colSelect.DataPropertyName = "cselect";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = false;
            this.colSelect.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSelect.Frozen = true;
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.ReadOnly = true;
            this.colSelect.Width = 49;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "cname";
            this.colName.HeaderText = "Filename";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 82;
            // 
            // colLength
            // 
            this.colLength.DataPropertyName = "clength";
            this.colLength.HeaderText = "Duration";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 80;
            // 
            // colFormat
            // 
            this.colFormat.DataPropertyName = "cformat";
            this.colFormat.HeaderText = "Video Format";
            this.colFormat.Name = "colFormat";
            this.colFormat.ReadOnly = true;
            this.colFormat.Width = 106;
            // 
            // colAudioFormat
            // 
            this.colAudioFormat.DataPropertyName = "caudioformat";
            this.colAudioFormat.HeaderText = "Audio Format";
            this.colAudioFormat.Name = "colAudioFormat";
            this.colAudioFormat.ReadOnly = true;
            this.colAudioFormat.Width = 106;
            // 
            // colSamplingRate
            // 
            this.colSamplingRate.DataPropertyName = "caudiosamplingrate";
            this.colSamplingRate.HeaderText = "Sampling Rate (Hz)";
            this.colSamplingRate.Name = "colSamplingRate";
            this.colSamplingRate.ReadOnly = true;
            this.colSamplingRate.Width = 141;
            // 
            // colWidth
            // 
            this.colWidth.DataPropertyName = "cwidth";
            this.colWidth.HeaderText = "Width";
            this.colWidth.Name = "colWidth";
            this.colWidth.ReadOnly = true;
            this.colWidth.Width = 65;
            // 
            // colHeight
            // 
            this.colHeight.DataPropertyName = "cheight";
            this.colHeight.HeaderText = "Height";
            this.colHeight.Name = "colHeight";
            this.colHeight.ReadOnly = true;
            this.colHeight.Width = 69;
            // 
            // colVideoFPS
            // 
            this.colVideoFPS.DataPropertyName = "cvideofps";
            this.colVideoFPS.HeaderText = "Frames per second";
            this.colVideoFPS.Name = "colVideoFPS";
            this.colVideoFPS.ReadOnly = true;
            this.colVideoFPS.Width = 139;
            // 
            // colVideoBitrate
            // 
            this.colVideoBitrate.DataPropertyName = "cvideobitrate";
            this.colVideoBitrate.HeaderText = "Video Bitrate (kbps)";
            this.colVideoBitrate.Name = "colVideoBitrate";
            this.colVideoBitrate.ReadOnly = true;
            this.colVideoBitrate.Width = 144;
            // 
            // colColorDepth
            // 
            this.colColorDepth.DataPropertyName = "cvideocolordepth";
            this.colColorDepth.HeaderText = "Video Color Depth";
            this.colColorDepth.Name = "colColorDepth";
            this.colColorDepth.ReadOnly = true;
            this.colColorDepth.Width = 135;
            // 
            // colVideoAspect
            // 
            this.colVideoAspect.DataPropertyName = "cvideoaspect";
            this.colVideoAspect.HeaderText = "Video Aspect";
            this.colVideoAspect.Name = "colVideoAspect";
            this.colVideoAspect.ReadOnly = true;
            this.colVideoAspect.Width = 107;
            // 
            // colBitrate
            // 
            this.colBitrate.DataPropertyName = "caudiobitrate";
            this.colBitrate.HeaderText = "Bitrate (kbps)";
            this.colBitrate.Name = "colBitrate";
            this.colBitrate.ReadOnly = true;
            this.colBitrate.Width = 108;
            // 
            // colChannels
            // 
            this.colChannels.DataPropertyName = "caudionch";
            this.colChannels.HeaderText = "Channels";
            this.colChannels.Name = "colChannels";
            this.colChannels.ReadOnly = true;
            this.colChannels.Width = 84;
            // 
            // colSize
            // 
            this.colSize.DataPropertyName = "csize";
            this.colSize.HeaderText = "Size (MB)";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            this.colSize.Width = 86;
            // 
            // colProfile
            // 
            this.colProfile.DataPropertyName = "cprofile";
            this.colProfile.HeaderText = "Profile";
            this.colProfile.Name = "colProfile";
            this.colProfile.ReadOnly = true;
            this.colProfile.Visible = false;
            this.colProfile.Width = 68;
            // 
            // colInputFile
            // 
            this.colInputFile.DataPropertyName = "cinputfile";
            this.colInputFile.HeaderText = "Input File";
            this.colInputFile.Name = "colInputFile";
            this.colInputFile.ReadOnly = true;
            this.colInputFile.Width = 85;
            // 
            // colOutputFIle
            // 
            this.colOutputFIle.DataPropertyName = "coutputfile";
            this.colOutputFIle.HeaderText = "Output File";
            this.colOutputFIle.Name = "colOutputFIle";
            this.colOutputFIle.ReadOnly = true;
            this.colOutputFIle.Visible = false;
            this.colOutputFIle.Width = 94;
            // 
            // colCreationDate
            // 
            this.colCreationDate.DataPropertyName = "ccreationdate";
            this.colCreationDate.HeaderText = "Creation Date";
            this.colCreationDate.Name = "colCreationDate";
            this.colCreationDate.ReadOnly = true;
            this.colCreationDate.Width = 110;
            // 
            // colModified
            // 
            this.colModified.DataPropertyName = "clastmodified";
            this.colModified.HeaderText = "Last Modified";
            this.colModified.Name = "colModified";
            this.colModified.ReadOnly = true;
            this.colModified.Width = 108;
            // 
            // colLengthSecs
            // 
            this.colLengthSecs.DataPropertyName = "clengthsecs";
            this.colLengthSecs.HeaderText = "Duration (seconds)";
            this.colLengthSecs.Name = "colLengthSecs";
            this.colLengthSecs.ReadOnly = true;
            this.colLengthSecs.Visible = false;
            this.colLengthSecs.Width = 139;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tsiDownload,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 99;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToTrayToolStripMenuItem,
            this.tsiThreadPriority,
            this.whenFinishedToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            this.minimizeToTrayToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.minimizeToTrayToolStripMenuItem.Text = "&Minimize to Tray";
            this.minimizeToTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToTrayToolStripMenuItem_Click);
            // 
            // tsiThreadPriority
            // 
            this.tsiThreadPriority.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realTimeToolStripMenuItem,
            this.highToolStripMenuItem,
            this.aboveNormalToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.belowNormalToolStripMenuItem,
            this.idleToolStripMenuItem});
            this.tsiThreadPriority.Name = "tsiThreadPriority";
            this.tsiThreadPriority.Size = new System.Drawing.Size(163, 22);
            this.tsiThreadPriority.Text = "&Thread Priority";
            // 
            // realTimeToolStripMenuItem
            // 
            this.realTimeToolStripMenuItem.Name = "realTimeToolStripMenuItem";
            this.realTimeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.realTimeToolStripMenuItem.Text = "Real Time";
            this.realTimeToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // highToolStripMenuItem
            // 
            this.highToolStripMenuItem.Name = "highToolStripMenuItem";
            this.highToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.highToolStripMenuItem.Text = "High";
            this.highToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // aboveNormalToolStripMenuItem
            // 
            this.aboveNormalToolStripMenuItem.Name = "aboveNormalToolStripMenuItem";
            this.aboveNormalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.aboveNormalToolStripMenuItem.Text = "Above Normal";
            this.aboveNormalToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // belowNormalToolStripMenuItem
            // 
            this.belowNormalToolStripMenuItem.Name = "belowNormalToolStripMenuItem";
            this.belowNormalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.belowNormalToolStripMenuItem.Text = "Below Normal";
            this.belowNormalToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // idleToolStripMenuItem
            // 
            this.idleToolStripMenuItem.Name = "idleToolStripMenuItem";
            this.idleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.idleToolStripMenuItem.Text = "Idle";
            this.idleToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // whenFinishedToolStripMenuItem
            // 
            this.whenFinishedToolStripMenuItem.Name = "whenFinishedToolStripMenuItem";
            this.whenFinishedToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.whenFinishedToolStripMenuItem.Text = "When Finished";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::VideoCutterJoinerExpert.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tsiDownload
            // 
            this.tsiDownload.Name = "tsiDownload";
            this.tsiDownload.Size = new System.Drawing.Size(167, 20);
            this.tsiDownload.Text = "&Download Free Applications";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpUsersManualToolStripMenuItem,
            this.visit4dotsSoftwareWebpageToolStripMenuItem,
            this.followUsOnTwitterToolStripMenuItem,
            this.feedbackToolStripMenuItem,
            this.checkForNewVersionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "&Help";
            // 
            // helpUsersManualToolStripMenuItem
            // 
            this.helpUsersManualToolStripMenuItem.Image = global::VideoCutterJoinerExpert.Properties.Resources.help2;
            this.helpUsersManualToolStripMenuItem.Name = "helpUsersManualToolStripMenuItem";
            this.helpUsersManualToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpUsersManualToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.helpUsersManualToolStripMenuItem.Text = "Help - &User\'s Manual";
            this.helpUsersManualToolStripMenuItem.Click += new System.EventHandler(this.helpUsersManualToolStripMenuItem_Click);
            // 
            // visit4dotsSoftwareWebpageToolStripMenuItem
            // 
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Image = global::VideoCutterJoinerExpert.Properties.Resources.earth;
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Name = "visit4dotsSoftwareWebpageToolStripMenuItem";
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Text = "&Visit softpcapps Software Webpage";
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Click += new System.EventHandler(this.visit4dotsSoftwareWebpageToolStripMenuItem_Click);
            // 
            // followUsOnTwitterToolStripMenuItem
            // 
            this.followUsOnTwitterToolStripMenuItem.Image = global::VideoCutterJoinerExpert.Properties.Resources.social_twitter_box_white_icon_24;
            this.followUsOnTwitterToolStripMenuItem.Name = "followUsOnTwitterToolStripMenuItem";
            this.followUsOnTwitterToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.followUsOnTwitterToolStripMenuItem.Text = "Follow us on Twitter";
            this.followUsOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.followUsOnTwitterToolStripMenuItem_Click);
            // 
            // feedbackToolStripMenuItem
            // 
            this.feedbackToolStripMenuItem.Image = global::VideoCutterJoinerExpert.Properties.Resources.edit;
            this.feedbackToolStripMenuItem.Name = "feedbackToolStripMenuItem";
            this.feedbackToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.feedbackToolStripMenuItem.Text = "&Feedback";
            this.feedbackToolStripMenuItem.Click += new System.EventHandler(this.feedbackToolStripMenuItem_Click);
            // 
            // checkForNewVersionToolStripMenuItem
            // 
            this.checkForNewVersionToolStripMenuItem.Name = "checkForNewVersionToolStripMenuItem";
            this.checkForNewVersionToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.checkForNewVersionToolStripMenuItem.Text = "Check For New Version";
            this.checkForNewVersionToolStripMenuItem.Click += new System.EventHandler(this.checkForNewVersionToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "cselect";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.NullValue = false;
            this.dataGridViewCheckBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewCheckBoxColumn1.Frozen = true;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Select";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 49;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "cname";
            this.dataGridViewTextBoxColumn1.HeaderText = "Filename";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 82;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "clength";
            this.dataGridViewTextBoxColumn2.HeaderText = "Duration";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "cformat";
            this.dataGridViewTextBoxColumn3.HeaderText = "Video Format";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 106;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "caudioformat";
            this.dataGridViewTextBoxColumn4.HeaderText = "Audio Format";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 106;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "caudiosamplingrate";
            this.dataGridViewTextBoxColumn5.HeaderText = "Sampling Rate (Hz)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 141;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "cwidth";
            this.dataGridViewTextBoxColumn6.HeaderText = "Width";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 65;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "cheight";
            this.dataGridViewTextBoxColumn7.HeaderText = "Height";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 69;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "cvideofps";
            this.dataGridViewTextBoxColumn8.HeaderText = "Frames per second";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 139;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "cvideobitrate";
            this.dataGridViewTextBoxColumn9.HeaderText = "Video Bitrate (kbps)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 144;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "cvideocolordepth";
            this.dataGridViewTextBoxColumn10.HeaderText = "Video Color Depth";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 135;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "cvideoaspect";
            this.dataGridViewTextBoxColumn11.HeaderText = "Video Aspect";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 107;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "caudiobitrate";
            this.dataGridViewTextBoxColumn12.HeaderText = "Bitrate (kbps)";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 108;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "caudionch";
            this.dataGridViewTextBoxColumn13.HeaderText = "Channels";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 84;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "csize";
            this.dataGridViewTextBoxColumn14.HeaderText = "Size (MB)";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 86;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "cprofile";
            this.dataGridViewTextBoxColumn15.HeaderText = "Profile";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Visible = false;
            this.dataGridViewTextBoxColumn15.Width = 68;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "cinputfile";
            this.dataGridViewTextBoxColumn16.HeaderText = "Input File";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 85;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "coutputfile";
            this.dataGridViewTextBoxColumn17.HeaderText = "Output File";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Visible = false;
            this.dataGridViewTextBoxColumn17.Width = 94;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "ccreationdate";
            this.dataGridViewTextBoxColumn18.HeaderText = "Creation Date";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 110;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "clastmodified";
            this.dataGridViewTextBoxColumn19.HeaderText = "Last Modified";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Width = 108;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "clengthsecs";
            this.dataGridViewTextBoxColumn20.HeaderText = "Duration (seconds)";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Visible = false;
            this.dataGridViewTextBoxColumn20.Width = 139;
            // 
            // frmClip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 691);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(300, 303);
            this.Name = "frmClip";
            this.ShowInTaskbar = true;
            this.Text = "Clip";
            this.Activated += new System.EventHandler(this.frmClip_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClip_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClip_FormClosed);
            this.Load += new System.EventHandler(this.frmClip_Load);
            this.cmsZoom.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tsCut.ResumeLayout(false);
            this.tsCut.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.plMedia.ResumeLayout(false);
            this.plMedia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMovie)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.plMediaJ.ResumeLayout(false);
            this.plMediaJ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.FlowLayoutPanel fplSegments;
        private System.Windows.Forms.CheckBox chkJoinParts;
        private System.Windows.Forms.Label lblTotalDuration;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picMovie;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel plMedia;
        private MediaSlider.MediaSlider msVolume;
        private GlowButton.GlowButton btnMute;
        private GlowButton.GlowButton btnStop;
        private GlowButton.GlowButton btnPlay;
        private GlowButton.GlowButton btnFastForward;
        private GlowButton.GlowButton btnRewind;
        public MediaSlider.MediaSlider msPosition;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel plMediaJ;
        private MediaSlider.MediaSlider msVolumeJ;
        private GlowButton.GlowButton btnMuteJ;
        private GlowButton.GlowButton btnStopJ;
        private GlowButton.GlowButton btnPlayJ;
        private GlowButton.GlowButton btnFastForwardJ;
        private GlowButton.GlowButton btnRewindJ;
        public MediaSlider.MediaSlider msPositionJ;
        private System.Windows.Forms.Label lblTimeJ;
        private System.Windows.Forms.PictureBox picJoin;
        private System.Windows.Forms.ToolStrip tsCut;
        private System.Windows.Forms.ToolStripButton tsbCutOpenVideo;
        private System.Windows.Forms.ToolStripButton tsbStopCut;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbJoinVideos;
        private System.Windows.Forms.ToolStripButton tsbJoinAddFolder;
        private System.Windows.Forms.ToolStripButton tsbJoinRemove;
        private System.Windows.Forms.ToolStripButton tsbJoinPlayPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbCutPlayPreview;
        private System.Windows.Forms.ToolStripButton tsbCutAdd;
        private System.Windows.Forms.ToolStripButton tsbCutRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbJoinAdd;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timPlayPositionJ;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAudioFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSamplingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVideoFPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVideoBitrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorDepth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVideoAspect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBitrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannels;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInputFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutputFIle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLengthSecs;
        private System.Windows.Forms.TextBox txtJoinTotalDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tsiDownload;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiThreadPriority;
        private System.Windows.Forms.ToolStripMenuItem realTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboveNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem belowNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idleToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripButton tsbCutVideo;
        private System.Windows.Forms.ToolStripMenuItem whenFinishedToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbSetStart;
        private System.Windows.Forms.ToolStripButton tsbSetEnd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblVideoFile;
        public System.Windows.Forms.MaskedTextBox mskPos;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbMoveBackMsec;
        private System.Windows.Forms.ToolStripButton tsbMoveForwardMsec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tsbMoveBack3Min;
        private System.Windows.Forms.ToolStripButton tsbMoveForward3Min;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton tsbMoveBack30Sec;
        private System.Windows.Forms.ToolStripButton tsbMoveForward30Sec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbMoveBack1Sec;
        private System.Windows.Forms.ToolStripButton tsbMoveForward1Sec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOpenOutputFolder;
        private System.Windows.Forms.Button btnBrowseOutputFolder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timCut;
        private System.Windows.Forms.ToolStripStatusLabel lblElapsedTime;
        private System.ComponentModel.BackgroundWorker bwConvert;
        private System.Windows.Forms.ToolStripProgressBar pbarCut;
        public System.Windows.Forms.ComboBox cmbOutputFolder;
        private System.Windows.Forms.Timer timDebug;
        private System.Windows.Forms.ToolStripButton tsbIncludeMode;
        private System.Windows.Forms.ToolStripButton tsbExcludeMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.ContextMenuStrip cmsZoom;
        private System.Windows.Forms.ToolStripMenuItem ti5Seconds;
        private System.Windows.Forms.ToolStripMenuItem tiSecond;
        private System.Windows.Forms.ToolStripMenuItem ti100Msecs;
        private System.Windows.Forms.ToolStripMenuItem ti10Msecs;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.ToolStripMenuItem ti10Seconds;
        public OwnerDrawnComboBox cmbOutputFormat;
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
    }
}
