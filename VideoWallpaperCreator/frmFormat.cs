using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace VideoWallpaperCreator
{
    public partial class frmFormat : VideoWallpaperCreator.CustomForm
    {
        public DataTable dt = new DataTable("table");
        public DataTable dtprofile = new DataTable("profile_settings");
        private List<FormatSetting> lstFormatSettings = new List<FormatSetting>();
        private List<String> lstFormatSettingsName = new List<String>();

        private int SelectedDTRowIndex = -1;
        private bool ConversionStopped = false;
        private bool ConversionStarted = false;
        private bool ConversionPaused = false;

        private string errstr = "";

        //        private string args = "";

        //public static frmMain Instance = null;
        public List<Process> lstProcessConvert = new List<Process>();

        public List<string> lstArgs = new List<string>();
        public List<string> lstFilesToDelete = new List<string>();
        public List<int> lstArgsRow = new List<int>();

        enum PlayerStateEnum
        {
            Playing,
            Paused,
            Stopped
        }

        PlayerStateEnum PlayerState = PlayerStateEnum.Stopped;

        enum ThreadPriority
        {
            RealTime, High, AboveNormal, Normal, BelowNormal, Idle
        }

        ThreadPriority ThreadPriorityLevel = ThreadPriority.Normal;


        Process ps = null;
        string args_play = "";

        string args = "";
        /// <summary>
        /// Path of selected file
        /// </summary>
        string filename = null;
        /// <summary>
        /// The process Object to run Mplayer.exe
        /// </summary>

        Process psFFMpeg = null;

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


            // psFFMpeg.ErrorDataReceived += psFFMpeg_ErrorDataReceived;
            // psFFMpeg.OutputDataReceived += psFFMpeg_ErrorDataReceived;
        }

        public frmFormat()
        {
            InitializeComponent();
            tsVideo.Renderer = new LightBlueButtonRenderer();
            tsAudio.Renderer = new LightBlueButtonRenderer();
            tsAudioVideo.Renderer = new LightBlueButtonRenderer();

            for (int k = 0; k < tsVideo.Items.Count; k++)
            {
                tsVideo.Items[k].Click += frmFormat_Click;
            }

            for (int k = 0; k < tsAudio.Items.Count; k++)
            {
                tsAudio.Items[k].Click += frmFormatA_Click;
            }
        }

        void frmFormat_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < tsVideo.Items.Count; k++)
            {
                ToolStripButton tsb = tsVideo.Items[k] as ToolStripButton;
                tsb.Checked = false;
            }
                        
            ToolStripButton tsel = sender as ToolStripButton;
            tsel.Checked = true;
        }

        void frmFormatA_Click(object sender, EventArgs e)
        {            

            for (int k = 0; k < tsAudio.Items.Count; k++)
            {
                ToolStripButton tsb = tsAudio.Items[k] as ToolStripButton;
                tsb.Checked = false;
            }

            ToolStripButton tsel = sender as ToolStripButton;
            tsel.Checked = true;
        }

        
        private void tsbAudio_Click(object sender, EventArgs e)
        {
            tsbAudio.Checked = true;
            tsbVideo.Checked = false;
            tsAudio.Left = tsVideo.Left;
            tsAudio.Top = tsVideo.Top;
            tsVideo.Visible = false;
            tsAudio.Visible = true;
        }

        private void tsbVideo_Click(object sender, EventArgs e)
        {
            tsbAudio.Checked = false;
            tsbVideo.Checked = true;
            
            tsVideo.Visible = true;
            tsAudio.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void CutJoin()
        {
            /*r
            if (ConversionStarted)
            {
                if (!psFFMpeg.HasExited)
                {
                    SuspendResumeThread.SuspendProcess(psFFMpeg.Id);
                    ConversionPaused = true;
                    ConversionStarted = false;
                    timConvert.Enabled = false;
                    //Properties.Resources.movie_convert_24;
                    tsbConvert.Image = Properties.Resources.movie_convert_24;
                    tsbConvert.Text = TranslateHelper.Translate("Resume");
                }


            }
            else if (ConversionPaused)
            {
                ConversionStarted = true;
                ConversionPaused = true;
                timConvert.Enabled = true;
                SuspendResumeThread.ResumeProcess(psFFMpeg.Id);
                tsbConvert.Image = Properties.Resources.media_pause;
                tsbConvert.Text = TranslateHelper.Translate("Pause Conversion");
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
                    lstArgs.Clear();
                    lstArgsRow.Clear();
                    lstFilesToDelete.Clear();

                    Module.SelectedFormatSetting = lstFormatSettings[cmbProfile.SelectedIndex];

                    for (int kk = 0; kk < dt.Rows.Count; kk++)
                    {
                        if (dt.Rows[kk]["cstatus"].ToString() != "-1")
                        {
                            dt.Rows[kk]["cstatus"] = 0;
                        }

                        dt.Rows[kk]["cCompletedSecs"] = 0;
                    }

                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        DataRow dr = dt.Rows[k];

                        // if the row is not selected...skip it....

                        if (dr["cselect"].ToString() != bool.TrueString)
                        {
                            continue;
                        }

                        // is the row is parent of a join.... get the join items...
                        if (dr["cIsPartOfJoin"].ToString() == bool.TrueString
                            && dr["cParentID"].ToString() == "-1")
                        {
                            GetJoinArgsResult resjoin = FFMpegArgsHelperJoin.GetJoinArgsForAudio(k);

                            for (int m = 0; m < resjoin.JoinArgs.Count; m++)
                            {
                                lstArgs.Add(resjoin.JoinArgs[m]);
                                lstArgsRow.Add(resjoin.JoinArgsRow[m]);
                            }

                            for (int m = 0; m < resjoin.JoinFilesToDelete.Count; m++)
                            {
                                lstFilesToDelete.Add(resjoin.JoinFilesToDelete[m]);
                            }

                            k = resjoin.MoveToKAfterwards;
                            continue;
                        }

                        // if the row is a split parent ....get split items...
                        else if (dr["cIsPartOfSplit"].ToString() == bool.TrueString
                            && dr["cParentID"].ToString() == "-1")
                        {
                            GetSplitArgsResult ressplit = FFMpegArgsHelperJoin.GetSplitArgsForAudio(k);

                            for (int m = 0; m < ressplit.SplitArgs.Count; m++)
                            {
                                lstArgs.Add(ressplit.SplitArgs[m]);
                                lstArgsRow.Add(ressplit.SplitArgsRow[m]);
                            }

                            for (int m = 0; m < ressplit.SplitFilesToDelete.Count; m++)
                            {
                                lstFilesToDelete.Add(ressplit.SplitFilesToDelete[m]);
                            }

                            k = ressplit.MoveToKAfterwards;
                            continue;

                        }

                        else
                        {
                            lstArgs.Add(" -vn " + FFMpegArgsHelperJoin.GetArgsForRow(dt.Rows[k]));

                            lstArgsRow.Add(k);
                        }
                    }

                    string txt = "";

                    for (int k = 0; k < lstArgs.Count; k++)
                    {
                        txt += lstArgs[k] + "\r\n";
                    }

                    for (int k = 0; k < lstArgs.Count; k++)
                    {
                        /* REMOVE COMMENTS ..
                        // return;
                        CreateFFMpegProcess();

                        psFFMpeg.StartInfo.Arguments = lstArgs[k];

                        SelectedDTRowIndex = lstArgsRow[k];

                        timConvert.Enabled = true;
                        lblElapsedTime.Visible = true;
                        lblElapsedTimeDesc.Visible = true;

                        bwConvert.RunWorkerAsync();

                        tsbConvert.Image = Properties.Resources.media_pause;
                        tsbStopConversion.Enabled = true;
                        tsbConvert.Text = TranslateHelper.Translate("Pause Conversion");

                        while (bwConvert.IsBusy)
                        {
                            Application.DoEvents();
                        }

                        if (ConversionStopped) return;
                         
                         */
               /*r     }

                }
                finally
                {
                    //rtimConvert.Enabled = false;
                    //rConversionProgressTime = 0;
                    ConversionStarted = false;

                    //lblElapsedTime.Visible = false;
                    //lblElapsedTimeDesc.Visible = false;

                    for (int m = 0; m < lstFilesToDelete.Count; m++)
                    {
                        if (System.IO.File.Exists(lstFilesToDelete[m]))
                        {
                            try
                            {
                                System.IO.File.Delete(lstFilesToDelete[m]);
                            }
                            catch (Exception exd)
                            {
                                errstr += TranslateHelper.Translate("Error. Could not Delete file") + " : " + lstFilesToDelete[m] + "\r\n" + exd.Message + "\r\n";
                            }
                        }
                    }

                    if (!chkShutdown.Checked)
                    {
                        if (!ConversionStopped)
                        {

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
                    }
                    else
                    {
                        //rProcessWhenFinished();
                    }

                    /*r
                    tsbConvert.Image = Properties.Resources.movie_convert_24;
                    tsbStopConversion.Enabled = false;
                    tsbConvert.Text = TranslateHelper.Translate("Convert");
                     
                     */
            /*r         
                }
            }
             */
        }           
             
    }

    public class LightBlueButtonRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var btn = e.Item as ToolStripButton;
            if (btn != null && btn.Checked)
            {
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                e.Graphics.FillRectangle(Brushes.DeepSkyBlue, bounds);
            }
            else
            {
                base.OnRenderButtonBackground(e);
            }
        }
    }
}
