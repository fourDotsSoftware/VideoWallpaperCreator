using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace VideoWallpaperCreator
{
    public partial class MediaSegment : UserControl
    {
        private int _StartMSecs;
        public int StartMSecs
        {
            get { return _StartMSecs; }
            set
            {
                if (frmClip.Instance != null && frmClip.Instance.ActiveMediaSegment == this)
                {
                    frmClip.Instance.mskCutStart.Text = FFMpegArgsHelper.GetStringFromTime(value);
                    
                    frmClip.Instance.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(EndMSecs-value);                    
                }

                _StartMSecs = value;
            }
        }

        private int _EndMSecs;        
        public int EndMSecs        
        {
            get { return _EndMSecs; }
            set
            {
                if (frmClip.Instance != null && frmClip.Instance.ActiveMediaSegment == this)
                {
                    frmClip.Instance.mskCutEnd.Text = FFMpegArgsHelper.GetStringFromTime(value);

                    frmClip.Instance.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(value-StartMSecs);
                }

                _EndMSecs = value;
            }
        }

        public string LastMskStartText = "";
        public string LastMskEndText = "";        

        public MediaSegment()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);
        }


        private void MediaSegment_Load(object sender, EventArgs e)
        {            
            foreach (Control co in this.Controls)
            {
                co.Click += MediaSegment_Click;
            }            

            mskStart.txtBox.KeyPress += mskStart_KeyPress;
            mskEnd.txtBox.KeyPress += mskEnd_KeyPress;
            mskDuration.txtBox.KeyPress += mskDuration_KeyPress;

            mskStart.txtBox.Validating += mskStart_Validating;
            mskEnd.txtBox.Validating += mskEnd_Validating;
            mskDuration.txtBox.Validating += mskDuration_Validating;

            mskStart.txtBox.Validating += MediaSegment_Click;
            mskEnd.txtBox.Validating += MediaSegment_Click;
            mskDuration.Validating += MediaSegment_Click;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(0,0,this.Width-1,this.Height-1));
        }

        private void lblDuration_Click(object sender, EventArgs e)
        {

        }

        

        private void MediaSegment_Click(object sender, EventArgs e)
        {
            if (!DoNotSetActiveSegment)
            {
                frmClip.Instance.SetActiveSegment(this);
            }
            
        }
                
        /*
        private void mskStart_Validated(object sender, EventArgs e)
        {
            int hours = int.Parse(mskStart.Text.Substring(0, 2).Replace("_", ""));
            int minutes = int.Parse(mskStart.Text.Substring(3, 2).Replace("_", ""));
            int secs = int.Parse(mskStart.Text.Substring(6, 2).Replace("_", ""));
            int msecs = int.Parse(mskStart.Text.Substring(9, 1).Replace("_", ""));

            TimeSpan ts = new TimeSpan(hours, minutes, secs);

            msSegment.SetRangeStart((int)ts.TotalSeconds*10+msecs);

            frmClip.Instance.msPosition.SetRangeStart((int)ts.TotalSeconds*10+msecs);
            this.Invalidate();

            frmClip.Instance.msPositionValue = (int)ts.TotalSeconds * 10 + msecs;
            frmClip.Instance.SeekPosition();

            frmClip.Instance.msPosition.Invalidate();

            int dmsecs = EndMSecs - StartMSecs;
            int dsecs = dmsecs / 10;
            int ddmsecs=dmsecs%10;

            //TimeSpan ts1 = new TimeSpan(0, 0, EndMSecs - StartMSecs);
            TimeSpan ts1 = new TimeSpan(0, 0, dsecs);
            mskDuration.Text = ts1.Hours.ToString("D2") + ":" + ts1.Minutes.ToString("D2") + ":" + ts1.Seconds.ToString("D2") + "." + ddmsecs.ToString();
            
            frmClip.Instance.UpdateVideoThumbnail();

            
        
        }
        */

        public void mskEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                mskEnd.txtBox.ValidateText();
                mskEnd_Validating(mskEnd.txtBox, new CancelEventArgs());
            }
        }
                
        public void mskEnd_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int msecs = TimeUpDownControl.StringToMsecs(mskEnd.Text);

                if (msecs > frmClip.Instance.LengthTotalMSecs)
                {
                    Module.ShowMessage("The Value exceeds Video File Duration !");
                    e.Cancel = true;
                    mskEnd.Text = mskEnd.LastAcceptedValue;
                    frmClip.Instance.mskCutEnd.Text = mskEnd.LastAcceptedValue;

                    return;
                }

                //?
                int pos = TimeUpDownControl.StringToMsecs(mskEnd.Text);                
                
                if (pos <= StartMSecs)
                {
                    Module.ShowMessage("End Time should be greater than Start Time !");
                    e.Cancel = true;
                    mskEnd.Text = mskEnd.LastAcceptedValue;
                    frmClip.Instance.mskCutEnd.Text = mskEnd.LastAcceptedValue;
                    return;
                }
                //end                                

                //7msSegment.SetRangeEnd(TimeUpDownControl.StringToMsecs(mskEnd.Text));

                //7frmClip.Instance.msPosition.SetRangeEnd(TimeUpDownControl.StringToMsecs(mskEnd.Text));
                this.Invalidate();

                frmClip.Instance.msPositionValue = TimeUpDownControl.StringToMsecs(mskEnd.Text);
                frmClip.Instance.btnSetEnd_Click(null, null);

                //?frmClip.Instance.SeekPosition();

                //7frmClip.Instance.msPosition.Invalidate();

                SetDuration();
                
                frmClip.Instance.UpdateVideoEndThumbnail();

                mskEnd.LastAcceptedValue = mskEnd.Text;

            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not set Value !", ex);
                e.Cancel = true;
                mskEnd.Text = mskEnd.LastAcceptedValue;

                return;
            }
        }

        public void SetDuration()
        {
            int dmsecs = EndMSecs - StartMSecs;
            
            mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(dmsecs);
            mskDuration.LastAcceptedValue = mskDuration.Text;            
        }


        public void mskStart_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int msecs = TimeUpDownControl.StringToMsecs(mskStart.Text);

                if (msecs > frmClip.Instance.LengthTotalMSecs)
                {
                    Module.ShowMessage("The Value exceeds Video File Duration !");
                    e.Cancel = true;                    
                    mskStart.Text = mskStart.LastAcceptedValue;
                    frmClip.Instance.mskCutStart.Text = mskStart.LastAcceptedValue;
                    
                    return;
                }
                                
                int pos = TimeUpDownControl.StringToMsecs(mskStart.Text);

                if (pos >= EndMSecs)
                {
                    Module.ShowMessage("Start Time should be less than End Time !");
                    e.Cancel = true;
                    mskStart.Text = mskStart.LastAcceptedValue;
                    frmClip.Instance.mskCutStart.Text = mskStart.LastAcceptedValue;
                    return;
                }
                //end

                //?7msSegment.SetRangeStart(TimeUpDownControl.StringToMsecs(mskStart.Text));

                //?7frmClip.Instance.msPosition.SetRangeStart(TimeUpDownControl.StringToMsecs(mskStart.Text));
                //?this.Invalidate();

                frmClip.Instance.msPositionValue = TimeUpDownControl.StringToMsecs(mskStart.Text);

                frmClip.Instance.btnSetClipStart_Click(null, null);

                frmClip.Instance.SeekPosition();

                //7frmClip.Instance.msPosition.Invalidate();

                SetDuration();

                frmClip.Instance.UpdateVideoThumbnail();

                mskStart.LastAcceptedValue = mskStart.Text;
                                
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not set Value !", ex);
                e.Cancel = true;                
                mskStart.Text = mskStart.LastAcceptedValue;
                
                return;
            }                       
        }

        public void mskStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                mskStart.txtBox.ValidateText();
                mskStart_Validating(mskStart.txtBox, new CancelEventArgs());
            }           
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (btnPlay.Tag==null || btnPlay.Tag.ToString()=="Play")
            {
                frmClip.Instance.PlaySegment(StartMSecs, EndMSecs);
                btnPlay.Image = Properties.Resources.media_stop2;
                btnPlay.Tag = "Stop";
            }
            else
            {
                frmClip.Instance.btnStop_Click(null, null);
            }
        }

        public void mskDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                mskDuration.txtBox.ValidateText();
                mskDuration_Validating(mskDuration.txtBox, new CancelEventArgs());
            }
        }

        public void mskDuration_Validating(object sender, CancelEventArgs e)
        {
            try
            {                                
                int msecs = TimeUpDownControl.StringToMsecs(mskDuration.Text);

                int mst = TimeUpDownControl.StringToMsecs(mskStart.Text);

                int men = msecs + mst;

                if (men > frmClip.Instance.LengthTotalMSecs)
                {
                    men = frmClip.Instance.LengthTotalMSecs;
                    msecs = frmClip.Instance.LengthTotalMSecs - mst;

                    mskDuration.Text = TimeUpDownControl.MsecsToString(msecs);
                    frmClip.Instance.mskDuration.Text = TimeUpDownControl.MsecsToString(msecs);
                }

                //7msSegment.SetRangeEnd(men);

                //7frmClip.Instance.msPosition.SetRangeEnd(men);

                mskEnd.Text = TimeUpDownControl.MsecsToString(men);
                frmClip.Instance.mskCutEnd.Text = TimeUpDownControl.MsecsToString(men);

                mskEnd.LastAcceptedValue = mskEnd.Text;

                //?this.Invalidate();

                frmClip.Instance.msPositionValue = men;
                frmClip.Instance.SeekPosition();

                frmClip.Instance.btnSetEnd_Click(null, null);

                //7frmClip.Instance.msPosition.Invalidate();

                SetDuration();

                frmClip.Instance.UpdateVideoEndThumbnail();

                mskDuration.LastAcceptedValue = mskDuration.Text;

            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not set Value !", ex);
                e.Cancel = true;
                mskDuration.Text = mskDuration.LastAcceptedValue;

                return;
            }
            finally
            {
                
            }
        }
                
        public void picThumbnailStart_Click(object sender, EventArgs e)
        {
            if (frmClip.Instance.ActiveMediaSegment != this)
            {
                frmClip.Instance.SetActiveSegment(this);
            }

            //1frmClip.Instance.msPositionValue = frmClip.Instance.msPosition.RangeStart;
            frmClip.Instance.msPositionValue = this.StartMSecs;
            //7frmClip.Instance.msPosition.DrawSlider();
            frmClip.Instance.SeekPosition();
            
        }

        private void picThumbnailEnd_Click(object sender, EventArgs e)
        {
            if (frmClip.Instance.ActiveMediaSegment != this)
            {
                frmClip.Instance.SetActiveSegment(this);
            }

            //1frmClip.Instance.msPositionValue = frmClip.Instance.msPosition.RangeEnd;
            frmClip.Instance.msPositionValue = this.EndMSecs;
            //7frmClip.Instance.msPosition.DrawSlider();
            frmClip.Instance.SeekPosition();
            
        }

        public bool DoNotSetActiveSegment = false;
                
        private void picThumbnailEnd_MouseMove(object sender, MouseEventArgs e)
        {
            DoNotSetActiveSegment = true;
        }

        private void picThumbnailEnd_MouseLeave(object sender, EventArgs e)
        {
            DoNotSetActiveSegment = false;
        }

        public static int GetRelativeSize(int size1, int width1, int width2)
        {
            int size2 = (int)((decimal)(size1 * width2) / (decimal)width1);

            return size2;
        }
    }

    public class FourDotsFlowLayoutPanel : FlowLayoutPanel
    {
        public FourDotsFlowLayoutPanel()
            : base()
        {

        }

        const int WM_NCLBUTTONDOWN = 0x00A1;
        const int WM_NCLBUTTONUP = 0x00A2;
        const int WM_LBUTTONUP = 0x0202;
        const int WM_EXITSIZEMOVE = 0x0232;
        const int WM_NCMOUSELEAVE = 0x02A2;

        public int OldHorizontalScrollValue = -1;        
                          
        protected override void WndProc(ref Message m)
        {
            /*
            if (m.Msg == WM_NCLBUTTONDOWN)
            {                
                OldHorizontalScrollValue = this.HorizontalScroll.Value;
            }

            else if (m.Msg == WM_NCLBUTTONUP || m.Msg==WM_LBUTTONUP || m.Msg==WM_EXITSIZEMOVE || m.Msg==WM_NCMOUSELEAVE)
            {
                //Module.ShowMessage("a");

                try
                {
                    frmClip.Instance.lblScrollPos.Visible = false;
                }
                catch { }
            }
            */

            base.WndProc(ref m);
        }
    }

    /*
    public class VideoThumbnailObject
    {
        public string Filepath;
        public string TimeString;

        public VideoThumbnailObject(string _Filepath, string _TimeString)
        {
            Filepath = _Filepath;
            TimeString = _TimeString;
        }
    }*/
}
