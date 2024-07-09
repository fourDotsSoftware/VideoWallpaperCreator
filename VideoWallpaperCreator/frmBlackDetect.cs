using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VideoWallpaperCreator
{
    public partial class frmBlackDetect : VideoWallpaperCreator.CustomForm
    {
        public string BlackDetectFilepath = "";
        private bool BlackFramesDetected = false;
        
        public frmBlackDetect()
        {
            InitializeComponent();
        }

        private void frmBlackDetect_Load(object sender, EventArgs e)
        {
            nudDuration.Value = Properties.Settings.Default.SetBlackDetectDuration;
            nudThreshold.Value = Properties.Settings.Default.SetBlackDetectThreshold;
            nudLuminance.Value = Properties.Settings.Default.SetBlackDetectLuminance;
        }

        private void btnOKBD_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SetBlackDetectDuration = nudDuration.Value;
            Properties.Settings.Default.SetBlackDetectThreshold = (int)nudThreshold.Value;
            Properties.Settings.Default.SetBlackDetectLuminance = nudLuminance.Value;

            this.DialogResult = DialogResult.OK;

            string bdargs = GetBlackDetectFFMpegParameters(frmClip.Instance.filepath);

            try
            {                                
                frmClip.Instance.ConversionStopped = false;
                frmClip.Instance.ConversionStarted = true;
                frmClip.Instance.errstr = "";

                frmClip.Instance.CompletedSecs = 0;                                                               
                
                frmClip.Instance.timCut.Enabled = true;
                //1lblElapsedTime.Visible = true;
                                
                decimal current_total_time = 0;

                frmProgress f = new frmProgress();
                f.lblCaption.Text = TranslateHelper.Translate("Please wait while detecting black scenes..");
                f.Show(this);
                f.timTime.Enabled = true;
                this.Enabled = false;
                f.progressBar1.Maximum = frmClip.Instance.LengthTotalMSecs;
                f.progressBar1.Value = 0;

                
                frmClip.Instance.CreateFFMpegProcess();

                frmClip.Instance.psFFMpeg.StartInfo.Arguments = bdargs;
                    
                frmClip.Instance.bwConvert.RunWorkerAsync();

                while (frmClip.Instance.bwConvert.IsBusy)
                {
                    Application.DoEvents();
                }

               if (frmClip.Instance.ConversionStopped) return;                
                                
            }
            finally
            {
                frmClip.Instance.timCut.Enabled = false;
                frmClip.Instance.ConversionProgressTime = 0;
                frmClip.Instance.ConversionStarted = false;                                

                if (frmProgress.Instance != null && frmProgress.Instance.Visible)
                {
                    frmProgress.Instance.Close();
                }

                this.Enabled = true;                              

                if (!frmClip.Instance.ConversionStopped)
                {                    
                    if (frmClip.Instance.errstr != String.Empty)
                    {
                        frmError fer = new frmError(TranslateHelper.Translate("Operation completed with Errors !"), frmClip.Instance.errstr);
                        fer.ShowDialog(this);                       
                    }
                    else
                    {
                        //Module.ShowMessage("Operation completed successfully !");

                        BlackFramesDetected=false;
                        
                        ParseBlackDetectResult(frmClip.Instance.LastFFMpegOutput);
                        /*
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(BlackDetectFilepath))
                        {
                            string str = sr.ReadToEnd();

                            ParseBlackDetectResult(str);
                        }
                        */

                        if (BlackFramesDetected)
                        {
                            if (Properties.Settings.Default.MsgBlackDetectExcludeMode)
                            {
                                frmMsgCheckBox fmc = new frmMsgCheckBox(frmMsgCheckBox.MsgModeEnum.OnBlackDetectExcludeMode, TranslateHelper.Translate("The Video Cut Mode was automatically set to Exclude Mode"));
                                fmc.ShowDialog();
                            }
                        }
                        else
                        {
                            Module.ShowMessage("No Black Frames were detected !");                            
                        }
                    }
                }

                
            }
        }

        public string GetBlackDetectFFMpegParameters(string filepath)
        {
            decimal dth = (decimal)Properties.Settings.Default.SetBlackDetectThreshold / (decimal)100;

            BlackDetectFilepath = System.IO.Path.GetTempFileName();

            decimal dbdur=(decimal)Properties.Settings.Default.SetBlackDetectDuration;
            
            string bdur = dbdur.ToString("#0.00").Replace(",",".");                       

            decimal dblum=(decimal)Properties.Settings.Default.SetBlackDetectLuminance;

            string blum = dblum.ToString("#0.00").Replace(",", ".");

            return "-i \"" + filepath + "\" -vf \"blackdetect=d=" + bdur +
            ":pic_th=" + dth.ToString("#0.00").Replace(",", ".") + ":pix_th=" + blum + "\" -an -f null - ";//2> \""+BlackDetectFilepath+"\"";
        }

        public void ParseBlackDetectResult(string str)
        {
            /*
                $start_s     = $_.line -match '(?<=black_start:)\S*(?= black_end:)'    | % {$matches[0]}
    $start_ts    = [timespan]::fromseconds($start_s)
    $black.start = "{0:HH:mm:ss.fff}" -f ([datetime]$start_ts.Ticks)

    # extract duration of black scene
    $end_s       = $_.line -match '(?<=black_end:)\S*(?= black_duration:)' | % {$matches[0]}
    $end_ts      = [timespan]::fromseconds($end_s)
    $black.end   = "{0:HH:mm:ss.fff}" -f ([datetime]$end_ts.Ticks)    
            */

            List<string> lstStart = new List<string>();
            List<string> lstEnd = new List<string>();

            Regex rexs = new Regex("(?<=black_start:)\\S*(?= black_end:)");
            Regex rexe = new Regex("(?<=black_end:)\\S*(?= black_duration:)");

            using (System.IO.StringReader sr = new System.IO.StringReader(str))
            {
                string line = null;

                while ((line = sr.ReadLine()) != null)
                {                   
                    if (rexs.IsMatch(line))
                    {
                        lstStart.Add(rexs.Match(line).Value);
                        lstEnd.Add(rexe.Match(line).Value);
                    }

                }
            }

            
            //MessageBox.Show(str);
            if (lstStart.Count > 0)
            {
                frmClip.Instance.fplSegments.Controls.Clear();

                for (int k = 0; k < lstStart.Count; k++)
                {
                    frmClip.Instance.tsiExcludeMode_Click(null, null);

                    MediaSegment ms = new MediaSegment();

                    int istart = FFMpegArgsHelper.GetTimeFromSecsString(lstStart[k]);
                    int iend = FFMpegArgsHelper.GetTimeFromSecsString(lstEnd[k]);

                    try
                    {
                        Module.LockWindowUpdate(frmClip.Instance.fplSegments.Handle);
                        frmClip.Instance.fplSegments.SuspendLayout();
                        ms.SuspendLayout();
                        
                        //7ms.msSegment.SetRangeStart(istart);
                        //7ms.msSegment.SetRangeEnd(iend);
                        

                        //msPosition.ForSetValuePixels = true;
                        //7frmClip.Instance.msPosition.SetRangeStart(ms.StartMSecs);
                        //7frmClip.Instance.msPosition.SetRangeEnd(ms.EndMSecs);

                        //7ms.RangeStartPixelsMsPosition = frmClip.Instance.msPosition.RangeStartPixels;
                        //7ms.RangeEndPixelsMsPosition = frmClip.Instance.msPosition.RangeEndPixels;

                        //msPosition.ForSetValuePixels = false;

                        frmClip.Instance.msPositionValue = ms.StartMSecs;

                        frmClip.Instance.fplSegments.Controls.Add(ms);

                        //1ms.lblSegment.Text = TranslateHelper.Translate("Clip")+" : "+ (fplSegments.Controls.Count).ToString("D2");
                        ms.lblSegment.Text = (frmClip.Instance.fplSegments.Controls.Count).ToString("D2");

                        int dsec = ms.EndMSecs - ms.StartMSecs;
                        ms.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(dsec);
                        ms.mskDuration.LastAcceptedValue = ms.mskDuration.Text;

                        ms.mskStart.Text = FFMpegArgsHelper.GetStringFromTime(ms.StartMSecs);
                        ms.mskStart.LastAcceptedValue = ms.mskStart.Text;

                        ms.mskEnd.Text = FFMpegArgsHelper.GetStringFromTime(ms.EndMSecs);
                        ms.mskEnd.LastAcceptedValue = ms.mskEnd.Text;

                        frmClip.Instance.fplSegments.SetFlowBreak(ms, true);

                        frmClip.Instance.DoNotSetMsPositionOnSetActive = true;
                        frmClip.Instance.SetActiveSegment(ms);
                        frmClip.Instance.DoNotSetMsPositionOnSetActive = false;

                        frmClip.Instance.UpdateVideoThumbnail();
                        frmClip.Instance.UpdateVideoEndThumbnail();
                        frmClip.Instance.UpdateTotalDuration();                        

                    }
                    finally
                    {
                        frmClip.Instance.fplSegments.ResumeLayout();
                        ms.ResumeLayout();

                        Module.LockWindowUpdate(IntPtr.Zero);

                        frmClip.Instance.DoNotSetMsPositionOnSetActive = false;
                    }
                }
            }
            /*
            string strbd = "";

            for (int k = 0; k < lstStart.Count; k++)
            {
                strbd += lstStart[k] + " - " + lstEnd[k] + "\r\n";
            }

            MessageBox.Show(strbd);
            */
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            nudDuration.Value = (decimal)2.0;
            nudLuminance.Value = (decimal)0.1;
            nudThreshold.Value = (decimal)98;

        }

        private void tbThreshold_Scroll(object sender, EventArgs e)
        {
            nudThreshold.Value = (decimal)tbThreshold.Value;
        }

        private void nudThreshold_ValueChanged(object sender, EventArgs e)
        {
            tbThreshold.Value = (int)nudThreshold.Value;
        }        

    }
}
