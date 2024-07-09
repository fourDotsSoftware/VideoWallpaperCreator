using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VideoWallpaperCreator
{
    public class PicStoryboardWave : System.Windows.Forms.PictureBox
    {
        /// <summary>
        /// Length of Video
        /// </summary>
        public TimeSpan _TimeSpan = new TimeSpan(0);
        public TimeSpan TimeSpan
        {
            get { return _TimeSpan; }

            set
            {
                _TimeSpan = value;

                LengthMsecs = _TimeSpan.TotalMilliseconds;
                dLengthMsecs = (decimal)LengthMsecs;
            }
        }

        /// <summary>
        /// Length in Msecs
        /// </summary>
        public double LengthMsecs = 0;
        public decimal  dLengthMsecs = 0;

        public Dictionary<int, Image> dicImages = new Dictionary<int, Image>();
        public Dictionary<int, Image> dicAudioImages = new Dictionary<int, Image>();
        public Dictionary<int, string> dicAudioImageFiles = new Dictionary<int, string>();
        public Dictionary<int, string> dicAudioFiles = new Dictionary<int, string>();
        
        public const int StoryboardImageWidth = 60;
        public const int StoryboardImageHeight = 45;
        public const int StoryboardTimeStringHeight = 15;
        public const int StoryboardAudioWaveHeight = 45;
        public const int StoryboardHandleHeight = 16;
        public const int StoryboardBarHeight = 15;

        public const int StoryboardAudioMsecsWidth = 120000;

        int StoryboardTimeStringY = 0;
        int StoryboardAudioWaveY = 0;
        int StoryboardBarY = 0;
        int StoryboardCurrentHeight = 0;

        int frameNumStart = 0;
        int frameNumEnd = 0;
        int frameMsecsStart = 0;
        int frameMsecsEnd = 0;

        int _lastPaintFrame = 0;
        int lastlastPaintFrame = 0;
        int lastPaintFrame
        {
            get { return _lastPaintFrame; }

            set
            {
                if (_lastPaintFrame != value)
                {
                    lastlastPaintFrame = _lastPaintFrame;
                    _lastPaintFrame = value;
                }
            }
        }

        int currentPaintFrame = -1;

        int lastStartFrame = -1;
        int lastEndFrame = -1;

        private int StartEndGripWidth = 4;

        public bool MovingStartHandle = false;
        public bool MovingEndHandle = false;
        private int MouseDownX = -1;

        public int StartPos
        {
            get
            {
                if (frmClip.Instance.ActiveMediaSegment != null)
                {
                    int stpos = CalculatePositionFromMsecs(frmClip.Instance.ActiveMediaSegment.StartMSecs);

                    return stpos;
                }

                return -1;
            }
        }

        public int EndPos
        {
            get
            {
                if (frmClip.Instance.ActiveMediaSegment != null)
                {
                    int enpos = CalculatePositionFromMsecs(frmClip.Instance.ActiveMediaSegment.EndMSecs);

                    return enpos;
                }

                return -1;
            }
        }

        public int StartMsecs
        {
            get
            {
                if (frmClip.Instance.ActiveMediaSegment != null)
                {
                    return frmClip.Instance.ActiveMediaSegment.StartMSecs;
                }

                return -1;
            }
        }

        public int EndMsecs
        {
            get
            {
                if (frmClip.Instance.ActiveMediaSegment != null)
                {
                    return frmClip.Instance.ActiveMediaSegment.EndMSecs;
                }

                return -1;
            }
        }

        private bool InPaintFrame = false;

        private Image Img = null;

        public int StoryboardSettingsHeight
        {
            get
            {
                int height = StoryboardTimeStringHeight;

                if (Properties.Settings.Default.ShowStoryboardImages)
                {
                    height += StoryboardImageHeight;
                }

                if (Properties.Settings.Default.ShowStoryboardAudioWave)
                {
                    height += StoryboardAudioWaveHeight;
                }

                height += StoryboardBarHeight;

                height += StoryboardHandleHeight;

                return height;
            }
        }

        public int StoryboardCursorHeight
        {
            get
            {
                return StoryboardSettingsHeight - StoryboardHandleHeight;
            }
        }

        //public const int StoryboardImageWidth = 90;
        //public const int StoryboardImageHeight = 49;

        private System.ComponentModel.BackgroundWorker bwPaintFrameImage = new System.ComponentModel.BackgroundWorker();
        private System.ComponentModel.BackgroundWorker bwPaintFrameAudioWaveform = new System.ComponentModel.BackgroundWorker();
        private System.ComponentModel.BackgroundWorker bwVideoThumbnailUpdate = new System.ComponentModel.BackgroundWorker();

        private bool InPaint = false;
        public bool CancelPaint = false;

        private bool UpdatingVideoThumbnail = false;
        
        public int StoryboardWidth = 0;

        public bool InMouseClick = false;

        public int CurrentStartMousePosition = -1;
        public int OldStartMousePosition = -1;
        public int OldPlayPosition = -1;

        private int OldSegmentStartPos = -1;
        private int OldSegmentEndPos = -1;

        private System.Drawing.Font FontTime = null;

        private int _StoryboardTimeFrameLengthMsecs = 5000;

        public decimal PixelsPerMsec = 0;

        public int StoryboardTimeFrameLengthMsecs
        {
            get { return _StoryboardTimeFrameLengthMsecs; }
            set
            {                
                if (frmClip.Instance == null) return;

                int lastval = frmClip.Instance.HScrollbar.Value;
                int lastmsecs;

                if (lastval < 0)
                {
                    lastval = 0;
                    lastmsecs = 0;
                }
                else
                {
                    lastmsecs = CalculateTimeMsecsFromMousePosition(lastval);
                }

                _StoryboardTimeFrameLengthMsecs = value;

                dicAudioImages.Clear();
                dicAudioImageFiles.Clear();

                decimal dfrlen = (decimal)value;
                decimal dimgw = (decimal)StoryboardImageWidth;
                
                PixelsPerMsec = dimgw / dfrlen;
                
                int cnt = ((int)LengthMsecs / value);
                int cntmod = ((int)LengthMsecs % value);

                decimal dlen = (decimal)LengthMsecs;
                decimal dval = (decimal)(value);

                decimal dcnt = dlen / dval;                

                if (cnt == 0)
                {
                    StoryboardFrameCount = 1;
                }

                else if (cntmod == 0)
                {
                    StoryboardFrameCount = cnt;
                }
                else
                {
                    StoryboardFrameCount = cnt + 1;
                }

                StoryboardFrameCount = (int)(dcnt+1);

                //5StoryboardFrameCount = cnt;

                //5StoryboardWidth = StoryboardImageWidth * StoryboardFrameCount;

                decimal diw = (decimal)StoryboardImageWidth;

                //7StoryboardWidth = (int)(dcnt * diw);

                StoryboardWidth = (int)(PixelsPerMsec * dLengthMsecs);

                if (StoryboardWidth <= frmClip.Instance.picMain.ClientSize.Width)
                {
                    frmClip.Instance.HScrollbar.Minimum = 0;
                    frmClip.Instance.HScrollbar.SmallChange = 0;
                    frmClip.Instance.HScrollbar.LargeChange = 0;
                    frmClip.Instance.HScrollbar.Maximum = 0;
                    frmClip.Instance.HScrollbar.Value = 0;                   
                }
                else
                {
                    int pos1 = CalculatePositionFromMsecs(1000);
                    int pos10 = CalculatePositionFromMsecs(10000);

                    frmClip.Instance.HScrollbar.Minimum = 0;
                    /*
                    frmClip.Instance.HScrollbar.SmallChange = frmClip.Instance.picMain.ClientSize.Width / 20;
                    frmClip.Instance.HScrollbar.LargeChange = frmClip.Instance.picMain.ClientSize.Width / 10;
                    */

                    frmClip.Instance.HScrollbar.SmallChange = frmClip.Instance.picMain.ClientSize.Width / 50;
                    frmClip.Instance.HScrollbar.LargeChange = frmClip.Instance.picMain.ClientSize.Width / 25;

                    //frmClip.Instance.HScrollbar.SmallChange = pos1;
                    //frmClip.Instance.HScrollbar.LargeChange = pos10;

                    frmClip.Instance.HScrollbar.Maximum = StoryboardWidth - frmClip.Instance.HScrollbar.ClientSize.Width;//frmClip.Instance.picMain.ClientSize.Width;
                    frmClip.Instance.HScrollbar.Maximum += frmClip.Instance.HScrollbar.LargeChange;

                    int newpos = CalculatePositionFromMsecs(lastmsecs) - frmClip.Instance.picMain.ClientSize.Width;                    

                    if (frmClip.Instance.HScrollbar.Value > 0)
                    {
                        try
                        {
                            frmClip.Instance.HScrollbar.Value = Math.Max(0, newpos);
                        }
                        catch { }
                    }
                }               
            }
        }

        public void SetupScrollbar()
        {
            if (StoryboardWidth <= frmClip.Instance.picMain.ClientSize.Width)
            {
                frmClip.Instance.HScrollbar.Minimum = 0;
                frmClip.Instance.HScrollbar.SmallChange = 0;
                frmClip.Instance.HScrollbar.LargeChange = 0;
                frmClip.Instance.HScrollbar.Maximum = 0;
                frmClip.Instance.HScrollbar.Value = 0;
            }
            else
            {                
                frmClip.Instance.HScrollbar.Minimum = 0;
                frmClip.Instance.HScrollbar.SmallChange = frmClip.Instance.picMain.ClientSize.Width / 20;
                frmClip.Instance.HScrollbar.LargeChange = frmClip.Instance.picMain.ClientSize.Width / 10;                

                frmClip.Instance.HScrollbar.Maximum = StoryboardWidth - frmClip.Instance.picMain.ClientSize.Width;
                frmClip.Instance.HScrollbar.Maximum += frmClip.Instance.HScrollbar.LargeChange;                
            }
        }

        private int StoryboardFrameCount = 0;

        public bool ShowingThumbnailInProcess = false;

        public PicStoryboardWave():base()
        {
            bwPaintFrameAudioWaveform.DoWork += bwPaintFrameAudioWaveform_DoWork;
            
            bwPaintFrameAudioWaveform.WorkerReportsProgress = true;

            bwPaintFrameAudioWaveform.ProgressChanged += bwPaintFrameAudioWaveform_ProgressChanged;

            bwPaintFrameAudioWaveform.RunWorkerCompleted += bwPaintFrameAudioWaveform_RunWorkerCompleted;

            bwPaintFrameAudioWaveform.WorkerSupportsCancellation = true;

            //---

            bwPaintFrameImage.WorkerReportsProgress = true;            

            bwPaintFrameImage.DoWork += bwPaintFrameImage_DoWork;

            bwPaintFrameImage.ProgressChanged += bwPaintFrameImage_ProgressChanged;

            bwPaintFrameImage.RunWorkerCompleted += bwPaintFrameImage_RunWorkerCompleted;

            bwPaintFrameImage.WorkerSupportsCancellation = true;

            //---

            bwVideoThumbnailUpdate.WorkerReportsProgress = true;

            bwVideoThumbnailUpdate.DoWork += bwVideoThumbnailUpdate_DoWork;

            bwVideoThumbnailUpdate.ProgressChanged += bwVideoThumbnailUpdate_ProgressChanged;

            bwVideoThumbnailUpdate.RunWorkerCompleted += bwVideoThumbnailUpdate_RunWorkerCompleted;

            //---

            //this.BackColor = Color.LightGray; 

            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            /*
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            */
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        void bwPaintFrameAudioWaveform_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            /*8
            InPaint = false;

            InPaintFrame = false;*/
        }

        void bwPaintFrameAudioWaveform_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                //using (Graphics g = this.CreateGraphics())
                //{
                //g.Clear(Color.LightGray);
                //}
            }
            else
            {
                StoryboardBwObject bwobj = (StoryboardBwObject)e.UserState;

                if (bwobj == null) return;
                if (bwobj.Image == null) return;

                currentPaintFrame = CalculateFrameNumberFromMsecs(bwobj.msecs);

                //5
                bwobj.posx = CalculatePositionFromMsecs(bwobj.msecs) - frmClip.Instance.HScrollbar.Value;

                int framemsecs = bwobj.msecs;

                int frameaudionum = framemsecs / StoryboardAudioMsecsWidth;

                int frameaudiomsecs = frameaudionum * StoryboardAudioMsecsWidth;

                int audioframewidth = CalculatePositionFromMsecs(StoryboardAudioMsecsWidth);

                int audiopos0 = CalculatePositionFromMsecs(framemsecs-frameaudiomsecs);

                string framemsecsstr = TimeSpanHelper.MsecsToFFMpegString(frameaudiomsecs);

                using (Graphics g = Graphics.FromImage(Img))
                {                                                           
                    g.FillRectangle(Brushes.LightGray, new Rectangle(bwobj.posx, StoryboardAudioWaveY, StoryboardImageWidth, StoryboardAudioWaveHeight));
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.DrawImage(bwobj.Image, new Rectangle(bwobj.posx, StoryboardAudioWaveY, StoryboardImageWidth, StoryboardAudioWaveHeight), new Rectangle(audiopos0, 0, StoryboardImageWidth, StoryboardAudioWaveHeight), GraphicsUnit.Pixel);

                    int curplaypos = CalculatePositionFromMsecs(frmClip.Instance.msPositionValue);

                    if (curplaypos - frmClip.Instance.HScrollbar.Value >= bwobj.posx && curplaypos <= (frmClip.Instance.HScrollbar.Value + bwobj.posx + StoryboardImageWidth))
                    {
                        g.DrawImage(Properties.Resources.small_arrow_down, curplaypos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                        g.FillRectangle(Brushes.Blue, curplaypos - frmClip.Instance.HScrollbar.Value - 1, StoryboardHandleHeight, 3, StoryboardCursorHeight);
                    }

                    if (frmClip.Instance.ActiveMediaSegment != null)
                    {
                        int stpos = CalculatePositionFromMsecs(frmClip.Instance.ActiveMediaSegment.StartMSecs);
                        int enpos = CalculatePositionFromMsecs(frmClip.Instance.ActiveMediaSegment.EndMSecs);

                        if (stpos - frmClip.Instance.HScrollbar.Value >= bwobj.posx && stpos <= (frmClip.Instance.HScrollbar.Value + bwobj.posx + StoryboardImageWidth))
                        {
                            g.DrawImage(Properties.Resources.small_arrow_down_green, stpos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                            g.FillRectangle(Brushes.LightGreen, stpos - frmClip.Instance.HScrollbar.Value - 1, StoryboardHandleHeight, 3, StoryboardCursorHeight);
                        }

                        if (enpos - frmClip.Instance.HScrollbar.Value >= bwobj.posx && enpos <= (frmClip.Instance.HScrollbar.Value + bwobj.posx + StoryboardImageWidth))
                        {
                            g.DrawImage(Properties.Resources.small_arrow_down_red, enpos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                            g.FillRectangle(Brushes.Red, enpos - frmClip.Instance.HScrollbar.Value - 1, StoryboardHandleHeight, 3, StoryboardCursorHeight);
                        }

                        if (!(frmClip.Instance.ActiveMediaSegment.StartMSecs == 0 && frmClip.Instance.ActiveMediaSegment.EndMSecs == frmClip.Instance.LengthTotalMSecs))
                        {
                            if (stpos - frmClip.Instance.HScrollbar.Value <= bwobj.posx + StoryboardImageWidth && bwobj.posx <= enpos - frmClip.Instance.HScrollbar.Value)
                            {
                                Color opcolor = Color.FromArgb(150, Color.LightGray);
                                using (SolidBrush opBrush = new SolidBrush(opcolor))
                                {
                                    int opstart = Math.Max(bwobj.posx, stpos - frmClip.Instance.HScrollbar.Value);
                                    int opwidth = Math.Min(bwobj.posx + StoryboardImageWidth - opstart, enpos - frmClip.Instance.HScrollbar.Value - opstart);

                                    g.FillRectangle(opBrush, new Rectangle(opstart, StoryboardAudioWaveY, opwidth, StoryboardAudioWaveHeight));
                                }
                            }
                        }
                    }

                    if (bwobj.posx + StoryboardImageWidth > StoryboardWidth)
                    {
                        g.FillRectangle(Brushes.LightGray, new Rectangle(StoryboardWidth, 0, this.Width - StoryboardWidth, this.Height));
                    }
                }

                

                this.Invalidate(new Rectangle(bwobj.posx, StoryboardAudioWaveY, StoryboardImageWidth, StoryboardAudioWaveHeight));
                //this.Invalidate();
            }            
        }

        void bwPaintFrameAudioWaveform_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                /*7
                if (!frmClip.Instance.Playing && !InMouseClick)
                {
                    bwPaintFrameImage.ReportProgress(-1);
                }
                */

                PaintImageArgs imgargs = (PaintImageArgs)e.Argument;

                if (imgargs.iterate)
                {
                    for (int k = imgargs.frameStart; k <= imgargs.frameEnd; k++)
                    {
                        PaintAudioImage(k);
                    }
                }
                else
                {
                    PaintAudioImage(imgargs.frameStart);

                    if (imgargs.frameStart != imgargs.frameEnd)
                    {
                        PaintAudioImage(imgargs.frameEnd);
                    }
                }

                /*
                if (frmClip.Instance.Playing)
                {
                    PaintImageFrame(frameNumStart);
                    PaintImageFrame(frameNumEnd);
                }
                else
                {
                    for (int k = frameNumStart; k <= frameNumEnd; k++)
                    {
                        if (bwPaint.CancellationPending)
                        {
                            return;
                        }

                        PaintImageFrame(k);
                    }
                }*/
            }
            finally
            {
                //8InPaint = false;
            }
        }

        void bwPaintFrameImage_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            InPaint = false;

            InPaintFrame = false;
        }

        void bwVideoThumbnailUpdate_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                frmClip.Instance.vthPreview.picThumbnail.BackColor = SystemColors.Control;
            }
            else
            {
                Image img = (Image)e.Result;

                frmClip.Instance.vthPreview.picThumbnail.Image = img;
            }
        }

        void bwVideoThumbnailUpdate_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                frmClip.Instance.vthPreview.picThumbnail.BackColor = SystemColors.Control;
            }
        }

        void bwVideoThumbnailUpdate_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                UpdatingVideoThumbnail = true;

                VideoThumbnailObject vtho = (VideoThumbnailObject)e.Argument;

                VideoThumbnailControl.CurrentImageTimeString = vtho.TimeString;

                //Module.WaitNMSeconds(300);

                bwVideoThumbnailUpdate.ReportProgress(-1);

                VideoThumbnail vt = new VideoThumbnail(vtho.Filepath, vtho.TimeString, 156, 100);

                if (vt.ThumbnailImage != null)
                {
                    e.Result = vt.ThumbnailImage;
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

        void bwPaintFrameImage_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                //using (Graphics g = this.CreateGraphics())
                //{
                //g.Clear(Color.LightGray);
                //}
            }
            else
            {
                StoryboardBwObject bwobj = (StoryboardBwObject)e.UserState;

                if (bwobj == null) return;
                if (bwobj.Image == null) return;

                currentPaintFrame = CalculateFrameNumberFromMsecs(bwobj.msecs);

                //5
                bwobj.posx = CalculatePositionFromMsecs(bwobj.msecs) - frmClip.Instance.HScrollbar.Value;

                using (Graphics g = Graphics.FromImage(Img))
                {
                    //Rectangle rangerectfull = new Rectangle(bwobj.posx, StoryboardBarY, StoryboardImageWidth, StoryboardBarHeight);
                    Rectangle rangerectfull = new Rectangle(0, StoryboardBarY, Math.Min(StoryboardWidth, this.Width), StoryboardBarHeight);

                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(rangerectfull, Color.LightYellow, Color.FromArgb(192, 192, 0), LinearGradientMode.Vertical))
                    {
                        fillBrush.GammaCorrection = true;

                        g.FillRectangle(fillBrush, rangerectfull);
                    }                    

                    if (frmClip.Instance.ActiveMediaSegment != null)
                    {
                        int stpos = CalculatePositionFromMsecs(frmClip.Instance.ActiveMediaSegment.StartMSecs);
                        int enpos = CalculatePositionFromMsecs(frmClip.Instance.ActiveMediaSegment.EndMSecs);

                        Rectangle rangerect = new Rectangle(stpos - frmClip.Instance.HScrollbar.Value, StoryboardBarY, enpos - stpos, StoryboardBarHeight);

                        using (LinearGradientBrush fillBrush = new LinearGradientBrush(rangerect, Color.LightGreen, Color.DarkGreen, LinearGradientMode.Vertical))
                        {
                            fillBrush.GammaCorrection = true;

                            g.FillRectangle(fillBrush, rangerect);
                        }
                    }

                    g.FillRectangle(Brushes.LightGray, new Rectangle(bwobj.posx, 0, StoryboardImageWidth, StoryboardHandleHeight));
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.DrawImage(bwobj.Image, new Point(bwobj.posx, StoryboardHandleHeight));

                    int curplaypos = CalculatePositionFromMsecs(frmClip.Instance.msPositionValue);

                    if (curplaypos - frmClip.Instance.HScrollbar.Value >= bwobj.posx && curplaypos <= (frmClip.Instance.HScrollbar.Value + bwobj.posx + StoryboardImageWidth))
                    {
                        g.DrawImage(Properties.Resources.small_arrow_down, curplaypos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                        g.FillRectangle(Brushes.Blue, curplaypos - frmClip.Instance.HScrollbar.Value - 1, StoryboardHandleHeight, 3, StoryboardCursorHeight);
                    }

                    if (frmClip.Instance.ActiveMediaSegment != null)
                    {
                        int stpos = CalculatePositionFromMsecs(frmClip.Instance.ActiveMediaSegment.StartMSecs);
                        int enpos = CalculatePositionFromMsecs(frmClip.Instance.ActiveMediaSegment.EndMSecs);

                        if (stpos - frmClip.Instance.HScrollbar.Value >= bwobj.posx && stpos <= (frmClip.Instance.HScrollbar.Value + bwobj.posx + StoryboardImageWidth))
                        {
                            g.DrawImage(Properties.Resources.small_arrow_down_green, stpos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                            g.FillRectangle(Brushes.LightGreen, stpos - frmClip.Instance.HScrollbar.Value - 1, StoryboardHandleHeight, 3, StoryboardCursorHeight);
                        }

                        if (enpos - frmClip.Instance.HScrollbar.Value >= bwobj.posx && enpos <= (frmClip.Instance.HScrollbar.Value + bwobj.posx + StoryboardImageWidth))
                        {
                            g.DrawImage(Properties.Resources.small_arrow_down_red, enpos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                            g.FillRectangle(Brushes.Red, enpos - frmClip.Instance.HScrollbar.Value - 1, StoryboardHandleHeight, 3, StoryboardCursorHeight);
                        }

                        if (!(frmClip.Instance.ActiveMediaSegment.StartMSecs == 0 && frmClip.Instance.ActiveMediaSegment.EndMSecs == frmClip.Instance.LengthTotalMSecs))
                        {
                            if (stpos - frmClip.Instance.HScrollbar.Value <= bwobj.posx + StoryboardImageWidth && bwobj.posx <= enpos - frmClip.Instance.HScrollbar.Value)
                            {
                                Color opcolor = Color.FromArgb(150, Color.LightGray);
                                using (SolidBrush opBrush = new SolidBrush(opcolor))
                                {
                                    int opstart = Math.Max(bwobj.posx, stpos - frmClip.Instance.HScrollbar.Value);
                                    int opwidth = Math.Min(bwobj.posx + StoryboardImageWidth - opstart, enpos - frmClip.Instance.HScrollbar.Value - opstart);

                                    g.FillRectangle(opBrush, new Rectangle(opstart, StoryboardHandleHeight, opwidth, StoryboardImageHeight));
                                }
                            }
                        }
                    }

                    OldPlayPosition = curplaypos;

                    if (bwobj.posx + StoryboardImageWidth > StoryboardWidth)
                    {
                        g.FillRectangle(Brushes.LightGray, new Rectangle(StoryboardWidth, 0, this.Width - StoryboardWidth, this.Height));
                    }
                }

            }

            this.Invalidate();
        }

        private int firstposx = -1;
        private int firstfplw = -1;

        void bwPaintFrameImage_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {                
                /*7
                if (!frmClip.Instance.Playing && !InMouseClick)
                {
                    bwPaintFrameImage.ReportProgress(-1);
                }
                */

                PaintImageArgs imgargs = (PaintImageArgs)e.Argument;

                if (imgargs.iterate)
                {
                    for (int k = imgargs.frameStart; k <= imgargs.frameEnd; k++)
                    {
                        PaintImageFrame(k);
                    }
                }
                else
                {
                    PaintImageFrame(imgargs.frameStart);

                    if (imgargs.frameStart != imgargs.frameEnd)
                    {
                        PaintImageFrame(imgargs.frameEnd);
                    }
                }

                /*
                if (frmClip.Instance.Playing)
                {
                    PaintImageFrame(frameNumStart);
                    PaintImageFrame(frameNumEnd);
                }
                else
                {
                    for (int k = frameNumStart; k <= frameNumEnd; k++)
                    {
                        if (bwPaint.CancellationPending)
                        {
                            return;
                        }

                        PaintImageFrame(k);
                    }
                }*/
            }
            finally
            {
                InPaint = false;                
            }
        }

        private void PaintImageFrame(int k)
        {
            int framemsecs = k * StoryboardTimeFrameLengthMsecs;

            //7bwPaintFrameImage.ReportProgress(curmsecs);

            string framemsecsstr = TimeSpanHelper.MsecsToFFMpegString(framemsecs);
            //?string curmsecsstr = FFMpegArgsHelper.GetStringFromTime(curmsecs);

            int framex = CalculatePositionFromMsecs(framemsecs) - frmClip.Instance.HScrollbar.Value;

            Image img = null;

            if (dicImages.ContainsKey(framemsecs))
            {
                img = dicImages[framemsecs];
            }
            else
            {
                try
                {
                    VideoThumbnail vt = new VideoThumbnail(frmClip.Instance.filepath, framemsecsstr, StoryboardImageWidth, StoryboardImageHeight);

                    if (vt.ThumbnailImage != null)
                    {
                        img = vt.ThumbnailImage;

                        dicImages.Add(framemsecs, img);
                    }
                }
                catch { }
            }

            StoryboardBwObject bwobj = new StoryboardBwObject(framemsecs, img, framemsecsstr, framex);

            bwPaintFrameImage.ReportProgress(1, bwobj);
        }

        private void PaintAudioImage(int k)
        {
            int framemsecs = k * StoryboardTimeFrameLengthMsecs;

            int frameaudionum = framemsecs / StoryboardAudioMsecsWidth;

            int frameaudiomsecs = frameaudionum * StoryboardAudioMsecsWidth;

            int audioframewidth=CalculatePositionFromMsecs(StoryboardAudioMsecsWidth);

            //7bwPaintFrameImage.ReportProgress(curmsecs);

            //7string framemsecsstr = TimeSpanHelper.MsecsToFFMpegString(framemsecs);

            string framemsecsstr = TimeSpanHelper.MsecsToFFMpegString(frameaudiomsecs);

            //?string curmsecsstr = FFMpegArgsHelper.GetStringFromTime(curmsecs);

            int framex = CalculatePositionFromMsecs(framemsecs) - frmClip.Instance.HScrollbar.Value;

            Image img = null;

            if (dicAudioImages.ContainsKey(frameaudionum))
            {
                img = dicAudioImages[frameaudionum];
            }
            else
            {
                try
                {
                    AudioWaveformImage vt = new AudioWaveformImage(frmClip.Instance.filepath, frameaudionum,framemsecsstr, audioframewidth, StoryboardAudioWaveHeight);

                    if (vt.ThumbnailImage != null)
                    {
                        img = vt.ThumbnailImage;

                        dicAudioImages.Add(frameaudionum, img);
                        dicAudioImageFiles.Add(frameaudionum, vt.ImageFilepath);
                    }
                }
                catch { }
            }

            StoryboardBwObject bwobj = new StoryboardBwObject(framemsecs, img, framemsecsstr, framex);

            bwPaintFrameAudioWaveform.ReportProgress(1, bwobj);
        }

        public string CalculateTimeStringFromMousePosition(int x)
        {
            try
            {
                // totalwidth mediasize
                // x            ;
                double totalwidth = (double)StoryboardWidth;
                double xd = (double)x;

                double curmsecs = (xd * LengthMsecs) / totalwidth;

                TimeSpan ts = new TimeSpan(0, 0, 0, 0, (int)curmsecs);

                return TimeSpanHelper.TimeSpanToFFMpegString(ts);

                //?return FFMpegArgsHelper.GetStringFromTime((int)curmsecs);
            }
            catch
            {
                return "00:00:00.000";
            }
        }

        public int CalculateTimeMsecsFromMousePosition(int x)
        {
            try
            {
                decimal dx = (decimal)x;
                return (int)(dx / PixelsPerMsec);
                
                // totalwidth mediasize
                // x            ;
                double totalwidth = (double)StoryboardWidth;
                double xd = (double)x;

                double curmsecs = (xd * LengthMsecs) / totalwidth;

                return (int)curmsecs;
            }
            catch
            {
                return 0;
            }
        }

        public int CalculatePositionFromMsecs(int msecs)
        {
            try
            {
                decimal dmsecs = (decimal)msecs;

                return (int)(dmsecs * PixelsPerMsec);

                // totalwidth mediasize
                // ;            msecs
                double totalwidth = (double)StoryboardWidth;
                double msecsd = (double)msecs;

                double posx = (msecsd * totalwidth) / LengthMsecs;

                return (int)posx;
            }
            catch
            {
                return 0;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (frmClip.Instance == null) return;
            if (frmClip.Instance.IsDisposed) return;
            if (frmClip.Instance.WindowState == FormWindowState.Minimized) return;

            this.Image = null;

            if (Img != null)
            {
                Img.Dispose();
            }

            Img = new Bitmap(this.Width, this.Height);


            this.Image = Img;

            PaintImg();
        }

        public void PaintImg()
        {
            if (frmClip.Instance.WindowState == FormWindowState.Minimized) return;

            FontTime = new Font(frmClip.Instance.Font.FontFamily, 7);            

            try
            {
                if (frmClip.Instance == null) return;

                InPaint = true;                

                int vthwidth = frmClip.Instance.vthPreview.Width;
                int fplw = frmClip.Instance.picMain.ClientSize.Width;
                //1int posx = frmClip.Instance.AutoScrollOffset.X;

                //3Point ps = frmClip.Instance.PointToScreen(new Point(frmClip.Instance.picMain.Left + 5, frmClip.Instance.picMain.Top + 5));

                //3int posx = this.PointToClient(ps).X;

                int posx = frmClip.Instance.HScrollbar.Value;

                firstposx = posx;
                firstfplw = fplw;                                

                /*
                if (!frmClip.Instance.Playing)
                {
                    pe.Graphics.Clear(Color.LightGray);
                }
                */
              
                /*
                int msecsStart = CalculateTimeMsecsFromMousePosition(posx);
                int msecsEnd = CalculateTimeMsecsFromMousePosition(posx + fplw);

                int frameNumStart = Math.Max(0, msecsStart / StoryboardTimeFrameLengthMsecs - 1);
                int frameNumEnd = Math.Min(StoryboardFrameCount - 1, msecsEnd / StoryboardTimeFrameLengthMsecs + 1);
                */

                frameNumStart = CalculateFrameNumberFromPixels(posx);
                frameNumEnd = CalculateFrameNumberFromPixels(posx+fplw);

                frameMsecsStart = frameNumStart * StoryboardTimeFrameLengthMsecs;
                frameMsecsEnd = frameNumEnd * StoryboardTimeFrameLengthMsecs;                

                StoryboardCurrentHeight = StoryboardTimeStringHeight;

                if (Properties.Settings.Default.ShowStoryboardImages)
                {
                    StoryboardTimeStringY = StoryboardImageHeight + StoryboardHandleHeight;
                    StoryboardCurrentHeight += StoryboardImageHeight;

                    if (Properties.Settings.Default.ShowStoryboardAudioWave)
                    {
                        StoryboardAudioWaveY = StoryboardTimeStringY + StoryboardTimeStringHeight;
                        //StoryboardCurrentHeight += StoryboardAudioWaveHeight;
                        StoryboardBarY = StoryboardAudioWaveY + StoryboardAudioWaveHeight;
                    }
                    else
                    {
                        StoryboardBarY = StoryboardTimeStringHeight + StoryboardImageHeight + StoryboardHandleHeight;
                    }
                }
                else
                {
                    StoryboardTimeStringY = StoryboardHandleHeight;

                    if (Properties.Settings.Default.ShowStoryboardAudioWave)
                    {
                        StoryboardAudioWaveY = StoryboardTimeStringY + StoryboardTimeStringHeight;
                        //StoryboardCurrentHeight += StoryboardAudioWaveHeight;

                        StoryboardBarY = StoryboardAudioWaveY + StoryboardAudioWaveHeight;
                    }
                    else
                    {
                        StoryboardBarY = StoryboardTimeStringHeight + StoryboardHandleHeight;
                    }
                }

                /*
                if (frmClip.Instance.Playing)
                {
                    int curFrame = CalculateFrameNumberFromMsecs(frmClip.Instance.msPositionValue);
                    int prevFrame = CalculateFrameNumberFromMsecs(frmClip.Instance.msPositionValue - 500);
                    
                    prevFrame = Math.Max(0,curFrame - 1);

                    frameNumStart = curFrame;
                    frameNumEnd = prevFrame;

                    lastPaintFrame = curFrame;
   
                    PaintFrame(pe, curFrame);

                    if (curFrame != prevFrame)
                    {
                        PaintFrame(pe, prevFrame);
                    }

                    if (Properties.Settings.Default.ShowStoryboardImages)
                    {
                        bwPaint.RunWorkerAsync(new PaintImageArgs(false, frameNumStart, frameNumEnd));
                    }
                }
                else
                {*/                

                using (Graphics g = Graphics.FromImage(Img))
                {
                    g.Clear(Color.LightGray);

                    Rectangle rangerectfull = new Rectangle(0, StoryboardBarY, this.Width, StoryboardBarHeight);

                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(rangerectfull, Color.LightYellow, Color.FromArgb(192, 192, 0), LinearGradientMode.Vertical))
                    {
                        fillBrush.GammaCorrection = true;

                        g.FillRectangle(fillBrush, rangerectfull);
                    }                    

                    for (int k = frameNumStart; k <= frameNumEnd; k++)
                    {                        
                        PaintFrame(g, k);
                    }
                }                

                this.Invalidate();

                if (Properties.Settings.Default.ShowStoryboardImages)
                {
                    while (bwPaintFrameImage.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    bwPaintFrameImage.RunWorkerAsync(new PaintImageArgs(true, frameNumStart, frameNumEnd));

                    while (bwPaintFrameImage.IsBusy)
                    {
                        Application.DoEvents();
                    }
                }

                if (Properties.Settings.Default.ShowStoryboardAudioWave)
                {
                    while (bwPaintFrameAudioWaveform.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    bwPaintFrameAudioWaveform.RunWorkerAsync(new PaintImageArgs(true, frameNumStart, frameNumEnd));

                    while (bwPaintFrameAudioWaveform.IsBusy)
                    {
                        Application.DoEvents();
                    }
                }

                //}                                                
            }
            catch
            {

            }
            finally
            {
                if (!Properties.Settings.Default.ShowStoryboardImages)
                {
                    InPaint = false;
                }

                if (!bwPaintFrameImage.IsBusy)
                {
                    InPaint = false;
                }
            }
            /*
            if (InPaint) return;

            try
            {
                InPaint = true;

                base.OnPaint(pe);

                if (frmClip.Instance == null) return;

                int vthwidth = frmClip.Instance.vthPreview.Width;
                int fplw = frmClip.Instance.fplMain.Width;
                //1int posx = frmClip.Instance.AutoScrollOffset.X;

                Point ps = frmClip.Instance.PointToScreen(new Point(frmClip.Instance.fplMain.Left + 5, frmClip.Instance.fplMain.Top + 5));

                int posx = this.PointToClient(ps).X;
                pe.Graphics.Clear(Color.LightGray);
                //pe.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(posx, 0, posx + fplw, this.Height));
                pe.Graphics.Flush();

                int msecsStart = CalculateTimeMsecsFromMousePosition(posx);
                int msecsEnd = CalculateTimeMsecsFromMousePosition(posx + fplw);

                int frameNumStart = Math.Max(0, msecsStart / StoryboardTimeFrameLengthMsecs - 1);
                int frameNumEnd = Math.Min(StoryboardFrameCount - 1, msecsEnd / StoryboardTimeFrameLengthMsecs + 1);

                int frameMsecsStart = frameNumStart * StoryboardTimeFrameLengthMsecs;
                int frameMsecsEnd = frameNumEnd * StoryboardTimeFrameLengthMsecs;

                //string timestringStart = CalculateTimeStringFromMousePosition(posx);
                //string timestringEnd = CalculateTimeStringFromMousePosition(posx+fplw);

                for (int k = frameNumStart; k <= frameNumEnd; k++)
                {
                    int curmsecs = k * StoryboardTimeFrameLengthMsecs;

                    string curmsecsstr = TimeSpanHelper.MsecsToFFMpegString(curmsecs);

                    int framex = CalculatePositionFromMsecs(curmsecs);

                    if (dicImages.ContainsKey(curmsecs))
                    {
                        pe.Graphics.DrawImage(dicImages[curmsecs], new Point(framex, 0));
                        pe.Graphics.DrawString(curmsecsstr, FontTime, Brushes.Black, new PointF((float)framex + 3, (float)StoryboardImageHeight + 2));
                        pe.Graphics.Flush();
                    }
                    else
                    {
                        try
                        {
                            VideoThumbnail vt = new VideoThumbnail(frmClip.Instance.filepath, curmsecsstr, StoryboardImageWidth, StoryboardImageHeight);

                            if (vt.ThumbnailImage != null)
                            {
                                Image img = vt.ThumbnailImage;
                                dicImages.Add(curmsecs, img);

                                pe.Graphics.DrawImage(img, new Point(framex, 0));
                                pe.Graphics.DrawString(curmsecsstr, FontTime, Brushes.Black, new PointF((float)framex + 3, (float)StoryboardImageHeight + 2));
                                pe.Graphics.Flush();

                            }
                        }
                        catch { }
                    }
                }
            }
            finally
            {
                InPaint = false;
            }
            */
        }

        public void PaintHandles()
        {
            if (frmClip.Instance.ActiveMediaSegment != null)
            {
                int stmsecs = frmClip.Instance.ActiveMediaSegment.StartMSecs;
                int enmsecs = frmClip.Instance.ActiveMediaSegment.EndMSecs;

                PaintHandles(stmsecs, enmsecs);
            }
        }

        public void PaintHandles(int startmsecs, int endmsecs)
        {
            using (Graphics g = Graphics.FromImage(Img))
            {
                g.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, this.Width, StoryboardHandleHeight));

                int curplaypos = CalculatePositionFromMsecs(frmClip.Instance.msPositionValue);

                if (curplaypos - frmClip.Instance.HScrollbar.Value >= 0 && curplaypos <= (frmClip.Instance.HScrollbar.Value + this.Width))
                {
                    g.DrawImage(Properties.Resources.small_arrow_down, curplaypos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                }

                int stpos = CalculatePositionFromMsecs(startmsecs);
                int enpos = CalculatePositionFromMsecs(endmsecs);

                if (stpos - frmClip.Instance.HScrollbar.Value >= 0 && stpos <= (frmClip.Instance.HScrollbar.Value + this.Width))
                {
                    g.DrawImage(Properties.Resources.small_arrow_down_green, stpos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                }

                if (enpos - frmClip.Instance.HScrollbar.Value >= 0 && enpos <= (frmClip.Instance.HScrollbar.Value + this.Width))
                {
                    g.DrawImage(Properties.Resources.small_arrow_down_red, enpos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                }                
            }

            this.Invalidate();
        }

        public void PaintStoryboardBar()
        {
            if (frmClip.Instance.ActiveMediaSegment != null)
            {
                int stmsecs = frmClip.Instance.ActiveMediaSegment.StartMSecs;
                int enmsecs = frmClip.Instance.ActiveMediaSegment.EndMSecs;

                PaintStoryboardBar(stmsecs, enmsecs);
            }
        }

        public void PaintStoryboardBar(int startmsecs,int endmsecs)
        {
            using (Graphics g = Graphics.FromImage(Img))
            {
                Rectangle rangerectfull = new Rectangle(0, StoryboardBarY, Math.Min(StoryboardWidth, this.Width), StoryboardBarHeight);

                using (LinearGradientBrush fillBrush = new LinearGradientBrush(rangerectfull, Color.LightYellow, Color.FromArgb(192, 192, 0), LinearGradientMode.Vertical))
                {
                    fillBrush.GammaCorrection = true;

                    g.FillRectangle(fillBrush, rangerectfull);
                }

                int stpos = CalculatePositionFromMsecs(startmsecs);
                int enpos = CalculatePositionFromMsecs(endmsecs);

                Rectangle rangerect = new Rectangle(stpos - frmClip.Instance.HScrollbar.Value, StoryboardBarY, enpos - stpos, StoryboardBarHeight);

                using (LinearGradientBrush fillBrush = new LinearGradientBrush(rangerect, Color.LightGreen, Color.DarkGreen, LinearGradientMode.Vertical))
                {
                    fillBrush.GammaCorrection = true;

                    g.FillRectangle(fillBrush, rangerect);
                }

                int curplaypos = CalculatePositionFromMsecs(frmClip.Instance.msPositionValue);

                if (curplaypos - frmClip.Instance.HScrollbar.Value >= 0 && curplaypos <= (frmClip.Instance.HScrollbar.Value + this.Width))
                {
                    g.DrawImage(Properties.Resources.small_arrow_down, curplaypos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                    g.FillRectangle(Brushes.Blue, curplaypos - frmClip.Instance.HScrollbar.Value - 1, StoryboardBarY, 3, StoryboardBarHeight);
                }

                if (stpos - frmClip.Instance.HScrollbar.Value >= 0 && stpos <= (frmClip.Instance.HScrollbar.Value + this.Width))
                {
                    g.DrawImage(Properties.Resources.small_arrow_down_green, stpos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                    g.FillRectangle(Brushes.LightGreen, stpos - frmClip.Instance.HScrollbar.Value - 1, StoryboardBarY, 3, StoryboardBarHeight);
                }

                if (enpos - frmClip.Instance.HScrollbar.Value >= 0 && enpos <= (frmClip.Instance.HScrollbar.Value + this.Width))
                {
                    g.DrawImage(Properties.Resources.small_arrow_down_red, enpos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                    g.FillRectangle(Brushes.Red, enpos - frmClip.Instance.HScrollbar.Value - 1, StoryboardBarY, 3, StoryboardBarHeight);
                }               
            }

            this.Invalidate();
        }

        public void PaintFrame(Graphics g, int k)
        {
            //if (InPaintFrame) return;

            try
            {
                InPaintFrame = true;

                int framemsecs = k * StoryboardTimeFrameLengthMsecs;

                string framemsecsstr = TimeSpanHelper.MsecsToFFMpegString(framemsecs);

                int framex = CalculatePositionFromMsecs(framemsecs) - frmClip.Instance.HScrollbar.Value;

                int curplaypos = CalculatePositionFromMsecs(frmClip.Instance.msPositionValue);

                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                //if (!frmClip.Instance.Playing)

                g.FillRectangle(Brushes.LightGray, new Rectangle(framex, 0, StoryboardImageWidth, StoryboardHandleHeight));

                if (Properties.Settings.Default.ShowStoryboardImages)
                {
                    if (!frmClip.Instance.Playing)
                    {
                        g.FillRectangle(Brushes.DimGray, new Rectangle(framex, StoryboardHandleHeight, StoryboardImageWidth, StoryboardImageHeight));
                    }
                }

                g.FillRectangle(Brushes.LightGray, new Rectangle(framex, StoryboardTimeStringY, StoryboardImageWidth, StoryboardTimeStringHeight));
                g.DrawString(framemsecsstr, FontTime, Brushes.Black, new PointF((float)framex + 3, (float)StoryboardTimeStringY + 2));
                g.DrawLine(Pens.DimGray, framex + StoryboardImageWidth, StoryboardHandleHeight, framex + StoryboardImageWidth, StoryboardCurrentHeight);

                //Rectangle rangerectfull = new Rectangle(framex, StoryboardBarY, StoryboardImageWidth, StoryboardBarHeight);
                Rectangle rangerectfull = new Rectangle(0, StoryboardBarY, Math.Min(StoryboardWidth,this.Width), StoryboardBarHeight);

                using (LinearGradientBrush fillBrush = new LinearGradientBrush(rangerectfull, Color.LightYellow, Color.FromArgb(192, 192, 0), LinearGradientMode.Vertical))
                {
                    fillBrush.GammaCorrection = true;

                    g.FillRectangle(fillBrush, rangerectfull);
                }

                if (frmClip.Instance.ActiveMediaSegment != null)
                {
                    int stpos = CalculatePositionFromMsecs(frmClip.Instance.ActiveMediaSegment.StartMSecs);
                    int enpos = CalculatePositionFromMsecs(frmClip.Instance.ActiveMediaSegment.EndMSecs);

                    if (stpos - frmClip.Instance.HScrollbar.Value >= framex && stpos <= (frmClip.Instance.HScrollbar.Value + framex + StoryboardImageWidth))
                    {
                        g.DrawImage(Properties.Resources.small_arrow_down_green, stpos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                        g.FillRectangle(Brushes.LightGreen, stpos - frmClip.Instance.HScrollbar.Value - 1, StoryboardHandleHeight, 3, StoryboardCursorHeight);
                    }

                    if (enpos - frmClip.Instance.HScrollbar.Value >= framex && enpos <= (frmClip.Instance.HScrollbar.Value + framex + StoryboardImageWidth))
                    {
                        g.DrawImage(Properties.Resources.small_arrow_down_red, enpos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                        g.FillRectangle(Brushes.Red, enpos - frmClip.Instance.HScrollbar.Value - 1, StoryboardHandleHeight, 3, StoryboardCursorHeight);
                    }

                    Blend blnd = new Blend();
                    blnd.Positions = new float[] { 0f, .5f, 1f };
                    blnd.Factors = new float[] { .2f, .8f, .2f };

                    Rectangle rangerect = new Rectangle(stpos - frmClip.Instance.HScrollbar.Value, StoryboardBarY, enpos - stpos, StoryboardBarHeight);

                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(rangerect, Color.LightGreen, Color.DarkGreen, LinearGradientMode.Vertical))
                    {
                        fillBrush.GammaCorrection = true;

                        g.FillRectangle(fillBrush, rangerect);
                    }

                    if (Properties.Settings.Default.ShowStoryboardImages)
                    {
                        if (stpos - frmClip.Instance.HScrollbar.Value <= framex + StoryboardImageWidth && framex <= enpos - frmClip.Instance.HScrollbar.Value)
                        {
                            Color opcolor = Color.FromArgb(150, Color.LightGray);
                            using (SolidBrush opBrush = new SolidBrush(opcolor))
                            {
                                int opstart = Math.Max(framex, stpos - frmClip.Instance.HScrollbar.Value);
                                int opwidth = Math.Min(framex + StoryboardImageWidth - opstart, enpos - frmClip.Instance.HScrollbar.Value - opstart);

                                g.FillRectangle(opBrush, new Rectangle(opstart, StoryboardHandleHeight, opwidth, StoryboardImageHeight));
                            }
                        }
                    }
                }

                /*
                if (!frmClip.Instance.Playing)
                {
                    if ((CurrentStartMousePosition - frmClip.Instance.HScrollbar.Value) >= framex && (CurrentStartMousePosition <= (frmClip.Instance.HScrollbar.Value + framex + StoryboardImageWidth)))
                    {
                        g.DrawImage(Properties.Resources.small_arrow_down, CurrentStartMousePosition - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                        g.FillRectangle(Brushes.Blue, CurrentStartMousePosition - frmClip.Instance.HScrollbar.Value - 1, StoryboardHandleHeight, 3, StoryboardCursorHeight);
                    }
                }
                */

                //if (frmClip.Instance.Playing)
                //{
                    if (curplaypos - frmClip.Instance.HScrollbar.Value >= framex && curplaypos <= (frmClip.Instance.HScrollbar.Value + framex + StoryboardImageWidth))
                    {
                        g.DrawImage(Properties.Resources.small_arrow_down, curplaypos - frmClip.Instance.HScrollbar.Value - StoryboardHandleHeight / 2, 0, 16, 16);
                        g.FillRectangle(Brushes.Blue, curplaypos - frmClip.Instance.HScrollbar.Value - 1, StoryboardHandleHeight, 3, StoryboardCursorHeight);

                        OldPlayPosition = curplaypos;
                    }
                //}

                if (framex + StoryboardImageWidth > StoryboardWidth)
                {
                    g.FillRectangle(Brushes.LightGray, new Rectangle(StoryboardWidth, 0, this.Width - StoryboardWidth, this.Height));
                }

            }
            finally
            {
                if (!Properties.Settings.Default.ShowStoryboardImages)
                {
                    InPaintFrame = false;
                }

            }
        }
        private int CalculateFrameNumberFromPixels(int posx)
        {
            decimal dposx = (decimal)posx;
            decimal dstartmsecs = dposx / PixelsPerMsec;
            decimal dframelenmsecs = (decimal)StoryboardTimeFrameLengthMsecs;

            int framenum = (int)(dstartmsecs / dframelenmsecs);

            return framenum;
        }

        private int CalculateFrameNumberFromMsecs(int msecs)
        {
            decimal dmsecs = (decimal)msecs;
            decimal dframelen = (decimal)StoryboardTimeFrameLengthMsecs;
            
            int framenum = (int)(dmsecs / dframelen);

            return framenum;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (true) //if (e.Button == System.Windows.Forms.MouseButtons.None)
            {
                int StartPixels = StartPos - frmClip.Instance.HScrollbar.Value;
                int EndPixels = EndPos - frmClip.Instance.HScrollbar.Value;

                if ((e.X <= EndPixels && e.X >= EndPixels - StartEndGripWidth) && EndPixels != -1)
                {
                    this.Cursor = Cursors.SizeWE;
                }
                else if ((e.X >= StartPixels && e.X <= StartPixels + StartEndGripWidth) && StartPixels != -1)
                {
                    this.Cursor = Cursors.SizeWE;
                }
                else
                {
                    //this.Cursor = null;

                    if (e.Button == System.Windows.Forms.MouseButtons.None)
                    {
                        this.Cursor = Cursors.Hand;
                    }
                }

                if (ShowingThumbnailInProcess)
                {
                    //return;
                }                
                else if (e.X<=StoryboardWidth)
                {
                    int vthwidth = frmClip.Instance.vthPreview.Width;
                    int fplw = frmClip.Instance.picMain.Width;
                    int posx = e.X + frmClip.Instance.HScrollbar.Value;

                    int ex0 = frmClip.Instance.PointToClient(new System.Drawing.Point(this.PointToScreen(new System.Drawing.Point(e.X, 0)).X, 0)).X;
                    int ex1 = fplw;

                    if (ex0 >= vthwidth / 2)
                    {
                        if (ex0 + (vthwidth / 2) > ex1)
                        {
                            frmClip.Instance.vthPreview.Left = fplw - vthwidth;
                        }
                        else
                        {
                            frmClip.Instance.vthPreview.Left = ex0 - vthwidth / 2;
                        }
                    }
                    else
                    {
                        frmClip.Instance.vthPreview.Left = 0;
                    }
                    frmClip.Instance.vthPreview.Top = frmClip.Instance.picMain.Top - frmClip.Instance.vthPreview.Height;

                    frmClip.Instance.vthPreview.Visible = true;
                    frmClip.Instance.vthPreview.BringToFront();

                    string timestring = CalculateTimeStringFromMousePosition(posx);

                    if (timestring != VideoThumbnailControl.CurrentImageTimeString)
                    {
                        frmClip.Instance.vthPreview.TimeString = timestring;                        
                        frmClip.Instance.vthPreview.UpdatePosLabel();

                        if (UpdatingVideoThumbnail)
                        {
                            return;
                        }                        

                        if (timestring != VideoThumbnailControl.CurrentImageTimeString)
                        {
                            VideoThumbnailObject vtho = new VideoThumbnailObject(frmClip.Instance.filepath, timestring);

                            while (bwVideoThumbnailUpdate.IsBusy)
                            {
                                Application.DoEvents();
                            }

                            bwVideoThumbnailUpdate.RunWorkerAsync(vtho);
                        }                        
                    }
                }

            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (MovingStartHandle)
                {
                    int stpix = e.X + frmClip.Instance.HScrollbar.Value;
                    int msecs = CalculateTimeMsecsFromMousePosition(stpix);

                    int dur = Math.Max(0, EndMsecs - msecs);

                    frmClip.Instance.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(dur);

                    UpdateTotalDurationWhileMovingHandles(dur);

                    PaintStoryboardBar(msecs, EndMsecs);
                    PaintHandles(msecs, EndMsecs);
                }
                else if (MovingEndHandle)
                {
                    int stpix = e.X + frmClip.Instance.HScrollbar.Value;
                    int msecs = CalculateTimeMsecsFromMousePosition(stpix);

                    int dur = Math.Max(0, msecs - StartMsecs);

                    frmClip.Instance.mskDuration.Text = FFMpegArgsHelper.GetStringFromTime(dur);

                    UpdateTotalDurationWhileMovingHandles(dur);

                    PaintStoryboardBar(StartMsecs, msecs);
                    PaintHandles(StartMsecs, msecs);
                }
            }
        }

        private void UpdateTotalDurationWhileMovingHandles(int newdur)
        {
            int secs = 0;

            foreach (MediaSegment ms in frmClip.Instance.fplSegments.Controls)
            {
                if (ms != frmClip.Instance.ActiveMediaSegment)
                {
                    secs += ms.EndMSecs - ms.StartMSecs;
                }
            }

            secs += newdur;

            string newTotalDuration = FFMpegArgsHelper.GetStringFromTime(secs);
            
            frmClip.Instance.mskTotalDuration.Text = newTotalDuration;
            frmClip.Instance.mskTotalDuration.LastAcceptedValue = newTotalDuration;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //base.OnMouseDown(e);

            MouseDownX = e.X;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int StartPixels = StartPos - frmClip.Instance.HScrollbar.Value;
                int EndPixels = EndPos - frmClip.Instance.HScrollbar.Value;

                if ((e.X <= EndPixels && e.X >= EndPixels - StartEndGripWidth) && EndPixels != -1)
                {
                    MovingEndHandle = true;
                }
                else if ((e.X >= StartPixels && e.X <= StartPixels + StartEndGripWidth) && StartPixels != -1)
                {
                    MovingStartHandle = true;
                }
                else
                {
                    MovingStartHandle = false;
                    MovingEndHandle = false;
                }
            }
            
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            int stpix = e.X + frmClip.Instance.HScrollbar.Value;
            int msecs = CalculateTimeMsecsFromMousePosition(stpix);

            if (MovingStartHandle)
            {
                frmClip.Instance.msPositionValue = msecs;
                frmClip.Instance.btnSetClipStart_Click(null, null);
            }
            else if (MovingEndHandle)
            {
                frmClip.Instance.msPositionValue = msecs;
                frmClip.Instance.btnSetEnd_Click(null, null);
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MovingStartHandle = false;
                MovingEndHandle = false;                
            }


        }

        public void PaintStartFrame()
        {
            if (frmClip.Instance.ActiveMediaSegment != null)
            {
                int startmsecs = frmClip.Instance.ActiveMediaSegment.StartMSecs;
                int endmsecs = frmClip.Instance.ActiveMediaSegment.EndMSecs;

                int framestart = CalculateFrameNumberFromMsecs(startmsecs);
                int frameend = CalculateFrameNumberFromMsecs(endmsecs);

                using (Graphics g = Graphics.FromImage(Img))
                {
                    if (lastStartFrame != -1)
                    {
                        PaintFrame(g, lastStartFrame);
                    }
                    else
                    {
                        lastStartFrame = framestart;
                    }

                    PaintFrame(g, framestart);
                }

                this.Invalidate();

                if (Properties.Settings.Default.ShowStoryboardImages)
                {
                    while (bwPaintFrameImage.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    bwPaintFrameImage.RunWorkerAsync(new PaintImageArgs(false, lastStartFrame, framestart));

                    while (bwPaintFrameImage.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    this.Invalidate();
                }

                if (Properties.Settings.Default.ShowStoryboardAudioWave)
                {
                    while (bwPaintFrameAudioWaveform.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    bwPaintFrameAudioWaveform.RunWorkerAsync(new PaintImageArgs(false, lastStartFrame, framestart));

                    while (bwPaintFrameAudioWaveform.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    this.Invalidate();
                }

                lastStartFrame = framestart;
            }
        }

        public void PaintEndFrame()
        {
            if (frmClip.Instance.ActiveMediaSegment != null)
            {
                int startmsecs = frmClip.Instance.ActiveMediaSegment.StartMSecs;
                int endmsecs = frmClip.Instance.ActiveMediaSegment.EndMSecs;

                int framestart = CalculateFrameNumberFromMsecs(startmsecs);
                int frameend = CalculateFrameNumberFromMsecs(endmsecs);

                using (Graphics g = Graphics.FromImage(Img))
                {
                    if (lastEndFrame != -1)
                    {
                        PaintFrame(g, lastEndFrame);
                    }
                    else
                    {
                        lastEndFrame = frameend;
                    }

                    PaintFrame(g, frameend);
                }

                this.Invalidate();

                if (Properties.Settings.Default.ShowStoryboardImages)
                {
                    while (bwPaintFrameImage.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    bwPaintFrameImage.RunWorkerAsync(new PaintImageArgs(false, lastEndFrame, frameend));

                    while (bwPaintFrameImage.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    this.Invalidate();
                }

                if (Properties.Settings.Default.ShowStoryboardAudioWave)
                {
                    while (bwPaintFrameAudioWaveform.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    bwPaintFrameAudioWaveform.RunWorkerAsync(new PaintImageArgs(false, lastEndFrame, frameend));

                    while (bwPaintFrameAudioWaveform.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    this.Invalidate();
                }

                lastEndFrame = frameend;
            }
        }

        public void PaintWhilePlaying()
        {
            if (InMouseClick) return;

            if (InPaint) return;
            
            PaintCurrentFrame();            
        }

        public void PaintCurrentFrame()
        {
            //lastPaintFrame = CalculateFrameNumberFromMsecs(frmClip.Instance.lastmsPositionValue);
            int curframe = CalculateFrameNumberFromMsecs(frmClip.Instance.msPositionValue);
            int lastpframe = lastPaintFrame;

            if (lastPaintFrame == curframe)
            {
                lastpframe = lastlastPaintFrame;
            }
            
            using (Graphics g = Graphics.FromImage(Img))
            {
                PaintFrame(g, lastpframe);

                PaintFrame(g, curframe);
            }

            this.Invalidate();
            

            if (Properties.Settings.Default.ShowStoryboardImages)
            {
                while (bwPaintFrameImage.IsBusy)
                {
                    Application.DoEvents();
                }

                bwPaintFrameImage.RunWorkerAsync(new PaintImageArgs(false, lastpframe, curframe));

                while (bwPaintFrameImage.IsBusy)
                {
                    Application.DoEvents();
                }

                this.Invalidate();
            }

            if (Properties.Settings.Default.ShowStoryboardAudioWave)
            {
                while (bwPaintFrameAudioWaveform.IsBusy)
                {
                    Application.DoEvents();
                }

                bwPaintFrameAudioWaveform.RunWorkerAsync(new PaintImageArgs(false, lastpframe, curframe));

                while (bwPaintFrameAudioWaveform.IsBusy)
                {
                    Application.DoEvents();
                }

                this.Invalidate();
            }

            lastPaintFrame = curframe;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            try
            {
                InMouseClick = true;                

                if (frmClip.Instance == null) return;                

                int curpos = frmClip.Instance.HScrollbar.Value + e.X;

                int msecs = frmClip.Instance.picMain.CalculateTimeMsecsFromMousePosition(curpos);                

                frmClip.Instance.msPositionValue = msecs;

                if (frmClip.Instance.Playing)
                {
                    frmClip.Instance.SeekPositionMplayer();
                }
                else
                {
                    frmClip.Instance.SeekPosition();
                }

                PaintCurrentFrame();                
            }
            finally
            {               
                InMouseClick = false;
                
            }
        }                
    }

    public class StoryboardBwObject
    {
        public int msecs = 0;
        public Image Image = null;
        public string timestring = "";
        public int posx = 0;

        public StoryboardBwObject(int _msecs, Image _Image, string _timestring,int _posx)
        {
            msecs = _msecs;
            Image = _Image;
            timestring = _timestring;
            posx = _posx;
        }
    }    
    
    public class PaintImageArgs
    {
        public bool iterate=false;
        public int frameStart=0;
        public int frameEnd;

        public PaintImageArgs(bool _iterate, int _frameStart, int _frameEnd)
        {
            iterate = _iterate;
            frameStart = _frameStart;
            frameEnd = _frameEnd;
        }
    }
    
    public class VideoThumbnailObject
    {
        public string Filepath;
        public string TimeString;
        
        public VideoThumbnailObject(string _Filepath, string _TimeString)
        {
            Filepath = _Filepath;
            TimeString = _TimeString;            
        }
    }
}
