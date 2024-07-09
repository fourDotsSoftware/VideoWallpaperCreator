using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace VideoWallpaperCreator
{
    public class FFMpegNormaizer
    {
        public static bool NormalizeAudio(string InputFile)
        {
            
            string args=" -i \"" + InputFile + "\" -af \"volumedetect\" -f null NUL ";

            string line;

            string maxvol = "";

            while ((line = frmMain.Instance.psFFMpeg.StandardError.ReadLine()) != null)
            {
                if (frmMain.Instance.bwConvert.CancellationPending)
                {
                    //psFFMpeg.Kill();
                    break;
                }
         
                Application.DoEvents();

                if (line.Contains(" max_volume: "))
                {
                    int spos = line.IndexOf(" max_volume: ") + " max_volume: ".Length;
                    int epos = line.IndexOf(" ", spos);

                    maxvol = line.Substring(spos, epos - spos);
                }

                //if (frmMain.Instance.psFFMpeg.HasExited) break;
            }

            if (maxvol != "0.0") // if it is not normalized
            {
                string prenormalizedFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(InputFile),
                    System.IO.Path.GetFileNameWithoutExtension(InputFile) + ".prenormalized" +
                    System.IO.Path.GetExtension(InputFile));
                try
                {
                    try
                    {
                        if (System.IO.File.Exists(prenormalizedFile))
                        {
                            System.IO.File.Delete(prenormalizedFile);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMain.Instance.errstr += TranslateHelper.Translate("Error could not Delete File") + " : " + prenormalizedFile;
                        return false;
                    }

                    try
                    {
                        System.IO.File.Move(InputFile, prenormalizedFile);
                    }
                    catch (Exception ex)
                    {
                        frmMain.Instance.errstr += TranslateHelper.Translate("Error could not Move File") + " : " + prenormalizedFile;
                        return false;
                    }

                    if (maxvol.StartsWith("-"))
                    {
                        maxvol = maxvol.Substring(1);
                    }

                    //frmMain.Instance.CreateFFMpegProcess();

                    //frmMain.Instance.psFFMpeg.StartInfo.Arguments =
                      //  " -y -i \"" + prenormalizedFile + "\" -af \"volume=" + maxvol + "dB\" \"" + InputFile + "\"";

                    //frmMain.Instance.psFFMpeg.Start();

                    //frmMain.Instance.SetThreadPriorityLevel(frmMain.Instance.psFFMpeg);

                    string args_normalize=" -y -i \"" + prenormalizedFile + "\" -af \"volume=" + maxvol + "dB\" \"" + InputFile + "\"";

                    SetProcessPriorityHelper.CreateAndRunProcess(args_normalize);

                    line = null;
                    string sout = "";

                    int beforeCompletedSecs = frmMain.Instance.CompletedSecs;

                    bool time_str_found = false;

                    string last_line = "";

                    while ((line = frmMain.Instance.psFFMpeg.StandardError.ReadLine()) != null)
                    {
                        if (frmMain.Instance.bwConvert.CancellationPending)
                        {
                            //psFFMpeg.Kill();
                            break;
                        }

                        sout += line;

                        if (line != null && line.Contains("time="))
                        {
                            time_str_found = true;

                            try
                            {
                                int spos = line.LastIndexOf("time=") + "time=".Length;
                                int epos = line.IndexOf(" ", spos);

                                string time = line.Substring(spos, epos - spos + 1);

                                //0sw.WriteLine("time=" + time);

                                TimeSpan ts = new TimeSpan(0,int.Parse(time.Substring(0, 2)), int.Parse(time.Substring(3, 2)),
                                    int.Parse(time.Substring(6, 2)),int.Parse(time.Substring(9,2))*10);

                                int completed_secs = (int)(ts.TotalMilliseconds / 10);

                                int total_media_secs = 0;

                                if ((bool)frmMain.Instance.dt.Rows[frmMain.Instance.SelectedDTRowIndex]["cHasCut"] == true)
                                {
                                    total_media_secs = (int)frmMain.Instance.dt.Rows[frmMain.Instance.SelectedDTRowIndex]["cCutlengthsecs"];
                                }
                                else
                                {
                                    total_media_secs = (int)frmMain.Instance.dt.Rows[frmMain.Instance.SelectedDTRowIndex]["clengthsecs"];
                                }

                                total_media_secs *= 2;

                                int media_secs = 0;

                                if ((bool)frmMain.Instance.dt.Rows[frmMain.Instance.SelectedDTRowIndex]["cHasCut"] == true)
                                {
                                    media_secs = (int)frmMain.Instance.dt.Rows[frmMain.Instance.SelectedDTRowIndex]["cCutlengthsecs"];
                                }
                                else
                                {
                                    media_secs = (int)frmMain.Instance.dt.Rows[frmMain.Instance.SelectedDTRowIndex]["clengthsecs"];
                                }

                                // we have already conveted the file so add media_secs to completed_secs for total progress

                                int progress = (int)((decimal)(media_secs + completed_secs) * 100 / (decimal)(total_media_secs));

                                //0sw.WriteLine("parsed time="+ts.ToString() + "." + msecs.ToString());

                                //0sw.WriteLine("before completed secs=" + CompletedSecs.ToString());

                                frmMain.Instance.CompletedSecs = beforeCompletedSecs + completed_secs;

                                //0sw.WriteLine("completed secs="+CompletedSecs.ToString());

                                //int totalsex = LastCutArgs.TotalDuration / 10;

                                //1int progress = (int)((decimal)CompletedSecs * 100 / (decimal)(LastCutArgs.TotalDuration));

                                frmMain.Instance.bwConvert.ReportProgress(progress, frmMain.Instance.CompletedSecs);

                            }
                            catch { }

                        }
                        else if (line != null && line.ToLower().StartsWith("error"))
                        {
                            if (!line.Contains("Invalid data found when processing input"))
                            {
                                //avoid this error that comes often but the file is ok
                                //Error while decoding stream #0:0: Invalid data found when processing input

                                frmMain.Instance.errstr += line + "\r\n";
                            }
                        }

                        Application.DoEvents();

                        //if (frmMain.Instance.psFFMpeg.HasExited) break;
                    }

                    //if no time= string was found this means that an error occured
                    if (!time_str_found)
                    {
                        frmMain.Instance.errstr += last_line + "\r\n";
                    }
                }
                finally
                {
                    try
                    {
                        if (System.IO.File.Exists(prenormalizedFile))
                        {
                            System.IO.File.Delete(prenormalizedFile);
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMain.Instance.errstr += TranslateHelper.Translate("Error could not Delete File") + " : " + prenormalizedFile;
                    }
                }
            }
            else
            {
                int total_media_secs=0;

                if ((bool)frmMain.Instance.dt.Rows[frmMain.Instance.SelectedDTRowIndex]["cHasCut"] == true)
                {
                    total_media_secs = (int)frmMain.Instance.dt.Rows[frmMain.Instance.SelectedDTRowIndex]["cCutlengthsecs"];
                }
                else
                {
                    total_media_secs = (int)frmMain.Instance.dt.Rows[frmMain.Instance.SelectedDTRowIndex]["clengthsecs"];
                }

                frmMain.Instance.CompletedSecs = frmMain.Instance.CompletedSecs + total_media_secs;

                frmMain.Instance.bwConvert.ReportProgress(100, frmMain.Instance.CompletedSecs);
            }

            return true;
        }
    }
}
