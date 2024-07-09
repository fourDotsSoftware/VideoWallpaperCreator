using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace VideoCutterJoinerExpert
{
    public partial class frmClip : VideoCutterJoinerExpert.CustomForm
    {
        public enum CutMode
        {
            Incude,
            Exclude
        }

        public static frmClip Instance = null;
        private GetCutArgsResult LastCutArgs = null;
        private int CompletedSecs = -1;
        public string FirstOutputFile = "";

        KeyMessageFilter filter;

        public CutMode CurrentCutMode = CutMode.Exclude;

        //0private StreamWriter sw = new StreamWriter(Application.StartupPath + "\\out.txt");
                
        List<SegmentPlay> lstSegmentPlay = new List<SegmentPlay>();
        int CurrentSegment = 0;

        List<JoinPlayItem> lstJoinPlay = new List<JoinPlayItem>();
        int CurrentSegmentJ = 0;

        private Color SegmentBackColor = SystemColors.Control;
        //        private Color SegmentActiveBackColor = Color.LightBlue;
        private Color SegmentActiveBackColor = Color.FromArgb(244, 240, 91);

        int LengthTotalMSecs = -1;
        int LengthISecs = -1;
        int LengthIMSecs = -1;

        string TimeEndString = "";

        string args_play = "";
        string args_playJ = "";

        bool Initialized = false;
        bool InitializedJ = false;

        enum PlayerStateEnum
        {
            Playing,
            Paused,
            Stopped,
            PlayingSegment,
            PlayingAllSegments,
            StoppedNext
        }

        PlayerStateEnum PlayerState = PlayerStateEnum.Stopped;
        PlayerStateEnum PlayerStateJ = PlayerStateEnum.Stopped;

        /// <summary>
        /// Path of selected file
        /// </summary>
        string filename = null;
        string filenameJ = null;
        /// <summary>
        /// The process Object to run Mplayer.exe
        /// </summary>

        Process ps = null;
        public string filepath = "";
        Process psJ = null;
        public string filepathJ = "";
        public int secs = 0;
        public Image MovieImage = null;
        private string MovieLength = "";

        private DataRow ParentRow=null;

        enum ThreadPriority
        {
            RealTime, High, AboveNormal, Normal, BelowNormal, Idle
        }

        ThreadPriority ThreadPriorityLevel = ThreadPriority.Normal;

        Process psFFMpeg = null;

        private bool ConversionStopped = false;
        private bool ConversionStarted = false;
        private bool ConversionPaused = false;
        private int ConversionProgressTime = 0;

        private string errstr = "";

        private List<string> CutFilesToDelete = new List<string>();
        
        private void CreateFFMpegProcess()
        {
            try
            {
                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.Kill();
                }
            }
            catch { }
            psFFMpeg = new Process();

            //Path of Mplayer exe
            psFFMpeg.StartInfo.FileName = "ffmpeg ";
            psFFMpeg.StartInfo.CreateNoWindow = true;
            psFFMpeg.StartInfo.UseShellExecute = false;
            //psFFMpeg.StartInfo.RedirectStandardInput = true;
            //psFFMpeg.StartInfo.RedirectStandardOutput = true;
            psFFMpeg.StartInfo.RedirectStandardError = true;

            psFFMpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //ffplayProcess.StartInfo.RedirectStandardOutput = true;

            /*
            for (int k = 0; k < tsiThreadPriority.DropDownItems.Count; k++)
            {
                ToolStripMenuItem tip = (ToolStripMenuItem)tsiThreadPriority.DropDownItems[k];
                if (tip.Checked)
                {
                    if (k==0)
                    {
                        if (psFFMpeg != null && !psFFMpeg.HasExited)
                        {
                            psFFMpeg.PriorityClass = ProcessPriorityClass.RealTime;
                        }
                    }
                    else if (k==1)
                    {
                        
                        if (psFFMpeg != null && !psFFMpeg.HasExited)
                        {
                            psFFMpeg.PriorityClass = ProcessPriorityClass.High;
                        }
                    }
                    else if (k==2)
                    {
                        
                        if (psFFMpeg != null && !psFFMpeg.HasExited)
                        {
                            psFFMpeg.PriorityClass = ProcessPriorityClass.Normal;
                        }
                    }
                    else if (k==3)
                    {
                        
                        if (psFFMpeg != null && !psFFMpeg.HasExited)
                        {
                            psFFMpeg.PriorityClass = ProcessPriorityClass.AboveNormal;
                        }
                    }
                    else if (k==4)
                    {
                        
                        if (psFFMpeg != null && !psFFMpeg.HasExited)
                        {
                            psFFMpeg.PriorityClass = ProcessPriorityClass.BelowNormal;
                        }
                    }
                    else if (k==5)
                    {
                        
                        if (psFFMpeg != null && !psFFMpeg.HasExited)
                        {
                            psFFMpeg.PriorityClass = ProcessPriorityClass.Idle;
                        }
                    }

                }
            }
            */

           // psFFMpeg.ErrorDataReceived += psFFMpeg_ErrorDataReceived;
           // psFFMpeg.OutputDataReceived += psFFMpeg_ErrorDataReceived;
        }

        public frmClip()
        {          

            InitializeComponent();
            
            Instance = this;
            SetEnabled(false);
            SetupJoin();
            /*
            secs=(int)dr["clengthsecs"];
            filepath=dr["cInputFile"].ToString();
            MovieImage = (Image)dr["cimage"];
            MovieLength = dr["clength"].ToString();

            ParentRow=dr;

            if (msPosition.Width>secs)
            {
                msPosition.Maximum=msPosition.Width;
            }
            else
            {
                msPosition.Maximum = secs;
            }

            msPosition.LengthSecs = secs;
            */

            ps = new Process();

            //Path of Mplayer exe
            ps.StartInfo.FileName = "mplayer ";
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardInput = true;
//            ps.StartInfo.RedirectStandardError = true;
            //-idle -input=/fifo";
            args_play = " -nofs  -noquiet  -osdlevel 0 -identify -slave -volume 0 ";
            args_play += "-nomouseinput -sub-fuzziness 1 ";

            //-wid will tell MPlayer to show output inisde our panel
            args_play += " -vo direct3d -ao dsound ";
            args_play += " -wid " + picMovie.Handle.ToString();
            int id = (int)this.Handle;//picMovie.Handle;
            //args += id;

            /*picMovie.Image = MovieImage;*/
            btnPlay.Enabled = true;

            msPositionJ.Maximum = 100;
            msPositionJ.Value = 100;
            //msPosition.IsForShowMeter = false;
            msPosition.MeterLargeStep = 3000;
            msPosition.MeterSmallStep = 600;

            filter = new KeyMessageFilter(this);
            // add the filter
            Application.AddMessageFilter(filter);
        }

        DataTable dt = new DataTable("table");

        private void SetupJoin()
        {
            psJ = new Process();

            //Path of Mplayer exe
            psJ.StartInfo.FileName = "mplayer ";
            psJ.StartInfo.CreateNoWindow = true;
            psJ.StartInfo.UseShellExecute = false;
            psJ.StartInfo.RedirectStandardInput = true;
            //-idle -input=/fifo";
            args_playJ = " -nofs -noquiet  -identify -slave ";
            args_playJ += "-nomouseinput -sub-fuzziness 1 ";

            //-wid will tell MPlayer to show output inisde our panel
            args_playJ += " -vo direct3d -ao dsound ";
            args_playJ += " -wid " + picJoin.Handle.ToString();

            dt.Columns.Add("cname");
            dt.Columns.Add("cprofile");
            dt.Columns.Add("cformat");
            dt.Columns.Add("cInputFile");
            dt.Columns.Add("cOutputFile");
            dt.Columns.Add("cTempOutputFile");
            dt.Columns.Add("cLength");
            dt.Columns.Add("clengthsecs", typeof(int));
            dt.Columns.Add("cTotalSecs", typeof(int));
            dt.Columns.Add("cCompletedSecs", typeof(int));
            dt.Columns.Add("cSize");
            dt.Columns.Add("cStatus", typeof(int));
            dt.Columns.Add("cProgress", typeof(int));
            dt.Columns.Add("ccreationdate");
            dt.Columns.Add("cLastModified");
            dt.Columns.Add("cImage", typeof(Image));
            dt.Columns.Add("cInfo");
            dt.Columns.Add("cSelect", typeof(bool));
            dt.Columns.Add("cClipId", typeof(int));
            dt.Columns.Add("cStart");
            dt.Columns.Add("cEnd");

            dt.Columns.Add("cStartSecs", typeof(int));
            dt.Columns.Add("cEndSecs", typeof(int));

            dt.Columns.Add("cParentId", typeof(int));
            dt.Columns.Add("cJoinSplitParts", typeof(bool));
            dt.Columns.Add("cShow", typeof(bool));
            dt.Columns.Add("cIsPartOfJoin", typeof(bool));
            dt.Columns.Add("cIsPartOfSplit", typeof(bool));
            dt.Columns.Add("cDisabled", typeof(bool));

            dt.Columns.Add("cWidth", typeof(int));
            dt.Columns.Add("cHeight", typeof(int));

            dt.Columns.Add("cAudioFormat");
            dt.Columns.Add("cAudioBitrate", typeof(decimal));
            dt.Columns.Add("cAudioSamplingRate", typeof(decimal));
            dt.Columns.Add("cAudioNCH", typeof(string));
            dt.Columns.Add("cVideoAspect");
            dt.Columns.Add("cVideoFPS", typeof(decimal));
            dt.Columns.Add("cVideoBitrate", typeof(decimal));
            dt.Columns.Add("cVideoColorDepth", typeof(decimal));


            //DataGridViewProgressColumn colProgress = new DataGridViewProgressColumn();
            //colProgress.Name = "colProgress";
            //colProgress.DataPropertyName = "cprogress";
            //colProgress.HeaderText = "Progress";

            //dgFiles.Columns.Add(colProgress);

            //ps.StartInfo.Arguments = args;
            //ps.Start();
                        
            //dgFiles.EnableHeadersVisualStyles = false;
            //dgFiles.DefaultCellStyle = new ForeColorDataGridViewCellStyle();

            dgFiles.AutoGenerateColumns = false;
            dgFiles.DataSource = dt;

            DatagridViewCheckBoxHeaderCell chkHeader = new DatagridViewCheckBoxHeaderCell();
            dgFiles.Columns[0].HeaderCell = chkHeader;
            chkHeader.OnCheckBoxClicked += chkHeader_OnCheckBoxClicked;

//            SetupSliderJ();
            msPositionJ.Maximum = 100;
            msPositionJ.Value = 1;


        }

        private void SetupSliderJ()
        {
            this.msPositionJ.IsForRangeSelect = false;
            this.msPositionJ.IsForShowSegment = false;
            this.msPositionJ.IsForShowTotalRange = false;

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
//            this.msPositionJ.ValueChanged += new MediaSlider.MediaSlider.ValueChangedDelegate(this.msPositionJ_ValueChanged);
  //          this.msPositionJ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.msPositionJ_MouseDown);
    //        this.msPositionJ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.msPositionJ_MouseUp);


            msPositionJ.Repaint();
            msPositionJ.DrawTrack();
        }
        void chkHeader_OnCheckBoxClicked(bool state)
        {
            foreach (DataGridViewRow row in dgFiles.Rows)
                row.Cells[0].Value = state;
        }


        bool HasStarted = false;

        void OpenFile()
        {            
            if (filename == null)
                return;
            //Close any current playing media file
            try
            {
               ps.Kill();
            }
            catch
            {
            }
                    
            try
            {
                ps.StartInfo.Arguments = args_play +" " + filename + "";
                ps.Start();

                System.Threading.Thread.Sleep(200);

                //0timDebug.Enabled = true;

                if (!Initialized)
                {
                    SendCommand("pause");
                    Initialized = true;
                }
                else
                {
                    if (btnMute.Checked)
                    {
                        SendCommand("mute 1");
                    }
                    else
                    {
                        SendCommand("set_property volume " + msVolume.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void OpenFileJ()
        {
            if (filenameJ == null)
                return;
            //Close any current playing media file
            try
            {
                psJ.Kill();
            }
            catch
            {
            }

            try
            {
                psJ.StartInfo.Arguments = args_playJ + " " + filenameJ + "";
                psJ.Start();

                System.Threading.Thread.Sleep(200);

                
                if (btnMuteJ.Checked)
                {
                    SendCommandJ("mute 1");
                }
                else
                {
                    SendCommandJ("set_property volume " + msVolumeJ.Value);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmClip_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.RemoveAt(1);

            msPosition.IsForRangeSelect = true;
            fplSegments.Left = plMedia.Left;
            
            //this.Left = frmMain.Instance.Left;
            //this.Top = frmMain.Instance.Top;
            //this.Width = frmMain.Instance.Width;
            //this.Height = frmMain.Instance.Height;

            msVolume.Maximum = 100;
            msVolume.Value = 70;

            msVolumeJ.Maximum = 100;
            msVolumeJ.Value = 70;

            this.Text = Module.ApplicationTitle;

            DownloadSuggestionsHelper ds = new DownloadSuggestionsHelper();
            ds.SetupDownloadMenuItems(tsiDownload);
            
            cmbOutputFolder.Items.Add(TranslateHelper.Translate("Same as Video's Folder"));
            cmbOutputFolder.Items.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\Video Cutter Expert Videos");
            cmbOutputFolder.SelectedIndex = 0;

            cmbOutputFormat.Items.Add(TranslateHelper.Translate("Keep same Format as Source"));
            cmbOutputFormat.Items.Add("MP4");
            cmbOutputFormat.Items.Add("WMV");
            cmbOutputFormat.Items.Add("FLV");
            cmbOutputFormat.Items.Add("AVI");
            cmbOutputFormat.Items.Add("MPEG");
            cmbOutputFormat.Items.Add("MOV");
            cmbOutputFormat.Items.Add("MKV");
            cmbOutputFormat.Items.Add("3GP");
            cmbOutputFormat.Items.Add("SWF");
            cmbOutputFormat.Items.Add("VOB");

            cmbOutputFormat.SelectedIndex = 0;

            UpdateHelper.InitializeCheckVersion();

            Label lbl = new Label();
            lbl.Text = TranslateHelper.Translate("Drag and Drop Videos Here !");
            lbl.AutoSize = true;
            lbl.Font = new Font(FontFamily.GenericSansSerif, 15);
            
            lbl.Top = tabPage1.Height / 2 - lbl.Height / 2;

            using (Graphics g = this.CreateGraphics())
            {
                SizeF sz = g.MeasureString(TranslateHelper.Translate("Drag and Drop Videos Here !"),lbl.Font);
                lbl.Left = tabPage1.Width / 2 - (int)(sz.Width / 2);
            }
            tabPage1.Controls.Add(lbl);
            
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Shutdown"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Sleep"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Hibernate"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Logoff"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Lock Workstation"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Restart"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Exit Application"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Explore Output Video"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Do Nothing"));

            foreach (ToolStripMenuItem ti in whenFinishedToolStripMenuItem.DropDownItems)
            {
                ti.Click += tiWhenFinished_Click;
            }

            if (Properties.Settings.Default.WhenFinishedIndex != -1)
            {
                ToolStripMenuItem ti = (ToolStripMenuItem)whenFinishedToolStripMenuItem.DropDownItems[Properties.Settings.Default.WhenFinishedIndex];
                ti.Checked = true;
            }

            ToolStripMenuItem tip = (ToolStripMenuItem)tsiThreadPriority.DropDownItems[Properties.Settings.Default.ThreadPriorityLevelIndex];
            tip.Checked = true;


            RepositionResize();


        }

        private void RepositionResize()
        {
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {

                if (Properties.Settings.Default.Width >= frmClip.Instance.MinimumSize.Width)
                {
                    this.Width = Properties.Settings.Default.Width;
                }
                else
                {
                    this.Width = frmClip.Instance.MinimumSize.Width;
                }

                if (Properties.Settings.Default.Height >= frmClip.Instance.MinimumSize.Height)
                {
                    this.Height = Properties.Settings.Default.Height;
                }
                else
                {
                    this.Height = frmClip.Instance.MinimumSize.Height;
                }

                if (Properties.Settings.Default.Left != -1)
                {
                    this.Left = Properties.Settings.Default.Left;
                }

                if (Properties.Settings.Default.Top != -1)
                {
                    this.Top = Properties.Settings.Default.Top;
                }
            }

            this.Show();
            this.BringToFront();
            this.Visible = true;
        }

        private void SavePositionSize()
        {
            Properties.Settings.Default.Maximized = (this.WindowState == FormWindowState.Maximized);
            Properties.Settings.Default.Left = this.Left;
            Properties.Settings.Default.Top = this.Top;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Save();

        }
        void tiWhenFinished_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem ti2 in whenFinishedToolStripMenuItem.DropDownItems)
            {
                ti2.Checked = false;
            }

            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            ti.Checked = true;

        }

        

        public void ClearSegmentBackColors()
        {
            for (int k = 0; k < fplSegments.Controls.Count; k++)
            {
                fplSegments.Controls[k].BackColor = SegmentBackColor;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {            
            MediaSegment ms = new MediaSegment();
           // ms.Width = plMedia.Width;
            ms.Width = fplSegments.Width-25;

            ms.msSegment.Width = msPosition.Width;
            //ms.msSegment.Width = fplSegments.Width - ms.btnPlay.Width - 15;
            ms.msSegment.Left = msPosition.Left;
            //ms.msSegment.Left = 0;

            ms.msSegment.IsForRangeSelect = false;
            ms.msSegment.IsForShowSegment = true;
            ms.msSegment.Maximum = msPosition.Maximum;
            ms.msSegment.LengthSecs = msPosition.LengthSecs;

            if (fplSegments.Controls.Count != 0)
            {               
                MediaSegment ms1 = fplSegments.Controls[fplSegments.Controls.Count - 1] as MediaSegment;

                if (ms1.msSegment.RangeEnd == msPosition.Maximum)
                {
                    Module.ShowMessage("Cannot add new Clip ! Your last Clip already is at the End of the Video !");
                    return;
                }

                ms.msSegment.ForSetValuePixels = true;
                ms.msSegment.RangeStartPixels = ms1.msSegment.RangeEndPixels;
                ms.msSegment.RangeEndPixels = ms1.msSegment.MaxRangeEndPixels;
                ms.msSegment.ForSetValuePixels = false;

                msPosition.ForSetValuePixels = true;
                msPosition.RangeStartPixels = ms.msSegment.RangeStartPixels;
                msPosition.RangeEndPixels = ms1.msSegment.MaxRangeEndPixels;
                
                msPosition.MinRangeStartPixels = ms1.msSegment.RangeEndPixels;

                msPosition.Value = ms.msSegment.RangeStart;

                msPosition.ForSetValuePixels = false;
            }
            else
            {
                ms.msSegment.ForSetValuePixels = true;
                ms.msSegment.RangeStartPixels = msPosition.RangeStartPixels;
                //ms.msSegment.RangeStart = msPosition.RangeStart;
                //1ms.msSegment.RangeEndPixels = msPosition.RangeEndPixels;
                ms.msSegment.RangeEndPixels = msPosition.MaxRangeEndPixels;
                //ms.msSegment.RangeEnd = msPosition.RangeEnd;

                ms.msSegment.ForSetValuePixels = false;
            }


            fplSegments.Controls.Add(ms);

            //1ms.lblSegment.Text = TranslateHelper.Translate("Clip")+" : "+ (fplSegments.Controls.Count).ToString("D2");
            ms.lblSegment.Text = (fplSegments.Controls.Count).ToString("D2");

            int dsec=ms.msSegment.RangeEnd - ms.msSegment.RangeStart;
            ms.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(dsec);
            
            //1int disec = dsec / 10;
            //1int dimsec = dsec % 10;
            
            //1TimeSpan ts = new TimeSpan(0, 0, disec);
            //1ms.mskDuration.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "." + dimsec.ToString();

            ms.mskStart.Text = FFMpegArgsHelper.GetStringFromTime(ms.msSegment.RangeStart);
            ms.mskEnd.Text = FFMpegArgsHelper.GetStringFromTime(ms.msSegment.RangeEnd);
            //1int d1sec = ms.msSegment.RangeStart;
            //1int d1isec = d1sec / 10;
            //1int d1imsec = d1sec % 10;

            //1int d2sec = ms.msSegment.RangeEnd;
            //1int d2isec = d2sec / 10;
            //1int d2imsec = d2sec % 10;
            
            //1TimeSpan tsS = new TimeSpan(0, 0, d1isec);
            //1TimeSpan tsE = new TimeSpan(0, 0, d2isec);

            //1ms.mskStart.Text = tsS.Hours.ToString("D2") + ":" + tsS.Minutes.ToString("D2") + ":" + tsS.Seconds.ToString("D2") + "." + d1imsec.ToString();
            //1ms.mskEnd.Text = tsE.Hours.ToString("D2") + ":" + tsE.Minutes.ToString("D2") + ":" + tsE.Seconds.ToString("D2") + "." + d2imsec.ToString();
                        
            fplSegments.SetFlowBreak(ms, true);
            SetActiveSegment(ms);

            UpdateVideoThumbnail();
            UpdateVideoEndThumbnail();
            UpdateTotalDuration();
        }

        private int GetMsSegmentPixels(int msposition_pixels)
        {
            // mspos.width mssegm.width
            // mspospixe x;

            if (fplSegments.Controls.Count == 0) return msposition_pixels;

            MediaSegment ms=fplSegments.Controls[0] as MediaSegment;

            return (int)((float)(msposition_pixels * ms.msSegment.Width) / (float)msPosition.Width);
        }

        private int GetMsPositionPixels(int mssegment_pixels)
        {
            // mspos.width mssegm.width
            // x;    mssegmentpixels

            if (fplSegments.Controls.Count == 0) return mssegment_pixels;

            MediaSegment ms = fplSegments.Controls[0] as MediaSegment;

            return (int)((float)(mssegment_pixels*msPosition.Width) / (float)ms.msSegment.Width);
        }


        public MediaSegment ActiveMediaSegment = null;

        public void SetActiveSegment(MediaSegment ms)
        {
            if (ms == null) return;

            ClearSegmentBackColors();
            ms.BackColor = SegmentActiveBackColor;

            //msPosition.RangeStart = ms.msSegment.RangeStart;
            //msPosition.RangeEnd = ms.msSegment.RangeEnd;
                     

            int k = fplSegments.Controls.IndexOf(ms);

            if (k > 0)
            {
                MediaSegment ms1 = (MediaSegment)fplSegments.Controls[k - 1];
                msPosition.MinRangeStartPixels = ms1.msSegment.RangeEndPixels;
            }
            else 
            {
                msPosition.MinRangeStartPixels = 0;
            }

            msPosition.ForSetValuePixels = true;

            msPosition.RangeStartPixels = ms.msSegment.RangeStartPixels;
            msPosition.RangeEndPixels = ms.msSegment.RangeEndPixels;

            msPosition.ForSetValuePixels = false;

            ActiveMediaSegment = ms;
            msPosition.Value = ms.msSegment.RangeStart;
            msPosition.Invalidate();
        }

        private void msPosition_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ActiveMediaSegment == null) return;

                MediaSegment ms = ActiveMediaSegment;

                ms.msSegment.RangeStartPixels = msPosition.RangeStartPixels;
                ms.msSegment.RangeEndPixels = msPosition.RangeEndPixels;
                //ms.msSegment.RangeStart = msPosition.RangeStart;
                //ms.msSegment.RangeEnd = msPosition.RangeEnd;

                int dsec = msPosition.RangeEnd - msPosition.RangeStart;

                if (dsec > msPosition.Maximum)
                {
                    dsec = msPosition.Maximum;
                }

                ms.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(dsec);

                //1int disec = dsec / 10;
                //1int dimsec = dsec % 10;


                //1TimeSpan ts = new TimeSpan(0, 0, disec);
                //1ms.mskDuration.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "." + dimsec.ToString();

                ms.mskStart.Text = FFMpegArgsHelper.GetStringFromTime(msPosition.RangeStart);
                ms.mskEnd.Text = FFMpegArgsHelper.GetStringFromTime(msPosition.RangeEnd);
                //1int d1sec = msPosition.RangeStart;
                //1int d1isec = d1sec / 10;
                //1int d1imsec = d1sec % 10;

                //1int d2sec = msPosition.RangeEnd;
                //1int d2isec = d2sec / 10;
                //1int d2imsec = d2sec % 10;

                //1TimeSpan tsS = new TimeSpan(0, 0, d1isec);
                //1TimeSpan tsE = new TimeSpan(0, 0, d2isec);

                //1ms.mskStart.Text = tsS.Hours.ToString("D2") + ":" + tsS.Minutes.ToString("D2") + ":" + tsS.Seconds.ToString("D2") + "." + d1imsec.ToString();
                //1ms.mskEnd.Text = tsE.Hours.ToString("D2") + ":" + tsE.Minutes.ToString("D2") + ":" + tsE.Seconds.ToString("D2") + "." + d2imsec.ToString();
                //---
                /*
                TimeSpan ts = new TimeSpan(0, 0, msPosition.RangeEnd - msPosition.RangeStart);
                ms.mskDuration.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

                TimeSpan tsS = new TimeSpan(0, 0, msPosition.RangeStart);
                TimeSpan tsE = new TimeSpan(0, 0, msPosition.RangeEnd);

                ms.mskStart.Text = tsS.Hours.ToString("D2") + ":" + tsS.Minutes.ToString("D2") + ":" + tsS.Seconds.ToString("D2");
                ms.mskEnd.Text = tsE.Hours.ToString("D2") + ":" + tsE.Minutes.ToString("D2") + ":" + tsE.Seconds.ToString("D2");
                */

                ms.Invalidate();

                UpdateTotalDuration();

                if (msPosition.InLeftRangeHandle)
                {
                    msPosition.Value = msPosition.RangeStart;
                }
                else if (msPosition.InRightRangeHandle)
                {
                    msPosition.Value = msPosition.RangeEnd;
                }
            }
        }

        private void btnDeleteSegment_Click(object sender, EventArgs e)
        {
            if (ActiveMediaSegment == null) return;
            if (fplSegments.Controls.Count == 1)
            {
                return;
            }

            MediaSegment msprevious = null;

            if (fplSegments.Controls.Count != 1)
            {
                for (int k = 1; k < fplSegments.Controls.Count; k++)
                {
                    if (fplSegments.Controls[k] == ActiveMediaSegment)
                    {
                        msprevious = (MediaSegment)fplSegments.Controls[k - 1];
                    }
                }

                if (fplSegments.Controls[0] == ActiveMediaSegment)
                {
                    msprevious = (MediaSegment)fplSegments.Controls[1];
                }
            }

            ActiveMediaSegment.Dispose();
            SetActiveSegment(msprevious);
            UpdateTotalDuration();
        }

        private string TotalDuration = "";
        private int TotalDurationSecs = 0;

        private void UpdateTotalDuration()
        {
            int secs = 0;

            foreach (MediaSegment ms in fplSegments.Controls)
            {
                secs += ms.msSegment.RangeEnd - ms.msSegment.RangeStart;    
            }

            if (secs > msPosition.Maximum)
            {
                secs = msPosition.Maximum;
            }

            //1int disec = secs / 10;
            //1int dimsec = secs % 10;

            //1TimeSpan ts = new TimeSpan(0, 0, disec);

            TotalDuration = FFMpegArgsHelper.GetStringFromTime(secs);
            
            //1TotalDuration=ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2")+"."+dimsec.ToString();
            TotalDurationSecs = secs;

            lblTotalDuration.Text = TranslateHelper.Translate("Total Duration") + " : " + TotalDuration;
        }

        private void btnFastForward_Click(object sender, EventArgs e)
        {
            //1int streampos = msPosition.Value + 10;
            int streampos = msPosition.Value + 100;

            //1if (msPosition.Value + 10 > msPosition.Maximum)
            if (msPosition.Value + 100 > msPosition.Maximum)
            {
                streampos = msPosition.Maximum;
            }

            string str = "";
            if (PlayerState == PlayerStateEnum.Paused)
            {
                str = "pausing ";
            }

            SendCommand(str + "seek 10 0");

            msPosition.Value = streampos;
            //SendCommand("pause");
        }

        private void btnFastForwardJ_Click(object sender, EventArgs e)
        {
            int streampos = msPositionJ.Value + 10;

            if (msPositionJ.Value + 10 > msPositionJ.Maximum)
            {
                streampos = msPositionJ.Maximum;
            }

            string str = "";
            if (PlayerStateJ == PlayerStateEnum.Paused)
            {
                str = "pausing ";
            }

            SendCommandJ(str + "seek 10 0");



            msPositionJ.Value = streampos;
            //SendCommand("pause");
        }

        private void btnRewind_Click(object sender, EventArgs e)
        {
            //1int streampos = msPosition.Value - 10;
            int streampos = msPosition.Value - 100;

            //1if (msPosition.Value - 10 < 0)
            if (msPosition.Value - 100 < 0)
            {
                streampos = 0;
            }

            string str = "";
            if (PlayerState == PlayerStateEnum.Paused)
            {
                str = "pausing ";
            }

            //SendCommand("set_property stream_pos " + streampos.ToString());
            SendCommand(str + "seek -10 0");
            
            msPosition.Value = streampos;
        }

        private void btnRewindJ_Click(object sender, EventArgs e)
        {
            int streampos = msPositionJ.Value - 10;

            if (msPositionJ.Value - 10 < 0)
            {
                streampos = 0;
            }

            string str = "";
            if (PlayerStateJ == PlayerStateEnum.Paused)
            {
                str = "pausing ";
            }

            //SendCommand("set_property stream_pos " + streampos.ToString());
            SendCommandJ(str + "seek -10 0");


            msPositionJ.Value = streampos;
        }

        public void SeekPosition()
        {
            if (filename == null) return;

            string str = "";
            if (PlayerState == PlayerStateEnum.Paused || PlayerState == PlayerStateEnum.Stopped)
            {
                str = "pausing ";
            }

            int dsecs = msPosition.Value / 10;
            string sms = msPosition.Value.ToString().Substring(msPosition.Value.ToString().Length - 1, 1);

            TimeSpan ts = new TimeSpan(0, 0, 0, dsecs, 0);
            lblTime.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "."+sms+" / " + MovieLength;

            SendCommand(str + "seek " + dsecs.ToString()+"."+sms + " 2 1");
            
            //System.Threading.Thread.Sleep(500);
        }

        public void SeekPositionJ()
        {
            string str = "";
            if (PlayerStateJ == PlayerStateEnum.Paused || PlayerStateJ == PlayerStateEnum.Stopped)
            {
                str = "pausing ";
            }

            TimeSpan ts = new TimeSpan(0, 0, msPositionJ.Value);
            lblTimeJ.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + " / " + dgFiles.CurrentRow.Cells["colLength"].Value.ToString();


            SendCommandJ(str + "seek " + msPositionJ.Value.ToString() + " 2");
        }

        public void msPosition_ValueChanged(object sender, EventArgs e)
        {
            //if (msPositionMouseDown && PlayerState != PlayerStateEnum.Stopped)
            //{
            if (msPositionMouseDown)
            {
                SeekPosition();
            }

            //}

            if (msPosition.Value == msPosition.Maximum)
            {
                //btnStop_Click_1(null, null);
            }
        }

        public void msPositionJ_ValueChanged(object sender, EventArgs e)
        {
            //if (msPositionMouseDown && PlayerState != PlayerStateEnum.Stopped)
            //{
            if (msPositionMouseDownJ)
            {
                SeekPositionJ();
            }

            //}

            if (msPositionJ.Value == msPositionJ.Maximum)
            {
                //btnStopJ_Click(null, null);
            }
        }

        private bool msPositionMouseDown = false;
        private bool msPositionMouseDownJ = false;

        private void msPosition_MouseDown(object sender, MouseEventArgs e)
        {
            ActiveMediaSegment.LastMskStartText = ActiveMediaSegment.mskStart.Text;
            ActiveMediaSegment.LastMskEndText = ActiveMediaSegment.mskEnd.Text;
            msPositionMouseDown = true;
        }

        private void msPositionJ_MouseDown(object sender, MouseEventArgs e)
        {
            msPositionMouseDownJ = true;
        }

        private void msPosition_MouseUp(object sender, MouseEventArgs e)
        {
            if (msPositionMouseDown)
            {
                msPositionMouseDown = false;
                UpdateVideoThumbnail();
                UpdateVideoEndThumbnail();
            }
        }

        public void UpdateVideoThumbnail()
        {
            if (ActiveMediaSegment.LastMskStartText != ActiveMediaSegment.mskStart.Text)
            {
                VideoThumbnail vt = new VideoThumbnail(filepath, ActiveMediaSegment.mskStart.Text);
                ActiveMediaSegment.picThumbnailStart.Image = vt.ThumbnailImage;
                ActiveMediaSegment.LastMskStartText = ActiveMediaSegment.mskStart.Text;
            }
        }

        public void UpdateVideoEndThumbnail()
        {
            if (ActiveMediaSegment.LastMskEndText != ActiveMediaSegment.mskStart.Text)
            {
                VideoThumbnail vt = new VideoThumbnail(filepath, ActiveMediaSegment.mskEnd.Text);
                ActiveMediaSegment.picThumbnailEnd.Image = vt.ThumbnailImage;
                ActiveMediaSegment.LastMskEndText = ActiveMediaSegment.mskEnd.Text;
            }
        }

        private void msPositionJ_MouseUp(object sender, MouseEventArgs e)
        {
            msPositionMouseDownJ = false;
        }

        private void btnPlay_MouseClick(object sender, MouseEventArgs e)
        {
            if (filepath == string.Empty)
            {
                msPosition.Maximum = 1;
                return;
            }

            if (PlayerState != PlayerStateEnum.Playing
    && PlayerState != PlayerStateEnum.PlayingSegment
    && PlayerState != PlayerStateEnum.PlayingAllSegments)
            {
                if (PlayerState == PlayerStateEnum.Paused)
                {
                    btnPlay.Image = Properties.Resources.pause;
                    SendCommand("pause");
                    PlayerState = PlayerStateEnum.Playing;

                    if (btnMute.Checked)
                    {
                        SendCommand("mute 1");
                    }
                    else
                    {
                        SendCommand("set_property volume " + msVolume.Value);
                    }

                }
                else if (PlayerState == PlayerStateEnum.Stopped)
                {
                    filename = "\"" + filepath + "\"";
                    OpenFile();
                    //msPosition.Value = 0;
                    //msPosition.Maximum = LengthTotalMSecs;
                    PlayerState = PlayerStateEnum.Playing;
                    btnStop.Enabled = true;
                    btnFastForward.Enabled = true;
                    btnRewind.Enabled = true;
                    btnPlay.Image = Properties.Resources.pause;

                    int dsecs = msPosition.Value / 10;
                    int dms = int.Parse(msPosition.Value.ToString().Substring(msPosition.Value.ToString().Length - 1, 1));
                    
                    SendCommand("seek " + dsecs.ToString()+"."+dms.ToString() + " 2 1");

                    if (btnMute.Checked)
                    {
                        SendCommand("mute 1");
                    }
                    else
                    {
                        SendCommand("set_property volume " + msVolume.Value);
                    }

                    if (msPosition.Value == msPosition.Maximum)
                    {
                        btnStop_Click_1(null, null);
                    }
                }
            }
            else
            {
                btnPlay.Image = Properties.Resources.play;
                SendCommand("pause");
                PlayerState = PlayerStateEnum.Paused;
            }

        }

        private void btnPlayJ_Click(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow != null)
            {
                if (PlayerStateJ != PlayerStateEnum.Playing)
                {
                    if (PlayerStateJ == PlayerStateEnum.Paused)
                    {
                        btnPlayJ.Image = Properties.Resources.pause;
                        SendCommandJ("pause");
                        PlayerStateJ = PlayerStateEnum.Playing;
                    }
                    else if (PlayerStateJ == PlayerStateEnum.Stopped || PlayerStateJ==PlayerStateEnum.StoppedNext)
                    {
                        string filepathJ = dgFiles.CurrentRow.Cells["colInputFile"].Value.ToString();
                        filenameJ = "\"" + filepathJ + "\"";
                        OpenFileJ();
                        msPositionJ.Value = 0;
                        msPositionJ.Maximum = (int)dgFiles.CurrentRow.Cells["colLengthSecs"].Value;
                        PlayerStateJ = PlayerStateEnum.Playing;
                        btnStopJ.Enabled = true;
                        btnFastForwardJ.Enabled = true;
                        btnRewindJ.Enabled = true;
                        btnPlayJ.Image = Properties.Resources.pause;
                    }
                }
                else
                {
                    btnPlayJ.Image = Properties.Resources.play;
                    SendCommandJ("pause");
                    PlayerStateJ = PlayerStateEnum.Paused;
                }
            }


        }


        private void btnStop_Click_1(object sender, EventArgs e)
        {
            SendCommand("stop");
            msPosition.Value = 0;
            btnPlay.Image = Properties.Resources.play;
            PlayerState = PlayerStateEnum.Stopped;
            btnFastForward.Enabled = false;
            btnRewind.Enabled = false;
            //1picMovie.Image = MovieImage;
            
        }

        private void btnStopJ_Click(object sender, EventArgs e)
        {
            SendCommandJ("stop");
            msPositionJ.Value = 0;
            btnPlayJ.Image = Properties.Resources.play;
            PlayerStateJ = PlayerStateEnum.Stopped;
            btnFastForwardJ.Enabled = false;
            btnRewindJ.Enabled = false;
        }


        /// <summary>
        /// Send command to Mplayer
        /// </summary>
        /// <param name="cmd">Command to send</param>
        /// <returns>true is command is sent otherwise false</returns>
        bool SendCommand(string cmd)
        {
            try
            {
                if (ps != null && ps.HasExited == false)
                {
                    ps.StandardInput.Write(cmd + "\n");
                    return true;
                }
                else
                {                    
                    OpenFile();
                    SeekPosition();                    
                    ps.StandardInput.Write(cmd + "\n");

                    return true;
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        bool SendCommandJ(string cmd)
        {
            try
            {
                if (psJ != null && psJ.HasExited == false)
                {
                    psJ.StandardInput.Write(cmd + "\n");
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void frmClip_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //Make sure Mplayer is exited when form is closed
                ps.Kill();
                psJ.Kill();
            }
            catch { }
        }

        private void timPlayerPosition_Tick(object sender, EventArgs e)
        {
            if (PlayerState == PlayerStateEnum.Playing
                || PlayerState==PlayerStateEnum.PlayingSegment 
                || PlayerState==PlayerStateEnum.PlayingAllSegments)
            {
                try
                {                   

                    if (msPosition.Value + 1 <= msPosition.Maximum)
                    {                       
                        msPosition.Value = msPosition.Value + 1;

                        if (PlayerState == PlayerStateEnum.PlayingSegment)
                        {
                            if (lstSegmentPlay[CurrentSegment].EndSecs <= msPosition.Value)
                            {
                                btnPlay_MouseClick(null, null);
                            }
                        }
                        else if (PlayerState == PlayerStateEnum.PlayingAllSegments)
                        {
                            if (lstSegmentPlay[CurrentSegment].EndSecs <= msPosition.Value)
                            {
                                PlayNextSegment();
                            }
                        }

                        lblTime.Text = FFMpegArgsHelper.GetStringFromTime(msPosition.Value) + " / " + MovieLength;

                        //1string sms = msPosition.Value.ToString();
                        //1int dmsecs = int.Parse(sms.Substring(sms.Length - 1, 1));

                        //1TimeSpan ts = new TimeSpan(0, 0, 0,msPosition.Value/10,0);
                        //1lblTime.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "."+dmsecs.ToString()+" / " + MovieLength;
                    }
                }
                catch { }
            }
        }

        private void timPlayerPositionJ_Tick(object sender, EventArgs e)
        {
            
            if (PlayerStateJ == PlayerStateEnum.Playing)
            {
                if (msPositionJ.Value + 1 <= msPositionJ.Maximum)
                {
                    msPositionJ.Value = msPositionJ.Value + 1;
                    TimeSpan ts = new TimeSpan(0, 0, msPositionJ.Value);
                    lblTimeJ.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + " / " + dgFiles.CurrentRow.Cells["colLength"].Value.ToString();
                }
                else
                {
                    PlayerStateJ = PlayerStateEnum.StoppedNext;
                }
            }
           /*
            else if (PlayerStateJ == PlayerStateEnum.PlayingAllSegments)
            {                         
                if (lstSegmentPlayJ[CurrentSegmentJ].EndSecs <= msPosition.Value)
                {
                    PlayNextSegmentJ();
                }                        
            }
            */
        }


        private void btnMute_MouseClick(object sender, MouseEventArgs e)
        {
            string str = "";
            if (PlayerState == PlayerStateEnum.Paused)
            {
                str = "pausing ";
            }

            SendCommand(str+"mute");
        }

        private void btnMuteJ_Click(object sender, EventArgs e)
        {
            string str = "";
            if (PlayerStateJ == PlayerStateEnum.Paused)
            {
                str = "pausing ";
            }

            SendCommandJ(str + "mute");
        }

        private void msVolume_ValueChanged(object sender, EventArgs e)
        {
            string str = "";
            if (PlayerState == PlayerStateEnum.Paused)
            {
                str = "pausing ";
            }
            SendCommand(str+"set_property volume " + msVolume.Value);

        }

        private void msVolumeJ_ValueChanged(object sender, EventArgs e)
        {
            string str = "";
            if (PlayerStateJ == PlayerStateEnum.Paused)
            {
                str = "pausing ";
            }
            SendCommandJ(str + "set_property volume " + msVolumeJ.Value);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            /*
            if (fplSegments.Controls.Count != 0)
            {
                DataRow drp = frmMain.Instance.dt.NewRow();
                for (int k = 0; k < ParentRow.Table.Columns.Count; k++)
                {
                    drp[k] = ParentRow[k];
                }

                drp["cname"] = TranslateHelper.Translate("Clip") + " - " + ParentRow["cname"].ToString();

                int iclipmax = frmMain.Instance.GetMaxClipId();

                drp["cclipid"] = iclipmax;
                drp["cJoinSplitParts"] = chkJoinParts.Checked;
                drp["cIsPartOfSplit"] = true;
                drp["cdisabled"]=!chkJoinParts.Checked;
                
                drp["cParentId"] = -1;

                // join split parts into one file...

                if (chkJoinParts.Checked)
                {
                    drp["clengthsecs"] = TotalDurationSecs;
                    drp["clength"] = TotalDuration;

                    string file = ParentRow["cInputFile"].ToString();
                    string dir = System.IO.Path.GetDirectoryName(file);
                    string filename = System.IO.Path.GetFileName(file);
                    string newfilename = drp["cname"].ToString();
                    string newfile = System.IO.Path.Combine(dir, newfilename);

                    drp["coutputfile"] = frmMain.Instance.CalculateOutputFile(newfile);
                    drp["cprogress"] = (int)0;
                    drp["cstatus"] = (int)0;
                }
                else
                {
                    // they are not joined...therefore parent row does not have an output file...
                    drp["coutputfile"] = "";
                    drp["cprogress"] = (int)-1;
                    drp["cstatus"] = (int)-1;
                }

                frmMain.Instance.dt.Rows.Add(drp);

                for (int j = 0; j < fplSegments.Controls.Count; j++)
                {
                    MediaSegment ms1 = fplSegments.Controls[j] as MediaSegment;

                    DataRow dr = frmMain.Instance.dt.NewRow();

                    for (int k = 0; k < ParentRow.Table.Columns.Count; k++)
                    {
                        dr[k] = ParentRow[k];
                    }
                                        
                    dr["cParentId"] = drp["cClipId"];
                    dr["cShow"] = true;
                    dr["cJoinSplitParts"] = chkJoinParts.Checked;
                    dr["cIsPartOfSplit"] = true;
                    dr["cdisabled"] = chkJoinParts.Checked;
                    

                    dr["cStartSecs"] = ms1.msSegment.RangeStart;
                    TimeSpan ts = new TimeSpan(0, 0, ms1.msSegment.RangeStart);
                    dr["cStart"] = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

                    dr["cEndSecs"] = ms1.msSegment.RangeEnd;
                    ts = new TimeSpan(0, 0, ms1.msSegment.RangeEnd);
                    dr["cEnd"] = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

                    int jj = j + 1;
                    dr["cname"] = TranslateHelper.Translate("Segment") + " " + jj.ToString() + " (" + dr["cStart"].ToString() +
                    " - " + dr["cend"].ToString() + ")" + " - " + ParentRow["cname"].ToString();

                    int ilen = ms1.msSegment.RangeEnd - ms1.msSegment.RangeStart;
                    dr["cLengthSecs"] = ilen;
                    ts = new TimeSpan(0, 0, ilen);
                    dr["cLength"] = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

                    string file = ParentRow["cInputFile"].ToString();
                    string dir = System.IO.Path.GetDirectoryName(file);

                    string newfilename = dr["cname"].ToString().Replace(":", "_");
                    string newfile = System.IO.Path.Combine(dir, newfilename);

                    if (!chkJoinParts.Checked)
                    {
                        dr["coutputfile"] = frmMain.Instance.CalculateOutputFile(newfile);
                        dr["cprogress"] = (int)0;
                        dr["cstatus"] = (int)0;
                    }
                    else
                    {
                        dr["cOutputFile"] = drp["cOutputFile"];
                        dr["cTempOutputFile"] = FFMpegArgsHelper.GetTempMediaFilepath(frmMain.Instance.CalculateOutputFile(newfile));
                        dr["cprogress"] = (int)-1;
                        dr["cstatus"] = (int)-1;
                    }

                    int rind = frmMain.Instance.dt.Rows.IndexOf(drp);
//                    int rind = frmMain.Instance.dt.Rows.IndexOf(ParentRow);
//                    frmMain.Instance.dt.Rows[rind]["cJoinSplitParts"] = chkJoinParts.Checked;
//                    frmMain.Instance.dt.Rows[rind]["cIsPartOfSplit"] = true;

                    frmMain.Instance.dt.Rows.InsertAt(dr, rind + 1 + j);
                }
            }
            */
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void PlaySegment(int startsecs, int endsecs)
        {
            btnStop_Click_1(null, null);
            
            CurrentSegment = 0;
            lstSegmentPlay.Clear();
            lstSegmentPlay.Add(new SegmentPlay() { StartSecs = startsecs, EndSecs = endsecs });

            msPosition.Value = startsecs;
            btnPlay_MouseClick(null, null);
            PlayerState = PlayerStateEnum.PlayingSegment;
        }

        private void PlayNextSegment()
        {
            CurrentSegment++;

            if (CurrentSegment < fplSegments.Controls.Count)
            {                                
                btnStop_Click_1(null, null);
                msPosition.Value = lstSegmentPlay[CurrentSegment].StartSecs;
                btnPlay_MouseClick(null, null);

                SetActiveSegment(fplSegments.Controls[CurrentSegment] as MediaSegment);

                PlayerState = PlayerStateEnum.PlayingAllSegments;
            }
            else
            {
                // pause
                btnPlay_MouseClick(null, null);
            }
        }

        

        private void btnPlayAll_Click(object sender, EventArgs e)
        {
            
            CurrentSegment = -1;

            lstSegmentPlay.Clear();

            for (int k = 0; k < fplSegments.Controls.Count; k++)
            {
                MediaSegment ms = fplSegments.Controls[k] as MediaSegment;                
                lstSegmentPlay.Add(new SegmentPlay() { StartSecs = ms.StartSecs, EndSecs = ms.EndSecs });
            }

            PlayNextSegment();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUninstallQuestionnaire f = new frmUninstallQuestionnaire(false);
            f.ShowDialog();
        }

        private void followUsOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.twitter.com/4dotsSoftware");
        }

        private void visit4dotsSoftwareWebpageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com");
        }

        private void helpUsersManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Application.StartupPath + "\\Video Cutter Joiner Expert - User's Manual.chm");
            System.Diagnostics.Process.Start(Module.HelpURL);
        }

        private List<string> lstImages = new List<string>();

        private void AddFile(string file)
        {
            try
            {
                //msPosition.IsForShowMeter = false;

                SetEnabled(true);
                this.Cursor = Cursors.WaitCursor;

                fplSegments.Controls.Clear();

                //  if (!Module.IsAcceptableMediaInput(file)) return;
                
                Process psImage = new Process();

                /*
                string iotempfile = System.IO.Path.GetTempFileName();

                System.IO.File.Delete(iotempfile);

                string tempdir = iotempfile + ".dir";

                if (!System.IO.Directory.Exists(tempdir))
                {
                    System.IO.Directory.CreateDirectory(tempdir);
                }

                string tempfile = tempdir + "\\00000001.jpg";

                lstImages.Add(tempfile);
                */

                //Path of Mplayer exe
                psImage.StartInfo.FileName = "mplayer ";
                psImage.StartInfo.CreateNoWindow = true;
                psImage.StartInfo.UseShellExecute = false;
                psImage.StartInfo.RedirectStandardInput = true;
                psImage.StartInfo.RedirectStandardOutput = true;
                //psImage.StartInfo.Arguments = " -ao null -frames 1 -identify \"" + file + "\" -vo jpeg:outdir=\"\"\"" + tempdir + "\"\"\"";
                psImage.StartInfo.Arguments = " -ao null -vo null -frames 0 -identify \"" + file + "\"";
                psImage.Start();
                psImage.WaitForExit();

                string str = psImage.StandardOutput.ReadToEnd();
                //        VideoInfo vi = GetVideoInfo(file, str);

                MediaInfo vi = GetInfo(file, str);

                if (vi.VideoWidth == 0)
                {
                    Module.ShowMessage("Unsupported File Type !");
                    SetEnabled(false);
                    return;
                }

                int ipos = str.IndexOf("ID_LENGTH=");

                if (ipos > 0)
                {
                    ipos = ipos + "ID_LENGTH=".Length;
                    int epos = str.IndexOf("\r", ipos);
                    string slen = str.Substring(ipos, epos - ipos);
                    int dpos = slen.LastIndexOf(".");
                    int dint = int.Parse(slen.Substring(0, dpos));
                    int ddec = int.Parse(slen.Substring(dpos + 1, 1));
                    
                    int dms = 10 * dint + ddec;

                    //decimal dlen = (decimal)dint + (decimal)ddec/(decimal)10;                    
                    //int len = (int)decimal.Parse(slen);

                    LengthTotalMSecs = dms;
                    LengthISecs = dint;
                    LengthIMSecs = ddec * 100;

                    secs = dms;

                    msPosition.Value = 0;
                    msPosition.Maximum = dms;

                    TimeSpan ts = new TimeSpan(0, 0, 0, dint, ddec * 100);

                    MovieLength = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "."+ddec.ToString();
                    
                }

                if (!psImage.HasExited)
                {
                    psImage.Kill();
                }

                psImage.Dispose();

                /*
                Image img = Image.FromFile(tempfile);
                Image img2 = (Image)img.Clone();

                int iwidth = img2.Width;
                int iheight = img2.Height;
                int newheight = 0;
                int newwidth = 0;

                if (iwidth > iheight)
                {
                    newheight = (int)(((float)picMovie.Width / (float)img2.Width) * img2.Height);
                    newwidth = picMovie.Width;

                }
                else
                {
                    newwidth = (int)(((float)picMovie.Height / (float)img2.Height) * img2.Width);
                    newheight = picMovie.Height;
                }

                Bitmap bmp = new Bitmap(img2, newwidth, newheight);
                img.Dispose();
                img2.Dispose();
                MovieImage = bmp;
                picMovie.BackColor = Color.Black;
                picMovie.Image = MovieImage;
                 
                */


                //dgFiles.RowHasDetailTable[dt.Rows.Count - 1] = true;
                
                msPosition.IsForRangeSelect = true;
                msPosition.Invalidate();
                btnPlay.Enabled = true;
                filepath = file;
                TimeSpan ts1 = new TimeSpan(0, 0, 0, LengthISecs, LengthIMSecs);
                
                int lms = LengthIMSecs / 100;

                lblTime.Text = ts1.Hours.ToString("D2") + ":" + ts1.Minutes.ToString("D2") + ":" + ts1.Seconds.ToString("D2") + "."+lms.ToString() + " / " + MovieLength;

                if (msPosition.Width > LengthTotalMSecs)
                {
                    //1msPosition.Maximum = msPosition.Width;

                    msPosition.Maximum = LengthTotalMSecs;
                }
                else
                {
                    msPosition.Maximum = LengthTotalMSecs;
                }

                msPosition.LengthSecs = LengthTotalMSecs;

                btnAdd_Click(null, null);

                TimeSpan ts2 = new TimeSpan(0, 0, 0);
                lblTime.Text = "00:00:00.0" + " / " + MovieLength;

                //btnPlay_MouseClick(null, null);
                //System.Threading.Thread.Sleep(300);
                //btnPlay_MouseClick(null, null);

                filename = "\"" + file + "\"";
                Initialized = false;
                OpenFile();
                Initialized = true;
                
                /*
                if (System.IO.File.Exists(tempfile))
                {
                    //System.IO.File.Delete(tempfile);
                }

                if (System.IO.Directory.Exists(tempdir))
                {
                    //  System.IO.Directory.Delete(tempdir);
                }
                  */
                              
                GC.Collect();

                btnPlay.Enabled = true;

                Initialized = true;

                //msPosition.IsForShowMeter = true;
                msPosition.Invalidate();
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void tsbAddFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.SelectedPath == String.Empty)
            {
                folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    string[] filez = System.IO.Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.*", SearchOption.AllDirectories);

                    for (int k = 0; k < filez.Length; k++)
                    {
                        try
                        {
                            if (Module.AcceptableMediaInputPattern.IndexOf("*" + System.IO.Path.GetExtension(filez[k]).ToLower() + ";") >= 0)
                            {
                                AddFileJ(filez[k]);
                            }
                        }
                        catch { }
                    }

                }
                finally
                {
                    this.Cursor = null;
                }
            }
        }


        private void btnOpenVideo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Module.OpenFilesFilter;

            openFileDialog1.Multiselect = false;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AddFile(openFileDialog1.FileName);
                tlblVideoFile.Text = openFileDialog1.FileName;
            }

            /*
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int k = 0; k < openFileDialog1.FileNames.Length; k++)
                {
                    AddFile(openFileDialog1.FileNames[k]);
                }
            }*/
        }

        private MediaInfo GetInfo(string filepath, string str)
        {
            MediaInfo vi = new MediaInfo();

            string info = "";

            str = str.Replace("==========================================================================", "===\r\n");
            StringReader sr = new StringReader(str);

            string line = null;

            bool wrote_clip_info = false;
            bool in_clip_info_value = false;

            FileInfo fi = new FileInfo(filepath);

            info += TranslateHelper.Translate("File Information") + "\r\n\r\n";
            info += TranslateHelper.Translate("Filename") + " : " + filepath + "\r\n";
            info += TranslateHelper.Translate("Extension") + " : " + System.IO.Path.GetExtension(filepath) + "\r\n";


            decimal dkb = (decimal)fi.Length / (decimal)1024;

            decimal dmb = dkb / (decimal)1024;

            info += TranslateHelper.Translate("File Size (KB)") + " : " + dkb.ToString("#.00") + "\r\n";
            info += TranslateHelper.Translate("File Size (MB)") + " : " + dmb.ToString("#.00") + "\r\n";
            info += TranslateHelper.Translate("Last modified") + " : " + fi.LastWriteTime.ToString() + "\r\n";
            info += TranslateHelper.Translate("Creation Date") + " : " + fi.CreationTime.ToString() + "\r\n";

            info += "\r\n\r\n";

            bool wrote_video_stream_info = false;
            bool wrote_audio_stream_info = false;
            bool opened_audio_decoder = false;

            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("Opening audio decoder:"))
                {
                    opened_audio_decoder = true;
                }

                if (line.StartsWith("ID_CLIP_INFO") && !wrote_clip_info)
                {
                    info += TranslateHelper.Translate("Clip Info") + "\r\n\r\n";
                    in_clip_info_value = false;
                    wrote_clip_info = true;
                }

                if (line.StartsWith("ID_VIDEO_FORMAT") && !wrote_video_stream_info)
                {
                    info += "\r\n" + TranslateHelper.Translate("Video Stream Info") + "\r\n\r\n";

                    wrote_video_stream_info = true;
                }

                if (line.StartsWith("ID_AUDIO_FORMAT") && !wrote_audio_stream_info)
                {
                    info += "\r\n" + TranslateHelper.Translate("Audio Stream Info") + "\r\n\r\n";

                    wrote_audio_stream_info = true;
                    in_clip_info_value = false;
                }

                if (line.StartsWith("ID_CLIP_INFO_NAME"))
                {
                    int spos = line.IndexOf("=");
                    info += line.Substring(spos + 1) + " : ";
                    in_clip_info_value = false;
                }
                else if (line.StartsWith("ID_CLIP_INFO_N="))
                {
                    in_clip_info_value = false;
                }
                else if (line.StartsWith("ID_CLIP_INFO_VALUE"))
                {
                    int spos = line.IndexOf("=");
                    info += line.Substring(spos + 1) + "\r\n";

                    in_clip_info_value = true;

                    continue;
                }
                else if (line.StartsWith("Load subtitles"))
                {
                    info += line + "\r\n";
                    in_clip_info_value = false;
                }
                else if (line.StartsWith("ID_DEMUXER"))
                {
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Demuxer") + " : " + line.Substring(spos + 1) + "\r\n";
                    in_clip_info_value = false;
                }
                else if (line.StartsWith("VIDEO:"))
                {
                    string[] vinfo = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    string vinfo_fps = "";
                    string vinfo_kbps = "";

                    for (int l = 0; l < vinfo.Length; l++)
                    {
                        if (vinfo[l] == "fps")
                        {
                            vinfo_fps = vinfo[l - 1];
                        }
                        else if (vinfo[l] == "kbps")
                        {
                            vinfo_kbps = vinfo[l - 1];
                        }


                    }

                    info += TranslateHelper.Translate("Video Format") + " : " + vinfo[1] + "\r\n";
                    info += TranslateHelper.Translate("Video Size") + " : " + vinfo[2] + "\r\n";
                    info += TranslateHelper.Translate("Video Color Depth") + " : " + vinfo[3] + "\r\n";
                    info += TranslateHelper.Translate("Video Frames Per Second") + " : " + vinfo_fps + " fps" + "\r\n";
                    info += TranslateHelper.Translate("Video Bitrate") + " : " + vinfo_kbps + " kbps" + "\r\n\r\n";

                    in_clip_info_value = false;
                    try
                    {
                        decimal color_depth = decimal.Parse(vinfo[3].Substring(0, vinfo[3].Length - 3), new System.Globalization.CultureInfo("en-US"));
                        vi.ColorDepth = color_depth;
                    }
                    catch { }
                    vi.FramesPerSecond = decimal.Parse(vinfo_fps, new System.Globalization.CultureInfo("en-US"));
                    vi.Bitrate = decimal.Parse(vinfo_kbps, new System.Globalization.CultureInfo("en-US"));
                    vi.VideoFormat = vinfo[1];

                }
                else if (line.StartsWith("ID_VIDEO_FORMAT"))
                {
                    int spos = line.IndexOf("=");
                    //info += TranslateHelper.Translate("Video Format") + " : " + line.Substring(spos+1)+"\r\n";
                    //vi.VideoFormat = line.Substring(spos + 1);

                    int spos2 = str.IndexOf("ID_VIDEO_CODEC=");
                    int epos2 = str.IndexOf("\n", spos2);
                    info += TranslateHelper.Translate("Video Codec") + " : " + str.Substring(spos2 + "ID_VIDEO_CODEC=".Length, epos2 - spos2 - "ID_VIDEO_CODEC=".Length) + "\r\n\r\n";
                    in_clip_info_value = false;
                }
                else if (line.StartsWith("ID_VIDEO_BITRATE"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    decimal decbitrate = decimal.Parse(line.Substring(spos + 1), new System.Globalization.CultureInfo("en-US"));
                    decimal dbrB = decbitrate / (decimal)1024;
                    decimal dbrk = decbitrate / (decimal)1000;

                    //info += TranslateHelper.Translate("Bitrate (kbps)") + " : " + dbrk.ToString("#.0") + "\r\n";
                    //info += TranslateHelper.Translate("Bitrate (kbytes/sec)") + " : " + dbrB.ToString("#.0#") + "\r\n";

                    //vi.Bitrate = dbrk;

                }
                else if (line.StartsWith("ID_VIDEO_WIDTH"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Width") + " : " + line.Substring(spos + 1) + "\r\n";

                    try
                    {
                        vi.VideoWidth = int.Parse(line.Substring(spos + 1));
                    }
                    catch { }

                }
                else if (line.StartsWith("ID_VIDEO_HEIGHT"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Height") + " : " + line.Substring(spos + 1) + "\r\n";

                    try
                    {
                        vi.VideoHeight = int.Parse(line.Substring(spos + 1));
                    }
                    catch { }
                }
                else if (line.StartsWith("ID_VIDEO_FPS"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    //info += TranslateHelper.Translate("Frames per Seconds (fps)") + " : " + line.Substring(spos+1) + "\r\n";
                    decimal decfps = decimal.Parse(line.Substring(spos + 1), new System.Globalization.CultureInfo("en-US"));
                    //vi.FramesPerSecond = decfps;

                }
                else if (line.StartsWith("ID_VIDEO_ASPECT"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Aspect") + " : " + line.Substring(spos + 1) + ":1\r\n";
                    vi.VideoAspect = line.Substring(spos + 1) + ":1";
                }
                else if (line.StartsWith("ID_AUDIO_FORMAT"))
                {

                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Audio Format") + " : " + line.Substring(spos + 1) + "\r\n";

                    vi.AudioFormat = line.Substring(spos + 1);

                    int spos2 = str.IndexOf("ID_AUDIO_CODEC=");
                    int epos2 = str.IndexOf("\n", spos2);
                    info += TranslateHelper.Translate("Audio Codec") + " : " + str.Substring(spos2 + "ID_AUDIO_CODEC=".Length, epos2 - spos2 - "ID_AUDIO_CODEC=".Length) + "\r\n\r\n";
                }
                else if (opened_audio_decoder && line.StartsWith("ID_AUDIO_BITRATE"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    decimal decbitrate = decimal.Parse(line.Substring(spos + 1), new System.Globalization.CultureInfo("en-US"));
                    decimal deckb = decbitrate / (decimal)1000;
                    info += TranslateHelper.Translate("Audio Bitrate (kbps)") + " : " + deckb.ToString("#.0") + "\r\n";

                    vi.AudioBitrate = deckb;
                }
                else if (opened_audio_decoder && line.StartsWith("ID_AUDIO_RATE"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    string sampling_rate = line.Substring(spos + 1);
                    decimal decrate = decimal.Parse(sampling_rate, new System.Globalization.CultureInfo("en-US"));

                    info += TranslateHelper.Translate("Audio Sampling Rate (Hz)") + " : " + decrate.ToString("#.0") + "\r\n";

                    vi.AudioSamplingRate = decrate;
                }
                else if (opened_audio_decoder && line.StartsWith("ID_AUDIO_NCH"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Number Of Channels") + " : " + line.Substring(spos + 1) + "\r\n";

                    if (line.Substring(spos + 1) == "2")
                    {
                        vi.Channels = "Stereo";
                    }
                    else
                    {
                        vi.Channels = "Mono";
                    }
                }
                else if (line.StartsWith("ID_LENGTH"))
                {
                    in_clip_info_value = false;
                    info += "\r\n" + TranslateHelper.Translate("Other Information") + "\r\n\r\n";
                    int spos = line.IndexOf("=");
                    int isecs = (int)decimal.Parse(line.Substring(spos + 1), new System.Globalization.CultureInfo("en-US"));
                    TimeSpan ts = new TimeSpan(0, 0, isecs);

                    info += TranslateHelper.Translate("Clip Length (time)") + " : " + ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "\r\n";
                }
                else if (line.StartsWith("ID_SEEKABLE"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Seekable") + " : " + (line.Substring(spos + 1) == "1" ? TranslateHelper.Translate("True") : TranslateHelper.Translate("False")) + "\r\n";
                }
                else if (line.StartsWith("ID_CHAPTERS"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Chapters") + " : " + line.Substring(spos + 1) + "\r\n";

                }

                if (in_clip_info_value)
                {
                    info += line + "\r\n";
                }
            }

            vi.Text = info;

            return vi;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSetEnd_Click(object sender, EventArgs e)
        {
            if (msPosition.Value <= ActiveMediaSegment.msSegment.RangeStart) 
            {
                return;
            }

            ActiveMediaSegment.msSegment.SetRangeEnd(msPosition.Value);

            this.Invalidate();

            frmClip.Instance.msPosition.SetRangeEnd(msPosition.Value);
            frmClip.Instance.msPosition.Invalidate();
                        
            frmClip.Instance.SeekPosition();

            ActiveMediaSegment.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.msSegment.RangeEnd - ActiveMediaSegment.msSegment.RangeStart);

            //1int dsec = ActiveMediaSegment.msSegment.RangeEnd - ActiveMediaSegment.msSegment.RangeStart;
            //1int disec = dsec / 10;
            //1int dimsec = dsec % 10;
            
            //1TimeSpan ts1 = new TimeSpan(0, 0, disec);
            //1ActiveMediaSegment.mskDuration.Text = ts1.Hours.ToString("D2") + ":" + ts1.Minutes.ToString("D2") + ":" + ts1.Seconds.ToString("D2") + "." + dimsec.ToString();

            ActiveMediaSegment.mskEnd.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.msSegment.RangeEnd);

            //1int d1sec=ActiveMediaSegment.msSegment.RangeEnd;
            //1int d1isec = d1sec / 10;
            //1int d1imsec = d1isec % 10;

            //1ts1 = new TimeSpan(0, 0, d1isec);
            //1ActiveMediaSegment.mskEnd.Text = ts1.Hours.ToString("D2") + ":" + ts1.Minutes.ToString("D2") + ":" + ts1.Seconds.ToString("D2") + "." + d1imsec.ToString();

            UpdateVideoEndThumbnail();
            UpdateTotalDuration();
        }

        private void SetEnabled(bool enabled)
        {
            groupBox2.Visible = enabled;            
            tsbCutAdd.Enabled = enabled;
            tsbCutRemove.Enabled = enabled;
            tsbSetStart.Enabled = enabled;
            tsbSetEnd.Enabled = enabled;
            tsbCutVideo.Enabled = enabled;

            tsbExcludeMode.Enabled = enabled;
            tsbIncludeMode.Enabled = enabled;

            tsbJoinPlayPreview.Enabled = enabled;
            tsbStopCut.Enabled = enabled;
            chkJoinParts.Visible = enabled;
            lblTotalDuration.Visible = enabled;
            tsbCutPlayPreview.Enabled = enabled;
        }

        private void btnSetClipStart_Click(object sender, EventArgs e)
        {
            ActiveMediaSegment.msSegment.SetRangeStart(msPosition.Value);

            this.Invalidate();

            frmClip.Instance.msPosition.SetRangeStart(msPosition.Value);
            frmClip.Instance.msPosition.Invalidate();

            frmClip.Instance.SeekPosition();

            ActiveMediaSegment.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.msSegment.RangeEnd - ActiveMediaSegment.msSegment.RangeStart);

            //1int dsec = ActiveMediaSegment.msSegment.RangeEnd - ActiveMediaSegment.msSegment.RangeStart;
            //1int disec = dsec / 10;
            //1int dimsec = dsec % 10;
            
            //1TimeSpan ts1 = new TimeSpan(0, 0,disec);
            //1ActiveMediaSegment.mskDuration.Text = ts1.Hours.ToString("D2") + ":" + ts1.Minutes.ToString("D2") + ":" + ts1.Seconds.ToString("D2") + "." + dimsec.ToString();

            ActiveMediaSegment.mskStart.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.msSegment.RangeStart);

            //1int dtsec = ActiveMediaSegment.msSegment.RangeStart;
            //1int dtisec = dtsec / 10;
            //1int dtimsec = dtsec % 10;

            //1ts1 = new TimeSpan(0, 0, dtisec);
            //1ActiveMediaSegment.mskStart.Text = ts1.Hours.ToString("D2") + ":" + ts1.Minutes.ToString("D2") + ":" + ts1.Seconds.ToString("D2") + "." + dtimsec.ToString();

            UpdateVideoThumbnail();
            UpdateTotalDuration();
        }

        private bool IsDragging = false;

        private void dgFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                IsDragging = true;
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void dgFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    AddFile(filez[k]);
                }
            }
        }

        private void CalculateTotalJoinDuration()
        {
            int total = 0;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (dt.Rows[k]["cselect"].ToString() == bool.TrueString)
                {
                    total += (int)dt.Rows[k]["clengthsecs"];
                }
            }

            TimeSpan ts=new TimeSpan(0,0,total);
            txtJoinTotalDuration.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

        }


        private void dgFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                //bool bval = (bool)dgFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                //dgFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !bval;

                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)dgFiles.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (ch1.Value == null)
                    ch1.Value = false;
                switch (ch1.Value.ToString())
                {
                    case "True":
                        ch1.Value = false;
                        break;
                    case "False":
                        ch1.Value = true;
                        break;
                }

                CalculateTotalJoinDuration();
            }
        }

        private void dgFiles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgFiles_CellContentClick(sender, e);
        }

        private void AddFileJ(string file)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //  if (!Module.IsAcceptableMediaInput(file)) return;

                DataRow dr = dt.NewRow();
                dr["cInputFile"] = file;
        //        dr["coutputfile"] = CalculateOutputFile(file);

                System.IO.FileInfo fi = new System.IO.FileInfo(file);
                long lsize = fi.Length;
                decimal dsize = (decimal)lsize / (decimal)1024;
                decimal dsizemb = dsize / (decimal)1024;


                dr["cname"] = fi.Name;
          //      dr["cprofile"] = cmbProfile.Text;
                dr["cSize"] = dsizemb.ToString("#.00");
                dr["clastmodified"] = fi.LastWriteTime.ToString();
                dr["cprogress"] = (int)0;
                dr["ccreationdate"] = fi.CreationTime.ToString();


                dr["cselect"] = true;

                dr["cParentId"] = -1;
                dr["cJoinSplitParts"] = false;
                dr["cShow"] = true;
                dr["cIsPartOfJoin"] = false;

                Process psImage = new Process();

                string iotempfile = System.IO.Path.GetTempFileName();

                System.IO.File.Delete(iotempfile);

                string tempdir = iotempfile + ".dir";

                if (!System.IO.Directory.Exists(tempdir))
                {
                    System.IO.Directory.CreateDirectory(tempdir);
                }

                string tempfile = tempdir + "\\00000001.jpg";

                lstImages.Add(tempfile);

                //Path of Mplayer exe
                psImage.StartInfo.FileName = "mplayer ";
                psImage.StartInfo.CreateNoWindow = true;
                psImage.StartInfo.UseShellExecute = false;
                psImage.StartInfo.RedirectStandardInput = true;
                psImage.StartInfo.RedirectStandardOutput = true;
                psImage.StartInfo.Arguments = " -ao null -frames 1 -identify \"" + file + "\" -vo jpeg:outdir=\"\"\"" + tempdir + "\"\"\"";
                psImage.Start();
                psImage.WaitForExit();

                string str = psImage.StandardOutput.ReadToEnd();
                //        VideoInfo vi = GetVideoInfo(file, str);

                MediaInfo vi = VideoInfoHelper.GetInfo(file, str);

                if (vi.VideoWidth == 0)
                {
                    Module.ShowMessage("Unsupported File Type !");
                    return;
                }
                dr["cwidth"] = vi.VideoWidth;
                dr["cheight"] = vi.VideoHeight;

                int iclipmax = 0;
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    int iclipid = (int)dt.Rows[k]["cclipid"];
                    if (iclipid >= iclipmax)
                    {
                        iclipmax++;
                    }
                }


                dr["cclipid"] = iclipmax;
                dr["cinfo"] = vi.Text;

                dr["cAudioFormat"] = vi.AudioFormat;
                dr["cAudioBitrate"] = vi.AudioBitrate;
                dr["cAudioSamplingRate"] = vi.AudioSamplingRate;
                dr["cAudioNCH"] = vi.Channels;
                dr["cVideoAspect"] = vi.VideoAspect;
                dr["cVideoFPS"] = vi.FramesPerSecond;
                dr["cVideoBitrate"] = vi.Bitrate;
                dr["cVideoColorDepth"] = vi.ColorDepth;

                /*
                if (string.IsNullOrEmpty(vi.VideoFormat))
                {
                    dr["cformat"] = vi.AudioFormat;
                }
                else
                {
                    dr["cformat"] = vi.VideoFormat;
                }
                */

                //dr["cformat"] = System.IO.Path.GetExtension(file).Substring(1).ToUpper();
                dr["cFormat"] = vi.VideoFormat;

                //dr["cchannels"] = vi.Channels;
                // dr["cbitrate"] = vi.Bitrate;
                //  dr["csamplingrate"] = vi.SamplingRate;

                int ipos = str.IndexOf("ID_LENGTH=");

                if (ipos > 0)
                {
                    ipos = ipos + "ID_LENGTH=".Length;
                    int epos = str.IndexOf("\r", ipos);
                    string slen = str.Substring(ipos, epos - ipos);
                    int len = (int)decimal.Parse(slen);

                    dr["clengthsecs"] = len;
                    dr["ctotalsecs"] = len;

                    TimeSpan ts = new TimeSpan(0, 0, len);

                    dr["clength"] = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");
                    dr["cstart"] = "00:00:00";
                    dr["cend"] = dr["clength"];
                }

                if (!psImage.HasExited)
                {
                    psImage.Kill();
                }

                psImage.Dispose();

                Image img = Image.FromFile(tempfile);
                Image img2 = (Image)img.Clone();

                int iwidth = img2.Width;
                int iheight = img2.Height;
                int newheight = 0;
                int newwidth = 0;

                if (iwidth > iheight)
                {
                    newheight = (int)(((float)picJoin.Width / (float)img2.Width) * img2.Height);
                    newwidth = picJoin.Width;

                }
                else
                {
                    newwidth = (int)(((float)picJoin.Height / (float)img2.Height) * img2.Width);
                    newheight = picJoin.Height;
                }

                Bitmap bmp = new Bitmap(img2, newwidth, newheight);
                img.Dispose();
                img2.Dispose();
                dr["cImage"] = bmp;
                picJoin.BackColor = Color.Black;

                //dgFiles.RowHasDetailTable[dt.Rows.Count - 1] = true;

                btnPlay.Enabled = true;

                if (System.IO.File.Exists(tempfile))
                {
                    //System.IO.File.Delete(tempfile);
                }

                if (System.IO.Directory.Exists(tempdir))
                {
                    //  System.IO.Directory.Delete(tempdir);
                }

                dt.Rows.Add(dr);

                GC.Collect();

                btnPlayJ.Enabled = true;
                tsbJoinPlayPreview.Enabled = true;
                tsbJoinRemove.Enabled = true;
                tsbJoinVideos.Enabled = true;

                CalculateTotalJoinDuration();
            }
            finally
            {
                this.Cursor = null;
            }

        }

        string LastInputFile = "";

        private void dgFiles_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow == null)
            {
                btnStopJ_Click(null, null);
                picJoin.Image = null;
                return;
            }
            if (dgFiles.CurrentRow.Cells["colInputFile"].Value.ToString() != LastInputFile)
            {
                if (dgFiles.CurrentRow.Cells["colInputFile"].Value.ToString() != LastInputFile)
                {
                    btnStopJ_Click(null, null);
                    picJoin.Image = null;
                }

                LastInputFile = dgFiles.CurrentRow.Cells["colInputFile"].Value.ToString();

                //SendCommand("loadfile " + LastInputFile);
                //SendCommand("pauing seek 1 0");

                DataRowView drv = (DataRowView)dgFiles.CurrentRow.DataBoundItem;
                if (!Convert.IsDBNull(drv.Row["cimage"]))
                {
                    picJoin.Image = (Image)drv.Row["cimage"];
                }
                else
                {
                    picJoin.Image = null;
                }

                msPositionJ.Value = 0;
                //1todo     msPosition.Maximum = int.Parse(drv.Row["clengthsecs"].ToString());


            }
        }

        private void tsbJoinAdd_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Module.OpenFilesFilter;

            openFileDialog1.Multiselect = true;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int k = 0; k < openFileDialog1.FileNames.Length; k++)
                {
                    AddFileJ(openFileDialog1.FileNames[k]);
                }
            }

        }

        private void tsbJoinRemove_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgsel = dgFiles.SelectedRows;

            for (int k = 0; k < dgsel.Count; k++)
            {
                if (dgFiles.Rows.IndexOf(dgsel[k]) >= 0)
                {
                    DataRowView drv = (DataRowView)dgsel[k].DataBoundItem;
                    int m = dt.Rows.IndexOf(drv.Row);

                    dgFiles.Rows.Remove(dgsel[k]);
                }
            }

            CalculateTotalJoinDuration();

        }

        private void tsbJoinVideos_Click(object sender, EventArgs e)
        {

        }

        private void tsbJoinPlayPreview_Click(object sender, EventArgs e)
        {
            if (dgFiles.Rows.Count == 0) return;

            btnStopJ_Click(null, null);
            
            for (int k = 0; k < dgFiles.Rows.Count; k++)
            {
                dgFiles.CurrentCell = dgFiles.Rows[k].Cells[0];

                if (dgFiles.Rows[k].Cells["colSelect"].Value.ToString() == bool.TrueString)
                {
                    btnPlayJ_Click(null, null);

                    while (PlayerStateJ != PlayerStateEnum.StoppedNext)
                    {
                        Application.DoEvents();
                    }
                }
            }

            /*
            CurrentSegmentJ = -1;

            lstJoinPlay.Clear();

            for (int k = 0; k < dt.Rows.Count;k++)
            {
                if (dt.Rows[k]["cselect"].ToString() == bool.TrueString)
                {
                    lstJoinPlay.Add(new JoinPlayItem() { Filepath = dt.Rows[k]["cinputfile"].ToString(), EndSecs = (int)dt.Rows[k]["clengthsecs"] });
                }
            }
             
             PlayNextSegmentJ();
             */


        }

        private void tsbCutVideo_Click(object sender, EventArgs e)
        {
            if (ConversionStarted)
            {
                if (!psFFMpeg.HasExited)
                {
                    SuspendResumeThread.SuspendProcess(psFFMpeg.Id);
                    ConversionPaused = true;
                    ConversionStarted = false;
                    timCut.Enabled = false;
                    tsbCutVideo.Image = Properties.Resources.cut1;
                    tsbCutVideo.Text = TranslateHelper.Translate("Resume");
                }
            }
            else if (ConversionPaused)
            {
                ConversionStarted = true;
                ConversionPaused = true;
                timCut.Enabled = true;
                SuspendResumeThread.ResumeProcess(psFFMpeg.Id);
                tsbCutVideo.Image = Properties.Resources.media_pause;
                tsbCutVideo.Text = TranslateHelper.Translate("Pause Cut");
            }
            else
            {
                try
                {
                    //SetupGrid();
                    //ProcessWhenFinished();
                    ConversionStopped = false;
                    ConversionStarted = true;
                    errstr = "";

                    //   Module.SelectedFormatSetting = lstFormatSettings[cmbProfile.SelectedIndex];

                    pbarCut.Value = 0;
                    CompletedSecs = 0;

                    CutFilesToDelete.Clear();

                    GetCutArgsResult res = GetCutArgs();
                    
                    //pbarCut.Maximum = 100;
                    //0pbarCut.Maximum = res.TotalDuration;
                    pbarCut.Maximum = res.TotalDuration;                                    

                    timCut.Enabled = true;
                    lblElapsedTime.Visible = true;
                    tsbCutVideo.Image = Properties.Resources.media_pause;
                    tsbStopCut.Visible = true;
                    tsbCutVideo.Text = TranslateHelper.Translate("Pause Cut");

                    for (int k = 0; k < res.ClipArgs.Count; k++)
                    {
                        CreateFFMpegProcess();

                        psFFMpeg.StartInfo.Arguments = res.ClipArgs[k];

                        //lblElapsedTimeDesc.Visible = true;

                        bwConvert.RunWorkerAsync();

                        while (bwConvert.IsBusy)
                        {
                            Application.DoEvents();
                        }

                        if (ConversionStopped) return;
                    }

                    if (res.JoinArgs != string.Empty)
                    {
                        CreateFFMpegProcess();

                        psFFMpeg.StartInfo.Arguments = res.JoinArgs;

                        //lblElapsedTimeDesc.Visible = true;

                        bwConvert.RunWorkerAsync();

                        while (bwConvert.IsBusy)
                        {
                            Application.DoEvents();
                        }

                        if (ConversionStopped) return;
                    }

                    //1}
                }
                finally
                {
                    timCut.Enabled = false;
                    ConversionProgressTime = 0;
                    ConversionStarted = false;

                    //lblElapsedTime.Visible = false;
                    //lblElapsedTimeDesc.Visible = false;

                    for (int k = 0; k < CutFilesToDelete.Count; k++)
                    {
                        try
                        {
                            System.IO.File.Delete(CutFilesToDelete[k]);
                        }
                        catch
                        {
                            errstr += TranslateHelper.Translate("Error. Could not Delete File") + " : " + CutFilesToDelete[k] + "\n\n";
                        }
                    }
                                        
                    if (!ConversionStopped)
                    {
                        ProcessWhenFinished();

                        if (errstr != String.Empty)
                        {
                            frmError fer = new frmError(TranslateHelper.Translate("Operation completed with Errors !"), errstr);
                            fer.ShowDialog();

                            //Module.ShowMessage(TranslateHelper.Translate("Operation completed with Errors !") + "\n\n" + errstr);
                        }
                        else
                        {
                            Module.ShowMessage("Operation completed successfully !");
                        }
                    }

                    tsbCutVideo.Image = Properties.Resources.cut1;
                    tsbStopCut.Visible = false;
                    tsbCutVideo.Text = TranslateHelper.Translate("Cut Video");
                }
            }
        }

        private void minimizeToTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Visible = false;
            notifyIcon1.Text = Module.ShortApplicationTitle;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.BringToFront();
            notifyIcon1.Visible = false;
        }


        private void realTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;

            if (tsi.Checked) return;

            for (int k = 0; k < tsiThreadPriority.DropDownItems.Count; k++)
            {
                ToolStripMenuItem tm = tsiThreadPriority.DropDownItems[k] as ToolStripMenuItem;
                tm.Checked = false;
            }

            tsi.Checked = true;

            if (sender == realTimeToolStripMenuItem)
            {
                ThreadPriorityLevel = ThreadPriority.RealTime;

                if (psFFMpeg!=null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.RealTime;
                }
            }
            else if (sender == highToolStripMenuItem)
            {
                ThreadPriorityLevel = ThreadPriority.High;

                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.High;
                }
            }
            else if (sender == normalToolStripMenuItem)
            {
                ThreadPriorityLevel = ThreadPriority.Normal;

                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.Normal;
                }
            }
            else if (sender == aboveNormalToolStripMenuItem)
            {
                ThreadPriorityLevel = ThreadPriority.AboveNormal;

                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.AboveNormal;
                }
            }
            else if (sender == belowNormalToolStripMenuItem)
            {
                ThreadPriorityLevel = ThreadPriority.BelowNormal;

                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.BelowNormal;
                }
            }
            else if (sender == idleToolStripMenuItem)
            {
                ThreadPriorityLevel = ThreadPriority.Idle;

                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.Idle;
                }
            }
        
        }

        private void checkForNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Module.CheckVersion(false);
        }
        
        private void tsbStopCut_Click(object sender, EventArgs e)
        {            
            ConversionStopped = true;
            ConversionStarted = false;
            ConversionPaused = false;

            tsbStopCut.Visible = false;
            tsbCutVideo.Image = Properties.Resources.cut1;
            tsbCutVideo.Text = TranslateHelper.Translate("Cut Video");

            try
            {
                psFFMpeg.Kill();
            }
            catch { }

            bwConvert.CancelAsync();
           
            /*
            for (int k = 0; k < lstProcessConvert.Count; k++)
            {
                try
                {
                    lstProcessConvert[k].Kill();
                }
                catch { }
            }*/
        }

        private void tsbMoveBack_Click(object sender, EventArgs e)
        {   
            if (msPosition.Value > 0)
            {
                msPosition.Value--;
                msPositionMouseDown  = true;
                msPosition_ValueChanged(null, null);
                msPositionMouseDown = false;
            }
        }
        
        private void tsbMoveForward_Click(object sender, EventArgs e)
        {
            /*
            int dsecs = msPosition.Value / 10;
            string ssecs = msPosition.Value.ToString();
            string sms = ssecs.Substring(ssecs.Length - 1, 1);
            int dms = int.Parse(sms);
            if (dms == 9)
            {
                dsecs++;
                dms = 0;

                if (dsecs > LengthISecs)
                {
                    return;
                }
            }
            else
            {
                dms++;

                if (dsecs == LengthISecs && dms * 100 > LengthIMSecs)
                {
                    return;
                }
            }

            SendCommand("pausing seek "+dsecs.ToString()+"."+dms.ToString()+" 2 1");
            //SendCommand("pausing set property time_pos " + msPosition.Value.ToString() + "." + MsecStep.ToString());
            
            //SendCommand("pausing get property time_pos");
            //" + msPosition.Value.ToString() + "." + MsecStep.ToString() + " 2 1");
            
            MsecStep++;

            if (MsecStep == 9)
            {
                MsecStep = 0;
            }

            MessageBox.Show(dsecs.ToString() + "." + dms.ToString());

            return;
            */

            if (msPosition.Value < msPosition.Maximum)
            {
                msPosition.Value++;
                msPositionMouseDown = true;
                msPosition_ValueChanged(null, null);
                msPositionMouseDown = false;
            }
        }

        private void mskPos_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskPos_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void mskPos_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tsbMovePosition(int step)
        {
            msPosition.Focus();

            if (step > 0)
            {
                if ((msPosition.Value + step) > msPosition.Maximum)
                {
                    msPosition.Value = msPosition.Maximum;
                }
                else
                {
                    msPosition.Value += step;
                }
            }
            else if (step < 0)
            {
                if (msPosition.Value + step < 0)
                {
                    msPosition.Value = 0;
                }
                else
                {
                    msPosition.Value += step;
                }
            }

            SeekPosition();
        }

        public void tsbMoveBackMsec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(-1);
        }

        public void tsbMoveForwardMsec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(1);
        }

        public void tsbMoveBack1Sec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(-10);
        }

        public void tsbMoveForward1Sec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(10);
        }

        public void tsbMoveBack30Sec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(-30 * 10);
        }

        public void tsbMoveForward30Sec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(30 * 10);
        }

        public void tsbMoveBack3Min_Click(object sender, EventArgs e)
        {
            tsbMovePosition(-3*60 * 10);
        }

        public void tsbMoveForward3Min_Click(object sender, EventArgs e)
        {
            tsbMovePosition(3 * 60 * 10);
        }

        private void mskPos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*1
                int hours = 0;
                int minutes = 0;
                int secs = 0;
                int msecs = 0;

                try
                {
                    hours = int.Parse(mskPos.Text.Substring(0, 2).Replace("_", ""));
                }
                catch { }

                try
                {
                    minutes = int.Parse(mskPos.Text.Substring(3, 2).Replace("_", ""));
                }
                catch { }

                try
                {
                    secs = int.Parse(mskPos.Text.Substring(6, 2).Replace("_", ""));
                }
                catch { }

                try
                {
                    msecs = int.Parse(mskPos.Text.Substring(9, 1).Replace("_", ""));
                }
                catch { }

                TimeSpan ts = new TimeSpan(hours, minutes, secs);

                msPosition.Value = (int)ts.TotalSeconds * 10 + msecs;
                */
            }
        }

        private void btnBrowseOutputFolder_Click(object sender, EventArgs e)
        {
            if (cmbOutputFolder.Text.Trim() != string.Empty && System.IO.Directory.Exists(cmbOutputFolder.Text))
            {
                folderBrowserDialog1.SelectedPath = cmbOutputFolder.Text;
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                bool found = false;

                for (int k = 0; k < cmbOutputFolder.Items.Count; k++)
                {
                    if (cmbOutputFolder.Items[k].ToString() == folderBrowserDialog1.SelectedPath)
                    {
                        found = true;
                        cmbOutputFolder.SelectedIndex = k;
                        return;
                    }
                }

                if (!found)
                {
                    cmbOutputFolder.Items.Add(folderBrowserDialog1.SelectedPath);
                    cmbOutputFolder.SelectedIndex = cmbOutputFolder.Items.Count - 1;
                }
            }

        }

        private void btnOpenOutputFolder_Click(object sender, EventArgs e)
        {
            string outfolder = "";

            if (cmbOutputFolder.Text == TranslateHelper.Translate("Same as Video's Folder"))
            {   
                outfolder = System.IO.Path.GetDirectoryName(filepath);
            }
            else if (cmbOutputFolder.Text.Trim() == string.Empty || !System.IO.Directory.Exists(cmbOutputFolder.Text))
            {
                Module.ShowMessage("Please specify a valid Output Folder !");
                return;
            }
            else
            {
                outfolder = cmbOutputFolder.Text;
            }

            //string args = string.Format("/e, /select, \"{0}\"", txtOutputFolder.Text);
            string args = string.Format("\"{0}\"", outfolder);
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);

        }
                
        private void frmClip_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        AddFile(filez[k]);
                    }
                    finally
                    {
                        this.Cursor = null;
                    }
                }
            }

        }

        private void frmClip_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                IsDragging = true;
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void frmClip_DragOver(object sender, DragEventArgs e)
        {
            IsDragging = true;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void ProcessWhenFinished()
        {
            int ichecked = -1;

            for (int k = 0; k < whenFinishedToolStripMenuItem.DropDownItems.Count - 1;k++ )
            {
                ToolStripMenuItem ti = (ToolStripMenuItem)whenFinishedToolStripMenuItem.DropDownItems[k];
                if (ti.Checked)
                {
                    ichecked = k;
                    break;
                }
            }
            
            
            if (ichecked == 0)
            {
                ShutdownHelper.Shutdown();
            }
            else if (ichecked == 1)
            {
                ShutdownHelper.Sleep();
            }
            else if (ichecked == 2)
            {
                ShutdownHelper.Hibernate();
            }
            else if (ichecked == 3)
            {
                ShutdownHelper.Logoff();
            }
            else if (ichecked == 4)
            {
                ShutdownHelper.Lock();
            }
            else if (ichecked == 5)
            {
                ShutdownHelper.Restart();
            }
            else if (ichecked == 6)
            {
                Application.Exit();
            }
            else if (ichecked == 7)
            {                
                string args = string.Format("/e, /select, \"{0}\"", FirstOutputFile);
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "explorer";
                info.UseShellExecute = true;
                info.Arguments = args;
                Process.Start(info);
            }
            
        }

        private void frmClip_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.RemoveMessageFilter(filter);

            int ichecked=-1;

            for (int k = 0; k < whenFinishedToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem ti = (ToolStripMenuItem)whenFinishedToolStripMenuItem.DropDownItems[k];

                if (ti.Checked)
                {
                    ichecked = k;
                    break;
                }
            }

            Properties.Settings.Default.WhenFinishedIndex = ichecked;

            ichecked = 3;

            for (int k = 0; k < tsiThreadPriority.DropDownItems.Count; k++)
            {
                ToolStripMenuItem ti = (ToolStripMenuItem)tsiThreadPriority.DropDownItems[k];

                if (ti.Checked)
                {
                    ichecked = k;
                    break;
                }
            }

            Properties.Settings.Default.ThreadPriorityLevelIndex = ichecked;

            Properties.Settings.Default.Save();

            SavePositionSize();            
        }

        private void timCut_Tick(object sender, EventArgs e)
        {
            ConversionProgressTime++;
            TimeSpan ts = new TimeSpan(0, 0, ConversionProgressTime);

            lblElapsedTime.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");
        }

        private void bwConvert_DoWork(object sender, DoWorkEventArgs e)
        {
            //0sw.WriteLine("ARGS=");
            //0sw.WriteLine(psFFMpeg.StartInfo.Arguments);

            psFFMpeg.Start();

            System.Threading.Thread.Sleep(300);

            if (ThreadPriorityLevel == ThreadPriority.RealTime)
            {
                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.RealTime;
                }
            }
            else if (ThreadPriorityLevel == ThreadPriority.High)
            {
                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.High;
                }
            }
            else if (ThreadPriorityLevel == ThreadPriority.Normal)
            {
                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.Normal;
                }
            }
            else if (ThreadPriorityLevel == ThreadPriority.AboveNormal)
            {
                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.AboveNormal;
                }
            }
            else if (ThreadPriorityLevel == ThreadPriority.BelowNormal)
            {
                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.BelowNormal;
                }
            }
            else if (ThreadPriorityLevel == ThreadPriority.Idle)
            {
                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.PriorityClass = ProcessPriorityClass.Idle;
                }
            }
            while (true)
            {
                string line;

                int beforeCompletedSecs = CompletedSecs;

                bool time_str_found = false;

                string last_line = "";

                while ((line = psFFMpeg.StandardError.ReadLine()) != null)
                {
                    last_line = line;

                    Application.DoEvents();

                    //0sw.WriteLine(line);
                    //0sw.Flush();

                    if (bwConvert.CancellationPending)
                    {
                        //psFFMpeg.Kill();
                        break;
                    }

                    if (line != null && line.Contains("time="))
                    {
                        time_str_found = true;

                        try
                        {
                            int spos = line.LastIndexOf("time=") + "time=".Length;
                            int epos = line.IndexOf(" ", spos);

                            string time = line.Substring(spos, epos - spos + 1);

                            //0sw.WriteLine("time=" + time);

                            TimeSpan ts = new TimeSpan(int.Parse(time.Substring(0, 2)), int.Parse(time.Substring(3, 2)),
                                int.Parse(time.Substring(6, 2)));

                            int completed_secs = (int)ts.TotalSeconds;
                            int msecs=int.Parse(time.Substring(9,1));

                            //0sw.WriteLine("parsed time="+ts.ToString() + "." + msecs.ToString());

                            //0sw.WriteLine("before completed secs=" + CompletedSecs.ToString());

                            CompletedSecs = beforeCompletedSecs+(completed_secs * 10 + msecs);

                            //0sw.WriteLine("completed secs="+CompletedSecs.ToString());

                            //int totalsex = LastCutArgs.TotalDuration / 10;

                            //1int progress = (int)((decimal)CompletedSecs * 100 / (decimal)(LastCutArgs.TotalDuration));

                            //1bwConvert.ReportProgress(progress);
                            bwConvert.ReportProgress(0,CompletedSecs);
                        }
                        catch { }

                    }
                    else if (line != null && line.ToLower().StartsWith("error"))
                    {
                        errstr += line;
                    }
                }

                //if no time= string was found this means that an error occured
                if (!time_str_found)
                {
                    errstr += last_line;
                }

                if (psFFMpeg.HasExited) break;
            }

            //0sw.WriteLine("END");
        }

        private void bwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int pg = (int)e.UserState;

            if (pg >= 0 && pg <= pbarCut.Maximum)
            {
                pbarCut.Value = pg;
            }
        }

        private void bwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {           
        }

        private List<Segment> GetIncludeModeSegments()
        {
            List<Segment> segments = new List<Segment>();                        

            for (int k = 0; k < fplSegments.Controls.Count; k++)
            {
                Segment seg = new Segment();
                MediaSegment ms = (MediaSegment)fplSegments.Controls[k];

                seg.RangeStart = ms.msSegment.RangeStart;
                seg.RangeEnd = ms.msSegment.RangeEnd;
            }

            return segments;
        }
        private List<Segment> GetExcludeModeSegments()
        {
            List<Segment> segments = new List<Segment>();

            int lastend = 0;

            for (int k = 0; k < fplSegments.Controls.Count; k++)
            {
                Segment seg = new Segment();
                MediaSegment ms = (MediaSegment)fplSegments.Controls[k];

                seg.RangeStart = lastend;
                seg.RangeEnd = ms.msSegment.RangeStart;

                if (seg.RangeStart != seg.RangeEnd) // do not include if first segment start with 0 ,for example.
                {
                    segments.Add(seg);
                }

                lastend = ms.msSegment.RangeEnd;
            }

            Segment segend = new Segment();
            segend.RangeStart = lastend;
            segend.RangeStart = LengthTotalMSecs;

            if (segend.RangeStart != segend.RangeEnd)
            {
                segments.Add(segend);
            }

            return segments;
        }

        private List<Segment> GetCutSegments()
        {
            if (CurrentCutMode == CutMode.Incude)
            {
                return GetIncludeModeSegments();
            }
            else if (CurrentCutMode == CutMode.Exclude)
            {
                return GetExcludeModeSegments();
            }

            return null;
        }

        private GetCutArgsResult GetCutArgs()
        {            
            List<string> str=GetOutputFilepathsHelper.GetOutputFilepaths(chkJoinParts.Checked);
            GetCutArgsResult res = new GetCutArgsResult();
            res.FirstOutputFile = str[0];
            FirstOutputFile = str[0];

            List<Segment> segments = GetCutSegments();

            //1for (int k=0;k<fplSegments.Controls.Count;k++)
            for (int k=0;k<segments.Count;k++)
            {         
                string args_split = " -y -i \""+filepath+"\" ";

                if (cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                {
                    //args_split += " -acodec copy -vcodec copy ";
                }

                //1MediaSegment ms = (MediaSegment)fplSegments.Controls[k];
                //1string tstart = ms.mskStart.Text;
                string tstart = FFMpegArgsHelper.GetStringFromTime(segments[k].RangeStart);
                //1int tm = ms.msSegment.RangeEnd - ms.msSegment.RangeStart;
                int tm = segments[k].RangeEnd - segments[k].RangeStart;
                int tsecs = tm / 10;
                int tmsecs = tm % 10;

                if (chkJoinParts.Checked && fplSegments.Controls.Count>1)
                {
                    res.TotalDuration += (tm * 2); // one for clip and one for join
                }
                else
                {
                    res.TotalDuration += tm; // only one for clip
                }

                args_split += " -ss " + tstart +" -t " + tsecs.ToString() + "." + tmsecs.ToString() + "0";

                if (cmbOutputFormat.Text.Trim() == "3GP" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    && System.IO.Path.GetExtension(filepath).ToLower()==".3gp"))
                {
                    args_split += " -r 20 -s 352x288 -b 400k -strict experimental -c:a aac -ac 1 -ar 8000 -ab 24k ";
                }
                if (cmbOutputFormat.Text.Trim() == "WMV" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    && System.IO.Path.GetExtension(filepath).ToLower()==".wmv"))
                {
                    args_split += " -q:a 2 -q:v 2 -vcodec msmpeg4 -acodec wmav2 ";
                }

                try
                {
                    if (System.IO.File.Exists(str[k]))
                    {
                        System.IO.File.Delete(str[k]);
                    }
                }
                catch { }

                // do not join split files..
                if (!chkJoinParts.Checked || fplSegments.Controls.Count ==1)
                {                                       
                    args_split += " \"" + str[k] + "\" ";                    
                }
                                            
                // join split files..
                else
                {
                    string tempfile = System.IO.Path.GetTempFileName();

                    try
                    {
                        System.IO.File.Delete(tempfile);
                    }
                    catch { }

                    if (cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    {
                        tempfile += System.IO.Path.GetExtension(filepath);
                    }
                    else
                    {
                        tempfile += "." + cmbOutputFormat.Text.Trim().ToLower();
                    }
                    
                    args_split += " \"" + tempfile + "\" ";
                    CutFilesToDelete.Add(tempfile);
                }

                res.ClipArgs.Add(args_split);
            }

            string parent_split_args = " -y ";

            if (chkJoinParts.Checked && fplSegments.Controls.Count > 1)
            {
                int file_count = CutFilesToDelete.Count;

                for (int m = 0; m < CutFilesToDelete.Count; m++)
                {
                    parent_split_args += " -i \"" + CutFilesToDelete[m] + "\" ";
                }

                parent_split_args += " -filter_complex \"";

                for (int m = 0; m < file_count; m++)
                {
                    parent_split_args += "[" + m.ToString() + ":0] [" + m.ToString() + ":1] ";

                    //[0:0] [0:1] [1:0] [1:1] 
                }

                parent_split_args += "concat=n=" + file_count.ToString() + ":v=1:a=1 [v] [a]\" -map \"[v]\" -map \"[a]\" ";

                // also get the conversion args....for the joined item....

                if (cmbOutputFormat.Text.Trim() == "3GP" ||
                    ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    && System.IO.Path.GetExtension(filepath).ToLower() == ".3gp"))
                {
                    parent_split_args += " -r 20 -s 352x288 -b 400k -strict experimental -c:a aac -ac 1 -ar 8000 -ab 24k ";
                }
                else if (cmbOutputFormat.Text.Trim() == "WMV" ||
                    ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    && System.IO.Path.GetExtension(filepath).ToLower() == ".wmv"))
                {
                    parent_split_args +=" -q:a 2 -q:v 2 -vcodec msmpeg4 -acodec wmav2 ";
                }

                parent_split_args += " \"" + str[0] + "\" ";

                // set up parent splitted join item...
                res.JoinArgs = parent_split_args;
            }

            LastCutArgs = res;

            //0MessageBox.Show(res.TotalDuration.ToString());

            return res;            
        }

        private bool DebugStartup = false;

        private void timDebug_Tick(object sender, EventArgs e)
        {
            if (DebugStartup) return;

            if (ps != null && ps.HasExited == true)
            {
                DebugStartup = true;
                try
                {
                    OpenFile();
                    SeekPosition();
                }
                finally
                {
                    DebugStartup = false;
                }                
            }
        }
                
        private void frmClip_Activated(object sender, EventArgs e)
        {
            msPosition.Focus();
        }

        private void tsbExclude_Click(object sender, EventArgs e)
        {
            CurrentCutMode = CutMode.Exclude;
            tsbExcludeMode.BackColor = Color.FromArgb(192, 192, 255);
            tsbIncludeMode.BackColor = Color.Transparent;
        }

        private void tsbIncludeMode_Click(object sender, EventArgs e)
        {
            CurrentCutMode = CutMode.Incude;
            tsbIncludeMode.BackColor = Color.FromArgb(192, 192, 255);
            tsbExcludeMode.BackColor = Color.Transparent;
        }
               

    }

    public class SegmentPlay
    {
        public int StartSecs = 0;
        public int EndSecs = 0;
    }

    public class JoinPlayItem
    {
        public string Filepath;
        public int EndSecs = 0;
    }

    public class GetCutArgsResult
    {
        public List<string> ClipArgs = new List<string>();
        public string JoinArgs = "";
        public int TotalDuration = 0;
        public string FirstOutputFile = "";
    }

    public class Segment
    {
        public int RangeStart;
        public int RangeEnd;
    }
}
