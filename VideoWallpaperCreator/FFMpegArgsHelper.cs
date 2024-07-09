using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace VideoWallpaperCreator
{
    class FFMpegArgsHelper
    {
        public static string GetArgsForRow(DataRow dr, string input_file, string output_file)
        {
            string args = "";
            /*
            if (dr["cselect"].ToString() == bool.TrueString)
            {

                args = " -y ";

                if (input_file != String.Empty)
                {
                    args += " -i \"" + input_file + "\" ";
                }

                bool fixed_profile = false;


                int epos = frmMain.Instance.cmbFormat.Text.IndexOf(" - ");

                string ext = frmMain.Instance.cmbFormat.Text.Substring(0, epos);

                if (ext == "MP3")
                {
                    args += " -acodec libmp3lame ";
                }
                else if (ext == "FLAC")
                {
                    args += " -acodec flac ";
                }
                else if (ext == "WAV")
                {
                    args += "";
                }
                else if (ext == "OGG")
                {
                    args += " -acodec libvorbis ";
                }
                else if (ext == "AC3")
                {
                    args += " -acodec ac3 ";
                }
                else if (ext == "AAC")
                {
                    args += " -strict experimental -c:a aac -cutoff 15000 ";
                }
                else if (ext == "M4A")
                {
                    args += " -strict experimental -c:a aac -cutoff 15000 ";
                }
                else if (ext == "MP2")
                {
                    args += " -acodec mp2 ";
                }
                else if (ext == "OPUS")
                {
                    args += " -acodec libopus ";
                }
                else if (ext == "WMA")
                {
                    args += " -acodec wmav2 ";
                }
                else if (ext == "AMR")
                {
                    args += " -ar 8000 -ac 1 -ab 12.2k ";
                    fixed_profile = true;

                }
                else if (ext == "AIFF")
                {
                    args += " -f aiff ";
                }

                if (!fixed_profile)
                {
                    if (Module.SelectedFormatSetting.AudioChannels == "Stereo - 2 Audio Channels")
                    {
                        args += " -ac 2";
                    }
                    else
                    {
                        args += " -ac 1";
                    }

                    args += " -ar " + Module.SelectedFormatSetting.SamplingRate.Replace("Hz", "");

                    args += " -ab " + Module.SelectedFormatSetting.BitRate;

                    if (Module.SelectedFormatSetting.EncodeMode == "VBR")
                    {
                        args += " -q:a " + Module.SelectedFormatSetting.VBRQuality + " ";

                    }

                    if (!Module.SelectedFormatSetting.KeepTheSameMetadata)
                    {
                        args += " -metadata title=\"" + Module.SelectedFormatSetting.Title + "\" ";
                        args += " -metadata timestamp=\"" + Module.SelectedFormatSetting.Timestamp + "\" ";
                        args += " -metadata author=\"" + Module.SelectedFormatSetting.Author + "\" ";
                        args += " -metadata copyright=\"" + Module.SelectedFormatSetting.Copyright + "\" ";
                        args += " -metadata comment=\"" + Module.SelectedFormatSetting.Comment + "\" ";

                        args += " -metadata album=\"" + Module.SelectedFormatSetting.Album + "\" ";
                        args += " -metadata track=\"" + Module.SelectedFormatSetting.Track + "\" ";
                        args += " -metadata year=\"" + Module.SelectedFormatSetting.Year + "\" ";

                        args += " -write_id3v2 " + (Module.SelectedFormatSetting.ID3v2 ? "1 " : "0 ");
                    }
                }

                int ivol = int.Parse(Module.SelectedFormatSetting.VolumeControl.Replace("%", ""));
                ivol = (int)((decimal)(ivol * 256) / (decimal)100);

                //  100 256
                //  150 x; x=256*150/100

                args += " -vol " + ivol.ToString();

                if (output_file != String.Empty)
                {
                    args += " \"" + output_file + "\" ";
                }
            }
            */
            return args;
        }
        public static string GetArgsForRow(DataRow dr)
        {
            return GetArgsForRow(dr, dr["cinputfile"].ToString(), dr["coutputfile"].ToString());
        }


        public static string GetTempMediaFilepath(string filepath)
        {
            return System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(filepath), System.IO.Path.GetFileNameWithoutExtension(filepath) + "_temp"+System.IO.Path.GetExtension(filepath));
        }

        public static GetJoinArgsResult GetJoinArgs(int k)
        {            

            GetJoinArgsResult res = new GetJoinArgsResult();
            /*
            DataTable dt = frmMain.Instance.dt;
            string parent_id = dt.Rows[k]["cClipID"].ToString();
            List<string> join_args = new List<string>();

            string parent_join_args = "";

            int max_width = -1;
            int max_height = -1;

            List<string> join_filez = new List<string>();
            List<string> pad_filez = new List<string>();

            int j = k;
            j++;

            int file_count = 0;

            while (j < dt.Rows.Count)
            {
                if (dt.Rows[j]["cParentID"].ToString() != parent_id)
                {
                    break;
                }

                if (dt.Rows[j]["cselect"].ToString() != bool.TrueString)
                {
                    j++;
                    continue;
                }
                else
                {
                    join_filez.Add(dt.Rows[j]["cInputFile"].ToString());
                    file_count++;
                }

                int iwidth = (int)dt.Rows[j]["cwidth"];
                if (max_width < iwidth) { max_width = iwidth; }

                int iheight = (int)dt.Rows[j]["cheight"];
                if (max_height < iheight) { max_height = iheight; }

                j++;
            }

            for (int m = k; m < j; m++)
            {
                if (dt.Rows[m]["cselect"].ToString() == bool.TrueString)
                {
                    int iwidth = (int)dt.Rows[m]["cwidth"];
                    int iheight = (int)dt.Rows[m]["cheight"];

                    // if the width and height are not the max ones.... pad it...in order to join it...
                    if (!(iwidth == max_width && iheight == max_height))
                    {
                        join_args.Add(" -i \"" + dt.Rows[m]["cInputFile"].ToString() + "\" -vf pad="
                           + max_width.ToString() + ":" + max_height.ToString() + " "
                           + "\"" + GetTempMediaFilepath(dt.Rows[m]["cInputFile"].ToString()) + "\"");

                        res.JoinFilesToDelete.Add(GetTempMediaFilepath(dt.Rows[m]["cInputFile"].ToString()));

                        int secs = (int)frmMain.Instance.dt.Rows[m]["clengthsecs"];
                        int totalsecs = (int)frmMain.Instance.dt.Rows[m]["ctotalsecs"];
                        frmMain.Instance.dt.Rows[m]["ctotalsecs"] = totalsecs + secs;

                        parent_join_args += " -i \"" + GetTempMediaFilepath(dt.Rows[m]["cInputFile"].ToString()) + "\" ";
                    }
                    else
                    {
                        parent_join_args += " -i \"" + dt.Rows[m]["cInputFile"].ToString() + "\" ";
                    }
                }
            }


            res.MoveToKAfterwards = j;

            if (file_count == 0)
            {
                return res;
            }

            parent_join_args += " -filter_complex \"";

            for (int m = 0; m < file_count; m++)
            {
                parent_join_args += "[" + m.ToString() + ":0] [" + m.ToString() + ":1] ";
            }

            parent_join_args += "concat=n=" + file_count.ToString() + ":v=1:a=1 [v] [a]\" -map \"[v]\" -map \"[a]\" \"" +
            GetTempMediaFilepath(dt.Rows[k]["cInputFile"].ToString()) + "\"";

            // set up parent join item...
            res.JoinArgs.Add(parent_join_args);
            res.JoinFilesToDelete.Add(GetTempMediaFilepath(dt.Rows[k]["cInputFile"].ToString()));

            // also get the conversion args....for the joined item....
            string args =GetArgsForRow(dt.Rows[k], GetTempMediaFilepath(dt.Rows[k]["cInputFile"].ToString()), dt.Rows[k]["cOutputFile"].ToString());
            res.JoinArgs.Add(args);
            */

            return res;
        }

        public static GetJoinArgsResult GetJoinArgsForAudio(int k)
        {
            

            GetJoinArgsResult res = new GetJoinArgsResult();


            /*
             * 
             * DataTable dt = frmMain.Instance.dt;
            string parent_id = dt.Rows[k]["cClipID"].ToString();
            List<string> join_args = new List<string>();

            string parent_join_args = "";

            int j = k;
            j++;

            int file_count = 0;

            while (j < dt.Rows.Count)
            {
                if (dt.Rows[j]["cParentID"].ToString() != parent_id)
                {
                    break;
                }

                if (dt.Rows[j]["cselect"].ToString() != bool.TrueString)
                {
                    j++;
                    continue;
                }
                else
                {                    
                    file_count++;
                }
                
                j++;
            }

            frmMain.Instance.dt.Rows[k]["ctotalsecs"] = 0;

            for (int m = k+1; m < j; m++)
            {
                if (dt.Rows[m]["cselect"].ToString() == bool.TrueString)
                {
                    parent_join_args += " -i \"" + dt.Rows[m]["cInputFile"].ToString() + "\" -vn ";
                    
                    int secs = (int)frmMain.Instance.dt.Rows[m]["clengthsecs"];
                    int totalsecs = (int)frmMain.Instance.dt.Rows[k]["ctotalsecs"];
                    totalsecs += secs;
                    frmMain.Instance.dt.Rows[k]["ctotalsecs"] = totalsecs;
                }
            }

            res.MoveToKAfterwards = j - 1;

            if (file_count == 0)
            {
                return res;
            }

            parent_join_args += " -filter_complex \"";

            for (int m = 0; m < file_count; m++)
            {
                parent_join_args += "[" + m.ToString() + ":1] ";
            }

            parent_join_args += "concat=n=" + file_count.ToString() + ":v=0:a=1 [a]\" -map \"[a]\" ";
            
            // also get the conversion args....for the joined item....
            parent_join_args += GetArgsForRow(dt.Rows[k], "", dt.Rows[k]["cOutputFile"].ToString());
            
            // set up parent join item...
            res.JoinArgs.Add(parent_join_args);
            res.JoinArgsRow.Add(k);
            */
            return res;
        }

        /*
        public static GetSplitArgsResult GetSplitArgsForAudio(int k)
        {
            

            GetSplitArgsResult res = new GetSplitArgsResult();
            /*
            DataTable dt = frmMain.Instance.dt;
            string parent_id = dt.Rows[k]["cClipId"].ToString();
            int j = k + 1;
            
            frmMain.Instance.dt.Rows[k]["cTotalSecs"]=0;

            while (j < dt.Rows.Count)
            {
                DataRow dr = dt.Rows[j];

                // if we have exited the split parent break...
                if (dt.Rows[j]["cParentID"].ToString() != parent_id)
                {
                    break;
                }

                // if the split parts are not joined afterwards and the split is not selected , skip it....
                if (dt.Rows[j]["cDisabled"].ToString() != bool.TrueString && dt.Rows[j]["cSelect"].ToString() != bool.TrueString)
                {
                    j++;
                    continue;
                }


                string args_split = " -vn "+GetArgsForRow(dt.Rows[j], dt.Rows[k]["cInputFile"].ToString(), "");

                int endsecs = (int)dr["cEndSecs"];
                int startsecs = (int)dr["cStartSecs"];
                int splitsecs = endsecs - startsecs;

                args_split += " -ss " + dr["cStart"].ToString() + ".00" + " -t " + splitsecs.ToString();

                // do not join split files..
                if (dr["cJoinSplitParts"].ToString() != bool.TrueString)
                {
                    args_split += " \"" + dr["cOutputFile"].ToString() + "\" ";
                    res.SplitArgsRow.Add(j);
                    frmMain.Instance.dt.Rows[j]["cTotalSecs"] = splitsecs;

                }
                // join split files..
                else
                {
                    args_split += " \"" + dr["cTempOutputFile"].ToString() + "\" ";
                    res.SplitFilesToDelete.Add(dr["cTempOutputFile"].ToString());
                    res.SplitArgsRow.Add(k);
                    frmMain.Instance.dt.Rows[k]["cTotalSecs"] = (int)(frmMain.Instance.dt.Rows[k]["cTotalSecs"]) + splitsecs;
                }

                res.SplitArgs.Add(args_split);

                j++;
            }

            string parent_split_args = "";

            if (dt.Rows[k]["cJoinSplitParts"].ToString() == bool.TrueString)
            {
                frmMain.Instance.dt.Rows[k]["cTotalSecs"] = 
                   (int)(frmMain.Instance.dt.Rows[k]["cTotalSecs"])+
                   (int)(frmMain.Instance.dt.Rows[k]["cLengthSecs"]);

                int file_count = res.SplitFilesToDelete.Count;

                for (int m=0;m<res.SplitFilesToDelete.Count;m++)
                {
                    if (!(dt.Rows[k+1+m]["cDisabled"].ToString() != bool.TrueString && dt.Rows[k+1+m]["cSelect"] != bool.TrueString))
                    {
                        parent_split_args += " -i \"" + res.SplitFilesToDelete[m] + "\" ";
                    }
                }

                parent_split_args += " -filter_complex \"";

                for (int m = 0; m < file_count; m++)
                {
                    parent_split_args += "[" + m.ToString() + ":0] ";
                }

                parent_split_args += "concat=n=" + file_count.ToString() + ":v=0:a=1 [a]\" -map \"[a]\" ";

                // also get the conversion args....for the joined item....
                parent_split_args += GetArgsForRow(dt.Rows[k], "", dt.Rows[k]["cOutputFile"].ToString());

                // set up parent splitted join item...
                res.SplitArgs.Add(parent_split_args);
                res.SplitArgsRow.Add(k);
            }

            res.MoveToKAfterwards = j-1;
            */
        /*
            return res;
        }
         */
        /*
        public static GetSplitArgsResult GetSplitArgs(int k)
        {            

            GetSplitArgsResult res = new GetSplitArgsResult();*/
         /*
            DataTable dt = frmMain.Instance.dt;
            string parent_id = dt.Rows[k]["cClipId"].ToString();
            int j = k + 1;

            int max_width = -1;
            int max_height = -1;

            while (j < dt.Rows.Count)
            {
                DataRow dr = dt.Rows[j];

                // if we have exited the split parent break...
                if (dt.Rows[j]["cParentID"].ToString() != parent_id)
                {
                    break;
                }

                // if the split parts are not joined afterwards and the split is not selected , skip it....
                if (dt.Rows[j]["cDisabled"].ToString() != bool.TrueString && dt.Rows[j]["cSelect"].ToString() != bool.TrueString)
                {
                    j++;
                    continue;
                }


                string args_split = GetArgsForRow(dt.Rows[j], dt.Rows[k]["cInputFile"].ToString(), "");

                int endsecs = (int)dr["cEndSecs"];
                int startsecs = (int)dr["cStartSecs"];
                int splitsecs = endsecs - startsecs;

                args_split += " -ss " + dr["cStart"].ToString() + ".00" + " -t " + splitsecs.ToString();
                args_split += " \"" + dr["cOutputFile"].ToString() + "\" ";

                if (dr["cJoinSplitParts"].ToString() == bool.TrueString)
                {
                    res.SplitFilesToDelete.Add(dr["cOutputFile"].ToString());

                    int iwidth = (int)dt.Rows[j]["cwidth"];
                    if (max_width < iwidth) { max_width = iwidth; }

                    int iheight = (int)dt.Rows[j]["cheight"];
                    if (max_height < iheight) { max_height = iheight; }
                }

                res.SplitArgs.Add(args_split);

                j++;
            }

            string parent_split_args = "";

            if (dt.Rows[k]["cJoinSplitParts"].ToString() == bool.TrueString)
            {
                int file_count = res.SplitFilesToDelete.Count;

                for (int m = k; m < j; m++)
                {
                    if (dt.Rows[m]["cDisabled"].ToString() != bool.TrueString && dt.Rows[m]["cSelect"] != bool.TrueString)
                    {
                        int iwidth = (int)dt.Rows[m]["cwidth"];
                        int iheight = (int)dt.Rows[m]["cheight"];

                        // if the width and height are not the max ones.... pad it...in order to join it...
                        if (!(iwidth == max_width && iheight == max_height))
                        {
                            res.SplitArgs.Add(" -i \"" + res.SplitFilesToDelete[m - k] + "\" -vf pad="
                               + max_width.ToString() + ":" + max_height.ToString() + " "
                               + "\"" + GetTempMediaFilepath(res.SplitFilesToDelete[m - k]) + "\"");

                            res.SplitFilesToDelete.Add(GetTempMediaFilepath(res.SplitFilesToDelete[m - k]));

                            parent_split_args += " -i \"" + GetTempMediaFilepath(res.SplitFilesToDelete[m - k]) + "\" ";
                        }
                        else
                        {
                            parent_split_args += " -i \"" + res.SplitFilesToDelete[m - k] + "\" ";
                        }
                    }
                }

                parent_split_args += " -filter_complex \"";

                for (int m = 0; m < file_count; m++)
                {
                    parent_split_args += "[" + m.ToString() + ":0] [" + m.ToString() + ":1] ";
                }

                parent_split_args += "concat=n=" + file_count.ToString() + ":v=1:a=1 [v] [a]\" -map \"[v]\" -map \"[a]\" \"" +
                GetTempMediaFilepath(dt.Rows[k]["cInputFile"].ToString()) + "\"";

                // set up parent splitted join item...
                res.SplitArgs.Add(parent_split_args);
                res.SplitFilesToDelete.Add(GetTempMediaFilepath(dt.Rows[k]["cInputFile"].ToString()));

                // also get the conversion args....for the joined item....
                string args = GetArgsForRow(dt.Rows[k], GetTempMediaFilepath(dt.Rows[k]["cInputFile"].ToString()), dt.Rows[k]["cOutputFile"].ToString());
                res.SplitArgs.Add(args);
            }

            res.MoveToKAfterwards = j;
            */
        /*
            return res;
        }
        */

        public static string GetStringFromTime(int msecs)
        {
            return TimeSpanHelper.MsecsToFFMpegString(msecs);
            //7
            /*
            int d1sec = msecs;
            int d1isec = d1sec / 10;
            int d1imsec = d1sec % 10;                       

            TimeSpan tsS = new TimeSpan(0, 0, d1isec);
            
            return tsS.Hours.ToString("D2") + ":" + tsS.Minutes.ToString("D2") + ":" + tsS.Seconds.ToString("D2") + "." + d1imsec.ToString();
            */
        }

        public static int GetTimeFromSecsString(string str)
        {
            //7
            /*
            int spos = str.IndexOf(".");

            //1string smsecs = str.Substring(spos + 1);
            string smsecs = str.Substring(spos + 1,1);
            int imsecs = int.Parse(smsecs);

            string ssecs = str.Substring(0, spos);
            int isecs = int.Parse(ssecs);
                        
            return isecs * 10 + imsecs;
            */

            return TimeUpDownControl.StringToMsecs(str);
        }

        public static int GetTimeFromString(string str)
        {
            //7
            /*
            int hours = 0;
            int minutes = 0;
            int secs = 0;
            int msecs = 0;

            try
            {
                hours = int.Parse(str.Substring(0, 2).Replace("_", ""));
            }
            catch { }

            try
            {
                minutes = int.Parse(str.Substring(3, 2).Replace("_", ""));
            }
            catch { }

            try
            {
                secs = int.Parse(str.Substring(6, 2).Replace("_", ""));
            }
            catch { }

            try
            {
                msecs = int.Parse(str.Substring(9, 1).Replace("_", ""));
            }
            catch { }

            TimeSpan ts = new TimeSpan(hours, minutes, secs);

            return (int)ts.TotalSeconds * 10 + msecs;
             
             */

            return TimeUpDownControl.StringToMsecs(str);
        }

        public static string GetDecimalTimeToString(decimal dec)
        {
            return Convert.ToString(dec, System.Globalization.CultureInfo.InvariantCulture).Replace(",",".");            
        }

        public static string GetSecsTimeFromMsecs(int tm)
        {
            //7
            /*
            int tsecs = tm / 10;
            int tmsecs = tm % 10;

            return tsecs.ToString() + "." + tmsecs.ToString() + "0";
            */

            int tsecs = tm / 1000;
            int tmsecs = tm % 1000;

            return tsecs.ToString() + "." + tmsecs.ToString("D2");
        }

        public static int GetMsecsFromSecsTime(string time)
        {
            int dotpos = time.IndexOf(".");

            int tsecs = 0;
            int tmsecs = 0;

            if (dotpos > 0)
            {
                tsecs = int.Parse(time.Substring(0, dotpos));

                string ms=time.Substring(dotpos + 1);

                if (ms.Length>3)
                {
                    ms=ms.Substring(0,3);
                }

                if (ms.Length==1)
                {
                    tmsecs=int.Parse(ms)*100;
                }
                else if (ms.Length==2)
                {
                    tmsecs=int.Parse(ms)*10;
                }
                else if (ms.Length==3)
                {
                    tmsecs=int.Parse(ms);
                }
            }
            else
            {
                tsecs = int.Parse(time);
            }

            return (tsecs * 1000 + tmsecs);
        }


        public static decimal GetTimeFromStringDecimal(string str)
        {
            return Convert.ToDecimal(str, System.Globalization.CultureInfo.InvariantCulture);
            /*
            int spos = str.IndexOf(".");

            if (spos < 0)
            {
                spos = str.IndexOf(",");
            }

            decimal dec = int.Parse(str.Substring(0, spos));

            int decpartlen = int.Parse(str.Substring(spos + 1));
            decimal decpart = 1;

            if (decpartlen == 0)
            {
                decpart = 0;
            }
            else
            {                
                for (int k = 0; k < decpartlen; k++)
                {
                    decpart = decimal.Multiply(decpart, (decimal)0.1);
                }
            }

            return dec + decpart;
            */
        }
    }
}
