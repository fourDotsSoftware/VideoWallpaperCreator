using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace VideoWallpaperCreator
{
    public partial class frmClip : VideoWallpaperCreator.CustomForm
    {
        public enum CutMode
        {
            Include,
            Exclude,
            Silence,
            Parts
        }

        public static frmClip Instance = null;
        private GetCutArgsResult LastCutArgs = null;
        public int CompletedSecs = -1;
        public string FirstOutputFile = "";

        Label lblDrag = new Label();

        KeyMessageFilter filter;

        public CutMode CurrentCutMode = CutMode.Include;

        //0private StreamWriter sw = new StreamWriter(Application.StartupPath + "\\out.txt");
                
        List<SegmentPlay> lstSegmentPlay = new List<SegmentPlay>();
        int CurrentSegment = 0;

        List<JoinPlayItem> lstJoinPlay = new List<JoinPlayItem>();
        int CurrentSegmentJ = 0;

        private Color SegmentBackColor = SystemColors.Control;
        //        private Color SegmentActiveBackColor = Color.LightBlue;
        private Color SegmentActiveBackColor = Color.FromArgb(244, 240, 91);

        public int LengthTotalMSecs = -1;
        public int LengthISecs = -1;
        public int LengthIMSecs = -1;

        string TimeEndString = "";

        string args_play = "";
        string args_playJ = "";

        bool Initialized = false;
        bool InitializedJ = false;

        public string LastFFMpegOutput = "";

        public int _msPositionValue = 0;
        public int msPositionValue
        {
            get { return _msPositionValue; }

            set
            {
                lastmsPositionValue = msPositionValue;

                _msPositionValue = value;
            }
        }

        public int lastmsPositionValue = 0;

        public int msPositionMaximum = 0;

        public int PlayK = 0;
        
        public enum PlayerStateEnum
        {
            Playing,
            Paused,
            PausedSegment,
            PausedAllSegments,
            Stopped,
            StoppedSegment,
            StoppedAllSegments,
            PlayingSegment,
            PlayingAllSegments,
            StoppedNext
        }

        public PlayerStateEnum PlayerState = PlayerStateEnum.Stopped;
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

        public enum ThreadPriority
        {
            High, AboveNormal, Normal, BelowNormal, Idle
        }

        public ThreadPriority ThreadPriorityLevel = ThreadPriority.Normal;

        public Process psFFMpeg = null;

        public bool ConversionStopped = false;
        public bool ConversionStarted = false;
        public bool ConversionPaused = false;
        public int ConversionProgressTime = 0;
        public bool OutputFileActionRepeat = false;

        public string errstr = "";

        private List<string> CutFilesToDelete = new List<string>();

        private BackgroundWorker bwVideoThumbnailUpdate = new BackgroundWorker();

        private int LastMouseX = 0;

        public frmClip()
        {

            InitializeComponent();
            
            Instance = this;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
         ControlStyles.AllPaintingInWmPaint, true);                                           

            ps = new Process();

            //Path of Mplayer exe
            ps.StartInfo.FileName = "mplayer ";
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardInput = true;
//            ps.StartInfo.RedirectStandardError = true;
            //-idle -input=/fifo";

            bwVideoThumbnailUpdate.DoWork += bwVideoThumbnailUpdate_DoWork;
            bwVideoThumbnailUpdate.RunWorkerCompleted += bwVideoThumbnailUpdate_RunWorkerCompleted;

            bwVideoThumbnailUpdate.WorkerReportsProgress = true;
            bwVideoThumbnailUpdate.ProgressChanged += bwVideoThumbnailUpdate_ProgressChanged;
        }

        private bool UpdatingVideoThumbnail=false;

        void bwVideoThumbnailUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                vthPreview.picThumbnail.BackColor=SystemColors.Control;
            }
        }

        public bool Playing
        {
            get
            {
                return (PlayerState == frmClip.PlayerStateEnum.Playing
            || PlayerState == frmClip.PlayerStateEnum.PlayingSegment
            || PlayerState == frmClip.PlayerStateEnum.PlayingAllSegments);
            }
        }
        private static uint RedrawWindowFlags;

        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

        #region Storyboard and Thumbnails

        void bwVideoThumbnailUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                vthPreview.picThumbnail.BackColor = SystemColors.Control;
            }
            else
            {
                RedrawWindow(picMovie.Handle, IntPtr.Zero, IntPtr.Zero, 0x0400/*RDW_FRAME*/ | 0x0100/*RDW_UPDATENOW*/
         | 0x0001/*RDW_INVALIDATE*/);

                Image img = (Image)e.Result;

                vthPreview.picThumbnail.Image = img;

                SeekPosition();
            }
        }

        void bwVideoThumbnailUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                UpdatingVideoThumbnail = true;

                VideoThumbnailObject vtho = (VideoThumbnailObject)e.Argument;

                VideoThumbnailControl.CurrentImageTimeString = vtho.TimeString;

                //Module.WaitNMSeconds(300);

                bwVideoThumbnailUpdate.ReportProgress(-1);

                if (vtho.TimeString == vthPreview.TimeString)
                {
                    //Module.WaitNMSeconds(200);

                    if (vtho.TimeString == vthPreview.TimeString)
                    {
                        VideoThumbnail vt = new VideoThumbnail(vtho.Filepath, vtho.TimeString, 156, 100);

                        if (vtho.TimeString == vthPreview.TimeString)
                        {

                            if (vt.ThumbnailImage != null)
                            {
                                e.Result = vt.ThumbnailImage;
                            }
                            else
                            {
                                e.Result = null;
                            }
                        }
                        else
                        {
                            e.Result = null;
                        }
                    }
                    else
                    {
                        e.Result = null;
                    }
                }
                else
                {
                    e.Result = null;
                }
            }
            catch
            {
                e.Result = null;
            }
            finally
            {
                UpdatingVideoThumbnail = false;
            }
        }

        private bool InShowStoryboard = false;

        private void chkShowStoryboard_CheckedChanged(object sender, EventArgs e)
        {
            if (InShowStoryboard)
            {
                return;
            }

            Properties.Settings.Default.ShowStoryboardImages = !Properties.Settings.Default.ShowStoryboardImages;

            if (!InShowStoryboard)
            {
                ShowStoryboard();
            }
        }

        private void ShowStoryboard()
        {
            try
            {
                InShowStoryboard = true;
                Module.LockWindowUpdate(this.Handle);
                this.SuspendLayout();
                plMedia.SuspendLayout();

                //1btnZoomIn.Visible = chkShowStoryboard.Checked;
                //1btnZoomOut.Visible = chkShowStoryboard.Checked;
                showStoryboardToolStripMenuItem.Checked = Properties.Settings.Default.ShowStoryboardImages;
                showStoryboardAudioWaveformToolStripMenuItem.Checked = Properties.Settings.Default.ShowStoryboardAudioWave;

                //1Properties.Settings.Default.ShowStoryboardImages = chkShowStoryboard.Checked;                                

                if (Properties.Settings.Default.ShowStoryboardImages && filepath != string.Empty)
                {
                }

                picMain.Height = picMain.StoryboardSettingsHeight;
                HScrollbar.Top = picMain.Bottom;
                /*
                if (!Properties.Settings.Default.ShowStoryboardImages)
                {                                        
                    
                    plMedia.Top += picMain.Height;
                    ts3min.Top += picMain.Height;
                    lbl3min.Top += picMain.Height;
                    ts30sec.Top += picMain.Height;
                    lbl30sec.Top += picMain.Height;
                    ts1sec.Top += picMain.Height;
                    lbl1sec.Top += picMain.Height;
                    ts01sec.Top += picMain.Height;
                    lbl01sec.Top += picMain.Height;
                    picMovie.Height += picMain.Height;

                }
                else
                {                    
                    
                    plMedia.Top -= picMain.Height;
                    ts3min.Top -= picMain.Height;
                    lbl3min.Top -= picMain.Height;
                    ts30sec.Top -= picMain.Height;
                    lbl30sec.Top -= picMain.Height;
                    ts1sec.Top -= picMain.Height;
                    lbl1sec.Top -= picMain.Height;
                    ts01sec.Top -= picMain.Height;
                    lbl01sec.Top -= picMain.Height;
                    picMovie.Height -= picMain.Height;

                }*/
            }
            finally
            {
                InShowStoryboard = false;
                Module.LockWindowUpdate(IntPtr.Zero);
                this.ResumeLayout();
                plMedia.ResumeLayout();
            }
        }

        private void showStoryboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InShowStoryboard)
            {
                return;
            }

            try
            {
                InShowStoryboard = true;

                chkShowStoryboard.Checked = !chkShowStoryboard.Checked;

                showStoryboardToolStripMenuItem.Checked = !showStoryboardToolStripMenuItem.Checked;

                Properties.Settings.Default.ShowStoryboardImages = showStoryboardToolStripMenuItem.Checked;

                ShowStoryboard();

                picMain.Invalidate();
            }
            finally
            {
                InShowStoryboard = false;
            }
        }

        private void showStoryboardAudioWaveformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InShowStoryboard)
            {
                return;
            }

            try
            {
                InShowStoryboard = true;
                chkShowStoryboardAudioWaveform.Checked = !chkShowStoryboardAudioWaveform.Checked;

                showStoryboardAudioWaveformToolStripMenuItem.Checked = !showStoryboardAudioWaveformToolStripMenuItem.Checked;

                Properties.Settings.Default.ShowStoryboardAudioWave = showStoryboardAudioWaveformToolStripMenuItem.Checked;

                ShowStoryboard();


                picMain.Invalidate();
            }
            finally
            {
                InShowStoryboard = false;
            }
        }

        private void chkShowStoryboardAudioWaveform_CheckedChanged(object sender, EventArgs e)
        {
            if (InShowStoryboard)
            {
                return;
            }

            Properties.Settings.Default.ShowStoryboardAudioWave = !Properties.Settings.Default.ShowStoryboardAudioWave;

            if (!InShowStoryboard)
            {
                ShowStoryboard();
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (picMain.StoryboardTimeFrameLengthMsecs > 100)
            {
                picMain.StoryboardTimeFrameLengthMsecs = picMain.StoryboardTimeFrameLengthMsecs / 2;
                picMain.PaintImg();
                //picMain.Invalidate();
            }

            /*5
            for (int k = 0; k < storyboardZoomToolStripMenuItem.DropDownItems.Count-1; k++)
            {
                ToolStripMenuItem ti = (ToolStripMenuItem)storyboardZoomToolStripMenuItem.DropDownItems[k];

                if (ti.Checked)
                {
                    ToolStripMenuItem ti2 = (ToolStripMenuItem)storyboardZoomToolStripMenuItem.DropDownItems[k + 1];
                    ti.Checked = false;
                    ti2.Checked = true;
                    ti2.PerformClick();
                    break;
                }
            }
            */

            /*
            Point p = new Point(btnZoomIn.Left, btnZoomIn.Top - 530);
            Point p2 = btnZoomIn.PointToScreen(p);
            //cmsZoom.Show(p2);

            //1cmsZoom.Show(btnZoomIn, -cmsZoom.Width, btnZoomIn.Height);

            int zoominterval = StoryBoardHelper.StoryBoardIntervalMsecs;
            
            for (int k = 0; k < cmsZoom.Items.Count-1; k++)
            {
                ToolStripMenuItem tsi = (ToolStripMenuItem)cmsZoom.Items[k];

                if (tsi.Checked)
                {
                    ToolStripMenuItem tsi2 = (ToolStripMenuItem)cmsZoom.Items[k + 1];
                    tsi2.Checked = true;
                    tsi.Checked = false;
                
                    if (k==0)
                    {
                        zoominterval = 10 * 1000;
                        
                    }
                    else if (k==1)
                    {
                        zoominterval = 5 * 1000;
                        
                    }
                    else if (k==2)
                    {
                        zoominterval = 1 * 1000;
                        
                    }
                    else if (k==3)
                    {
                        zoominterval = 100;
                        
                    }
                    else if (k == 4)
                    {
                        zoominterval = 10;
                    }
                    break;
                }                
            }

            StoryBoardHelper.StoryBoardIntervalMsecs = zoominterval;

            Zoom();

            */
        }

        public void btnZoomOut_Click(object sender, EventArgs e)
        {
            picMain.StoryboardTimeFrameLengthMsecs = picMain.StoryboardTimeFrameLengthMsecs * 2;
            picMain.PaintImg();
            //picMain.Invalidate();

            /*5
            for (int k = 1; k < storyboardZoomToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem ti = (ToolStripMenuItem)storyboardZoomToolStripMenuItem.DropDownItems[k];

                if (ti.Checked)
                {
                    ToolStripMenuItem ti2 = (ToolStripMenuItem)storyboardZoomToolStripMenuItem.DropDownItems[k-1];
                    ti.Checked = false;
                    ti2.Checked = true;
                    ti2.PerformClick();
                    break;
                }
            }
            */

            /*
            storyboardZoomToolStripMenuItem_DropDownOpening(null, null);

            int zoominterval = StoryBoardHelper.StoryBoardIntervalMsecs;                      

            for (int k = 1; k < cmsZoom.Items.Count; k++)
            {
                ToolStripMenuItem tsi = (ToolStripMenuItem)cmsZoom.Items[k];

                if (tsi.Checked)
                {
                    ToolStripMenuItem tsi2 = (ToolStripMenuItem)cmsZoom.Items[k-1];
                    tsi2.Checked = true;
                    tsi.Checked = false;

                    if (k == 1)
                    {
                        zoominterval = 30 * 1000;                                                   
                    }
                    else if (k == 2)
                    {
                        zoominterval = 10 * 1000;
                        
                    }
                    else if (k == 3)
                    {
                        zoominterval = 5 * 1000; 
                        
                    }
                    else if (k == 4)
                    {
                        zoominterval = 1 * 1000; 
                    }
                    else if (k==5)
                    {
                        zoominterval = 100; 
                    }
                    
                    break;
                }
            }

            Point p = new Point(btnZoomIn.Left, btnZoomIn.Top - 530);
            Point p2 = btnZoomIn.PointToScreen(p);
            //cmsZoom.Show(p2);

            //1 12.2014 cmsZoom.Show(btnZoomOut, -cmsZoom.Width, btnZoomOut.Height);

            StoryBoardHelper.StoryBoardIntervalMsecs = zoominterval;
            //1StoryBoardHelper.ZoomIn();
            Zoom();

            //StoryBoardHelper.UpdateThumbnails();
            */
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollPos(IntPtr hWnd, System.Windows.Forms.Orientation nBar);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);

        [Serializable, StructLayout(LayoutKind.Sequential)]
        struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        public enum ScrollInfoMask : uint
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS),
        }

        private void ShowScrollPos()
        {
            SCROLLINFO si = new SCROLLINFO();
            si.cbSize = (uint)Marshal.SizeOf(si);
            si.fMask = (uint)ScrollInfoMask.SIF_ALL;

            GetScrollInfo(HScrollbar.Handle, (int)System.Windows.Forms.Orientation.Horizontal, ref si);

            int hz = si.nTrackPos;//GetScrollPos((IntPtr)fplStoryboard.Handle, System.Windows.Forms.Orientation.Horizontal);            

            lblScrollPos.Visible = true;
            lblScrollPos.BringToFront();
            lblScrollPos.Text = FFMpegArgsHelper.GetStringFromTime(hz);

            Application.DoEvents();

            //5            RedrawWindow(lblScrollPos.Handle, IntPtr.Zero, IntPtr.Zero, 0x0400/*RDW_FRAME*/ | 0x0100/*RDW_UPDATENOW*/
            //5| 0x0001/*RDW_INVALIDATE*/);


        }

        private void ti10Seconds_Click(object sender, EventArgs e)
        {
            //5StoryBoardHelper.StoryBoardIntervalMsecs = 10 * 1000;
            //1StoryBoardHelper.ZoomIn();
            //5Zoom();
        }

        private void ti5Seconds_Click(object sender, EventArgs e)
        {
            //5StoryBoardHelper.StoryBoardIntervalMsecs = 5 * 1000;
            //1StoryBoardHelper.ZoomIn();
            //5Zoom();
        }

        private void tiSecond_Click(object sender, EventArgs e)
        {
            //5StoryBoardHelper.StoryBoardIntervalMsecs = 1 * 1000;
            //1StoryBoardHelper.ZoomIn();
            //5Zoom();
        }

        private void ti100Msecs_Click(object sender, EventArgs e)
        {
            //5StoryBoardHelper.StoryBoardIntervalMsecs = 100;
            //1StoryBoardHelper.ZoomIn();
            //5Zoom();
        }

        private void tsbSilenceMode_Click(object sender, EventArgs e)
        {
            /*
            CurrentCutMode = CutMode.Silence;
            tsbExcludeMode.BackColor = Color.Transparent; 
            tsbIncludeMode.BackColor = Color.Transparent;
            tsbSilenceMode.BackColor = Color.FromArgb(192, 192, 255);
            tsbSplitParts.BackColor = Color.Transparent;

            fplSegments.Enabled = true;
            */
        }

        private void ti30Seconds_Click(object sender, EventArgs e)
        {
            //5StoryBoardHelper.StoryBoardIntervalMsecs = 30 * 1000;
            //1StoryBoardHelper.ZoomIn();
            //5Zoom();
        }

        private void HScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            lblScrollPos.Text = picMain.CalculateTimeStringFromMousePosition(e.NewValue);
            lblScrollPos.BringToFront();
            lblScrollPos.Visible = true;

            if (Control.MouseButtons == System.Windows.Forms.MouseButtons.None)
            {
                //picMain.Invalidate();   
                picMain.PaintImg();
                lblScrollPos.Visible = false;
            }
        }

        #endregion

        DataTable dt = new DataTable("table");                                           

        #region OnLoad - Closing

        private void SetupOnLoad()
        {
            args_play = " -nofs  -noquiet  -osdlevel 0 -identify -slave -volume 0 ";
            args_play += "-nomouseinput -sub-fuzziness 1 ";

            //-wid will tell MPlayer to show output inisde our panel
            args_play += " -vo direct3d -ao dsound ";
            args_play += " -wid " + picMovie.Handle.ToString();

            args_play += " -ss " + FFMpegArgsHelper.GetStringFromTime(msPositionValue);
            //3
            //3args_play = "";

            int id = (int)this.Handle;//picMovie.Handle;
            //args += id;

            /*picMovie.Image = MovieImage;*/
            //1btnPlay.Enabled = true;
            
            //1filter = new KeyMessageFilter(this);
            // add the filter
            //1Application.AddMessageFilter(filter);
                        
            //1fplSegments.Left = plMedia.Left;

            //this.Left = frmMain.Instance.Left;
            //this.Top = frmMain.Instance.Top;
            //this.Width = frmMain.Instance.Width;
            //this.Height = frmMain.Instance.Height;

            msVolume.Maximum = 100;
            msVolume.Value = 70;

            this.Text = Module.ApplicationTitle;

            DownloadSuggestionsHelper ds = new DownloadSuggestionsHelper();
            ds.SetupDownloadMenuItems(tsiDownload);            

            cmbOutputFormat.Items.Add(TranslateHelper.Translate("Keep same Format as Source"));
            cmbOutputFormat.Items.Add("MP4 - MPEG4 Video");
            cmbOutputFormat.Items.Add("WMV - Windows Media Video");
            cmbOutputFormat.Items.Add("FLV - Flash Video Format");
            cmbOutputFormat.Items.Add("AVI - Audio-Video Interleaved");
            cmbOutputFormat.Items.Add("MPEG - MPEG Video");
            cmbOutputFormat.Items.Add("MOV - Quicktime Video");
            cmbOutputFormat.Items.Add("MKV - Matroska Video");
            cmbOutputFormat.Items.Add("3GP - 3GP File Format");
            cmbOutputFormat.Items.Add("SWF - SWF Flash Video");
            cmbOutputFormat.Items.Add("VOB - Video Object Format");

            /*
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
            */
            cmbOutputFormat.SelectedIndex = 0;

            

            /*
            lblDrag.Text = TranslateHelper.Translate("Drag and Drop Videos Here !");
            lblDrag.AutoSize = true;
            lblDrag.Font = new Font(FontFamily.GenericSansSerif, 15);
            lblDrag.BackColor = Color.Transparent;

            lblDrag.Top = this.Height / 2 - lblDrag.Height / 2;
            */
            using (Graphics g = this.CreateGraphics())
            {
                SizeF sz = g.MeasureString(TranslateHelper.Translate("Drag and Drop Videos Here !"), this.Font);
                //lbl.Left = this.Width / 2 - (int)(sz.Width / 2);
            }
            //this.Controls.Add(lbl);

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
            try
            {
                if (Properties.Settings.Default.ThreadPriorityLevelIndex >= tsiThreadPriority.DropDownItems.Count)
                {
                    Properties.Settings.Default.ThreadPriorityLevelIndex = tsiThreadPriority.DropDownItems.Count - 1;
                }

                ToolStripMenuItem tip = (ToolStripMenuItem)tsiThreadPriority.DropDownItems[Properties.Settings.Default.ThreadPriorityLevelIndex];
                tip.Checked = true;
            }
            catch
            {
                normalToolStripMenuItem.Checked = true;
                Properties.Settings.Default.ThreadPriorityLevelIndex = 2;
            }

            RepositionResize();

            tsbIncludeMode_Click(null, null);

            AddLanguageMenuItems();
                        
            try
            {                
                InShowStoryboard = true;                

                chkShowStoryboard.Checked = Properties.Settings.Default.ShowStoryboardImages;
                showStoryboardToolStripMenuItem.Checked = Properties.Settings.Default.ShowStoryboardImages;

                chkShowStoryboardAudioWaveform.Checked = Properties.Settings.Default.ShowStoryboardAudioWave;
                showStoryboardAudioWaveformToolStripMenuItem.Checked = Properties.Settings.Default.ShowStoryboardAudioWave;
                
                ShowStoryboard();                
                
            }
            finally
            {
                InShowStoryboard = false;
            }

            SetEnabled(false);

            RecentFilesHelper.FillMenuRecentFile();

            mskPos.txtBox.KeyPress += mskPos_KeyPress;
            mskPos.txtBox.Validating += mskPos_Validating;

            fadeInFadeOutToolStripMenuItem.Checked = Properties.Settings.Default.FadeInFadeOut;
            joinClipsToolStripMenuItem.Checked=Properties.Settings.Default.JoinParts;

            ToolStripMenuItem tiStoryB = (ToolStripMenuItem)storyboardZoomToolStripMenuItem.DropDownItems[Properties.Settings.Default.ShowStoryBoardIndex];
            tiStoryB.Checked = true;
            tiStoryB.PerformClick();

            if (Properties.Settings.Default.CutOutMode)
            {
                CurrentCutMode = CutMode.Exclude;
                tsiExcludeMode.Checked = true;
                tsiIncludeMode.Checked = false;
            }
            else
            {
                CurrentCutMode = CutMode.Include;
                tsiIncludeMode.Checked = true;
                tsiExcludeMode.Checked = false;
            }


            foreach (Control co in this.Controls)
            {
                co.Enter += co_Enter;

                foreach (Control co2 in co.Controls)
                {
                    co2.Enter+=co_Enter;
                    co2.MouseUp += co2_MouseUp;

                }
            }


            picMain.Height = picMain.StoryboardSettingsHeight;

            mskCutStart.txtBox.KeyPress += mskCutStart_KeyPress;
            mskCutStart.txtBox.Validating += mskCutStart_Validating;

            mskCutEnd.txtBox.KeyPress += mskCutEnd_KeyPress;
            mskCutEnd.txtBox.Validating += mskCutEnd_Validating;

            mskDuration.txtBox.KeyPress += mskDuration_KeyPress;
            mskDuration.txtBox.Validating += mskDuration_Validating;

            mskTotalDuration.txtBox.KeyPress += mskTotalDuration_KeyPress;
            mskTotalDuration.txtBox.Validating += mskTotalDuration_Validating;

        }

        private void frmClip_Load(object sender, EventArgs e)
        {
            SetupOnLoad();

            UpdateHelper.InitializeCheckVersion();
        }

        private void RepositionResize()
        {
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {

                if (Properties.Settings.Default.Width != -1)
                {
                    this.Width = Properties.Settings.Default.Width;
                }


                if (Properties.Settings.Default.Height != -1)
                {
                    this.Height = Properties.Settings.Default.Height;
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

            if (this.Width < 300)
            {
                this.Width = 300;
            }

            if (this.Height < 300)
            {
                this.Height = 300;
            }

            if (this.Top < 0)
            {
                this.Top = 0;
            }

            if (this.Left < 0)
            {
                this.Left = 0;
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

        private void SetEnabled(bool enabled)
        {
            sbtnInfo.Visible = enabled;

            chkShowStoryboard.Visible = enabled;
            fadeInFadeOutToolStripMenuItem.Enabled = enabled;

            tsbPlay.Enabled = enabled;

            lbl01sec.Visible = enabled;
            lbl1sec.Visible = enabled;
            lbl3min.Visible = enabled;
            lbl30sec.Visible = enabled;
            lblKFrames.Visible = enabled;

            picMovie.Visible = enabled;

            lblMovieLength.Visible = enabled;
            lblMovieLengthValue.Visible = enabled;

            ts01sec.Visible = enabled;
            ts1sec.Visible = enabled;
            ts3min.Visible = enabled;
            ts30sec.Visible = enabled;
            tsKeyFrame.Visible = enabled;

            plMedia.Visible = enabled;
            tsbCutAdd.Enabled = enabled;
            tsbCutRemove.Enabled = enabled;
            tsbSetStart.Enabled = enabled;
            tsbSetEnd.Enabled = enabled;
            tsbCutVideo.Enabled = enabled;

            /*
            tsbExcludeMode.Enabled = enabled;
            tsbIncludeMode.Enabled = enabled;
            tsbSilenceMode.Enabled = enabled;
            */

            tsiIncludeMode.Enabled = enabled;
            tsiExcludeMode.Enabled = enabled;
            tsiSilenceMode.Enabled = enabled;

            //1tsbStopCut.Enabled = enabled;
            joinClipsToolStripMenuItem.Enabled = enabled;
            //7lblTotalDuration.Visible = enabled;
            tsbCutPlayPreview.Enabled = enabled;

            fplSegments.Visible = enabled;

            //7
            /*
            if (chkShowStoryboard.Checked)
            {                
                btnZoomIn.Visible = enabled;
                btnZoomOut.Visible = enabled;
                chkShowStoryboard.Visible = enabled;
            }
            else
            {
                
                btnZoomIn.Visible = false;
                btnZoomOut.Visible = false;
            }
            */
            editToolStripMenuItem.Enabled = enabled;
            viewToolStripMenuItem.Enabled = enabled;
            navigationToolStripMenuItem.Enabled = enabled;

            for (int k = 0; k < toolsToolStripMenuItem.DropDownItems.Count; k++)
            {
                if (toolsToolStripMenuItem.DropDownItems[k] != videoJoinerToolStripMenuItem)
                {
                    toolsToolStripMenuItem.DropDownItems[k].Enabled = enabled;
                }
            }
            //toolsToolStripMenuItem.Enabled = enabled;

            joinClipsToolStripMenuItem.Enabled = enabled;
            cmbOutputFormat.Visible = enabled;
            lblOutputFormat.Visible = enabled;


            //tsbSplitParts.Enabled = enabled;
            tsiSplitInParts.Enabled = enabled;

            saveFrameAsImageToolStripMenuItem.Enabled = enabled;

            picMain.Visible = enabled;
            HScrollbar.Visible = enabled;
        }

        private void frmClip_FormClosing(object sender, FormClosingEventArgs e)
        {
            //1Application.RemoveMessageFilter(filter);

            int ichecked = -1;

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

            for (int k = 0; k < storyboardZoomToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem tiStoryB = (ToolStripMenuItem)storyboardZoomToolStripMenuItem.DropDownItems[k];

                if (tiStoryB.Checked)
                {
                    Properties.Settings.Default.ShowStoryBoardIndex = k;
                    break;
                }
            }

            Properties.Settings.Default.Save();

            SavePositionSize();
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

            if (System.IO.Directory.Exists(VideoThumbnail.ThumbnailsPath))
            {
                string[] filez = System.IO.Directory.GetFiles(VideoThumbnail.ThumbnailsPath);

                for (int k = 0; k < filez.Length; k++)
                {
                    try
                    {
                        System.IO.File.Delete(filez[k]);
                    }
                    catch
                    {
                    }
                }
            }
        }        

        #endregion

        void co2_MouseUp(object sender, MouseEventArgs e)
        {
            picMain.MovingStartHandle = false;
            picMain.MovingEndHandle = false;
        }

        void co_Enter(object sender, EventArgs e)
        {            
             vthPreview.Visible = false;            

            lblScrollPos.Visible = false;
        }

        void mskPos_Validating(object sender, CancelEventArgs e)
        {

        }

        void mskPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                msPositionValue = FFMpegArgsHelper.GetTimeFromString(mskPos.Text);
                SeekPosition();
            }
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

        #region Segments - Cuts

        public void ClearSegmentBackColors()
        {
            for (int k = 0; k < fplSegments.Controls.Count; k++)
            {
                fplSegments.Controls[k].BackColor = SegmentBackColor;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //26.7
            if (msPositionValue == msPositionMaximum)
            {
                Module.ShowMessage("Cannot add new Clip ! You are already at the End of the Video !");
                return;
            }
            //end

            MediaSegment ms = new MediaSegment();

            try
            {
                Module.LockWindowUpdate(fplSegments.Handle);
                fplSegments.SuspendLayout();
                ms.SuspendLayout();                                                                                                                               

                if (fplSegments.Controls.Count != 0)
                {
                    MediaSegment ms1 = fplSegments.Controls[fplSegments.Controls.Count - 1] as MediaSegment;
                    /* 26.7
                    if (ms1.EndMSecs == msPositionMaximum)
                    {
                        Module.ShowMessage("Cannot add new Clip ! Your last Clip already is at the End of the Video !");
                        return;
                    }
                    */                    
                                        
                    //25.7 ms.msSegment.SetRangeStart(ms1.EndMSecs + 1);
                    ms.StartMSecs = msPositionValue;
                    ms.EndMSecs = LengthTotalMSecs;                                                           

                    msPositionValue = ms.StartMSecs;
                    
                }
                else
                {
                    ms.StartMSecs = 0;
                    ms.EndMSecs=LengthTotalMSecs;                                                                                

                    msPositionValue = ms.StartMSecs;
                }


                fplSegments.Controls.Add(ms);

                //1ms.lblSegment.Text = TranslateHelper.Translate("Clip")+" : "+ (fplSegments.Controls.Count).ToString("D2");
                ms.lblSegment.Text = (fplSegments.Controls.Count).ToString("D2");

                int dsec = ms.EndMSecs - ms.StartMSecs;
                ms.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(dsec);
                ms.mskDuration.LastAcceptedValue = ms.mskDuration.Text;

                ms.mskStart.Text = FFMpegArgsHelper.GetStringFromTime(ms.StartMSecs);
                ms.mskStart.LastAcceptedValue = ms.mskStart.Text;

                ms.mskEnd.Text = FFMpegArgsHelper.GetStringFromTime(ms.EndMSecs);
                ms.mskEnd.LastAcceptedValue = ms.mskEnd.Text;

                fplSegments.SetFlowBreak(ms, true);

                this.DoNotSetMsPositionOnSetActive = true;
                SetActiveSegment(ms);
                this.DoNotSetMsPositionOnSetActive = false;

                UpdateVideoThumbnail();
                UpdateVideoEndThumbnail();
                UpdateTotalDuration();

                //25.7 SeekPosition();                                                

            }
            finally
            {
                fplSegments.ResumeLayout();
                ms.ResumeLayout();

                Module.LockWindowUpdate(IntPtr.Zero);

                this.DoNotSetMsPositionOnSetActive = false;

                if (fplSegments.Controls.Count > 1)
                {
                    tsbCutRemove.Enabled = true;
                }
                else
                {
                    tsbCutRemove.Enabled = false;
                }
            }
        }        

        private int GetMsSegmentPixels(int msposition_pixels)
        {
            // mspos.width mssegm.width
            // mspospixe x;

            if (fplSegments.Controls.Count == 0) return msposition_pixels;

            MediaSegment ms=fplSegments.Controls[0] as MediaSegment;

            //7return (int)((float)(msposition_pixels * ms.msSegment.Width) / (float)msPosition.Width);
            return 0;
        }

        private int GetMsPositionPixels(int mssegment_pixels)
        {
            // mspos.width mssegm.width
            // x;    mssegmentpixels

            if (fplSegments.Controls.Count == 0) return mssegment_pixels;

            MediaSegment ms = fplSegments.Controls[0] as MediaSegment;

            //7return (int)((float)(mssegment_pixels*msPosition.Width) / (float)ms.msSegment.Width);
            return 0;
        }
        
        public MediaSegment ActiveMediaSegment = null;
        public bool DoNotSetMsPositionOnSetActive = false;

        public void SetActiveSegment(MediaSegment ms)
        {
            if (ms == null) return;

            ActiveMediaSegment = ms;                       

            //26.7
            if (!DoNotSetMsPositionOnSetActive)
            {
                //ActiveMediaSegment.picThumbnailStart_Click(null, null);                
            }

            ClearSegmentBackColors();
            ms.BackColor = SegmentActiveBackColor;                                 

            int k = fplSegments.Controls.IndexOf(ms);           

            if (k > 0)
            {
                MediaSegment ms1 = (MediaSegment)fplSegments.Controls[k - 1];

                //21.7 msPosition.MinRangeStartPixels = ms1.EndMSecsPixels;
                //23.7 msPosition.MinRangeStartPixels = ms1.RangeEndPixelsMsPosition;
                //7msPosition.MinRangeStartPixels = 0;
                    //MediaSegment.GetRelativeSize(ms1.EndMSecsPixels, ms1.msSegment.Width, msPosition.Width);
            }
            else 
            {
                //7msPosition.MinRangeStartPixels = 0;
            }

            /*
            msPosition.ForSetValuePixels = true;

            //21.7 msPosition.RangeStartPixels = ms.StartMSecsPixels;
            //21.7 msPosition.RangeEndPixels = ms.EndMSecsPixels;

            msPosition.RangeStartPixels = ms.RangeStartPixelsMsPosition;
            msPosition.RangeEndPixels = ms.RangeEndPixelsMsPosition;
            //msPosition.RangeStartPixels = MediaSegment.GetRelativeSize(ms.StartMSecsPixels, ms.msSegment.Width, msPosition.Width);
            //msPosition.RangeEndPixels = MediaSegment.GetRelativeSize(ms.EndMSecsPixels, ms.msSegment.Width, msPosition.Width);

            msPosition.ForSetValuePixels = false;
            */

            //23.7                     
            
            //end


            msPositionValue = ms.StartMSecs;
            mskCutStart.Text = ms.mskStart.Text;
            mskCutEnd.Text = ms.mskEnd.Text;
            mskDuration.Text = ms.mskDuration.Text;

            /*8
            picMain.PaintStoryboardBar();
            picMain.PaintStartFrame();
            picMain.PaintEndFrame();*/

            picMain.PaintImg();
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

            if (fplSegments.Controls.Count > 1)
            {
                tsbCutRemove.Enabled = true;
            }
            else
            {
                tsbCutRemove.Enabled = false;
            }
        }

        private string TotalDuration = "";
        private int TotalDurationMSecs = 0;

        public void UpdateTotalDuration()
        {
            int secs = 0;

            foreach (MediaSegment ms in fplSegments.Controls)
            {
                secs += ms.EndMSecs - ms.StartMSecs;
            }

            /*8?
            if (secs > msPositionMaximum)
            {
                secs = msPositionMaximum;
            }
            */
            TotalDuration = FFMpegArgsHelper.GetStringFromTime(secs);

            TotalDurationMSecs = secs;

            //lblTotalDuration.Text = TranslateHelper.Translate("Total Clip Duration") + " : " + TotalDuration;
            mskTotalDuration.Text = TotalDuration;
            mskTotalDuration.LastAcceptedValue = TotalDuration;
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
            if (ActiveMediaSegment.LastMskEndText != ActiveMediaSegment.mskEnd.Text)
            {
                VideoThumbnail vt = new VideoThumbnail(filepath, ActiveMediaSegment.mskEnd.Text);
                ActiveMediaSegment.picThumbnailEnd.Image = vt.ThumbnailImage;
                ActiveMediaSegment.LastMskEndText = ActiveMediaSegment.mskEnd.Text;

            }
        }        

        #endregion                                

        #region Media Player

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
                args_play = " -nofs  -noquiet  -osdlevel 0 -identify -slave -volume 0 ";
                args_play += "-nomouseinput -sub-fuzziness 1 ";

                //-wid will tell MPlayer to show output inisde our panel
                args_play += " -vo direct3d -ao dsound ";
                args_play += " -wid " + picMovie.Handle.ToString();

                args_play += " -ss " + FFMpegArgsHelper.GetStringFromTime(msPositionValue);

                ps.StartInfo.Arguments = args_play + " " + filename + "";
                ps.Start();

                //System.Threading.Thread.Sleep(200);

                SetProcessPriorityHelperPartial.SetProcessPriority(ref ps);

                //0timDebug.Enabled = true;

                PlayK = 0;

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

        // <summary>
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
                    //8SeekPositionMplayer();                    

                    //ps.StandardInput.Write("loadfile \"" +filepath+"\" \n");
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

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (filepath == string.Empty)
            {
                msPositionMaximum = 1;
                return;
            }

            if (PlayerState != PlayerStateEnum.Playing
    && PlayerState != PlayerStateEnum.PlayingSegment
    && PlayerState != PlayerStateEnum.PlayingAllSegments)
            {
                if (PlayerState == PlayerStateEnum.Paused || PlayerState == PlayerStateEnum.PausedSegment || PlayerState == PlayerStateEnum.PausedAllSegments)
                {
                    picScreenshot.Visible = false;
                    picMovie.Visible = true;

                    // resume after pause

                    //1btnPlay.Image = Properties.Resources.pause;

                    if (PlayerState == PlayerStateEnum.Paused)
                    {
                        tsbPlay.Image = Properties.Resources.media_pause;
                        tsbPlay.Text = TranslateHelper.Translate("&Pause");
                        tsbStop.Visible = true;
                    }
                    else
                    {
                        tsbCutPlayPreview.Image = Properties.Resources.media_pause;
                        tsbCutPlayPreview.Text = TranslateHelper.Translate("&Pause");
                        tsbStopPreview.Visible = true;
                    }

                    SendCommand("pause");

                    if (PlayerState == PlayerStateEnum.Paused)
                    {
                        PlayerState = PlayerStateEnum.Playing;
                    }
                    else if (PlayerState == PlayerStateEnum.PausedSegment)
                    {
                        PlayerState = PlayerStateEnum.PlayingSegment;
                    }
                    else if (PlayerState == PlayerStateEnum.PausedAllSegments)
                    {
                        PlayerState = PlayerStateEnum.PlayingAllSegments;
                    }

                    if (btnMute.Checked)
                    {
                        SendCommand("mute 1");
                    }
                    else
                    {
                        SendCommand("set_property volume " + msVolume.Value);
                    }

                }
                else if (PlayerState == PlayerStateEnum.Stopped || PlayerState == PlayerStateEnum.StoppedSegment || PlayerState == PlayerStateEnum.StoppedAllSegments)
                {
                    picScreenshot.Visible = false;
                    picMovie.Visible = true;
                    picMovie.BringToFront();

                    // play from start

                    filename = "\"" + filepath + "\"";
                    OpenFile();
                    //msPositionValue = 0;
                    //msPositionMaximum = LengthTotalMSecs;

                    //1btnStop.Enabled = true;
                    //btnFastForward.Enabled = true;
                    //btnRewind.Enabled = true;                    

                    //7
                    /*
                    int dsecs = msPositionValue / 10;
                    int dms = int.Parse(msPositionValue.ToString().Substring(msPositionValue.ToString().Length - 1, 1));
                    
                    SendCommand("seek " + dsecs.ToString()+"."+dms.ToString() + " 2 1");
                    */

                    //8string strmspos = FFMpegArgsHelper.GetSecsTimeFromMsecs(msPositionValue);
                    //*SendCommand("seek " + strmspos + " 2 1");

                    picScreenshot.Visible = false;
                    picMovie.Visible = true;
                    picMovie.BringToFront();

                    //8SeekPositionMplayer();

                    if (PlayerState == PlayerStateEnum.Stopped)
                    {
                        //1btnPlay.Image = Properties.Resources.pause;
                        tsbPlay.Image = Properties.Resources.media_pause;
                        tsbPlay.Text = TranslateHelper.Translate("&Pause");
                        tsbStop.Visible = true;

                        PlayerState = PlayerStateEnum.Playing;
                    }
                    else if (PlayerState == PlayerStateEnum.StoppedAllSegments || PlayerState == PlayerStateEnum.StoppedSegment)
                    {
                        //1btnPlay.Image = Properties.Resources.pause;
                        tsbCutPlayPreview.Image = Properties.Resources.media_pause;
                        tsbCutPlayPreview.Text = TranslateHelper.Translate("&Pause");
                        tsbStopPreview.Visible = true;

                        if (PlayerState == PlayerStateEnum.StoppedAllSegments)
                        {
                            PlayerState = PlayerStateEnum.PlayingAllSegments;
                        }
                        else if (PlayerState == PlayerStateEnum.StoppedSegment)
                        {
                            PlayerState = PlayerStateEnum.PlayingSegment;
                        }
                    }

                    //8SendCommand("pause");

                    if (btnMute.Checked)
                    {
                        SendCommand("mute 1");
                    }
                    else
                    {
                        SendCommand("set_property volume " + msVolume.Value);
                    }

                    if (msPositionValue == msPositionMaximum)
                    {
                        btnStop_Click(null, null);
                    }
                }
            }
            else
            {
                // pause

                //1btnPlay.Image = Properties.Resources.play;

                //tsbStop.Visible = false;

                SendCommand("pause");

                if (PlayerState == PlayerStateEnum.Playing)
                {
                    PlayerState = PlayerStateEnum.Paused;
                    tsbPlay.Image = Properties.Resources.media_play_green1;
                    tsbPlay.Text = TranslateHelper.Translate("&Play");
                }
                else if (PlayerState == PlayerStateEnum.PlayingSegment)
                {
                    PlayerState = PlayerStateEnum.PausedSegment;
                    tsbCutPlayPreview.Image = Properties.Resources.media_play1;
                    tsbCutPlayPreview.Text = TranslateHelper.Translate("&Play Preview");
                }
                else if (PlayerState == PlayerStateEnum.PlayingAllSegments)
                {
                    PlayerState = PlayerStateEnum.PausedAllSegments;
                    tsbCutPlayPreview.Image = Properties.Resources.media_play1;
                    tsbCutPlayPreview.Text = TranslateHelper.Translate("&Play Preview");
                }

                SeekPosition();
            }

        }                       
        public void btnStop_Click(object sender, EventArgs e)
        {
            SendCommand("stop");
            msPositionValue = 0;
            //1btnPlay.Image = Properties.Resources.play;
            PlayerState = PlayerStateEnum.Stopped;
            //btnFastForward.Enabled = false;
            //btnRewind.Enabled = false;
            //1picMovie.Image = MovieImage;

            System.Threading.Thread.Sleep(100);

            SeekPosition();

            ResetImagesOnStop();

            picMain.PaintCurrentFrame();

        }

        private void ResetImagesOnStop()
        {
            tsbCutPlayPreview.Image = Properties.Resources.media_play1;
            tsbCutPlayPreview.Text = TranslateHelper.Translate("Play Preview");

            tsbPlay.Image = Properties.Resources.media_play_green1;
            tsbPlay.Text = TranslateHelper.Translate("Play");

            tsbStop.Visible = false;
            tsbStopPreview.Visible = false;

            for (int k = 0; k < fplSegments.Controls.Count; k++)
            {
                MediaSegment ms = (MediaSegment)fplSegments.Controls[k];
                ms.btnPlay.Image = Properties.Resources.media_play;
                ms.btnPlay.Tag = "Play";
            }
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (!btnMute.Checked)
            {
                string str = "";
                if (PlayerState == PlayerStateEnum.Paused || PlayerState == PlayerStateEnum.PausedSegment || PlayerState == PlayerStateEnum.PausedAllSegments)
                {
                    str = "pausing ";
                }

                SendCommand(str + "mute");
            }
            else
            {

                string str = "";
                if (PlayerState == PlayerStateEnum.Paused || PlayerState == PlayerStateEnum.PausedSegment || PlayerState == PlayerStateEnum.PausedAllSegments)
                {
                    str = "pausing ";
                }

                SendCommand(str + "mute 0");

            }
        }

        private void msVolume_ValueChanged(object sender, EventArgs e)
        {
            string str = "";
            if (PlayerState == PlayerStateEnum.Paused || PlayerState == PlayerStateEnum.PausedSegment || PlayerState == PlayerStateEnum.PausedAllSegments)
            {
                str = "pausing ";
            }
            SendCommand(str + "set_property volume " + msVolume.Value);

        }

        public void PlaySegment(int startsecs, int endsecs)
        {
            //btnStop_Click(null, null);
            //SendCommand("stop");

            CurrentSegment = 0;
            lstSegmentPlay.Clear();
            lstSegmentPlay.Add(new SegmentPlay() { StartSecs = startsecs, EndSecs = endsecs });

            msPositionValue = startsecs;
            PlayerState = PlayerStateEnum.StoppedSegment;
            btnPlay_Click(null, null);
            PlayerState = PlayerStateEnum.PlayingSegment;

        }

        private void PlayNextSegment()
        {
            CurrentSegment++;

            if (CurrentSegment < lstSegmentPlay.Count)
            {
                //8btnStop_Click(null, null);

                SendCommand("stop");
                //8msPositionValue = 0;

                //SeekPositionMplayer();

                //PlayerState = PlayerStateEnum.Stopped;                

                //System.Threading.Thread.Sleep(100);

                //8SeekPosition();

                //8ResetImagesOnStop();

                //8picMain.PaintCurrentFrame();

                PlayerState = PlayerStateEnum.StoppedAllSegments;
                msPositionValue = lstSegmentPlay[CurrentSegment].StartSecs;
                //8SeekPositionMplayer();

                btnPlay_Click(null, null);

                //03.14 added comment
                DoNotSetMsPositionOnSetActive = true;
                if (CurrentCutMode != CutMode.Exclude)
                {
                    SetActiveSegment(fplSegments.Controls[CurrentSegment] as MediaSegment);
                }
                else
                {
                    SetActiveSegmentForExcludePreview(fplSegments.Controls[CurrentSegment] as MediaSegment);
                }
                DoNotSetMsPositionOnSetActive = false;
                //end

                //PlayerState = PlayerStateEnum.PlayingAllSegments;
            }
            else if (CurrentSegment >= lstSegmentPlay.Count)
            {
                btnStop_Click(null, null);
            }
            else
            {
                btnPlay_Click(null, null);
            }
        }

        private void SetActiveSegmentForExcludePreview(MediaSegment ms)
        {
            if (ms == null) return;

            ClearSegmentBackColors();
            ms.BackColor = SegmentActiveBackColor;

            picMain.Invalidate();
        }

        private void btnPlayAll_Click(object sender, EventArgs e)
        {
            if (PlayerState == PlayerStateEnum.PlayingAllSegments || PlayerState == PlayerStateEnum.PlayingSegment
                || PlayerState == PlayerStateEnum.PausedAllSegments || PlayerState == PlayerStateEnum.PausedSegment)
            {
                //1btnStop_Click_1(null, null);
                btnPlay_Click(null, null);
                return;
            }

            CurrentSegment = -1;

            lstSegmentPlay.Clear();

            /*
            for (int k = 0; k < fplSegments.Controls.Count; k++)
            {
                MediaSegment ms = fplSegments.Controls[k] as MediaSegment;                
                lstSegmentPlay.Add(new SegmentPlay() { StartSecs = ms.StartSecs, EndSecs = ms.EndSecs });
            }
            */

            List<Segment> segments = new List<Segment>();

            if (CurrentCutMode == CutMode.Include)
            {
                segments = GetIncludeModeSegments();
            }
            else if (CurrentCutMode == CutMode.Exclude)
            {
                segments = GetExcludeModeSegments();
            }

            for (int k = 0; k < segments.Count; k++)
            {
                lstSegmentPlay.Add(new SegmentPlay() { StartSecs = segments[k].RangeStart, EndSecs = segments[k].RangeEnd });
            }


            PlayNextSegment();
            //1tsbCutPlayPreview.Image = Properties.Resources.media_stop1;
            //1tsbCutPlayPreview.Text = TranslateHelper.Translate("Stop Preview");
        }

        private void timPlayerPosition_Tick(object sender, EventArgs e)
        {
            if (PlayerState == PlayerStateEnum.Playing
                || PlayerState == PlayerStateEnum.PlayingSegment
                || PlayerState == PlayerStateEnum.PlayingAllSegments)
            {
                try
                {

                    if (msPositionValue + 100 <= msPositionMaximum)
                    {
                        msPositionValue = msPositionValue + 100;

                        PlayK++;

                        //if (msPositionValue % 500 <= 100)
                        if (PlayK == 5)
                        {
                            PlayK = 0;

                            //5picMain.UpdatePlayPosition(msPositionValue * 10);

                            int curplaypos = picMain.CalculatePositionFromMsecs(frmClip.Instance.msPositionValue);

                            //picMain.Invalidate();

                            //picMain.Invalidate(new Rectangle(picMain.OldPlayPosition-16, 0, 16, picMain.Height));

                            //picMain.Invalidate(new Rectangle(curplaypos-16,0,16,picMain.Height));
                            //picMain.Invalidate();

                            //picMain.PaintImg();

                            picMain.PaintWhilePlaying();

                        }

                        if (PlayerState == PlayerStateEnum.PlayingSegment)
                        {
                            /*
                            if (lstSegmentPlay[CurrentSegment].EndSecs <= msPositionValue)
                            {
                                btnPlay_Click(null, null);
                            }
                            */

                            if (lstSegmentPlay[CurrentSegment].EndSecs <= msPositionValue)
                            {
                                btnStop_Click(null, null);
                            }
                        }
                        else if (PlayerState == PlayerStateEnum.PlayingAllSegments)
                        {
                            if (lstSegmentPlay[CurrentSegment].EndSecs <= msPositionValue)
                            {
                                PlayNextSegment();
                            }
                        }

                        //2lblTime.Text = FFMpegArgsHelper.GetStringFromTime(msPositionValue) + " / " + MovieLength;                        
                        mskPos.Text = FFMpegArgsHelper.GetStringFromTime(msPositionValue);
                        //7lblTime.Text = " / " + MovieLength;
                    }
                    else
                    {
                        if (PlayerState != PlayerStateEnum.PlayingAllSegments)
                        {
                            btnStop_Click(null, null);
                        }
                        else if (PlayerState == PlayerStateEnum.PlayingAllSegments)
                        {
                            PlayNextSegment();
                        }
                    }
                }
                catch
                {

                }
            }
        }        

        #endregion        
        
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
                drp["cJoinSplitParts"] = Properties.Settings.Default.JoinParts;
                drp["cIsPartOfSplit"] = true;
                drp["cdisabled"]=!Properties.Settings.Default.JoinParts;
                
                drp["cParentId"] = -1;

                // join split parts into one file...

                if (Properties.Settings.Default.JoinParts)
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
                    dr["cJoinSplitParts"] = Properties.Settings.Default.JoinParts;
                    dr["cIsPartOfSplit"] = true;
                    dr["cdisabled"] = Properties.Settings.Default.JoinParts;
                    

                    dr["cStartSecs"] = ms1.StartMSecs;
                    TimeSpan ts = new TimeSpan(0, 0, ms1.StartMSecs);
                    dr["cStart"] = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

                    dr["cEndSecs"] = ms1.EndMSecs;
                    ts = new TimeSpan(0, 0, ms1.EndMSecs);
                    dr["cEnd"] = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

                    int jj = j + 1;
                    dr["cname"] = TranslateHelper.Translate("Segment") + " " + jj.ToString() + " (" + dr["cStart"].ToString() +
                    " - " + dr["cend"].ToString() + ")" + " - " + ParentRow["cname"].ToString();

                    int ilen = ms1.EndMSecs - ms1.StartMSecs;
                    dr["cLengthSecs"] = ilen;
                    ts = new TimeSpan(0, 0, ilen);
                    dr["cLength"] = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

                    string file = ParentRow["cInputFile"].ToString();
                    string dir = System.IO.Path.GetDirectoryName(file);

                    string newfilename = dr["cname"].ToString().Replace(":", "_");
                    string newfile = System.IO.Path.Combine(dir, newfilename);

                    if (!Properties.Settings.Default.JoinParts)
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
//                    frmMain.Instance.dt.Rows[rind]["cJoinSplitParts"] = Properties.Settings.Default.JoinParts;
//                    frmMain.Instance.dt.Rows[rind]["cIsPartOfSplit"] = true;

                    frmMain.Instance.dt.Rows.InsertAt(dr, rind + 1 + j);
                }
            }
            */
            this.DialogResult = DialogResult.OK;
        }        

        #region Help Menu

        private void helpUsersManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Application.StartupPath + "\\Video Cutter Joiner Expert - User's Manual.chm");
            System.Diagnostics.Process.Start(Module.HelpURL);
        }

        private void pleaseDonateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/donate.php");
        }

        private void dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/downloads/4dots-Software-PRODUCT-CATALOG.pdf");
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

        private void checkForNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Module.CheckVersion(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private List<string> lstImages = new List<string>();

        string LastInputFile = "";

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

        #region Toolbar Functions

        private void AddFile(string file)
        {
            try
            {
                if (!System.IO.File.Exists(file))
                {
                    Module.ShowMessage("Video File does not exist !");
                    return;
                }

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
                    int ddec = int.Parse(slen.Substring(dpos + 1, 2));
                    
                    int dms = 1000 * dint + ddec*10;

                    //decimal dlen = (decimal)dint + (decimal)ddec/(decimal)10;                    
                    //int len = (int)decimal.Parse(slen);

                    //8
                    FFMPEGInfo finfo = new FFMPEGInfo(file);
                    //end


                    //8LengthTotalMSecs = dms;

                    LengthTotalMSecs = finfo.DurationMsecs;

                    /*7
                    LengthISecs = dint;
                    LengthIMSecs = ddec * 100;

                    secs = dms;
                    
                    msPositionValue = 0;
                    msPositionMaximum = dms;
                     
                    */

                    msPositionValue = 0;
                    msPositionMaximum = LengthTotalMSecs;

                    if (dms == 0)
                    {
                        Module.ShowMessage("Unsupported File Type !");
                        SetEnabled(false);
                        return;
                    }

                    /*
                    TimeSpan ts = new TimeSpan(0, 0, 0, dint, ddec * 100);
                    MovieLength = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "."+ddec.ToString(); 
                     
                    */

                    MovieLength = TimeSpanHelper.MsecsToFFMpegString(LengthTotalMSecs);

                    lblMovieLengthValue.Text = MovieLength;

                    tlblVideoFile.Text = file;

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
                
                //1btnPlay.Enabled = true;
                filepath = file;

                /*
                TimeSpan ts1 = new TimeSpan(0, 0, 0, LengthISecs, LengthIMSecs);
                picMain.TimeSpan = ts1; 
                 
                */

                picMain.dicImages.Clear();
                picMain.dicAudioFiles.Clear();
                picMain.dicAudioImages.Clear();
                picMain.dicAudioImageFiles.Clear();

                picMain.TimeSpan = new TimeSpan(0, 0, 0, 0, LengthTotalMSecs);

                picMain.StoryboardTimeFrameLengthMsecs = 5000;                                                                                

                //2lblTime.Text = ts1.Hours.ToString("D2") + ":" + ts1.Minutes.ToString("D2") + ":" + ts1.Seconds.ToString("D2") + "."+lms.ToString() + " / " + MovieLength;
                //7mskPos.Text = FFMpegArgsHelper.GetStringFromTime(LengthIMSecs);
                //7lblTime.Text= " / " + MovieLength;                

                btnAdd_Click(null, null);
                
                TimeSpan ts2 = new TimeSpan(0, 0, 0);
                
                mskPos.Text = TimeSpanHelper.MsecsToFFMpegString(0);
                
                //btnPlay_MouseClick(null, null);
                //System.Threading.Thread.Sleep(300);
                //btnPlay_MouseClick(null, null);

                filename = "\"" + file + "\"";
                Initialized = false;
                OpenFile();
                SeekPosition();
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

                //1btnPlay.Enabled = true;

                Initialized = true;

                //8picMain.PaintImg();
                tlblVideoFile.Text = file;

                RecentFilesHelper.AddRecentFile(file);   
             

                //"All Supported Video Files (*.avi;*.mp4;*.mpeg;*.mpg;*.mov;*.mkv;*.flv;*.wmv;*.3gp;*.vob;*.swf)|"+

                string ext = System.IO.Path.GetExtension(file).Substring(1).ToUpper();

                for (int k = 0; k < cmbOutputFormat.Items.Count; k++)
                {
                    if (cmbOutputFormat.Items[k].ToString().StartsWith(ext + " "))
                    {
                        cmbOutputFormat.SelectedIndex = k;
                        break;
                    }
                }
                
            }
            finally
            {
                this.Cursor = null;
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

        private void tsbCutOpenVideo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            AddFile(e.ClickedItem.Text);
        }

        public void btnSetEnd_Click(object sender, EventArgs e)
        {
            if (msPositionValue <= ActiveMediaSegment.StartMSecs)
            {
                return;
            }

            ActiveMediaSegment.EndMSecs = msPositionValue;

            this.Invalidate();                        
            
            //25.7 frmClip.Instance.SeekPosition();

            ActiveMediaSegment.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.EndMSecs - ActiveMediaSegment.StartMSecs);
            ActiveMediaSegment.mskDuration.LastAcceptedValue = ActiveMediaSegment.mskDuration.Text;
            
            ActiveMediaSegment.mskEnd.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.EndMSecs);
            ActiveMediaSegment.mskEnd.LastAcceptedValue = ActiveMediaSegment.mskEnd.Text;

            UpdateVideoEndThumbnail();
            UpdateTotalDuration();

            picMain.PaintImg();
            
            picMain.PaintStoryboardBar();
            picMain.PaintEndFrame();
            

            
        }
        
        /*
        public void SetEndWhileMovingHandles()
        {
            ActiveMediaSegment.EndMSecs = msPositionValue;

            ActiveMediaSegment.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.EndMSecs - ActiveMediaSegment.StartMSecs);
            ActiveMediaSegment.mskDuration.LastAcceptedValue = ActiveMediaSegment.mskDuration.Text;

            ActiveMediaSegment.mskStart.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.StartMSecs);
            ActiveMediaSegment.mskStart.LastAcceptedValue = ActiveMediaSegment.mskStart.Text;

            UpdateTotalDuration();

            picMain.PaintStoryboardBar();            

        }
        public void SetStartWhileMovingHandles()
        {
            ActiveMediaSegment.StartMSecs = msPositionValue;            
            
            ActiveMediaSegment.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.EndMSecs - ActiveMediaSegment.StartMSecs);
            ActiveMediaSegment.mskDuration.LastAcceptedValue = ActiveMediaSegment.mskDuration.Text;

            ActiveMediaSegment.mskStart.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.StartMSecs);
            ActiveMediaSegment.mskStart.LastAcceptedValue = ActiveMediaSegment.mskStart.Text;
            
            UpdateTotalDuration();            

            picMain.PaintStoryboardBar();
            picMain.PaintStartFrame();          
        }
        */

        public void btnSetClipStart_Click(object sender, EventArgs e)
        {
            //21.7.14
            if (msPositionValue > ActiveMediaSegment.EndMSecs)
            {
                btnSetEnd_Click(null, null);
            }
            //end

            ActiveMediaSegment.StartMSecs = msPositionValue;

            this.Invalidate();            

            //25.7 frmClip.Instance.SeekPosition();

            ActiveMediaSegment.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.EndMSecs - ActiveMediaSegment.StartMSecs);
            ActiveMediaSegment.mskDuration.LastAcceptedValue = ActiveMediaSegment.mskDuration.Text;
            
            ActiveMediaSegment.mskStart.Text = FFMpegArgsHelper.GetStringFromTime(ActiveMediaSegment.StartMSecs);
            ActiveMediaSegment.mskStart.LastAcceptedValue = ActiveMediaSegment.mskStart.Text;
            
            UpdateVideoThumbnail();
            UpdateTotalDuration();

            picMain.PaintImg();
            
            picMain.PaintStoryboardBar();
            picMain.PaintStartFrame();          
            
        }

        #endregion                                                              

        #region Other Menu Functions

        private void saveFrameAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaveFrameImage f = new frmSaveFrameImage();

            if (f.ShowDialog() == DialogResult.OK)
            {

                string time_position = FFMpegArgsHelper.GetStringFromTime(msPositionValue);

                string fn_time_position = time_position.Replace(":", "_");

                saveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(filepath);
                saveFileDialog1.FileName = "frame_" + fn_time_position + ".jpg";
                saveFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        VideoThumbnail.SaveFrameAsImage(filepath, f.rdOriginalSize.Checked,
                            f.chkWidth.Checked ? (int)f.nudWidth.Value : -1,
                            f.chkHeight.Checked ? (int)f.nudHeight.Value : -1,
                            time_position, saveFileDialog1.FileName);
                    }
                    catch (Exception ex)
                    {
                        frmError fe = new frmError("Error could not Save Frame as Image !", ex.Message);
                        fe.ShowDialog(this);
                    }
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

            if (sender == highToolStripMenuItem)
            {
                ThreadPriorityLevel = ThreadPriority.High;                
            }
            else if (sender == normalToolStripMenuItem)
            {
                ThreadPriorityLevel = ThreadPriority.Normal;
                
            }
            else if (sender == aboveNormalToolStripMenuItem)
            {
                ThreadPriorityLevel = ThreadPriority.AboveNormal;

            }
            else if (sender == belowNormalToolStripMenuItem)
            {
                ThreadPriorityLevel = ThreadPriority.BelowNormal;                
            }
            else if (sender == idleToolStripMenuItem)
            {
                ThreadPriorityLevel = ThreadPriority.Idle;
            }

            SetProcessPriorityHelperPartial.SetProcessPriority(ref psFFMpeg);

        }

        #endregion

        #region Navigation

        private void jumpToMovieEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msPositionValue = msPositionMaximum;
            SeekPosition();

        }

        private void jumpToMovieStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msPositionValue = 0;
            SeekPosition();
        }

        private void jumpToCutEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msPositionValue = ActiveMediaSegment.EndMSecs;
            SeekPosition();
        }

        private void jumpToCutStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msPositionValue = ActiveMediaSegment.StartMSecs;
            SeekPosition();
        }

        private void tsbMoveBackKFrame_Click(object sender, EventArgs e)
        {
            FFMpegKeyFrameInfo finfo = new FFMpegKeyFrameInfo(filepath, msPositionValue, false);

            if (finfo.PreviousKeyFrameMsecs != -1)
            {
                msPositionValue = finfo.PreviousKeyFrameMsecs;
                SeekPosition();
            }
        }

        private void tsbMoveForwardKFrame_Click(object sender, EventArgs e)
        {
            FFMpegKeyFrameInfo finfo = new FFMpegKeyFrameInfo(filepath, msPositionValue, true);

            if (finfo.NextKeyFrameMsecs != -1)
            {
                msPositionValue = finfo.NextKeyFrameMsecs;
                SeekPosition();
            }
        }

        private void tsbMoveBack_Click(object sender, EventArgs e)
        {   
            if (msPositionValue > 0)
            {
                msPositionValue--;
                msPositionMouseDown  = true;
                msPosition_ValueChanged(null, null);
                msPositionMouseDown = false;
            }
        }
        
        private void tsbMoveForward_Click(object sender, EventArgs e)
        {
            /*
            int dsecs = msPositionValue / 10;
            string ssecs = msPositionValue.ToString();
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
            //SendCommand("pausing set property time_pos " + msPositionValue.ToString() + "." + MsecStep.ToString());
            
            //SendCommand("pausing get property time_pos");
            //" + msPositionValue.ToString() + "." + MsecStep.ToString() + " 2 1");
            
            MsecStep++;

            if (MsecStep == 9)
            {
                MsecStep = 0;
            }

            MessageBox.Show(dsecs.ToString() + "." + dms.ToString());

            return;
            */

            if (msPositionValue < msPositionMaximum)
            {
                msPositionValue++;
                msPositionMouseDown = true;
                msPosition_ValueChanged(null, null);
                msPositionMouseDown = false;
            }
        }
                
        private void tsbMovePosition(int step)
        {            
            if (step > 0)
            {
                if ((msPositionValue + step) > msPositionMaximum)
                {
                    msPositionValue = msPositionMaximum;
                }
                else
                {
                    msPositionValue += step;
                }
            }
            else if (step < 0)
            {
                if (msPositionValue + step < 0)
                {
                    msPositionValue = 0;
                }
                else
                {
                    msPositionValue += step;
                }
            }

            SeekPosition();
        }

        public void tsbMoveBackMsec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(-100);
        }

        public void tsbMoveForwardMsec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(100);
        }

        public void tsbMoveBack1Sec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(-1000);
        }

        public void tsbMoveForward1Sec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(1000);
        }

        public void tsbMoveBack30Sec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(-30 * 1000);
        }

        public void tsbMoveForward30Sec_Click(object sender, EventArgs e)
        {
            tsbMovePosition(30 * 1000);
        }

        public void tsbMoveBack3Min_Click(object sender, EventArgs e)
        {
            tsbMovePosition(-3*60 * 1000);
        }

        public void tsbMoveForward3Min_Click(object sender, EventArgs e)
        {
            tsbMovePosition(3 * 60 * 1000);
        }

        private void selectNextCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ic = fplSegments.Controls.IndexOf(ActiveMediaSegment);

            if (ic >= 0 && ic < fplSegments.Controls.Count - 1)
            {
                frmClip.Instance.SetActiveSegment((MediaSegment)fplSegments.Controls[ic + 1]);
            }
        }

        private void selectPreviousCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ic = fplSegments.Controls.IndexOf(ActiveMediaSegment);

            if (ic >= 1)
            {
                frmClip.Instance.SetActiveSegment((MediaSegment)fplSegments.Controls[ic - 1]);
            }
        }

        #endregion

        #region Drag and Drop Function

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
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void frmClip_DragOver(object sender, DragEventArgs e)
        {            
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        #endregion                

        #region Cut Function

        public void CreateFFMpegProcess()
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

        public void tsbCutVideo_Click(object sender, EventArgs e)
        {
            if (ConversionStarted)
            {
                if (!psFFMpeg.HasExited)
                {
                    SuspendResumeThread.SuspendProcess(psFFMpeg.Id);
                    ConversionPaused = true;
                    ConversionStarted = false;
                    timCut.Enabled = false;
                    //1tsbCutVideo.Image = Properties.Resources.cut1;
                    //1tsbCutVideo.Text = TranslateHelper.Translate("Resume");

                    if (frmProgress.Instance != null)
                    {
                        frmProgress.Instance.btnPause.Image = Properties.Resources.cut1;
                        frmProgress.Instance.btnPause.Text = TranslateHelper.Translate("Resume");
                        frmProgress.Instance.timTime.Enabled = false;
                    }
                }
            }
            else if (ConversionPaused)
            {
                ConversionStarted = true;
                ConversionPaused = true;
                timCut.Enabled = true;
                SuspendResumeThread.ResumeProcess(psFFMpeg.Id);
                //1tsbCutVideo.Image = Properties.Resources.media_pause;
                //1tsbCutVideo.Text = TranslateHelper.Translate("Pause Cut");

                if (frmProgress.Instance != null)
                {
                    frmProgress.Instance.btnPause.Image = Properties.Resources.media_pause;
                    frmProgress.Instance.btnPause.Text = TranslateHelper.Translate("Pause");
                    frmProgress.Instance.timTime.Enabled = true;
                }
            }
            else
            {
                if (Properties.Settings.Default.MsgCutWithKeepSameFormat)
                {
                    frmMsgCheckBox fmc = new frmMsgCheckBox(frmMsgCheckBox.MsgModeEnum.OnCutWithKeepSameFormat,
                    TranslateHelper.Translate("For more accurate cutting, please select a Specific Output Format and do not just select to keep the same format"));

                    fmc.ShowDialog();
                }

                if (fplSegments.Controls.Count > 1 && cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                {
                    Module.ShowMessage("You have to set a specific Output Format if you have more than 1 cuts !");
                    return;
                }

                if (tsiExcludeMode.Checked && cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                {
                    Module.ShowMessage("You have to set a specific Output Format if you use Cut Out Mode !");
                    return;
                }

                if (fplSegments.Controls.Count == 1 && CurrentCutMode == CutMode.Exclude)
                {
                    MediaSegment ms = (MediaSegment)fplSegments.Controls[0];
                    if (ms.StartMSecs == 0 && ms.EndMSecs == LengthTotalMSecs)
                    {
                        Module.ShowMessage("Cannot create a Clip when the whole Movie is excluded !");
                        return;
                    }
                }

                try
                {

                    //SetupGrid();
                    //ProcessWhenFinished();
                    ConversionStopped = false;
                    ConversionStarted = true;
                    errstr = "";
                    //1 12.2014 Properties.Settings.Default.FadeInFadeOut = fadeInFadeOutToolStripMenuItem.Checked;

                    //   Module.SelectedFormatSetting = lstFormatSettings[cmbProfile.SelectedIndex];

                    //1pbarCut.Value = 0;
                    CompletedSecs = 0;

                    CutFilesToDelete.Clear();

                    GetCutArgsResult res = null;

                    if (CurrentCutMode == CutMode.Parts)
                    {
                        res = GetCutArgsForSplitInParts();
                    }
                    else
                    {
                        res = GetCutArgs();
                    }

                    //pbarCut.Maximum = 100;
                    //0pbarCut.Maximum = res.TotalDuration;
                    //1pbarCut.Maximum = res.TotalDuration;                                    

                    timCut.Enabled = true;
                    lblElapsedTime.Visible = true;
                    //1tsbCutVideo.Image = Properties.Resources.media_pause;
                    //1tsbStopCut.Visible = true;
                    //1tsbCutVideo.Text = TranslateHelper.Translate("Pause Cut");

                    decimal current_total_time = 0;

                    frmProgress f = new frmProgress();
                    f.Show(this);
                    f.timTime.Enabled = true;
                    this.Enabled = false;
                    f.progressBar1.Maximum = res.TotalDuration;
                    f.progressBar1.Value = 0;

                    for (int k = 0; k < res.ClipArgs.Count; k++)
                    {
                        CreateFFMpegProcess();

                        /*
                         24.7.14
                        if (CurrentCutMode == CutMode.Parts && k>0)
                        {
                            current_total_time += FFMpegArgsHelper.GetTimeFromStringDecimal(VideoInfoHelper.GetVideoTime(res.OutputFiles[k-1]));
                            res.ClipArgs[k]=res.ClipArgs[k].Replace("[CURRENT_TOTAL_TIME]",FFMpegArgsHelper.GetDecimalTimeToString(current_total_time));
                                                        
                        }
                        */

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
                    }

                    //1}
                }
                finally
                {
                    timCut.Enabled = false;
                    ConversionProgressTime = 0;
                    ConversionStarted = false;
                    OutputFileActionRepeat = false;

                    //lblElapsedTime.Visible = false;
                    //lblElapsedTimeDesc.Visible = false;

                    if (frmProgress.Instance != null && frmProgress.Instance.Visible)
                    {
                        frmProgress.Instance.Close();
                    }

                    this.Enabled = true;

                    for (int k = 0; k < CutFilesToDelete.Count; k++)
                    {
                        if (!CutFilesToDelete[k].StartsWith("|||SKIP|||"))
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
                    }

                    if (!ConversionStopped)
                    {
                        ProcessWhenFinished();

                        if (errstr != String.Empty)
                        {
                            frmError fer = new frmError(TranslateHelper.Translate("Operation completed with Errors !"), errstr);
                            fer.ShowDialog(this);

                            //Module.ShowMessage(TranslateHelper.Translate("Operation completed with Errors !") + "\n\n" + errstr);
                        }
                        else
                        {
                            Module.ShowMessage("Operation completed successfully !");
                        }
                    }

                    //1tsbCutVideo.Image = Properties.Resources.cut1;
                    //1tsbStopCut.Visible = false;
                    //1tsbCutVideo.Text = TranslateHelper.Translate("Cut Video");
                }
            }
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

            LastFFMpegOutput = "";
            
            psFFMpeg.Start();

            //System.Threading.Thread.Sleep(300);
            SetProcessPriorityHelperPartial.SetProcessPriority(ref psFFMpeg);
                        
            while (true)
            {
                string line;

                int beforeCompletedSecs = CompletedSecs;

                bool time_str_found = false;

                string last_line = "";

                while ((line = psFFMpeg.StandardError.ReadLine()) != null)
                {
                    last_line = line;

                    LastFFMpegOutput += line + "\r\n";

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

                line = null;
                                
                if (psFFMpeg.HasExited) break;
            }

            //0sw.WriteLine("END");
        }

        private void bwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int pg = (int)e.UserState;

            /*1
            if (pg >= 0 && pg <= pbarCut.Maximum)
            {
                pbarCut.Value = pg;
            }
            */

            if (frmProgress.Instance != null && frmProgress.Instance.Visible)
            {
                if (pg >= 0 && pg <= frmProgress.Instance.progressBar1.Maximum)
                {
                    frmProgress.Instance.progressBar1.Value = pg;
                }
            }
        }

        private void bwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {           
        }

        public void tsbStopCut_Click(object sender, EventArgs e)
        {
            ConversionStopped = true;
            ConversionStarted = false;
            ConversionPaused = false;

            //1tsbStopCut.Visible = false;
            //1tsbCutVideo.Image = Properties.Resources.cut1;
            //1tsbCutVideo.Text = TranslateHelper.Translate("Cut Video");

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

            if (frmProgress.Instance != null && frmProgress.Instance.Visible)
            {
                frmProgress.Instance.Close();
            }

            if (ConversionStopped)
            {
                Module.ShowMessage("Cutting process stopped !");
                return;
            }
        }

        private void ProcessWhenFinished()
        {
            int ichecked = -1;

            for (int k = 0; k < whenFinishedToolStripMenuItem.DropDownItems.Count - 1; k++)
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

        public bool ChkEqualParts = false;
        public bool ChkTime = false;
        public bool ChkFilesize = false;
        public int SplitEqualParts = 0;
        public string SplitTime = "";
        public long SplitFilesize = 0L;

        private void tsbSplitParts_Click(object sender, EventArgs e)
        {
            ChkEqualParts = false;
            ChkTime = false;
            ChkFilesize = false;
            SplitEqualParts = 0;
            SplitTime = "";
            SplitFilesize = 0L;

            frmSplitByParts f = new frmSplitByParts();

            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.chkEqualParts.Checked)
                {
                    ChkEqualParts = true;
                    SplitEqualParts = (int)f.nudEqualParts.Value;
                }
                else if (f.chkFileSize.Checked)
                {
                    ChkFilesize = true;

                    if (f.cmbFilesize.SelectedIndex == 0)
                    {
                        SplitFilesize = int.Parse(f.txtFilesize.Text);
                    }
                    else if (f.cmbFilesize.SelectedIndex == 1)
                    {
                        SplitFilesize = 1024 * (int.Parse(f.txtFilesize.Text));
                    }
                    else if (f.cmbFilesize.SelectedIndex == 2)
                    {
                        SplitFilesize = 1024 * 1024 * (int.Parse(f.txtFilesize.Text));
                    }
                }
                else if (f.chkTime.Checked)
                {
                    ChkTime = true;
                    SplitTime = f.mskTime.Text;
                }

                CurrentCutMode = CutMode.Parts;

                tsbCutVideo_Click(null, null);
            }
        }

        private void tsiIncludeMode_Click(object sender, EventArgs e)
        {
            CurrentCutMode = CutMode.Include;
            fplSegments.Enabled = true;
            tsiIncludeMode.Checked = true;
            tsiExcludeMode.Checked = false;
            tsiSilenceMode.Checked = false;

            Properties.Settings.Default.CutOutMode = false;
        }

        public void tsiExcludeMode_Click(object sender, EventArgs e)
        {
            CurrentCutMode = CutMode.Exclude;
            fplSegments.Enabled = true;
            tsiIncludeMode.Checked = false;
            tsiExcludeMode.Checked = true;
            tsiSilenceMode.Checked = false;

            Properties.Settings.Default.CutOutMode = true;
        }

        private void tsiSilenceMode_Click(object sender, EventArgs e)
        {
            CurrentCutMode = CutMode.Silence;
            fplSegments.Enabled = true;
            tsiIncludeMode.Checked = false;
            tsiExcludeMode.Checked = false;
            tsiSilenceMode.Checked = true;
        }

        #endregion

        #region Cut Args

        private List<Segment> GetIncludeModeSegments()
        {
            List<Segment> segments = new List<Segment>();                        

            for (int k = 0; k < fplSegments.Controls.Count; k++)
            {
                Segment seg = new Segment();
                MediaSegment ms = (MediaSegment)fplSegments.Controls[k];

                seg.RangeStart = ms.StartMSecs;
                seg.RangeEnd = ms.EndMSecs;

                segments.Add(seg);
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
                seg.RangeEnd = ms.StartMSecs-1;

                if (!(lastend == 0 && ms.StartMSecs == 0)) // do not include if first segment start with 0 ,for example.
                {
                    if (seg.RangeEnd <= seg.RangeStart)
                    {
                        throw new Exception("Error Segments are invalid !");
                    }
                    
                    
                    segments.Add(seg);                    
                }

                lastend = ms.EndMSecs+1;
            }

            Segment segend = new Segment();
            segend.RangeStart = lastend;
            segend.RangeEnd = LengthTotalMSecs;

            if (segend.RangeEnd>segend.RangeStart) // do not add a segment which ends with end
            {
                segments.Add(segend);
            }

            return segments;
        }

        private List<Segment> GetSilenceModeSegments()
        {
            List<Segment> segments = new List<Segment>();

            int lastend = 0;

            for (int k = 0; k < fplSegments.Controls.Count; k++)
            {
                Segment seg = new Segment();
                MediaSegment ms = (MediaSegment)fplSegments.Controls[k];

                seg.RangeStart = lastend;
                seg.RangeEnd = ms.StartMSecs - 1;

                if (!(lastend == 0 && ms.StartMSecs == 0)) // do not include if first segment start with 0 ,for example.
                {
                    if (seg.RangeEnd <= seg.RangeStart)
                    {
                        throw new Exception("Error Segments are invalid !");
                    }


                    segments.Add(seg);
                }

                Segment segsilence=new Segment();
                segsilence.RangeStart = ms.StartMSecs;
                segsilence.RangeEnd = ms.EndMSecs;
                segsilence.Silence = true;

                segments.Add(segsilence);
                
                lastend = ms.EndMSecs + 1;
            }

            Segment segend = new Segment();
            segend.RangeStart = lastend;
            segend.RangeEnd = LengthTotalMSecs;

            if (segend.RangeEnd > segend.RangeStart) // do not add a segment which ends with end
            {
                segments.Add(segend);
            }

            return segments;
        }

        private List<Segment> GetCutSegments()
        {
            if (CurrentCutMode == CutMode.Include)
            {
                return GetIncludeModeSegments();
            }
            else if (CurrentCutMode == CutMode.Exclude)
            {
                return GetExcludeModeSegments();
            }
            else if (CurrentCutMode == CutMode.Silence)
            {
                return GetSilenceModeSegments();
            }

            return null;
        }

        private GetCutArgsResult GetCutArgsForSplitInParts()
        {
            List<string> str = str = GetOutputFilepathsHelper.GetOutputFilepathsForSplitParts(ChkEqualParts, ChkTime, ChkFilesize, SplitEqualParts, SplitTime, SplitFilesize);

            GetCutArgsResult res = new GetCutArgsResult();
            res.FirstOutputFile = str[0];
            res.TotalDuration = LengthTotalMSecs;
            res.OutputFiles = str;
            FirstOutputFile = str[0];
                        
            string format = cmbOutputFormat.Text.Trim();
            int spos = format.IndexOf(" - ");
            if (spos >= 0)
            {
                format = format.Substring(0, spos);
            }

            if (ChkTime)
            {            
                //int part_msecs=FFMpegArgsHelper.GetTimeFromString(SplitTime);
                int part_msecs = TimeUpDownControl.StringToMsecs(SplitTime);
                int time_total_msecs = 0;

                for (int k = 0; k < str.Count; k++)
                {
                    string args_split = "";

                    //1
                    
                    args_split += " -ss " + FFMpegArgsHelper.GetStringFromTime(time_total_msecs) + " -t " + SplitTime;

                    args_split += " -y -i \"" + filepath + "\" ";

                    time_total_msecs += part_msecs;

                    if (format == "3GP" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    && System.IO.Path.GetExtension(filepath).ToLower() == ".3gp"))
                    {
                        args_split += " -r 20 -s 352x288 -b 400k -strict experimental -c:a aac -ac 1 -ar 8000 -ab 24k ";
                    }
                    else if (format == "WMV" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                        && System.IO.Path.GetExtension(filepath).ToLower() == ".wmv"))
                    {
                        args_split += " -q:a 2 -q:v 2 -vcodec msmpeg4 -acodec wmav2 ";
                    }
                    else
                    {
                        args_split += " -acodec copy -vcodec copy ";
                    }

                    args_split += " " + Properties.Settings.Default.ExtraFFMpegArgs + " ";

                    try
                    {
                        if (System.IO.File.Exists(str[k]))
                        {
                            System.IO.File.Delete(str[k]);
                        }
                    }
                    catch { }
                                                            
                    args_split += " \"" + str[k] + "\" ";

                    res.ClipArgs.Add(args_split);
                    
                }
            }
            else if (ChkEqualParts)
            {
                //FileInfo fi = new FileInfo(frmClip.Instance.filepath);

                //int length_parts = (int)((double)fi.Length / (double)SplitEqualParts);
                //int length_parts_div = (int)((double)fi.Length % (double)SplitEqualParts);

                int total_time = frmClip.Instance.LengthTotalMSecs;

                int part_time = (int)((decimal)total_time / (decimal)SplitEqualParts);
                                
                int time_total_msecs = 0;

                string spart_time = FFMpegArgsHelper.GetStringFromTime(part_time);
                
                for (int k = 0; k < str.Count; k++)
                {
                    string args_split = "";
                                        
                    if (k == str.Count - 1) // last one part
                    {
                        //args_split += " -ss [CURRENT_TOTAL_TIME] ";
                        args_split += " -ss " + FFMpegArgsHelper.GetStringFromTime(time_total_msecs);
                    }
                    else if (k == 0)
                    {
                        args_split += " -ss 0.0 -t " + spart_time;
                    }
                    else
                    {
                        //args_split += " -ss [CURRENT_TOTAL_TIME] -t " + spart_time;
                        args_split += " -ss " + FFMpegArgsHelper.GetStringFromTime(time_total_msecs) + " -t " + spart_time;
                    }

                    args_split += " -y -i \"" + filepath + "\" ";

                    if (format == "3GP" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                        && System.IO.Path.GetExtension(filepath).ToLower() == ".3gp"))
                    {
                        args_split += " -r 20 -s 352x288 -b 400k -strict experimental -c:a aac -ac 1 -ar 8000 -ab 24k ";
                    }
                    else if (format == "WMV" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                        && System.IO.Path.GetExtension(filepath).ToLower() == ".wmv"))
                    {
                        args_split += " -q:a 2 -q:v 2 -vcodec msmpeg4 -acodec wmav2 ";
                    }
                    else
                    {
                        args_split += " -vcodec copy -acodec copy ";
                    }

                    args_split += " " + Properties.Settings.Default.ExtraFFMpegArgs + " ";

                    try
                    {
                        if (System.IO.File.Exists(str[k]))
                        {
                            System.IO.File.Delete(str[k]);
                        }
                    }
                    catch { }

                    args_split += " \"" + str[k] + "\" ";

                    res.ClipArgs.Add(args_split);

                    time_total_msecs += part_time;
                }
            }
            /*
            else if (ChkEqualParts)
            {               
                FileInfo fi=new FileInfo(frmClip.Instance.filepath);
                                
                int length_parts=(int)((double)fi.Length/(double)SplitEqualParts);
                int length_parts_div = (int)((double)fi.Length % (double)SplitEqualParts);

                for (int k = 0; k < str.Count; k++)
                {
                    string args_split = "";

                    args_split += " -y -i \"" + filepath + "\" ";

                    if (k == str.Count - 1) // last one part
                    {
                        args_split += " -ss [CURRENT_TOTAL_TIME] ";
                    }
                    else if (k == 0)
                    {
                        args_split += " -ss 0.0 -fs " + length_parts;
                    }
                    else
                    {
                        args_split += " -ss [CURRENT_TOTAL_TIME] -fs " + length_parts;
                    }

                    if (format == "3GP" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                        && System.IO.Path.GetExtension(filepath).ToLower() == ".3gp"))
                    {
                        args_split += " -r 20 -s 352x288 -b 400k -strict experimental -c:a aac -ac 1 -ar 8000 -ab 24k ";
                    }
                    if (format == "WMV" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                        && System.IO.Path.GetExtension(filepath).ToLower() == ".wmv"))
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

                    args_split += " \"" + str[k] + "\" ";

                    res.ClipArgs.Add(args_split);
                }
            }
            */
            else if (ChkFilesize)
            {                               
                for (int k = 0; k < str.Count; k++)
                {
                    string args_split = "";                                                                
                                        
                    if (k == str.Count - 1) // last one part
                    {
                        args_split += " -ss [CURRENT_TOTAL_TIME] ";
                    }
                    else if (k == 0)
                    {
                        args_split += " -ss 0.0 -fs " + SplitFilesize;
                    }
                    else
                    {
                        args_split += " -ss [CURRENT_TOTAL_TIME] -fs " + SplitFilesize;
                    }

                    args_split += " -y -i \"" + filepath + "\" ";

                    if (format == "3GP" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                        && System.IO.Path.GetExtension(filepath).ToLower() == ".3gp"))
                    {
                        args_split += " -r 20 -s 352x288 -b 400k -strict experimental -c:a aac -ac 1 -ar 8000 -ab 24k ";
                    }
                    else if (format == "WMV" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                        && System.IO.Path.GetExtension(filepath).ToLower() == ".wmv"))
                    {
                        args_split += " -q:a 2 -q:v 2 -vcodec msmpeg4 -acodec wmav2 ";
                    }
                    else if (cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    {
                        args_split += " -acodec copy -vcodec copy ";
                    }

                    args_split += " " + Properties.Settings.Default.ExtraFFMpegArgs + " ";

                    try
                    {
                        if (System.IO.File.Exists(str[k]))
                        {
                            System.IO.File.Delete(str[k]);
                        }
                    }
                    catch { }

                    args_split += " \"" + str[k] + "\" ";

                    res.ClipArgs.Add(args_split);
                }
            }

            LastCutArgs = res;

            return res;
        }

        private GetCutArgsResult GetCutArgs()
        {
            List<Segment> segments = GetCutSegments();

            List<string> str = GetOutputFilepathsHelper.GetOutputFilepaths(Properties.Settings.Default.JoinParts,segments.Count);                      
            
            GetCutArgsResult res = new GetCutArgsResult();

            string firstoutfile = str[0];

            if (firstoutfile.StartsWith("|||SKIP|||"))
            {
                firstoutfile = firstoutfile.Substring("|||SKIP|||".Length);
            }

            res.FirstOutputFile = firstoutfile;
            res.OutputFiles = str;

            FirstOutputFile = firstoutfile;
                        
            string format = cmbOutputFormat.Text.Trim();
            int spos = format.IndexOf(" - ");
            if (spos >= 0)
            {
                format = format.Substring(0, spos);
            }

            int total_dur_msecs = 0;

            //1for (int k=0;k<fplSegments.Controls.Count;k++)
            for (int k=0;k<segments.Count;k++)
            {
                string args_split = "";

                if (CurrentCutMode == CutMode.Include && (!Properties.Settings.Default.JoinParts || fplSegments.Controls.Count == 1))
                {
                    if (str[k].StartsWith("|||SKIP|||"))
                    {
                        continue;
                    }
                }

                //1               

                if (cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                {
                    //args_split += " -acodec copy -vcodec copy ";
                }                               

                //1MediaSegment ms = (MediaSegment)fplSegments.Controls[k];
                //1string tstart = ms.mskStart.Text;
                string tstart = FFMpegArgsHelper.GetStringFromTime(segments[k].RangeStart);
                //1int tm = ms.EndMSecs - ms.StartMSecs;
                int tm = segments[k].RangeEnd - segments[k].RangeStart;

                total_dur_msecs += tm;

                int tsecs = tm / 1000;
                int tmsecs = tm % 1000;

                if (CurrentCutMode==CutMode.Exclude || (Properties.Settings.Default.JoinParts && fplSegments.Controls.Count>1))
                {
                    res.TotalDuration += (tm * 2); // one for clip and one for join
                }
                else
                {
                    res.TotalDuration += tm; // only one for clip
                }

                //3.2017 check out fade in fade out !!
                #region Fade In - Fade Out

                if (Properties.Settings.Default.FadeInFadeOut && ((!Properties.Settings.Default.JoinParts || Properties.Settings.Default.FadeSeparately || fplSegments.Controls.Count == 1)
                    || (Properties.Settings.Default.JoinParts && (k==0 || k==fplSegments.Controls.Count-1))))

                {
                    args_split += " -filter_complex \"";

                    if (Properties.Settings.Default.FadeInFadeOut && ((!Properties.Settings.Default.JoinParts || Properties.Settings.Default.FadeSeparately || fplSegments.Controls.Count == 1)
                    || (Properties.Settings.Default.JoinParts && (k == 0))))
                    {

                        if (Properties.Settings.Default.FadeIn)
                        {
                            if (Properties.Settings.Default.FadeInSeconds)
                            {
                                args_split += "fade=t=in:st=" + FFMpegArgsHelper.GetSecsTimeFromMsecs(segments[k].RangeStart);
                                args_split += ":d=" + Properties.Settings.Default.FadeInSecondsVal.ToString("#0.0").Replace(",", ".");
                            }
                        }

                        if (!Properties.Settings.Default.JoinParts || Properties.Settings.Default.FadeSeparately || fplSegments.Controls.Count == 1)
                        {
                            if (Properties.Settings.Default.FadeIn && Properties.Settings.Default.FadeOut)
                            {
                                args_split += ",";
                            }
                        }
                    }

                    if (Properties.Settings.Default.FadeInFadeOut && ((!Properties.Settings.Default.JoinParts || Properties.Settings.Default.FadeSeparately || fplSegments.Controls.Count == 1)
                    || (Properties.Settings.Default.JoinParts && (k == fplSegments.Controls.Count-1))))
                    {
                        if (Properties.Settings.Default.FadeOut)
                        {
                            if (Properties.Settings.Default.FadeOutSeconds)
                            {
                                int fadeoutmsecs = (int)(Properties.Settings.Default.FadeOutSecondsVal * 10);
                                string fadeoutstart = FFMpegArgsHelper.GetSecsTimeFromMsecs(segments[k].RangeEnd - fadeoutmsecs);
                                args_split += "fade=t=out:st=" + fadeoutstart + ":d=" + Properties.Settings.Default.FadeOutSecondsVal.ToString("#0.0").Replace(",", ".");

                            }
                        }
                    }

                    args_split += "\" ";
                }

                #endregion

                args_split += " -ss " + tstart +" -t " + tsecs.ToString() + "." + tmsecs.ToString() + "0";

                //6.12.2014 begin

                if (segments[k].Silence)
                {

                    args_split += " -y -i \"" + filepath + "\" -f lavfi -i aevalsrc=0 -c:v copy  " +
                    " -map 0:v -map 1:a -shortest";

                    /*
                    args_split+=" -y filter_complex -i \"" + filepath + "\" -f lavfi -i aevalsrc=0 "+
                        "[0:0] [1:1] concat=n=2:v=1:a=1 [v] [a]\" -map \"[v]\" -map \"[a]\" -shortest ";
                     */

                }
                else
                {
                    args_split += " -y -i \"" + filepath + "\" ";
                }

                //end
                if (format == "3GP" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    && System.IO.Path.GetExtension(filepath).ToLower()==".3gp"))
                {
                    args_split += " -r 20 -s 352x288 -b 400k -strict experimental -c:a aac -ac 1 -ar 8000 -ab 24k ";
                }
                else if (format == "WMV" || ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    && System.IO.Path.GetExtension(filepath).ToLower()==".wmv"))
                {
                    args_split += " -q:a 2 -q:v 2 -vcodec msmpeg4 -acodec wmav2 ";
                }
                else if (cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                {
                    args_split+=" -acodec copy -vcodec copy ";
                }

                args_split += " "+Properties.Settings.Default.ExtraFFMpegArgs+" ";

                try
                {
                    if (System.IO.File.Exists(str[k]))
                    {
                        System.IO.File.Delete(str[k]);
                    }
                }
                catch { }

                // do not join split files..
                //6.8.14 if (!Properties.Settings.Default.JoinParts || fplSegments.Controls.Count ==1)
                if (CurrentCutMode==CutMode.Include && (!Properties.Settings.Default.JoinParts || fplSegments.Controls.Count == 1))
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
                        tempfile += "." + format.ToLower();
                    }
                    
                    args_split += " \"" + tempfile + "\" ";
                    CutFilesToDelete.Add(tempfile);
                }

                res.ClipArgs.Add(args_split);
            }

            string parent_split_args = " -y ";

            //03.14
            parent_split_args += " -analyzeduration 10000000 ";
            //end

            if (CurrentCutMode==CutMode.Exclude || (Properties.Settings.Default.JoinParts && fplSegments.Controls.Count > 1))
            {
                int file_count = CutFilesToDelete.Count;

                for (int m = 0; m < CutFilesToDelete.Count; m++)
                {
                    if (Properties.Settings.Default.JoinParts)
                    {
                        if (str[0].StartsWith("|||SKIP|||"))
                        {
                            parent_split_args += " -i \"" + CutFilesToDelete[m].Substring("|||SKIP|||".Length) + "\" ";
                        }
                        else
                        {
                            parent_split_args += " -i \"" + CutFilesToDelete[m] + "\" ";
                        }
                    }
                    else
                    {
                        if (str[m].StartsWith("|||SKIP|||"))
                        {
                            parent_split_args += " -i \"" + CutFilesToDelete[m].Substring("|||SKIP|||".Length) + "\" ";
                        }
                        else
                        {
                            parent_split_args += " -i \"" + CutFilesToDelete[m] + "\" ";
                        }
                    }
                }

                parent_split_args += " -filter_complex \"";

                for (int m = 0; m < file_count; m++)
                {
                    /*
                    if (CurrentCutMode == CutMode.Silence)
                    {
                        if (segments[m].Silence)
                        {
                            parent_split_args += "[" + m.ToString() + ":0] ";
                        }
                        else
                        {
                            parent_split_args += "[" + m.ToString() + ":0] [" + m.ToString() + ":1] ";
                        }
                    }
                    
                    else
                    {
                    */
                        parent_split_args += "[" + m.ToString() + ":0] [" + m.ToString() + ":1] ";
                    //}
                    //[0:0] [0:1] [1:0] [1:1] 
                }

                parent_split_args += "concat=n=" + file_count.ToString() + ":v=1:a=1 [v] [a]\" -map \"[v]\" -map \"[a]\" ";                               

                // also get the conversion args....for the joined item....

                if (format == "3GP" ||
                    ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    && System.IO.Path.GetExtension(filepath).ToLower() == ".3gp"))
                {
                    parent_split_args += " -r 20 -s 352x288 -b 400k -strict experimental -c:a aac -ac 1 -ar 8000 -ab 24k ";
                }
                else if (format == "WMV" ||
                    ((cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    && System.IO.Path.GetExtension(filepath).ToLower() == ".wmv"))
                {
                    parent_split_args +=" -q:a 2 -q:v 2 -vcodec msmpeg4 -acodec wmav2 ";
                }
                else if (cmbOutputFormat.Text.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                {
                    parent_split_args += " -acodec copy -vcodec copy ";
                }

                parent_split_args += " " + Properties.Settings.Default.ExtraFFMpegArgs + " ";

                parent_split_args += " \"" + str[0] + "\" ";

                // set up parent splitted join item...
                res.JoinArgs = parent_split_args;
            }

            LastCutArgs = res;

            //0MessageBox.Show(res.TotalDuration.ToString());

            return res;            
        }

        #endregion
                        
        private void tsbExclude_Click(object sender, EventArgs e)
        {
            /*
            CurrentCutMode = CutMode.Exclude;
            tsbExcludeMode.BackColor = Color.FromArgb(192, 192, 255);
            tsbIncludeMode.BackColor = Color.Transparent;
            tsbSilenceMode.BackColor = Color.Transparent;
            tsbSplitParts.BackColor = Color.Transparent;

            fplSegments.Enabled = true;
            */
        }

        private void tsbIncludeMode_Click(object sender, EventArgs e)
        {
            /*
            CurrentCutMode = CutMode.Incude;
            tsbIncludeMode.BackColor = Color.FromArgb(192, 192, 255);
            tsbExcludeMode.BackColor = Color.Transparent;
            tsbSilenceMode.BackColor = Color.Transparent;
            tsbSplitParts.BackColor = Color.Transparent;

            fplSegments.Enabled = true;
            */
        }       

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            if (this.filename == null)
            {
                Font f = new Font(FontFamily.GenericSansSerif, 18);   
                SizeF sz = e.Graphics.MeasureString(TranslateHelper.Translate("Drag and Drop Videos Here !"), f);
                e.Graphics.DrawString(TranslateHelper.Translate("Drag and Drop Videos Here !"),f,Brushes.DimGray,
                    new PointF(this.Width / 2 - (int)(sz.Width / 2),this.Height / 2 - lblDrag.Height / 2));
                    //lbl.Left = this.Width / 2 - (int)(sz.Width / 2);
                
            }
        }                              

        public int FirstVisibleControlInd = -1;
        public int LastVisibleControlInd = -1;

        public int Line = 0;        
                
        public bool InScrollEvent = false;

        public BackgroundWorker bwImgUpdate = null;                       

        #region Media Player

        private void btnFastForward_Click(object sender, EventArgs e)
        {
            //1int streampos = msPositionValue + 10;
            int streampos = msPositionValue + 100;

            //1if (msPositionValue + 10 > msPositionMaximum)
            if (msPositionValue + 100 > msPositionMaximum)
            {
                streampos = msPositionMaximum;
            }

            string str = "";
            if (PlayerState == PlayerStateEnum.Paused || PlayerState == PlayerStateEnum.PausedSegment || PlayerState == PlayerStateEnum.PausedAllSegments)
            {
                str = "pausing ";
            }

            SendCommand(str + "seek 10 0");

            msPositionValue = streampos;
            //SendCommand("pause");
        }

        private void btnRewind_Click(object sender, EventArgs e)
        {
            //1int streampos = msPositionValue - 10;
            int streampos = msPositionValue - 100;

            //1if (msPositionValue - 10 < 0)
            if (msPositionValue - 100 < 0)
            {
                streampos = 0;
            }

            string str = "";
            if (PlayerState == PlayerStateEnum.Paused || PlayerState == PlayerStateEnum.PausedSegment || PlayerState == PlayerStateEnum.PausedAllSegments)
            {
                str = "pausing ";
            }

            //SendCommand("set_property stream_pos " + streampos.ToString());
            SendCommand(str + "seek -10 0");

            msPositionValue = streampos;
        }

        public void SeekPosition()
        {
            if (filename == null) return;

            string str = "";

            /*3
            if (PlayerState == PlayerStateEnum.Paused || PlayerState == PlayerStateEnum.Stopped || PlayerState == PlayerStateEnum.PausedSegment || PlayerState == PlayerStateEnum.PausedAllSegments)
            {
                str = "pausing ";
            }
            */
            //SendCommand(str + "seek " + FFMpegArgsHelper.GetStringFromTime(msPositionValue) + " 2 1");            

            //1lblTime.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "."+sms+" / " + MovieLength;

            //3SendCommand(str + "seek " + dsecs.ToString() + "." + sms + " 2 1");

            //2lblTime.Text = FFMpegArgsHelper.GetStringFromTime(msPositionValue);

            string time_string = FFMpegArgsHelper.GetStringFromTime(msPositionValue);
            mskPos.Text = time_string;


            //SendCommand(str + "seek " + FFMpegArgsHelper.GetStringFromTime(msPositionValue) + " 2 1");
            //System.Threading.Thread.Sleep(500);            

            try
            {
                //7VideoThumbnail vth = new VideoThumbnail(filepath, time_string, "");
                VideoThumbnail vth = new VideoThumbnail(filepath, time_string, -1, picMovie.Height);

                if (vth.ThumbnailImage != null)
                {
                    if (vth.ThumbnailImage.Width > picScreenshot.Width)
                    {
                        picScreenshot.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        picScreenshot.SizeMode = PictureBoxSizeMode.CenterImage;
                    }

                    picScreenshot.Image = vth.ThumbnailImage;
                }
                else
                {
                    picScreenshot.Image = null;
                }
            }
            catch
            {
                picScreenshot.Image = null;
            }

            picScreenshot.Bounds = picMovie.Bounds;
            picScreenshot.Visible = true;
            picScreenshot.BringToFront();

            picMain.PaintCurrentFrame();
        }

        public void SeekPositionMplayer()
        {
            picScreenshot.Visible = false;
            picMovie.Visible = true;
            picMovie.BringToFront();

            if (filename == null) return;

            string str = "";

            //8if (PlayerState == PlayerStateEnum.Paused || PlayerState == PlayerStateEnum.Stopped || PlayerState == PlayerStateEnum.PausedSegment || PlayerState == PlayerStateEnum.PausedAllSegments)

            if (!Playing)
            {
                str = "pausing ";
            }

            //SendCommand(str + "seek " + FFMpegArgsHelper.GetStringFromTime(msPositionValue) + " 2 1");            

            //7
            /*
            int dsecs = msPositionValue / 10;
            string sms = msPositionValue.ToString().Substring(msPositionValue.ToString().Length - 1, 1);

            TimeSpan ts = new TimeSpan(0, 0, 0, dsecs, 0);
            */
            //1lblTime.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "."+sms+" / " + MovieLength;

            //7SendCommand(str + "seek " + dsecs.ToString()+"."+sms + " 2 1");            

            string strmspos = FFMpegArgsHelper.GetSecsTimeFromMsecs(msPositionValue);

            SendCommand(str + "seek " + strmspos + " 2 1");

            //2lblTime.Text = FFMpegArgsHelper.GetStringFromTime(msPositionValue);
            mskPos.Text = FFMpegArgsHelper.GetStringFromTime(msPositionValue);


            //SendCommand(str + "seek " + FFMpegArgsHelper.GetStringFromTime(msPositionValue) + " 2 1");
            //System.Threading.Thread.Sleep(500);
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

            if (msPositionValue == msPositionMaximum)
            {
                //btnStop_Click_1(null, null);
            }

            /*
            if (!(PlayerState == PlayerStateEnum.Playing
                || PlayerState == PlayerStateEnum.PlayingSegment
                || PlayerState == PlayerStateEnum.PlayingAllSegments) && !picMain.InMouseClick)
            {
                int oldstartpos=picMain.CurrentStartMousePosition;

                picMain.CurrentStartMousePosition = picMain.CalculatePositionFromMsecs(msPositionValue * 100);
                picMain.Invalidate(new Rectangle(oldstartpos-3,0,6,picMain.Height));
                picMain.Invalidate(new Rectangle(picMain.CurrentStartMousePosition - 3, 0, 6, picMain.Height));
            }*/
        }

        private bool msPositionMouseDown = false;


        private void msPosition_MouseDown(object sender, MouseEventArgs e)
        {
            ActiveMediaSegment.LastMskStartText = ActiveMediaSegment.mskStart.Text;
            ActiveMediaSegment.LastMskEndText = ActiveMediaSegment.mskEnd.Text;
            msPositionMouseDown = true;
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

        private void volumeUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (msVolume.Value < msVolume.Maximum - 1)
            {
                msVolume.Value++;
            }

            msVolume_ValueChanged(null, null);
        }

        private void volumeDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (msVolume.Value >0)
            {
                msVolume.Value--;
            }

            msVolume_ValueChanged(null, null);
        }

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnMute.Checked = !btnMute.Checked;

            btnMute_Click(null, null);
        }

        #endregion

        #region Localization

        private void AddLanguageMenuItems()
        {
            for (int k = 0; k < frmLanguage.LangCodes.Count; k++)
            {
                ToolStripMenuItem ti = new ToolStripMenuItem();
                ti.Text = frmLanguage.LangDesc[k];
                ti.Tag = frmLanguage.LangCodes[k];
                ti.Image = frmLanguage.LangImg[k];

                if (Properties.Settings.Default.Language == frmLanguage.LangCodes[k])
                {
                    ti.Checked = true;
                }

                ti.Click += new EventHandler(tiLang_Click);

                if (k < 25)
                {
                    languages1ToolStripMenuItem.DropDownItems.Add(ti);
                }
                else
                {
                    languages2ToolStripMenuItem.DropDownItems.Add(ti);
                }

                //languageToolStripMenuItem.DropDownItems.Add(ti);
            }
        }

        void tiLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            string langcode = ti.Tag.ToString();
            ChangeLanguage(langcode);

            //for (int k = 0; k < languageToolStripMenuItem.DropDownItems.Count; k++)
            for (int k = 0; k < languages1ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages1ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }

            for (int k = 0; k < languages2ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages2ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }
        }

        private void ChangeLanguage(string language_code)
        {
            Properties.Settings.Default.Language = language_code;
            frmLanguage.SetLanguage();

            bool maximized = (this.WindowState == FormWindowState.Maximized);
            this.WindowState = FormWindowState.Normal;
            
            /*
            RegistryKey key = Registry.CurrentUser;
            RegistryKey key2 = Registry.CurrentUser;

            try
            {
                key = key.OpenSubKey("Software\\softpcapps Software", true);

                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\softpcapps Software");
                }

                key2 = key.OpenSubKey(frmLanguage.RegKeyName, true);

                if (key2 == null)
                {
                    key2 = key.CreateSubKey(frmLanguage.RegKeyName);
                }

                key = key2;

                //key.SetValue("Language", language_code);
                key.SetValue("Menu Item Caption", TranslateHelper.Translate("Change PDF Properties"));
            }
            catch (Exception ex)
            {
                Module.ShowError(ex);
                return;
            }
            finally
            {
                key.Close();
                key2.Close();
            }
            */
            //1SaveSizeLocation();

            SavePositionSize();

            this.Controls.Clear();

            InitializeComponent();

            SetupOnLoad();

            if (maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            this.ResumeLayout(true);

        }

        #endregion

        #region Share

        private void tsiFacebook_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareFacebook();
        }

        private void tsiTwitter_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareTwitter();
        }

        private void tsiGooglePlus_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareGooglePlus();
        }

        private void tsiLinkedIn_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareLinkedIn();
        }

        private void tsiEmail_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareEmail();
        }

        #endregion                               

        private void tsiSplitBlackDetect_Click(object sender, EventArgs e)
        {
            frmBlackDetect f = new frmBlackDetect();

            if (f.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private string LastTimeTooltip = "";        

        private void msPosition_MouseLeave(object sender, EventArgs e)
        {            
            LastTimeTooltip = "";            

            vthPreview.Visible = false;
        }

        private void frmClip_MouseMove(object sender, MouseEventArgs e)
        {            
            LastTimeTooltip = "";

            vthPreview.Visible = false;
        }

        private void picMovie_MouseMove(object sender, MouseEventArgs e)
        {            
            LastTimeTooltip = "";

            vthPreview.Visible = false;
        }        

        #region Options Menu

        private void openOutputFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string outfolder = "";

            if (Properties.Settings.Default.OutputFolder == TranslateHelper.Translate("Same as Video Folder"))
            {
                outfolder = System.IO.Path.GetDirectoryName(frmClip.Instance.filepath);
            }
            else if (Properties.Settings.Default.OutputFolder.Trim() == string.Empty || !System.IO.Directory.Exists(Properties.Settings.Default.OutputFolder))
            {
                Module.ShowMessage("Please specify a valid Output Folder !");
                return;
            }
            else
            {
                outfolder = Properties.Settings.Default.OutputFolder;
            }

            //string args = string.Format("/e, /select, \"{0}\"", txtOutputFolder.Text);
            string args = string.Format("\"{0}\"", outfolder);
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptions f = new frmOptions();
            f.ShowDialog();
        }

        private void fadeInFadeOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fadeInFadeOutToolStripMenuItem.Checked)
            {
                frmFadeInOut f = new frmFadeInOut();
                f.ShowDialog();
            }

            Properties.Settings.Default.FadeInFadeOut = fadeInFadeOutToolStripMenuItem.Checked;
        }

        private void joinClipsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.JoinParts = joinClipsToolStripMenuItem.Checked;
        }

        private void openOriginalVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(filepath);
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not Open Video", ex.Message);
            }
        }

        private void openCutVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(FirstOutputFile);
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not Open Video", ex.Message);
            }
        }

        private void sbtnInfo_Click(object sender, EventArgs e)
        {
            frmVideoInfo f = new frmVideoInfo(filepath);
            f.ShowDialog();
        }

        private void joinClipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void videoJoinerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVideoJoin f = new frmVideoJoin();
            f.ShowDialog();
        }
        #endregion

        private void cmbOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OutputFormat = cmbOutputFormat.Text;
        }               

        private void vthPreview_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                SeekPosition();
            }
        }        

        private void picMain_MouseLeave(object sender, EventArgs e)
        {
            vthPreview.Visible = false;
        }        

        private void frmClip_Resize(object sender, EventArgs e)
        {
            this.Invalidate();

            picMain.Width = this.ClientSize.Width;
            HScrollbar.Width = picMain.Width;
            //picMain.SetupScrollbar();

            picMain.StoryboardTimeFrameLengthMsecs = picMain.StoryboardTimeFrameLengthMsecs;                       

        }

        #region Mask Textboxes Handlers

        private void mskCutStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            ActiveMediaSegment.mskStart.Text = mskCutStart.Text;
            ActiveMediaSegment.mskStart_KeyPress(null, e);            
        }

        private void mskCutStart_Validating(object sender, CancelEventArgs e)
        {
            ActiveMediaSegment.mskStart_Validating(null, e);
        }

        private void mskCutEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ActiveMediaSegment.mskEnd.Text = mskCutEnd.Text;
            ActiveMediaSegment.mskEnd_KeyPress(null, e);
        }

        private void mskCutEnd_Validating(object sender, CancelEventArgs e)
        {
            ActiveMediaSegment.mskEnd_Validating(null, e);
        }

        private void mskDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            ActiveMediaSegment.mskDuration.Text = mskDuration.Text;
            ActiveMediaSegment.mskDuration_KeyPress(null, e);
        }

        private void mskDuration_Validating(object sender, CancelEventArgs e)
        {
            ActiveMediaSegment.mskDuration_Validating(null, e);
        }

        public void mskTotalDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                mskTotalDuration.txtBox.ValidateText();
                mskTotalDuration_Validating(mskTotalDuration.txtBox, new CancelEventArgs());
            }
        }

        public void mskTotalDuration_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int msecs = TimeUpDownControl.StringToMsecs(mskTotalDuration.Text);              

                int mst = TimeUpDownControl.StringToMsecs(mskCutStart.Text);

                int mse = TimeUpDownControl.StringToMsecs(mskCutEnd.Text);

                int totalexcdur = (TotalDurationMSecs - (mse - mst));
                int newdur = msecs - totalexcdur;
                int newend = mst + newdur;

                int maxnewdur = LengthTotalMSecs - mst - totalexcdur;

                if (totalexcdur > msecs)
                {
                    Module.ShowMessage("Invalid Value ! Try removing other Cuts before setting this low value.");
                    e.Cancel = true;
                    mskTotalDuration.Text = mskTotalDuration.LastAcceptedValue;                   
                    return;               
                }

                if (newdur>maxnewdur)
                {
                    Module.ShowMessage("The Value exceeds Video File Duration !");
                    e.Cancel = true;
                    mskTotalDuration.Text = mskTotalDuration.LastAcceptedValue;                   

                    return;
                }                

                mskCutEnd.Text = TimeUpDownControl.MsecsToString(newend);
                frmClip.Instance.mskCutEnd.Text = TimeUpDownControl.MsecsToString(newend);

                ActiveMediaSegment.mskEnd.LastAcceptedValue = ActiveMediaSegment.mskEnd.Text;
                mskDuration.LastAcceptedValue = mskTotalDuration.Text;

                frmClip.Instance.msPositionValue = newend;
                frmClip.Instance.SeekPosition();

                frmClip.Instance.btnSetEnd_Click(null, null);                

                ActiveMediaSegment.SetDuration();

                frmClip.Instance.UpdateVideoEndThumbnail();               
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not set Value !", ex);
                e.Cancel = true;
                mskTotalDuration.Text = mskTotalDuration.LastAcceptedValue;

                return;
            }
            finally
            {

            }
        }

        #endregion
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
        public List<string> OutputFiles = new List<string>();
    }

    public class Segment
    {
        public int RangeStart;
        public int RangeEnd;

        public bool Silence = false;
    }
}
