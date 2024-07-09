using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace VideoWallpaperCreator
{
    class FFMpegKeyFrameInfo
    {
        public int PreviousKeyFrameMsecs=-1;
        public int NextKeyFrameMsecs=-1;

        public FFMpegKeyFrameInfo(string filepath, int msecs,bool next)
        {
            try
            {
                frmClip.Instance.Cursor = Cursors.WaitCursor;

                if (next) msecs++;

                bool found = false;

                while (true)
                {

                    int offsetsecs = 5;
                    int offsetmsecs = offsetsecs * 1000;                    
                    
                    string time_position = "";

                    if (next)
                    {
                        time_position = FFMpegArgsHelper.GetStringFromTime(msecs);
                    }
                    else
                    {
                        time_position = FFMpegArgsHelper.GetStringFromTime(Math.Max(0, msecs - offsetmsecs));
                    }

                    if (!System.IO.Directory.Exists(VideoThumbnail.ThumbnailsPath))
                    {
                        System.IO.Directory.CreateDirectory(VideoThumbnail.ThumbnailsPath);
                    }

                    string iotempfile = System.IO.Path.Combine(VideoThumbnail.ThumbnailsPath, Guid.NewGuid().ToString() + System.IO.Path.GetExtension(filepath));

                    Process psImage = new Process();

                    psImage.StartInfo.FileName = "ffmpeg ";
                    psImage.StartInfo.CreateNoWindow = true;
                    psImage.StartInfo.UseShellExecute = false;
                    psImage.StartInfo.RedirectStandardInput = true;
                    psImage.StartInfo.RedirectStandardOutput = true;
                    psImage.StartInfo.RedirectStandardError = true;

                    psImage.StartInfo.Arguments = " -debug_ts -ss " + time_position + " -i \"" + filepath
                        + "\" -t " + offsetsecs.ToString() + " \"" + iotempfile + "\"";

                    /*
                    psImage.StartInfo.Arguments = " -debug_ts -ss " + time_position + " -i \"" + filepath
                        //+ "\" -vf select=\"eq(pict_type\\,I)\" -vframes 1 -f null NUL "; //2> \"" + iotempfile + "\"";
                        + "\" -vf select=\"eq(pict_type\\,I)\" -vframes 1 \"" + iotempfile + "\"";
                    */
                    psImage.Start();
                    //psImage.WaitForExit();

                    string txt = psImage.StandardError.ReadToEnd();

                    //System.IO.File.WriteAllText(@"c:\1\ftxt.txt", txt);

                    if (!psImage.HasExited)
                    {
                        psImage.Kill();
                    }

                    psImage.Dispose();

                    int spos = 0;

                    while (true)
                    {
                        spos = txt.IndexOf("keyframe:1", spos);

                        if (spos == -1)
                        {
                            break;
                        }

                        int bef = txt.LastIndexOf("best_effort_ts_time:", spos);

                        if (bef == -1)
                        {
                            break;
                        }

                        bef += "best_effort_ts_time:".Length;

                        int befe = txt.IndexOf(" ", bef);

                        string time = txt.Substring(bef, befe - bef);

                        if (time == "0")
                        {
                            spos++;
                        }
                        else if (time.StartsWith("-"))
                        {
                            /*
                            time = time.Substring(1);

                            int timemsecs = (-1) * FFMpegArgsHelper.GetMsecsFromSecsTime(time);

                            PreviousKeyFrameMsecs = msecs + timemsecs;
                            */

                            spos = spos + 1;

                            continue;
                        }
                        else
                        {
                            /*
                            spos = txt.IndexOf("keyframe:1", spos + 1);

                            if (spos == -1) return;

                            bef = txt.LastIndexOf("best_effort_ts_time:", spos);

                            if (bef == -1) return;

                            bef += "best_effort_ts_time:".Length;

                            befe = txt.IndexOf(" ", bef);
                            */

                            time = txt.Substring(bef, befe - bef);

                            int timemsecs2 = FFMpegArgsHelper.GetMsecsFromSecsTime(time);

                            NextKeyFrameMsecs = msecs + timemsecs2;

                            if (next)
                            {
                                found = true;

                                break;                                
                            }
                            else
                            {
                                if (timemsecs2 != offsetmsecs)
                                {
                                    PreviousKeyFrameMsecs = Math.Max(0, msecs + timemsecs2 - offsetmsecs);
                                }

                                spos++;

                                found = true;

                                continue;
                            }
                        }
                    }

                    if (found)
                    {
                        break;
                    }

                    if (next)
                    {
                        msecs += offsetmsecs;

                        if (msecs > frmClip.Instance.LengthTotalMSecs)
                        {
                            break;
                        }
                    }
                    else
                    {
                        msecs -= offsetmsecs;

                        if (msecs < 0)
                        {
                            break;
                        }
                    }

                    GC.Collect();

                    System.Threading.Thread.Sleep(100);
                }
            }
            catch { }
            finally
            {
                frmClip.Instance.Cursor = null;
            }
        }        
    }
}
