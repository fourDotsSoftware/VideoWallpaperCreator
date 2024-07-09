using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace VideoWallpaperCreator
{
    public partial class frmMain : VideoWallpaperCreator.CustomForm
    {
        public DataTable dt = new DataTable("table");
        public DataTable dtClipboard = new DataTable("table");

        public static frmMain Instance = null;

        public Process psFFMpeg = null;

        public bool ConversionStopped = false;
        public bool ConversionStarted = false;
        public bool ConversionPaused = false;
        public int ConversionProgressTime = 0;

        public int CompletedSecs = -1;
        private string _FirstOutputFile = "";

        public string ExplicitOutputFilepath = "";
        public bool OutputFileActionRepeat = false;

        public List<BatchResult> lstBatchResult = new List<BatchResult>();

        public string FirstOutputFile
        {
            get { return _FirstOutputFile; }
            set
            {
                if (value != string.Empty)
                {                    
                    _FirstOutputFile = value;
                }
            }
        }

        public string errstr = "";
        public string LastFFMpegOutput = "";

        int beforeCompletedSecs = 0;

        bool time_str_found = false;

        string last_line = "";
        
        BackgroundWorker bwConvert = new BackgroundWorker();

        VideoPlayer VideoPlayer;
                        
        public frmMain()
        {
            InitializeComponent();

            Instance = this;

            if (Module.args != null && Module.args.Length>0 && Module.args[0].ToLower() == "-minimize")
            {                
                notMain.Visible = true;

                this.WindowState = FormWindowState.Minimized;
                
                this.ShowIcon = false;

                this.Visible = false;

                this.Hide();

                ShowOnLoad = true;
                ShowMsgMinimized();
                ShowOnLoad = false;
            }             
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgVideo.AutoGenerateColumns = false;

            slblTotalDuration.Text = "";
            slblTotalVideos.Text = "";
            lblElapsedTime.Visible = false;

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("selected", typeof(bool));
                dt.Columns.Add("videoimg", typeof(Image));
                dt.Columns.Add("ind", typeof(int));
                dt.Columns.Add("durationmsecs", typeof(int));
                dt.Columns.Add("videoinfo", typeof(FFMPEGInfo));
            }

            dgVideo.DataSource = dt;

            UpdateInfo();            

            /*
            AddFile(@"c:\1\natgeo.mov");
            AddFile(@"c:\1\wings.mp4");
            AddFile(@"c:\1\wings30.mp4");
            AddFile(@"c:\1\zelda first commercial.mpeg");
            AddFile(@"c:\1\MOV04074.MPG");
            AddFile(@"c:\1\natgeo.mov");
            AddFile(@"c:\1\wings.mp4");
            AddFile(@"c:\1\wings30.mp4");
            AddFile(@"c:\1\zelda first commercial.mpeg");
            AddFile(@"c:\1\MOV04074.MPG");
            */

            bwConvert.DoWork += bwConvert_DoWork;
            bwConvert.RunWorkerCompleted += bwConvert_RunWorkerCompleted;
            bwConvert.ProgressChanged += bwConvert_ProgressChanged;
            bwConvert.WorkerReportsProgress = true;
            bwConvert.WorkerSupportsCancellation = true;

            SetupOnLoad();



            //DownloadFFMPEG32bit.CheckDownloadFFMPEG32bit();

            if (Properties.Settings.Default.CheckWeek)
            {
                UpdateHelper.InitializeCheckVersionWeek();
            }

            ResizeControls();

            if (Module.args != null && Module.args.Length > 0 && Module.args[0].ToLower() == "-minimize")
            {
                /*
                notMain.Visible = true;

                this.WindowState = FormWindowState.Minimized;

                this.ShowIcon = false;

                this.Visible = false;

                this.Hide();*/
            }
            else
            {
                RepositionResize();
            }

            if (Module.args != null && Module.args.Length > 0 && Module.args[0].ToLower() == "-minimize")
            {
                if (tsbPlay.Enabled)
                {
                    tsbPlay_Click(null, null);
                }
            }

            if ((this.WindowState==FormWindowState.Normal) || (this.WindowState==FormWindowState.Maximized))
            {
                WasSizeNormal = true;
            }
            else
            {
                WasSizeNormal = false;
            }

        }

        #region Join Function

        void bwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
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

                    decimal d1 = (decimal)frmProgress.Instance.progressBar1.Value;
                    decimal d2 = (decimal)frmProgress.Instance.progressBar1.Maximum;

                    decimal dprog = (d1 / d2) * 100;

                    int iprog=(int)dprog;

                    frmProgress.Instance.progressBar1.lblText = iprog.ToString() + "%";

                    int totalprog = frmProgress.Instance.PreviousTotalProgress + pg;

                    if (totalprog >= 0 && totalprog <= frmProgress.Instance.pbarTotal.Maximum)
                    {
                        frmProgress.Instance.pbarTotal.Value = totalprog;

                        decimal dt1 = (decimal)frmProgress.Instance.pbarTotal.Value;
                        decimal dt2 = (decimal)frmProgress.Instance.pbarTotal.Maximum;

                        decimal dtprog = (dt1 / dt2) * 100;

                        int itprog = (int)dtprog;

                        frmProgress.Instance.pbarTotal.lblText = itprog.ToString() + "%";
                    }
                }
            }
        }

        void bwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if no time= string was found this means that an error occured
            if (!time_str_found)
            {
                errstr += last_line;
            }            
        }

        void bwConvert_DoWork(object sender, DoWorkEventArgs e)
        {
            //0sw.WriteLine("ARGS=");
            //0sw.WriteLine(psFFMpeg.StartInfo.Arguments);

            LastFFMpegOutput = "";

            beforeCompletedSecs = CompletedSecs;

            time_str_found = false;

            last_line = "";

            Console.WriteLine("ARGS=" + psFFMpeg.StartInfo.Arguments);

            psFFMpeg.Start();            
            
            psFFMpeg.BeginErrorReadLine();
            psFFMpeg.BeginOutputReadLine();

            psFFMpeg.WaitForExit();

            psFFMpeg.Close();

            psFFMpeg.Dispose();
            psFFMpeg = null;

            /*
            if (!time_str_found)
            {
                errstr += last_line;
            }*/

        }

        public void tsbStopJoin_Click(object sender, EventArgs e)
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
                Module.ShowMessage("Join process stopped !");
                return;
            }
        }

        private void EnableDisableForm(bool enable)
        {
            foreach (Control co in this.Controls)
            {
                co.Enabled = enable;
            }
        }

        public void tsbCreateWallpaper_Click(object sender, EventArgs e)
        {
            if (ConversionStarted)
            {
                if (!psFFMpeg.HasExited)
                {
                    SuspendResumeThread.SuspendProcess(psFFMpeg.Id);
                    ConversionPaused = true;
                    ConversionStarted = false;
                    timJoinVideos.Enabled = false;

                    if (frmProgress.Instance != null)
                    {
                        frmProgress.Instance.btnPause.Image = Properties.Resources.merge_24;
                        frmProgress.Instance.btnPause.Text = TranslateHelper.Translate("Resume");
                        frmProgress.Instance.timTime.Enabled = false;
                    }
                }
            }
            else if (ConversionPaused)
            {
                ConversionStarted = true;
                ConversionPaused = true;
                timJoinVideos.Enabled = true;
                SuspendResumeThread.ResumeProcess(psFFMpeg.Id);

                if (frmProgress.Instance != null)
                {
                    frmProgress.Instance.btnPause.Image = Properties.Resources.media_pause;
                    frmProgress.Instance.btnPause.Text = TranslateHelper.Translate("Pause");
                    frmProgress.Instance.timTime.Enabled = true;
                }
            }
            else
            {
                try
                {
                    tsbStop_Click(null, null);

                    Properties.Settings.Default.Fps = (int)nudFps.Value;

                    Properties.Settings.Default.Interval = (int)nudInterval.Value;

                    Properties.Settings.Default.WallpaperWidth = (int)nudWidth.Value;

                    Properties.Settings.Default.Save();

                    ConversionStopped = false;
                    ConversionStarted = true;
                    errstr = "";

                    CompletedSecs = 0;

                    timJoinVideos.Enabled = true;
                    lblElapsedTime.Visible = true;                    

                    VideoWallpaperParameters vp = new VideoWallpaperParameters();
                    vp.Fps = (int)nudFps.Value;
                    vp.Width = (int)nudWidth.Value;

                    VideoWallpaperArgs va = VideoWallpaperMaker.GetVideoWallpaperArgs(dt, vp);

                    frmProgress f = new frmProgress();
                    f.Show(this);
                    f.timTime.Enabled = true;
                    //this.Enabled = false;
                    EnableDisableForm(false);
                    f.progressBar1.Maximum = 2* va.TotalDuration;
                    f.progressBar1.Value = 0;
                    //f.lblOutputFile.Text = System.IO.Path.GetFileName(res.JoinFile);                    

                    if (ConversionStopped) return;

                    for (int k = 0; k < va.Args.Count; k++)
                    {
                        CreateFFMpegProcess();

                        psFFMpeg.StartInfo.Arguments = va.Args[k];

                        bwConvert.RunWorkerAsync();

                        while (bwConvert.IsBusy)
                        {
                            Application.DoEvents();
                        }                        

                        if (ConversionStopped) return;
                    }

                    if (frmAbout2.LDT == string.Empty)
                    {
                        //3VideoWallpaperMaker.AddNonRegisteredWatermark();
                    }

                    

                }
                finally
                {
                    timJoinVideos.Enabled = false;
                    ConversionProgressTime = 0;
                    ConversionStarted = false;
                    //8OutputFileActionRepeat = false;                    

                    if (frmProgress.Instance != null && frmProgress.Instance.Visible)
                    {
                        frmProgress.Instance.Close();
                    }

                    //this.Enabled = true;

                    EnableDisableForm(true);

                    tsbPlay.Enabled = VideoWallpaperMaker.GetPlayingEnabled();
                    tsbTest.Enabled = VideoWallpaperMaker.GetPlayingEnabled();

                    startToolStripMenuItem.Enabled = tsbPlay.Enabled;

                    if (!ConversionStopped)
                    {
                        if (errstr != String.Empty)
                        {
                            frmError fer = new frmError(TranslateHelper.Translate("Operation completed with Errors !"), errstr);
                            fer.ShowDialog(this);
                        }
                        else
                        {
                            if (Properties.Settings.Default.ShowMsgTest)
                            {
                                frmMsgCheckBox f = new frmMsgCheckBox(frmMsgCheckBox.MsgModeEnum.TestAdvised,
                                    TranslateHelper.Translate("Video Wallpaper was successfully created !") + "\n\n" +
                                    TranslateHelper.Translate("It is advised in order to avoid crashes to test the Video Wallpaper first.")+"\n\n"+
                                    TranslateHelper.Translate("Press on the TEST button to test it.") + "\n\n" +
                                    TranslateHelper.Translate("Press on the Play button to view the Video Wallpaper !"));

                                f.Show(this);
                            }
                            else
                            {
                                if (Properties.Settings.Default.ShowMsgOnSuccess)
                                {
                                    Module.ShowMessage("Operation completed successfully !");
                                }
                            }
                        }
                    }
                }
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

        private void timJoinVideos_Tick(object sender, EventArgs e)
        {
            ConversionProgressTime++;
            TimeSpan ts = new TimeSpan(0, 0, ConversionProgressTime);

            //8lblElapsedTime.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");//8
        }

        public void CreateFFMpegProcess()
        {
            System.Threading.Thread.Sleep(300);

            try
            {
                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.Kill();
                }
            }
            catch { }

            System.Threading.Thread.Sleep(300);            
            
            LastFFMpegOutput = "";

            last_line = "";            

            psFFMpeg = new Process();
                        
            psFFMpeg.StartInfo.CreateNoWindow = true;
            psFFMpeg.StartInfo.UseShellExecute = false;
            psFFMpeg.StartInfo.RedirectStandardError = true;
            psFFMpeg.StartInfo.RedirectStandardOutput = true;

            psFFMpeg.OutputDataReceived += psFFMpeg_OutputDataReceived;
            psFFMpeg.ErrorDataReceived += psFFMpeg_ErrorDataReceived;

            psFFMpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            if (Properties.Settings.Default.FFMPEG64Bit == 1)
            {
                psFFMpeg.StartInfo.FileName = "ffmpeg64 ";
            }
            else
            {
                psFFMpeg.StartInfo.FileName = "ffmpeg32 ";
            }

            psFFMpeg.StartInfo.WorkingDirectory = System.Windows.Forms.Application.StartupPath;                                    

            //System.Threading.Thread.Sleep(500);

        }

        void psFFMpeg_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            string line = e.Data;

            Console.WriteLine(line);

            if (line != null)
            {
                last_line = line;
            }

            LastFFMpegOutput += line + "\r\n";

            Application.DoEvents();

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
                    int msecs = int.Parse(time.Substring(9, 1));

                    //0sw.WriteLine("parsed time="+ts.ToString() + "." + msecs.ToString());

                    //0sw.WriteLine("before completed secs=" + CompletedSecs.ToString());

                    CompletedSecs = beforeCompletedSecs + (completed_secs * 10 + msecs);

                    //0sw.WriteLine("completed secs="+CompletedSecs.ToString());

                    //int totalsex = LastCutArgs.TotalDuration / 10;

                    //1int progress = (int)((decimal)CompletedSecs * 100 / (decimal)(LastCutArgs.TotalDuration));

                    //1bwConvert.ReportProgress(progress);
                    bwConvert.ReportProgress(0, CompletedSecs);
                }
                catch { }

            }
            else if (line != null && line.ToLower().StartsWith("error"))
            {
                if (!time_str_found)
                {
                    errstr += line;
                }
            }
        }

        void psFFMpeg_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //Console.WriteLine("OUTPUT:"+e.Data);
        }

        #endregion

        #region Basic Toolbar Functions

        public void AddFile(string filepath)
        {
            if (filepath.Trim() == string.Empty) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                Bitmap bmp = new Bitmap(700, 110);

                int dur = -1;

                FFMPEGInfo finfo = null;

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    finfo = new FFMPEGInfo(filepath);

                    if (!finfo.Success)
                    {
                        return;
                    }

                    string timestring = FFMpegArgsHelperJoin.GetStringFromTime((int)(finfo.DurationMsecs / 2));

                    VideoThumbnail vt = new VideoThumbnail(filepath, timestring, 156, 100);

                    int x = 5;
                    int y = 5;

                    g.FillRectangle(Brushes.Black, new Rectangle(x, y, 156, 100));

                    if (vt.ThumbnailImage != null)
                    {
                        g.DrawImage(vt.ThumbnailImage, new Rectangle(x, y, 156, 100));
                    }

                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    Font f = new Font(dgVideo.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

                    x = 170;
                    y = 10;

                    g.DrawString(System.IO.Path.GetFileName(filepath), f, Brushes.DarkBlue, new PointF(x, y));
                    y += f.Height + 4;

                    string duration = TranslateHelper.Translate("Duration") + " : " + finfo.DurationStr;

                    dur = finfo.DurationMsecs;

                    g.DrawString(duration, f, Brushes.DimGray, new PointF(x, y));
                    y += f.Height + 4;


                    string video = TranslateHelper.Translate("Video") + " : " + finfo.VideoEncoder + " " + finfo.VideoSize + " " + finfo.VideoBitRate + " " + finfo.VideoFrameRate + " " + finfo.VideoPixelFormat;

                    g.DrawString(video, f, Brushes.DimGray, new PointF(x, y));

                    y += f.Height + 4;

                    string audio = TranslateHelper.Translate("Audio") + " : " + finfo.AudioEncoder + " " + finfo.AudioSamplingRate + " " + finfo.AudioBitRate + " " + finfo.AudioChannels + " " + finfo.AudioSampleFormat;

                    g.DrawString(audio, f, Brushes.DimGray, new PointF(x, y));

                }

                DataRow dr = dt.NewRow();
                dr["selected"] = false;
                dr["videoimg"] = bmp;
                dr["durationmsecs"] = dur;
                dr["videoinfo"] = finfo;

                if (dt.Rows.Count == 0)
                {
                    dr["selected"] = true;
                }

                dt.Rows.Add(dr);

                SetEnabled(true);

                UpdateInfo();

                RecentFilesHelper.AddRecentFileJoin(filepath);

            }
            catch (Exception ex)
            {
                this.Cursor = null;

                Module.ShowError(TranslateHelper.Translate("Error could not Add Video to List !") + " : " + filepath);
            }
            finally
            {
                this.Cursor = null;
            }
        }

        public void AddFolder(string folder_path)
        {
            if (!System.IO.Directory.Exists(folder_path)) return;

            string[] filez = null;

            if (System.IO.Directory.GetDirectories(folder_path).Length > 0)
            {
                DialogResult dres = Module.ShowQuestionDialog("Would you like to add also Subdirectories ?", TranslateHelper.Translate("Add Subdirectories ?"));

                if (dres == DialogResult.Yes)
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.AllDirectories);
                }
                else
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.TopDirectoryOnly);
                }
            }
            else
            {
                filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.TopDirectoryOnly);
            }                                            

            try
            {
                this.Cursor = Cursors.WaitCursor;

                for (int k = 0; k < filez.Length; k++)
                {
                    if (Module.IsAcceptableMediaInput(filez[k]))                    
                    {
                        System.Threading.Thread.Sleep(100);
                        AddFile(filez[k]);
                    }
                }
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void tsbAddFolder_ButtonClick(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                AddFolder(folderBrowserDialog1.SelectedPath);                
            }

        }

        private void tsbAddFolder_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!System.IO.Directory.Exists(e.ClickedItem.Text))
            {
                Module.ShowMessage(TranslateHelper.Translate("Folder does not exist !") + "\n\n" + e.ClickedItem.Text);
                return;
            }

            AddFolder(e.ClickedItem.Text);
            
        }

        private void tsbMoveUp_Click(object sender, EventArgs e)
        {
            if (dgVideo.SelectedRows == null) return;
            if (dgVideo.SelectedRows.Count == 0) return;

            List<DataRow> lst = new List<DataRow>();
            List<int> lstind = new List<int>();

            for (int k = 0; k < dgVideo.SelectedRows.Count; k++)
            {                
                lstind.Add(dgVideo.SelectedRows[k].Index);
            }

            lstind.Sort();

            for (int k = 0; k < lstind.Count; k++)
            {
                DataRowView drv = (DataRowView)dgVideo.Rows[lstind[k]].DataBoundItem;
                lst.Add(drv.Row);
            }

            dgVideo.ClearSelection();

            for (int k = 0; k < lst.Count; k++)
            {
                int ind = lstind[k];

                if (ind > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = lst[k][0];
                    dr["durationmsecs"] = lst[k]["durationmsecs"];
                    dr["videoinfo"] = lst[k]["videoinfo"];

                    // 0 1 2 3 4 5
                    // remove 4
                    // insert 3
                    // select 3

                    dt.Rows.Remove(lst[k]);

                    dt.Rows.InsertAt(dr, ind - 1);
                }
            }

            //dgVideo.Refresh();

            dgVideo.ClearSelection();

            int newind = -1;

            for (int k = 0; k < lstind.Count; k++)
            {
                if (lstind[k] > 0)
                {
                    dgVideo.Rows[lstind[k] - 1].Selected = true;

                    if (k == 0)
                    {
                        newind = lstind[k] - 1;
                    }
                }
                else
                {
                    dgVideo.Rows[lstind[k]].Selected = true;

                    if (k == 0)
                    {
                        newind = lstind[k];
                    }
                }
            }

            dgVideo.FirstDisplayedScrollingRowIndex = newind;

            UpdateInfo();
        }

        private void tsbMoveDown_Click(object sender, EventArgs e)
        {
            if (dgVideo.SelectedRows == null) return;
            if (dgVideo.SelectedRows.Count == 0) return;

            List<DataRow> lst = new List<DataRow>();
            List<int> lstind = new List<int>();

            for (int k = 0; k < dgVideo.SelectedRows.Count; k++)
            {
                lstind.Add(dgVideo.SelectedRows[k].Index);
            }

            lstind.Sort();

            for (int k = 0; k < lstind.Count; k++)
            {
                DataRowView drv = (DataRowView)dgVideo.Rows[lstind[k]].DataBoundItem;
                lst.Add(drv.Row);
            }

            dgVideo.ClearSelection();

            for (int k = lst.Count-1 ; k >=0; k--)
            {
                int ind = lstind[k];

                if (ind < dt.Rows.Count - 1)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = lst[k][0];
                    dr["durationmsecs"] = lst[k]["durationmsecs"];
                    dr["videoinfo"] = lst[k]["videoinfo"];

                    dt.Rows.Remove(lst[k]);

                    dt.Rows.InsertAt(dr, ind + 1);                    
                }                
            }            
            
            //dgVideo.Refresh();

            dgVideo.ClearSelection();

            int newind = -1;

            for (int k = lstind.Count-1 ; k>=0; k--)
            {
                if (lstind[k] <dgVideo.Rows.Count-1)
                {
                    dgVideo.Rows[lstind[k] + 1].Selected = true;

                    if (k == 0)
                    {
                        newind = lstind[k] + 1;
                    }
                }
                else
                {
                    dgVideo.Rows[lstind[k]].Selected = true;

                    if (k == 0)
                    {
                        newind = lstind[k];
                    }
                }
            }

            dgVideo.FirstDisplayedScrollingRowIndex = newind;

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            int tdur = 0;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                dt.Rows[k]["ind"] = k+1;
                tdur+=((int)dt.Rows[k]["durationmsecs"]);
            }

            slblTotalVideos.Text = TranslateHelper.Translate("Total Videos") + " : " + dt.Rows.Count.ToString();

            slblTotalDuration.Text = TranslateHelper.Translate("Total Duration") + " : " + FFMpegArgsHelperJoin.GetStringFromTime(tdur);
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (dgVideo.SelectedRows == null) return;

            List<DataRow> lst = new List<DataRow>();

            for (int k = 0; k < dgVideo.SelectedRows.Count; k++)
            {
                DataRowView drv = (DataRowView)dgVideo.SelectedRows[k].DataBoundItem;
                lst.Add(drv.Row);
            }

            for (int k = 0; k < lst.Count; k++)
            {
                dt.Rows.Remove(lst[k]);
            }

            if (dt.Rows.Count == 0)
            {
                SetEnabled(false);
            }
        }

        private void tsbAdd_ButtonClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Module.OpenFilesFilter;

            openFileDialog1.Multiselect = true;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int k = 0; k < openFileDialog1.FileNames.Length; k++)
                {
                    AddFile(openFileDialog1.FileNames[k]);
                }

            }
        }

        private void tsbAdd_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            AddFile(e.ClickedItem.Text);
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();            

           SetEnabled(false);

           UpdateInfo();
        }

        #endregion                        

        #region Right Click Menu - Tools Menu

        private void cmsVideos_Opening(object sender, CancelEventArgs e)
        {
            Point p = dgVideo.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            DataGridView.HitTestInfo hit = dgVideo.HitTest(p.X, p.Y);

            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                dgVideo.CurrentCell = dgVideo.Rows[hit.RowIndex].Cells[hit.ColumnIndex];

                try
                {
                    DataRow dr = dt.Rows[hit.RowIndex];

                    
                }
                catch { }

            }

            if (dgVideo.CurrentRow == null)
            {
                e.Cancel = true;
            }
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            VideoPlayer.play_Click(null, null);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgVideo.CurrentRow == null) return;

            DataRowView drv = (DataRowView)dgVideo.CurrentRow.DataBoundItem;

            DataRow dr = drv.Row;

            FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

            string filepath = finfo.Filepath;

            System.Diagnostics.Process.Start(filepath);

        }

        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)dgVideo.CurrentRow.DataBoundItem;

            DataRow dr = drv.Row;

            FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

            string filepath = finfo.Filepath;            

            string args = string.Format("/e, /select, \"{0}\"", filepath);

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);

        }

        private void copyFullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)dgVideo.CurrentRow.DataBoundItem;

            DataRow dr = drv.Row;

            FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

            string filepath = finfo.Filepath;

            Clipboard.Clear();

            Clipboard.SetText(filepath);
        }

        private void videoInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)dgVideo.CurrentRow.DataBoundItem;

            DataRow dr = drv.Row;

            FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

            string filepath = finfo.Filepath;

            frmVideoInfo f = new frmVideoInfo(filepath);

            f.ShowDialog();
        }

        private void tiToolsOpenOutput_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(FirstOutputFile))
            {
                Module.ShowMessage(TranslateHelper.Translate("Join Output File does not exist !") + "\n\n" + FirstOutputFile);
                return;
            }

            System.Diagnostics.Process.Start(FirstOutputFile);
        }

        private void tiToolsExploreOutput_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(FirstOutputFile))
            {
                Module.ShowMessage(TranslateHelper.Translate("Join Output File does not exist !") + "\n\n" + FirstOutputFile);
                return;
            }

            string filepath = FirstOutputFile;

            string args = string.Format("/e, /select, \"{0}\"", filepath);

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);
        }

        private void tiToolsCopyPathOutput_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(FirstOutputFile))
            {
                Module.ShowMessage(TranslateHelper.Translate("Join Output File does not exist !") + "\n\n" + FirstOutputFile);
                return;
            }

            string filepath = FirstOutputFile;

            Clipboard.Clear();

            Clipboard.SetText(filepath);
        }

        private void tiToolsVideoInfoOutput_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(FirstOutputFile))
            {
                Module.ShowMessage(TranslateHelper.Translate("Join Output File does not exist !") + "\n\n" + FirstOutputFile);
                return;
            }

            frmVideoInfo f = new frmVideoInfo(FirstOutputFile);

            f.ShowDialog();
        }

        private void playLastOutputFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(FirstOutputFile))
            {
                Module.ShowMessage(TranslateHelper.Translate("Join Output File does not exist !") + "\n\n" + FirstOutputFile);
                return;
            }

            VideoPlayer.playvideo(FirstOutputFile);
        }
        #endregion

        #region Drag and Drop

        private void dgVideo_DragEnter(object sender, DragEventArgs e)
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

        private void dgVideo_DragOver(object sender, DragEventArgs e)
        {            
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void dgVideo_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {                    
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;                        

                        if (System.IO.File.Exists(filez[k]))
                        {
                            AddFile(filez[k]);
                        }
                        else if (System.IO.Directory.Exists(filez[k]))
                        {
                            AddFolder(filez[k]);
                        }
                    }
                    finally
                    {
                        this.Cursor = null;
                    }
                }
            }
        }

        #endregion

        #region Help

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
            frmAbout2 f = new frmAbout2();
            f.ShowDialog();
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            frmUninstallQuestionnaire f = new frmUninstallQuestionnaire(false);
            f.ShowDialog();
            */

            System.Diagnostics.Process.Start("https://softpcapps.com/support/bugfeature.php?app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
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
            tsbStop_Click(null, null);

            Application.Exit();
        }

        #endregion

        #region Share

        private void shareOnFacebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareFacebook();
        }

        private void shareOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareTwitter();
        }

        private void shareOnGooglePlusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareGooglePlus();
        }

        private void shareOnLinkedinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareLinkedIn();
        }

        private void shareWithEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareEmail();
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

        private bool InChangeLanguage = false;

        private void ChangeLanguage(string language_code)
        {
            try
            {
                InChangeLanguage = true;

                Properties.Settings.Default.Language = language_code;
                frmLanguage.SetLanguage();

                Properties.Settings.Default.Save();
                Module.ShowMessage("Please restart the application !");
                Application.Exit();
                return;

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
            finally
            {
                InChangeLanguage = false;
            }
        }

        #endregion

        #region OnLoad

        bool FreeForPersonalUse = false;
        bool FreeForPersonalAndCommercialUse = true;

        private void SetTitle()
        {
            string str = "";

            if (!FreeForPersonalUse && !FreeForPersonalAndCommercialUse)
            {
                if (frmAbout2.LDT == string.Empty)
                {
                    str += " - " + TranslateHelper.Translate("Trial Version - Unlicensed - Please Buy !");
                }
                else
                {
                    str += " - " + TranslateHelper.Translate("Licensed Version");
                }
            }
            else if (FreeForPersonalUse)
            {
                str += " - " + TranslateHelper.Translate("Free for Personal Use Only - Please Donate !");
            }
            else if (FreeForPersonalAndCommercialUse)
            {
                str += " - " + TranslateHelper.Translate("Free for Personal and Commercial Use - Please Donate !");
            }

            this.Text = Module.ApplicationTitle + str.ToUpper();
        }

        private void SetupOnLoad()
        {
            args_play = " -nofs  -noquiet  -osdlevel 0 -identify -slave -volume 0 ";
            args_play += "-nomouseinput -sub-fuzziness 1 ";

            //-wid will tell MPlayer to show output inisde our panel
            args_play += " -vo direct3d -ao dsound ";
            //9 args_play += " -wid " + picMovie.Handle.ToString();

            args_play += " -ss " + FFMpegArgsHelperJoin.GetStringFromTime(0);
            //3
            //3args_play = "";

            int id = (int)this.Handle;//picMovie.Handle;            

            /* 9
            msVolume.Maximum = 100;
            msVolume.Value = 70;
            */

            this.Text = Module.ApplicationTitle;
                        
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

            AddLanguageMenuItems();            

            SetEnabled(false);

            //1RecentFilesHelper.FillMenuRecentFile();

            RecentFilesHelper.FillJoinRecentFile();

            VideoPlayer = new VideoPlayer(btnRewind, btnFastForward, btnPlay, btnStop, btnMute, msVolume,
                msPosition, lblTime, picVideoPlayer);

            this.AllowDrop = true;
            this.DragDrop += dgVideo_DragDrop;
            this.DragOver += dgVideo_DragOver;
            this.DragEnter += dgVideo_DragEnter;
                       
                        
            dtClipboard = dt.Clone();            

            if (Properties.Settings.Default.FFMPEG64Bit == 0)
            {
                if (Module.IsWindows64Bit)
                {
                    useFFMPEG64bitToolStripMenuItem_Click(null, null);
                }
                else
                {
                    useFFMPEG32bitToolStripMenuItem_Click(null, null);
                }
            }
            else if (Properties.Settings.Default.FFMPEG64Bit == 1)
            {
                useFFMPEG64bitToolStripMenuItem_Click(null, null);
            }
            else if (Properties.Settings.Default.FFMPEG64Bit == 2)
            {
                useFFMPEG32bitToolStripMenuItem_Click(null, null);
            }

            rdFastComputer.Checked = Properties.Settings.Default.FastComputer;
            rdSlowComputer.Checked = !Properties.Settings.Default.FastComputer;

            nudInterval.Value = Properties.Settings.Default.Interval;

            nudFps.Value = Properties.Settings.Default.Fps;

            if (Properties.Settings.Default.WallpaperWidth == -1)
            {
                nudWidth.Value = Screen.PrimaryScreen.WorkingArea.Width;
            }
            else
            {
                nudWidth.Value = Properties.Settings.Default.WallpaperWidth;
            }

            chkStartup.Checked = RunOnWindowsStartupHelper.GetRunOnWindowsStartup();

            minimizeToSystemTrayToolStripMenuItem.Checked = Properties.Settings.Default.MinimizeToSystemTray;

            loopVideosToolStripMenuItem.Checked = Properties.Settings.Default.LoopVideos;

            tsbPlay.Enabled = VideoWallpaperMaker.GetPlayingEnabled();
            startToolStripMenuItem.Enabled = tsbPlay.Enabled;

            if (Properties.Settings.Default.AddedVideos.Trim() == "-1")
            {
                addCloudsSampleVideoToolStripMenuItem_Click(null, null);
            }
            else if (Properties.Settings.Default.AddedVideos != string.Empty)
            {
                string[] videoz = Properties.Settings.Default.AddedVideos.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < videoz.Length; k++)
                {
                    if (System.IO.File.Exists(videoz[k]))
                    {
                        AddFile(videoz[k]);
                    }
                }
            }

            tsbPlay.Enabled = false;
            tsbTest.Enabled = false;

            if (System.IO.Directory.Exists(VideoWallpaperMaker.WallpaperImagesFolder))
            {
                string[] filez = System.IO.Directory.GetFiles(VideoWallpaperMaker.WallpaperImagesFolder);

                if (filez.Length > 0)
                {
                    tsbTest.Enabled = true;
                    tsbPlay.Enabled = true;
                }
            }

            checkForNewVersionEachWeekToolStripMenuItem.Checked = Properties.Settings.Default.CheckWeek;

            SetTitle();
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

        private void frmClip_Load(object sender, EventArgs e)
        {
            //SetupOnLoad();

            //UpdateHelper.InitializeCheckVersion();
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
            if (this.WindowState != FormWindowState.Minimized)
            {
                Properties.Settings.Default.Maximized = (this.WindowState == FormWindowState.Maximized);
                Properties.Settings.Default.Left = this.Left;
                Properties.Settings.Default.Top = this.Top;
                Properties.Settings.Default.Width = this.Width;
                Properties.Settings.Default.Height = this.Height;
                Properties.Settings.Default.Save();
            }
        }

        private void SetEnabled(bool enabled)
        {
            tsbCreateWallpaper.Enabled = enabled;
            btnPlay.Enabled = enabled;
        }

        public static bool WasInFormClosing = false;

        private void SaveSettings()
        {
            string videoz = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                FFMPEGInfo finfo = (FFMPEGInfo)dt.Rows[k]["videoinfo"];

                videoz += finfo.Filepath + "|||";
            }

            Properties.Settings.Default.AddedVideos = videoz;

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

            Properties.Settings.Default.Fps = (int)nudFps.Value;

            Properties.Settings.Default.Interval = (int)nudInterval.Value;

            Properties.Settings.Default.WallpaperWidth = (int)nudWidth.Value;

            Properties.Settings.Default.FastComputer = rdFastComputer.Checked;

            Properties.Settings.Default.CheckWeek = checkForNewVersionEachWeekToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SavePositionSize();
        }

        private void frmVideoJoin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WasInFormClosing) return;

            WasInFormClosing = true;

            /*
            if (!InChangeLanguage)
            {
                if (frmPurchase.RenMove && frmPurchase.Msg != DisplayMessageType1.License_Expired)
                {
                    if (frmPurchase.Datefrom != string.Empty)
                    {
                        frmPurchase f = new frmPurchase(frmPurchase.Msg, frmPurchase.Datefrom, frmPurchase.Datelast);
                        f.ShowDialog();
                    }
                    else
                    {
                        frmPurchase f = new frmPurchase(frmPurchase.Msg);
                    }
                }
            }
            */

            SaveSettings();

            tsbStop_Click(null, null);
            
        }

        private void frmVideoJoin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                psFFMpeg.Kill();
            }
            catch { }

            try
            {
                VideoPlayer.ps.Kill();
            }
            catch { }

            /*
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
            }*/
        }

        #endregion

        #region Media Player

        private string args_play = "";

        #endregion        

        #region Import - Enter List

        private void importVideosFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string curdir = Environment.CurrentDirectory;

                try
                {
                    Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);

                    using (System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName))
                    {
                        string line = null;

                        while ((line = sr.ReadLine()) != null)
                        {
                            string fullfilepath = System.IO.Path.GetFullPath(line);

                            try
                            {
                                AddFile(fullfilepath);
                            }
                            catch (Exception ex)
                            {
                                Module.ShowError("Error. Could not Add Video to list", ex);
                            }
                        }
                    }
                }
                finally
                {
                    Environment.CurrentDirectory = curdir;
                }
            }
        }

        private void importVideosFromCSVFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportCSV f = new frmImportCSV();

            if (f.ShowDialog() == DialogResult.OK)
            {
                f.ImportCSV(f.txtFilepath.Text);
            }
        }

        private void importVideosFromExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportExcel f = new frmImportExcel();

            if (f.ShowDialog() == DialogResult.OK)
            {
                f.ImportListExcel(f.txtFilepath.Text);
            }
        }

        private void enterListOfVideosToJoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                FFMPEGInfo finfo = (FFMPEGInfo)dt.Rows[k]["videoinfo"];

                txt += finfo.Filepath + "\r\n";
            }

            frmMultipleFiles f = new frmMultipleFiles(false,txt);

            if (f.ShowDialog() == DialogResult.OK)
            {
                dt.Rows.Clear();

                for (int k = 0; k < f.txtFiles.Lines.Length; k++)
                {
                    AddFile(f.txtFiles.Lines[k]);
                }
            }
        }

        #endregion

        #region Batch Join

        private void addCurrentVideoFilesToBatchJoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show output format...
            string outputext = "";
            string outputparams = "";

            
        }

        private void importBatchListFromTextFileMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importBatchListFromCSVFileMenuItem_Click_Click(object sender, EventArgs e)
        {

        }

        private void importBatchListFromExcelFileMenuItem_Click_Click(object sender, EventArgs e)
        {

        }

        private void enterBatchListMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void batchJoinToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        #endregion                        

        private void saveCurrentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count==0)
            {
                Module.ShowMessage("Current Selection is Empty !");
                return;
            }

            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false,Encoding.Default))
                {
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        FFMPEGInfo finfo=(FFMPEGInfo)dt.Rows[k]["videoinfo"];
                        sw.WriteLine(finfo.Filepath);
                    }                        
                }
            }
        }

        private void saveJoinArgsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void setOutputFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        public int CurrentTotalJoinDuration
        {
            get
            {
                int dur = 0;

                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    int msecs = (int)dt.Rows[k]["durationmsecs"];

                    dur += msecs;
                }

                return dur;
            }
        }

        public string CurrentFirstFilepath
        {
            get
            {
                if (dt.Rows.Count > 0)
                {
                    FFMPEGInfo f = (FFMPEGInfo)dt.Rows[0]["videoinfo"];

                    return f.Filepath;
                }

                return "";
            }
        }
        private void tiToolsFileSizeBitrates_Click(object sender, EventArgs e)
        {
            
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void batchJoinToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void addCurrentVideoFilesToBatchJoinToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgVideo.SelectAll();
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgVideo.ClearSelection();
        }

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgVideo.Rows.Count; k++)
            {
                dgVideo.Rows[k].Selected = !dgVideo.Rows[k].Selected;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
        }

        private void buyApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.BuyURL);

        }

        private void enterLicenseKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (dgVideo.SelectedRows == null) return;
            if (dgVideo.SelectedRows.Count == 0) return;

            dtClipboard.Clear();

            for (int k = 0; k < dgVideo.SelectedRows.Count; k++)
            {
                DataRowView drv = (DataRowView)dgVideo.SelectedRows[k].DataBoundItem;

                DataRow dr = drv.Row;

                DataRow dr0 = dtClipboard.NewRow();

                for (int m = 0; m < dt.Columns.Count; m++)
                {
                    dr0[m] = dr[m];
                }

                dtClipboard.Rows.Add(dr0);
            }
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {
            int sel = 0;

            if (dgVideo.CurrentRow != null)
            {
                sel = dgVideo.CurrentRow.Index;
            }

            for (int k = 0; k < dtClipboard.Rows.Count; k++)
            {
                DataRow dr = dtClipboard.Rows[k];

                DataRow dr0 = dt.NewRow();

                for (int m = 0; m < dt.Columns.Count; m++)
                {
                    dr0[m] = dr[m];
                }

                dt.Rows.InsertAt(dr0, sel + k+1);
            }

            UpdateInfo();
        }        

        private void copyEXIFInformationCreationDateLastModificationDateFromThisVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                dt.Rows[k]["selected"] = false;
            }            

            
            
        }

        private void useFFMPEG64bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useFFMPEG64bitToolStripMenuItem.Checked = true;
            useFFMPEG32bitToolStripMenuItem.Checked = false;

            Properties.Settings.Default.FFMPEG64Bit = 1;
        }

        private void useFFMPEG32bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useFFMPEG64bitToolStripMenuItem.Checked = false;
            useFFMPEG32bitToolStripMenuItem.Checked = true;

            Properties.Settings.Default.FFMPEG64Bit = 2;
        }

        private void rdFastComputer_Click(object sender, EventArgs e)
        {
            nudFps.Value = 10;
            nudInterval.Value = 300;
        }

        private void rdSlowComputer_Click(object sender, EventArgs e)
        {
            nudFps.Value = 1;
            nudInterval.Value = 2000;
        }

        private List<WallpaperImage> lstImages = new List<WallpaperImage>();
        private int CurrentImageIndex = 0;
        private int MaxImageIndex = 0;

        private void tsbPlay_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                /*
                Properties.Settings.Default.Fps = (int)nudFps.Value;

                Properties.Settings.Default.Interval = (int)nudInterval.Value;

                Properties.Settings.Default.WallpaperWidth = (int)nudWidth.Value;
                */

                Properties.Settings.Default.Interval = (int)nudInterval.Value;

                timWallpaper.Interval = Properties.Settings.Default.Interval;

                //VideoWallpaperMaker.SaveOldWallpaper();

                string[] filez = System.IO.Directory.GetFiles(VideoWallpaperMaker.WallpaperImagesFolder);

                lstImages.Clear();

                for (int k = 0; k < filez.Length; k++)
                {
                    lstImages.Add(new WallpaperImage(filez[k]));
                }

                lstImages.Sort();

                CurrentImageIndex = 0;

                MaxImageIndex = lstImages.Count - 1;

                timWallpaper.Enabled = true;

                tsbPlay.Enabled = false;

                tsbStop.Enabled = true;

                SaveSettings();

            }
            finally
            {
                this.Cursor = null;
            }
            
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            timWallpaper.Enabled = false;

            timTest.Enabled = false;

            System.Threading.Thread.Sleep(1000);

            VideoWallpaperMaker.RestoreOldWallpaper();

            tsbPlay.Enabled = VideoWallpaperMaker.GetPlayingEnabled();
            startToolStripMenuItem.Enabled = tsbPlay.Enabled;

            tsbStop.Enabled = false;
        }

        private void timWallpaper_Tick(object sender, EventArgs e)
        {
            VideoWallpaperMaker.SetWallpaper(lstImages[CurrentImageIndex].Filepath);

            CurrentImageIndex = CurrentImageIndex + 1;

            if (CurrentImageIndex >= MaxImageIndex)
            {
                if (Properties.Settings.Default.LoopVideos)
                {
                    CurrentImageIndex = 0;
                }
                else
                {
                    timWallpaper.Enabled = false;
                }
            }
        }

        private void timTest_Tick(object sender, EventArgs e)
        {
            tsbStop_Click(null, null);

            if (Properties.Settings.Default.ShowMsgTestEnd)
            {
                frmMsgCheckBox f = new frmMsgCheckBox(frmMsgCheckBox.MsgModeEnum.OnTestEnd, TranslateHelper.Translate("Test stopped !"));

                f.Show(this);
            }
        }

        private void tsbTest_Click(object sender, EventArgs e)
        {            
            if (Properties.Settings.Default.ShowMsgTestStart)
            {
                frmMsgCheckBox f=new frmMsgCheckBox(frmMsgCheckBox.MsgModeEnum.OnTestStart,TranslateHelper.Translate("Playing of Video Wallpaper will stop in 60 seconds automatically ! If your computer gets slow try increasing the Timer Interval value."));

                f.Show(this);
            }

            tsbPlay_Click(null, null);

            timTest.Enabled = true;

            tsbStop.Enabled = true;
        }

        private void chkStartup_Click(object sender, EventArgs e)
        {
            bool suc=RunOnWindowsStartupHelper.SetRunAtWindowsStartup(chkStartup.Checked, "-minimize");

            if (!suc)
            {
                chkStartup.Checked = !chkStartup.Checked;
            }
        }

        private void minimizeToSystemTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MinimizeToSystemTray = minimizeToSystemTrayToolStripMenuItem.Checked;
        }

        private bool OnResize = false;

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (OnResize) return;                       

            if (Properties.Settings.Default.MinimizeToSystemTray)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Visible = false;

                    if (WasSizeNormal)
                    {
                        ShowMsgMinimized();
                    }
                }
            }

            if ((this.WindowState == FormWindowState.Normal) || (this.WindowState == FormWindowState.Maximized))
            {
                WasSizeNormal = true;
            }
            else
            {
                WasSizeNormal = false;
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Module.args = null;

                OnResize = true;

                this.ShowIcon = true;

                this.Show();

                this.WindowState = FormWindowState.Normal;

                WasSizeNormal = true;

                this.Show();

                this.Visible = true;

                this.BringToFront();

                RepositionResize();
            }
            finally
            {
                OnResize = false;
            }
        }

        private void loopVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LoopVideos = loopVideosToolStripMenuItem.Checked;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MessageHelper.WM_COPYDATA)
            {
                MessageHelper.COPYDATASTRUCT mystr = new MessageHelper.COPYDATASTRUCT();
                Type mytype = mystr.GetType();
                mystr = (MessageHelper.COPYDATASTRUCT)m.GetLParam(mytype);                

                string arg = mystr.lpData;
                
                if (arg == "SHOW")
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.Show();
                    this.BringToFront();                    
                }
            }
            else if (m.Msg == MessageHelper.WM_ACTIVATEAPP)
            {
                this.Show();

                this.WindowState = FormWindowState.Normal;
                this.Show();
                this.BringToFront();                
            }


            base.WndProc(ref m);
        }

        private void addCloudsSampleVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFile(System.IO.Path.Combine(Application.StartupPath, "clouds.mp4"));
        }

        private bool WasSizeNormal = false;
        private bool ShowOnLoad = false;

        private void ShowMsgMinimized()
        {
            if (!WasSizeNormal && !ShowOnLoad) return;

            if (!Properties.Settings.Default.MsgMinimized) return;

            frmMessageCheckbox f = new frmMessageCheckbox(TranslateHelper.Translate("Minimized to Windows System Tray"), TranslateHelper.Translate("The application is now minmized to the Windows System Tray"), "", frmMessageCheckbox.MessageType.MsgMinimized);
            f.TopMost = true;
            f.Show();
            f.BringToFront();
            f.TopMost = false;
        }

        private void notMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showToolStripMenuItem_Click(null, null);
        }
    }

    public class BatchResult
    {
        public string Outfilepath = "";
        public string Msg = "";
        public bool HasError = false;
    }

    public class WallpaperImage : IComparable<WallpaperImage>
    {
        public string Filepath = "";

        public WallpaperImage(string fp)
        {
            Filepath = fp;
        }

        public string ShortFilename
        {
            get
            {
                return System.IO.Path.GetFileNameWithoutExtension(Filepath);
            }
        }

        public int CompareTo(WallpaperImage o)
        {
            string fn = System.IO.Path.GetFileNameWithoutExtension(this.Filepath);

            int spos = fn.IndexOf("-");

            string videoind = fn.Substring("image".Length, spos - "image".Length);

            int ivideoind = int.Parse(videoind);

            string imageind = fn.Substring(spos + 1);

            int iimageind = int.Parse(imageind);

            int spos2 = o.ShortFilename.IndexOf("-");

            string videoind2 = o.ShortFilename.Substring("image".Length, spos2 - "image".Length);

            int ivideoind2 = int.Parse(videoind2);

            string imageind2 = o.ShortFilename.Substring(spos2 + 1);

            int iimageind2 = int.Parse(imageind2);

            if (ivideoind < ivideoind2)
            {
                return ivideoind.CompareTo(ivideoind2);
            }
            else if (ivideoind > ivideoind2)
            {
                return ivideoind.CompareTo(ivideoind2);
            }
            else
            {
                return iimageind.CompareTo(iimageind2);
            }            
        }        
    }
}
