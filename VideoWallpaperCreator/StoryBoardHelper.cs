using System;
using System.Collections.Generic;
using System.Text;

namespace VideoWallpaperCreator
{
    class StoryBoardHelper
    {
        public static StoryBoardControlCollection StoryBoardCol = new StoryBoardControlCollection();
        public static int StoryBoardIntervalMsecs = 10 * 1000;

        public static int LastLeftTime = -1;
        public static int LastRightTime = -1;
        public static int LastControlCount = 0;       
       
        public static void ZoomIn(System.ComponentModel.DoWorkEventArgs e)
        {
            if (!Properties.Settings.Default.ShowStoryboard) return;

            try
            {
                //1frmClip.Instance.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                if (frmClip.Instance.bwZoom.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                frmClip.Instance.SetFormCursor(System.Windows.Forms.Cursors.WaitCursor);

                int interval = StoryBoardIntervalMsecs;

                //int nums = hval / width;
                int nums = (frmClip.Instance.LengthTotalMSecs * 100) / StoryBoardIntervalMsecs;

                if (nums > 500)
                {
                    Module.ShowMessage("Movie too large to zoom in. Try zooming in into a specific frame.");
                    //9frmClip.Instance.btnZoomOut_Click(null, null);
                    frmClip.Instance.ZoomOut();

                    return;
                }

                //1StoryboardThumbnail thumb = frmClip.Instance.fplStoryboard.GetChildAtPoint(new System.Drawing.Point(10, 10)) as StoryboardThumbnail;
                StoryboardThumbnail thumb = frmClip.Instance.GetThumbChildAtPoint(new System.Drawing.Point(10, 10));

                if (thumb == null)
                {
                    thumb = new StoryboardThumbnail();
                    thumb.Time = 0;
                    thumb.TimeString = FFMpegArgsHelper.GetStringFromTime(0);
                    thumb.Margin = new System.Windows.Forms.Padding(0);

                }

                int hval = frmClip.Instance.fplStoryboard.HorizontalScroll.Value;
                //int starttime = thumb.Time;
                //int initialtime = starttime;

                int starttime = 0;
                int initialtime = thumb.Time;

                StoryboardThumbnail st = new StoryboardThumbnail();
                int width = st.Width;               

                // store the thumbnail that is currently at the left pos of the panel - where the time starts
                StoryboardThumbnail leftposthumb = null;

                //3 frmClip.Instance.fplStoryboard.SuspendLayout();
                //1frmClip.Instance.fplStoryboard.Controls.Clear();
                frmClip.Instance.ClearThumbControls();

                int totalmsecs=(frmClip.Instance.LengthTotalMSecs * 100);

                for (int k = 0; k <= nums && starttime <= totalmsecs; k++)
                {
                    if (frmClip.Instance.bwZoom.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    StoryboardThumbnail stth = StoryBoardCol[starttime];

                    if (stth == null)
                    {
                        StoryboardThumbnail storyth = new StoryboardThumbnail();
                        storyth.Time = starttime;
                        storyth.TimeString = FFMpegArgsHelper.GetStringFromTime(starttime / 100);
                        storyth.ControlIndex = k;
                        storyth.Margin = new System.Windows.Forms.Padding(0);
                        
                        StoryBoardCol.Add(storyth, starttime, false);

                        frmClip.Instance.AddThumbControl(storyth);

                        //1frmClip.Instance.fplStoryboard.Controls.Add(storyth);

                        if (starttime <= initialtime)
                        {
                            leftposthumb = storyth;
                        }
                    }
                    else
                    {
                        //1frmClip.Instance.fplStoryboard.Controls.Add(stth);
                        frmClip.Instance.AddThumbControl(stth);

                        stth.ControlIndex = k;

                        if (starttime <= initialtime)
                        {
                            leftposthumb = stth;
                        }
                    }

                    starttime += StoryBoardIntervalMsecs;
                }

                if (frmClip.Instance.bwZoom.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                if (leftposthumb.Left >= 0)
                {
                    //1frmClip.Instance.fplStoryboard.HorizontalScroll.Value = leftposthumb.Left;
                    frmClip.Instance.SetHScrollValue(leftposthumb.Left);
                }
                else
                {
                    //1frmClip.Instance.fplStoryboard.HorizontalScroll.Value = 0;
                    frmClip.Instance.SetHScrollValue(0);
                }

                if (frmClip.Instance.bwImgUpdate != null)
                {
                    frmClip.Instance.bwImgUpdate.CancelAsync();

                    frmClip.Instance.bwImgUpdate.Dispose();
                    frmClip.Instance.bwImgUpdate = null;
                }

                frmClip.Instance.bwImgUpdate = new System.ComponentModel.BackgroundWorker();
                frmClip.Instance.bwImgUpdate.DoWork += frmClip.Instance.bwStoryboardImageUpdater_DoWork;
                frmClip.Instance.bwImgUpdate.WorkerSupportsCancellation = true;
                                
                //9frmClip.Instance.SuspendThumbLayout();
                //5frmClip.Instance.fplStoryboard.SuspendLayout();
                //8frmClip.Instance.bwStoryboardImageUpdater.RunWorkerAsync();
                frmClip.Instance.bwImgUpdate.RunWorkerAsync();
                /*
                if (frmClip.Instance.bwStoryboardImageUpdater.IsBusy)
                {
                    frmClip.Instance.bwStoryboardImageUpdater.CancelAsync();
                }

                
                while (frmClip.Instance.bwStoryboardImageUpdater.IsBusy)
                {
                    System.Windows.Forms.Application.DoEvents();
                }                               

                frmClip.Instance.bwStoryboardImageUpdater.RunWorkerAsync();
                */
            }
            finally
            {
                //1frmClip.Instance.fplStoryboard.Cursor = null;
                frmClip.Instance.SetFormCursor(null);

                
                //1frmClip.Instance.fplStoryboard.PerformLayout();
                //3frmClip.Instance.PerformThumbLayout();
            }
            /*
            int ind = frmClip.Instance.fplStoryboard.Controls.IndexOf(leftposthumb);
            
            for (int k = ind-15; k < ind+15; k++)
            {
                if (k < 0)
                {
                    continue;
                }

                if (k>=frmClip.Instance.fplStoryboard.Controls.Count)
                {
                    break;
                }

                StoryboardThumbnail storyt = (StoryboardThumbnail)frmClip.Instance.fplStoryboard.Controls[k];
                storyt.UpdateImage();

            }*/

        }

        public static void ZoomIntoFrame(StoryboardThumbnail thumb)
        {
            try
            {
                frmClip.Instance.fplStoryboard.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                int hval = thumb.Left;

                int starttime = thumb.Time;
                int initialtime = starttime;

                StoryboardThumbnail st = new StoryboardThumbnail();
                int width = st.Width;
                
                //1int childindex=frmClip.Instance.fplStoryboard.Controls.IndexOf(thumb);
                int childindex = thumb.ControlIndex;

                // store the thumbnail that is currently at the left pos of the panel - where the time starts
                StoryboardThumbnail leftposthumb = null;

                //4frmClip.Instance.fplStoryboard.SuspendLayout();

                int nums = thumb.DifWithNextFrame / thumb.ZoomIntervalMsecs;                               

                leftposthumb = StoryBoardCol[starttime];

                starttime += thumb.ZoomIntervalMsecs;
                
                for (int k = 1; k <=nums; k++)
                {
                    StoryboardThumbnail stth = StoryBoardCol[starttime];

                    if (stth == null)
                    {
                        StoryboardThumbnail storyth = new StoryboardThumbnail();
                        storyth.Time = starttime;
                        storyth.TimeString = FFMpegArgsHelper.GetStringFromTime(starttime / 100);
                        storyth.ControlIndex = childindex + k ;
                        storyth.Margin = new System.Windows.Forms.Padding(0);

                        StoryBoardCol.Add(storyth, starttime, false);
                        frmClip.Instance.fplStoryboard.Controls.Add(storyth);
                        frmClip.Instance.fplStoryboard.Controls.SetChildIndex(storyth, childindex + k);

                        if (starttime <= initialtime)
                        {
                            leftposthumb = storyth;
                        }
                    }
                    else
                    {
                        frmClip.Instance.fplStoryboard.Controls.Add(stth);
                        frmClip.Instance.fplStoryboard.Controls.SetChildIndex(stth, childindex + k);
                        
                        stth.ControlIndex = childindex + k;

                        if (starttime <= initialtime)
                        {
                            leftposthumb = stth;
                        }
                    }

                    starttime += thumb.ZoomIntervalMsecs;

                    if (starttime / 100 > frmClip.Instance.LengthTotalMSecs)
                    {
                        break;
                    }
                }

                int controlcount=frmClip.Instance.fplStoryboard.Controls.Count;

                for (int k = childindex + nums+1; k < controlcount; k++)
                {
                    StoryboardThumbnail sto = (StoryboardThumbnail)frmClip.Instance.fplStoryboard.Controls[k];
                    sto.ControlIndex = k;
                }

                if (leftposthumb.Left >= 0)
                {
                    if (leftposthumb.Left > frmClip.Instance.fplStoryboard.HorizontalScroll.Maximum)
                    {
                        frmClip.Instance.fplStoryboard.HorizontalScroll.Value=frmClip.Instance.fplStoryboard.HorizontalScroll.Maximum;
                    }
                    else
                    {
                    frmClip.Instance.fplStoryboard.HorizontalScroll.Value = leftposthumb.Left;
                    }
                }
                else
                {
                    frmClip.Instance.fplStoryboard.HorizontalScroll.Value = 0;
                }

                /*
                frmClip.Instance.fplStoryboard.ResumeLayout();
                frmClip.Instance.fplStoryboard.PerformLayout();
                */

                frmClip.Instance.PerformThumbLayout();

                if (frmClip.Instance.bwImgUpdate != null)
                {
                    frmClip.Instance.bwImgUpdate.CancelAsync();

                    frmClip.Instance.bwImgUpdate.Dispose();
                    frmClip.Instance.bwImgUpdate = null;
                }

                frmClip.Instance.bwImgUpdate = new System.ComponentModel.BackgroundWorker();
                frmClip.Instance.bwImgUpdate.DoWork += frmClip.Instance.bwStoryboardImageUpdater_DoWork;
                frmClip.Instance.bwImgUpdate.WorkerSupportsCancellation = true;

                //9frmClip.Instance.SuspendThumbLayout();
                //5frmClip.Instance.fplStoryboard.SuspendLayout();
                
                frmClip.Instance.bwImgUpdate.RunWorkerAsync();

            }
            finally
            {
                frmClip.Instance.fplStoryboard.Cursor = null;
            }
            /*
            int ind = frmClip.Instance.fplStoryboard.Controls.IndexOf(leftposthumb);
            
            for (int k = ind-15; k < ind+15; k++)
            {
                if (k < 0)
                {
                    continue;
                }

                if (k>=frmClip.Instance.fplStoryboard.Controls.Count)
                {
                    break;
                }

                StoryboardThumbnail storyt = (StoryboardThumbnail)frmClip.Instance.fplStoryboard.Controls[k];
                storyt.UpdateImage();

            }*/

        }
    }

    public class StoryBoardControlCollection
    {
        public List<StoryboardThumbnail> Thumbnails = new List<StoryboardThumbnail>();
        public List<int> Time = new List<int>();
        public List<bool> HasImage = new List<bool>();

        public void Add(StoryboardThumbnail thumb,int time,bool hasimage)
        {
            Thumbnails.Add(thumb);
            Time.Add(time);
            HasImage.Add(hasimage);
        }


        public StoryboardThumbnail this[int time]
        {
            get
            {
                int spos = Time.IndexOf(time);

                if (spos < 0)
                {
                    return null;
                }
                else
                {
                    return Thumbnails[spos];
                }
            }
        }
    }
}
