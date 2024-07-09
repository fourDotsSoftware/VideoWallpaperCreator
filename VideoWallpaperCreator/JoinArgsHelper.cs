using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace VideoWallpaperCreator
{
    public class JoinArgsHelper
    {
        public DataTable dt=null;        

        /*
        bool FadeIn = false;
        bool FadeOut = false;
        decimal FadeInSeconds = 2;
        decimal FadeOutSeconds = 2;
        */

        public JoinArgsHelper()
        {

        }

        public JoinArgsHelper(DataTable _dt)
        {
            dt=_dt;

            /*
            FadeIn = _FadeIn;
            FadeOut = _FadeOut;
            FadeInSeconds = _FadeInSeconds;
            FadeOutSeconds = _FadeOutSeconds;*/
        }

        public string GetSampleRate(string sample_rate)
        {
            try
            {
                return sample_rate.ToLower().Replace("khz", "").Replace("hz", "");
            }
            catch
            {
                return "";
            }
        }

        public string GetFrameRate(string frame_rate)
        {
            try
            {
                int spos = frame_rate.IndexOf("(");

                if (spos >= 0)
                {
                    int epos = frame_rate.IndexOf(")", spos);

                    frame_rate = frame_rate.Substring(0, spos) + frame_rate.Substring(epos+1);                    
                }

                frame_rate = frame_rate.Replace("fps", "").Trim();                                

                return frame_rate;
            }
            catch
            {
                return "";
            }
        }

        public string GetVideoSize(string video_size)
        {
            try
            {
                if (video_size.IndexOf("(") >= 0)
                {
                    int spos = video_size.IndexOf("(");
                    int epos = video_size.IndexOf(")", spos);

                    video_size = video_size.Substring(spos + 1, epos - spos - 1);
                }

                return video_size.Replace("*", "x");
            }
            catch
            {
                return "";
            }
        }
        public JoinArgs GetJoinArgsDifferentType(OutputFormatResult res)
        {
            /*
            res.selectedProfile,
            res.selectedProfileCategory
            res.additionalArgs,*/            

            JoinArgs jargs=GetJoinArgsDifferentType(res.extension,
        res.ffmpegParameters,
        res.firstPassArgs,
        res.secondPassArgs,        
        res.videoBitRate,
        res.videoFrameRate,
        res.videoSize,
        res.videoAspectRatio,
        res.videoTwoPass,
        res.videoDeinterlace,
        res.audioBitRate,
        res.audioSampleRate,
        res.audioChannels,
        res.audioVolume,
        res.audioNormalize,
        res.audioMute,
        res.copyMetadata,
        res.fadeIn,
        res.fadeOut,
        res.fadeInSeconds,
        res.fadeOutSeconds,
        res.replaceAudio,
        res.mixAudio,
        res.mixVolume,
        res.mixAudioFile,
        res.DrawTextArgs,
        res.OverlayArgs
        );

            jargs.OutputFormatResult = res;

            return jargs;
        }


        public JoinArgs GetJoinArgsDifferentType(string outputext, string outputparams,string firstPassArgs,string secondPassArgs,
            string videoBitRate,string videoFrameRate,string videoSize,string videoAspectRatio,bool videoTwoPass,bool videoDeinterlace,
            string audioBitRate,string audioSampleRate,string audioChannels,string audioVolume,bool audioNormalize,bool audioMute,bool copyMetadata,
            bool fadeIn, bool fadeOut, decimal fadeInSeconds, decimal fadeOutSeconds,bool replaceAudio,bool mixAudio,string mixAudioVolume,string mixAudioFile,
            DrawTextArgs drawTextArgs,OverlayArgs overlayArgs)
        {            
            JoinArgs joinargs = new JoinArgs();            
            
            if (videoBitRate != string.Empty) outputparams += " -b:v " + videoBitRate;
            if (videoFrameRate != string.Empty) outputparams += " -r " + GetFrameRate(videoFrameRate);
            if (videoSize != string.Empty) outputparams += " -s " + GetVideoSize(videoSize);
            if (videoAspectRatio != string.Empty) outputparams += " -aspect " + videoAspectRatio;
            if (audioBitRate != string.Empty) outputparams += " -b:a " + audioBitRate;
            if (audioSampleRate != string.Empty) outputparams += " -ar " + GetSampleRate(audioSampleRate);
            if (audioChannels != string.Empty) outputparams += " -ac " + audioChannels;
            if (audioMute) outputparams += " -an ";

            drawTextArgs.drawTextX = GetXArgText(drawTextArgs.drawTextX);
            drawTextArgs.drawTextY = GetYArgText(drawTextArgs.drawTextY);

            overlayArgs.OverlayX = GetXArgOverlay(overlayArgs.OverlayX);
            overlayArgs.OverlayY = GetYArgOverlay(overlayArgs.OverlayY);

            drawTextArgs.drawTextText = drawTextArgs.drawTextText.Replace("'", @"\'");

            if (audioMute && replaceAudio)
            {
                audioMute = false;
            }

            string metadata_args = "";

            if (copyMetadata) metadata_args = " -map_metadata 0 ";

            string outputparams_original = outputparams;

            bool has_filter_params = HasParameter("-vf", outputparams);

            outputparams = RemoveVideoFilterArgsFromArgs(outputparams);

            string audioVolumeParams="";
    
            if (audioVolume != string.Empty)
            {
                if (audioVolume.IndexOf("%") > 0)
                {
                    audioVolume = audioVolume.Replace("%", "");

                    decimal decVol1 = decimal.Parse(audioVolume);
                    decimal decVol2 = (decimal)100;
                    decimal decVol = decVol1 / decVol2;

                    audioVolumeParams += "volume=" + decVol.ToString() + "";
                }
                else
                {
                    audioVolumeParams += "volume=" + audioVolume + "";
                }
            }

            string mixAudioVolumeParams = "";

            if (mixAudioVolume != string.Empty)
            {
                if (mixAudioVolume.IndexOf("%") > 0)
                {
                    mixAudioVolume = mixAudioVolume.Replace("%", "");

                    decimal decVol1 = decimal.Parse(mixAudioVolume);
                    decimal decVol2 = (decimal)100;
                    decimal decVol = decVol1 / decVol2;

                    mixAudioVolumeParams += ",volume=" + decVol.ToString();
                }
                else
                {
                    mixAudioVolumeParams += ",volume=" + mixAudioVolume;
                }
            }

            FFMPEGInfo firstinfo = (FFMPEGInfo)dt.Rows[0]["videoinfo"];
            joinargs.JoinFile = GetJoinFile(firstinfo.Filepath, outputext);            

            string dtextargs = "";

            if (drawTextArgs != null && drawTextArgs.drawText)
            {
                joinargs.DrawTextFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(joinargs.JoinFile), Guid.NewGuid().ToString() + outputext);                

                string shadowstr = "";

                string fontsdir = System.IO.Path.Combine(System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)).FullName, "fonts");

                string font = drawTextArgs.drawTextFont;

                if (!System.IO.File.Exists(drawTextArgs.drawTextFont))
                {
                    font = System.IO.Path.Combine(fontsdir, font);
                }

                font = font.Replace(@"\", @"\\\").Replace(":", @"\:");

                if (drawTextArgs.drawTextShadow)
                {
                    shadowstr = "shadowx=2:shadowy=2:shadowcolor=" + Module.HexConverter(drawTextArgs.drawTextShadowColor) + ":";
                }

                dtextargs = "drawtext=fontfile='" + font + "':" +
                    "fontcolor=" + Module.HexConverter(drawTextArgs.drawTextFontColor) +
                    //":x=" + drawTextArgs.drawTextX + ":y=" + drawTextArgs.drawTextY + ":fontsize=" + drawTextArgs.drawTextFontSize.ToString() + ":" + shadowstr + "text='" + drawTextArgs.drawTextText + "'";
                    ":" + GetScrollTextXY(drawTextArgs.scrollText,drawTextArgs.scrollTextSpeed,drawTextArgs.drawTextX,drawTextArgs.drawTextY) + ":fontsize=" + drawTextArgs.drawTextFontSize.ToString() + ":" + shadowstr + "text='" + drawTextArgs.drawTextText + "'";

                //joinargs.DrawTextArgs = " -i \"" + joinargs.DrawTextFile + "\" -filter_complex \"" + dtextargs + "\" " + outputparams_original + metadata_args + " -y ";
            }

            List<string> lst = new List<string>();

            string args = "";

            int tdur = 0;

            int joindur = 0;                                        

            string fileargs="";
            string concatargs = "";
            string fargs=" -filter_complex \"";
            
            int offset = 0;

            if (overlayArgs.Overlay)
            {
                offset = 1;
                fileargs += " -i \"" + overlayArgs.OverlayImageFile + "\" ";
            }

            for (int k = 0; k < dt.Rows.Count; k++)
            {                
                FFMPEGInfo finfo = (FFMPEGInfo)dt.Rows[k]["videoinfo"];
                
                joindur += finfo.DurationMsecs;

                joinargs.InputFiles.Add(finfo.Filepath);

                if (k==0 || dt.Rows[k]["selected"].ToString()==bool.TrueString)
                {
                    joinargs.InputFileForCopyEXIF = finfo.Filepath;
                }

                fileargs+=" -i \"" + finfo.Filepath + "\" ";

                fargs += "[" + (k+offset).ToString() + ":v:0]";

                if (audioMute || replaceAudio)
                {
                    //concatargs += "[" + k.ToString() + ":v:0]";
                    concatargs += "[v" + (k).ToString() + "]";
                }
                else if (audioVolumeParams != string.Empty)
                {
                    concatargs += "[v" + (k).ToString() + "] [a" + (k).ToString() + "] ";
                }
                else
                {
                    if (finfo.AudioEncoder == string.Empty)
                    {
                        concatargs += "[v" + (k).ToString() + "] [" + (dt.Rows.Count + offset).ToString() + ":a] ";
                    }
                    else
                    {
                        //concatargs += "[" + k.ToString() + ":v:0] [" + k.ToString() + ":a:0] ";
                        concatargs += "[v" + (k).ToString() + "] [" + (k + offset).ToString() + ":a:0] ";
                    }
                }

                if (fadeIn)
                {
                    fargs += "fade=t=in:st=" + FFMpegArgsHelperJoin.GetSecsTimeFromMsecs(0);
                    fargs += ":d=" + fadeInSeconds.ToString("#0.0").Replace(",", ".") + ",";
                }

                if (fadeOut)
                {
                    int fadeoutmsecs = (int)(fadeOutSeconds * 1000);
                    //!string fadeoutstart = FFMpegArgsHelperJoin.GetSecsTimeFromMsecs(firstinfo.DurationMsecs - fadeoutmsecs);
                    string fadeoutstart = FFMpegArgsHelperJoin.GetSecsTimeFromMsecs(finfo.DurationMsecs - fadeoutmsecs);

                    fargs += "fade=t=out:st=" + fadeoutstart + ":d=" + fadeOutSeconds.ToString("#0.0").Replace(",", ".") + ",";
                }                

                //was not commented !!
                //if (k>0)
                if (true)
                {                                      
                    /*
                    if (firstinfo.VideoWidth != finfo.VideoWidth
                        || firstinfo.VideoHeight != finfo.VideoHeight
                        || firstinfo.VideoSAR !=finfo.VideoSAR
                        || firstinfo.VideoDAR !=finfo.VideoDAR
                        )
                    */

                    // was without comments !!
                    /*
                    if (firstinfo.VideoWidth != finfo.displayVideoWidth
                        || firstinfo.VideoHeight != finfo.displayVideoHeight
                        || firstinfo.VideoSAR != finfo.VideoSAR
                        || firstinfo.VideoDAR != finfo.VideoDAR
                        )*/
                    if (true)
                    {                        

                        decimal dw = (decimal)firstinfo.VideoWidth;
                        decimal dh = (decimal)firstinfo.VideoHeight;

                        decimal r1 = dw / dh;

                        //if (firstinfo.VideoWidth >= firstinfo.VideoHeight)
                        //{                            

                        //0decimal d1w = (decimal)finfo.VideoWidth;
                        //0decimal d1h = (decimal)finfo.VideoHeight;

                        decimal d1w = (decimal)finfo.displayVideoWidth;
                        decimal d1h = (decimal)finfo.displayVideoHeight;

                        decimal r2 = d1w / d1h;

                        //if (d1w >= d1h)
                        //10.2017 if (dw < dh)
                        if (false)
                        {
                            decimal dnh = dw / r2;
                            //decimal dnw = d1w;

                            int ih = (int)dnh;
                            //1int iw = Math.Min(finfo.VideoWidth, firstinfo.VideoWidth);
                            int iw = Math.Min(finfo.displayVideoWidth, firstinfo.VideoWidth);

                            /*
                            string argspad = " -i \"" + finfo.Filepath + "\" -c:a copy -vf scale=" + iw + ":" + ih +
                                ",pad=" + firstinfo.VideoWidth.ToString() + ":" + firstinfo.VideoHeight.ToString() +
                                ":color=black:x=(" + firstinfo.VideoWidth.ToString() + "/2-" +
                            iw + "/2):y=(" + firstinfo.VideoHeight.ToString() + "/2-" +
                                ih.ToString() + "/2) " + outputparams + " -y \"" + outpadfile + "\" ";
                            */

                            fargs += "scale=" + iw + ":" + ih +
                                ",pad=" + firstinfo.VideoWidth.ToString() + ":" + firstinfo.VideoHeight.ToString() +
                                ":color=black:x=(" + firstinfo.VideoWidth.ToString() + "/2-" +
                            iw + "/2):y=(" + firstinfo.VideoHeight.ToString() + "/2-" +
                                //ih.ToString() + "/2),setsar="+firstinfo.VideoSAR+",setdar="+firstinfo.VideoDAR+"\" " + outputparams + " -y \"" + outpadfile + "\" ";
                                ih.ToString() + "/2),setsar=" + firstinfo.VideoSAR + ",";
                        }
                        else
                        {
                            decimal dnw = 0;
                            decimal dnh = 0;
                            int iw = 0;
                            int ih = 0;

                            if ((r1 >= r2 && r1 >= 1) || (r1 < r2 && r1 < 1))
                            {
                                dnw = dh * r2;
                                dnh = dw / r1;
                                iw = (int)dnw;
                                //ih = Math.Min(finfo.VideoHeight, firstinfo.VideoHeight);
                                ih = (int)dnh;
                            }
                            else
                            {
                                dnh = dw / r2;
                                dnw = dnh * r1;
                                iw = (int)dnw;
                                ih = (int)dnh;
                            }

                            fargs += "scale=" + iw.ToString() + ":" + ih +
                                ",pad=" + firstinfo.VideoWidth.ToString() + ":" + firstinfo.VideoHeight.ToString() +
                                ":color=black:x=(" + firstinfo.VideoWidth.ToString() + "/2-" +
                                iw.ToString() + "/2):y=(" + firstinfo.VideoHeight.ToString() + "/2-" + ih + "/2)," +
                                //"setsar="+firstinfo.VideoSAR+",setdar="+firstinfo.VideoDAR+"\" "+                                
                                "setsar=" + firstinfo.VideoSAR + ",";                                
                        }

                        /*}
                        else
                        {
                            
                            decimal d1w = (decimal)finfo.VideoWidth;
                            decimal d1h = (decimal)finfo.VideoHeight;

                            dh = dw * (d1w / d1h);
                            int ih = (int)dh;

                            string argspad = " -i \"" + finfo.Filepath + "\" -c:a copy -vf scale=" + finfo.VideoWidth.ToString() + ":" + ih.ToString() +
                                ",pad=width=" + firstinfo.VideoWidth.ToString() + ":height=" + firstinfo.VideoHeight.ToString() +
                                ":color=black:x=0:y=(" + firstinfo.VideoHeight.ToString() + "/2-" +
                                ih.ToString() + "/2) " + outputparams + " -y \"" + outpadfile + "\" ";

                            joinargs.DifOutputArgs.Add(argspad);
                        }                        */                                                
                    }                    
                }

                if (videoDeinterlace)
                {
                    fargs+= "yadif,";
                }

                if (drawTextArgs.drawText && !drawTextArgs.drawTextFrom && !drawTextArgs.drawTextTo && drawTextArgs.scrollText==0)
                {
                    fargs += dtextargs + ","; 
                }

                if (!SettingsHelper.RenMove && frmPurchase.RenMove)
                {                    
                   string fontsdir1 = System.IO.Path.Combine(System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)).FullName, "fonts");

                   string font1 = "arial.ttf";
                
                   font1 = System.IO.Path.Combine(fontsdir1, font1);               

                font1 = font1.Replace(@"\", @"\\\").Replace(":", @"\:");
                
                 string shadowstr1 = "shadowx=2:shadowy=2:shadowcolor=" + Module.HexConverter(System.Drawing.Color.DarkGray) + ":";
                
                string dtextargs1 = "drawtext=fontfile='" + font1 + "':" +
                    "fontcolor=" + Module.HexConverter(System.Drawing.Color.DarkBlue) +                    
                    ":" +"x=W/2-tw/2:y=H-th"  + ":fontsize=24" + ":" + shadowstr1 + "text='" + "Joined with softpcapps Software Video Wallpaper Creator - softpcapps.com" + "',";

                fargs += dtextargs1;
                }
                // no additional filters add 'copy' filter to bypass empty filter ffmpeg errors
                if (fargs.EndsWith("]"))
                {
                    fargs += "copy,";
                }

                if (fargs.EndsWith(","))
                {
                    fargs = fargs.Substring(0, fargs.Length - 1);
                }

                fargs+=" [v"+k.ToString()+"];";

                if (audioVolumeParams != string.Empty)
                {
                    fargs += "[" + (k + offset).ToString() + ":a:0]" + audioVolumeParams + " [a" + k.ToString() + "];";
                }
            }

            fileargs += " -f lavfi -t 0.1 -i anullsrc ";

            string mapvargs = " -map \"[v]\" ";
            string overlaylastargs = "";

            if (overlayArgs.Overlay)
            {
                mapvargs = " -map \"[vlast]\" ";
                overlaylastargs = ";[v]overlay=x=" + overlayArgs.OverlayX + ":y=" + overlayArgs.OverlayY + "[vlast]";
            }

            if (audioMute)
            {
                concatargs += " concat=n=" + dt.Rows.Count + ":v=1:a=0 [v]"+ overlaylastargs+"\"" +mapvargs;
            }
            else if (replaceAudio)
            {
                concatargs += " concat=n=" + dt.Rows.Count + ":v=1:a=0 [v]";
            }
            else
            {
                concatargs += " concat=n=" + dt.Rows.Count + ":v=1:a=1 [v] [a]";
            }

            if (replaceAudio)
            {
                concatargs+= ";["+(dt.Rows.Count+offset)+":a:0]apad [lasta]"+overlaylastargs+"\" "+mapvargs+" -map \"[lasta]\" ";
                fileargs += " -i \"" + mixAudioFile + "\" -shortest ";

            }
            else if (mixAudio)
            {
                concatargs += ";[a]apad,amix=inputs=2"+mixAudioVolumeParams+" [lasta]" +  overlaylastargs+"\" "+mapvargs +" -map \"[lasta]\" ";
                fileargs += " -i \"" + mixAudioFile + "\" -shortest ";
                //-shortest
            }
            else if (!audioMute)
            {
                concatargs += overlaylastargs+"\" "+mapvargs+" -map \"[a]\" ";
            }

            if (fargs.EndsWith(","))
            {
                fargs=fargs.Substring(0,fargs.Length-1);
            }            

            args = fileargs + fargs + concatargs;

            tdur = joindur;

            joinargs.DurationMsecs = joindur;

            if (audioNormalize)
            {               
                joinargs.NormalizeFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(joinargs.JoinFile), Guid.NewGuid().ToString() + outputext);

                joinargs.NormalizeArgs1 = " -i \"" + joinargs.NormalizeFile+"\" -af \"volumedetect\" -f null NUL ";

                joinargs.NormalizeArgs2 = " -y -i \"" + joinargs.NormalizeFile + "\" "+outputparams+metadata_args+" -af \"volume=" + "[REPLACE_MAXVOL]" + "dB\" -y ";

                joinargs.DurationMsecs += 2 * joindur;
            }

            joinargs.Args = args + " " + outputparams_original + metadata_args + " -y ";

            if (has_filter_params)
            {                
                joinargs.JoinFileWithNoFilter = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(joinargs.JoinFile), Guid.NewGuid().ToString() + outputext);                

                joinargs.JoinArgsWithNoFilter = " -i \"" + joinargs.JoinFileWithNoFilter + "\" " + outputparams_original + metadata_args + " -y ";

                joinargs.Args = args + " " + outputparams+ metadata_args + " -y ";

                joinargs.DurationMsecs += joindur;

                /*
                if (audioVolume != string.Empty)
                {
                    joinargs.AudioVolumeFile= System.IO.Path.Combine(VideoThumbnail.ThumbnailsPath, Guid.NewGuid().ToString() + outputext);

                    if (audioNormalize)
                    {
                        joinargs.AudioVolumeArgs = " -i \"" + joinargs.NormalizeFile + "\" " + outputparams+metadata_args + " " + audioVolumeParams + " -y ";

                        joinargs.AudioVolumeArgsNoNormalize = " -i \"" + joinargs.JoinFileWithNoFilter + "\" " + outputparams+metadata_args + " " + audioVolumeParams + " -y ";
                    }
                    else
                    {
                        joinargs.AudioVolumeArgs = " -i \"" + joinargs.JoinFileWithNoFilter + "\" " + outputparams+metadata_args + " " + audioVolumeParams + " -y ";
                    }

                    args_last = " -i \"" + joinargs.AudioVolumeFile + "\" " + outputparams_original+metadata_args + " -y ";

                    joinargs.DurationMsecs += joindur;
                }                               
                */
                

                //joinargs.DurationMsecs += tdur;

                //joinargs.DurationMsecs += joindur;
            }
            else
            {
                

                //joinargs.DurationMsecs += joindur;
            }           

            if (drawTextArgs.drawText && (drawTextArgs.drawTextFrom || drawTextArgs.drawTextTo || drawTextArgs.scrollText!=0))
            {
                string starttime="00:00:00.0";
                string endtime="99:59:59";                

                string timefrom="00:00:00.0";
                string timeto="99:59:59";                

                if (drawTextArgs.drawTextFrom)
                {
                    timefrom=drawTextArgs.drawTextFromTime;
                }

                if (drawTextArgs.drawTextTo)
                {
                    timeto=drawTextArgs.drawTextToTime;
                }

                timefrom=timefrom.Replace(":",@"\:");
                timeto=timeto.Replace(":",@"\:");
                starttime = starttime.Replace(":", @"\:");
                endtime = endtime.Replace(":", @"\:");

                string newdrawargs="-filter_complex \""+
                "[0:v:0]trim='"+starttime+":"+timefrom+"',setpts=PTS-STARTPTS[v1];"+
                "[0:a:0]atrim='"+starttime+":"+timefrom+"',asetpts=PTS-STARTPTS[a1];"+
                "[0:v:0]"+dtextargs+",trim='"+timefrom+":"+timeto+"',setpts=PTS-STARTPTS[v2];"+
                "[0:a:0]atrim='"+timefrom+":"+timeto+"',asetpts=PTS-STARTPTS[a2];"+
                "[0:v:0]trim='"+timeto+":"+endtime+"',setpts=PTS-STARTPTS[v3];"+
                "[0:a:0]atrim='"+timeto+":"+endtime+"',asetpts=PTS-STARTPTS[a3];"+                              
                "[v1][a1][v2][a2][v3][a3] concat=n=3:v=1:a=1 [v][a]\" -map \"[v]\" -map \"[a]\" ";

                if (audioMute)
                {
                    newdrawargs = "-filter_complex \"" +
                "[0:v:0]trim='" + starttime + ":" + timefrom + "',setpts=PTS-STARTPTS[v1];" +                
                "[0:v:0]" + dtextargs + ",trim='" + timefrom + ":" + timeto + "',setpts=PTS-STARTPTS[v2];" +                
                "[0:v:0]trim='" + timeto + ":" + endtime + "',setpts=PTS-STARTPTS[v3];" +                
                "[v1][v2][v3] concat=n=3:v=1:a=0 [v]\" -map \"[v]\" ";

                }
                joinargs.DrawTextArgs = " -i \"" + joinargs.DrawTextFile + "\" " +
                    newdrawargs + outputparams + metadata_args;

                joinargs.DurationMsecs += joindur;
            }


             joinargs.DurationMsecs = joinargs.DurationMsecs / 100;
            
            return joinargs;
        }

        private string GetScrollTextXY(int scrollText, string scrollTextSpeed, string x, string y)
        {
            if (scrollText == 0)
            {
                return "x="+x+":y="+y;
            }
            else if (scrollText == 1)
            {
                return "x=w-mod(t*"+scrollTextSpeed+@"\,w+tw):y="+y;
            }
            else if (scrollText==2)
            {
                return "x=mod(t*"+scrollTextSpeed+@"\,w+tw):y="+y;
            }
            else if (scrollText == 3)
            {
                return "x=" + x + ":y=h-mod(t*" + scrollTextSpeed + @"\,h+th)";
            }
            else if (scrollText == 4)
            {
                return "x=" + x + ":y=mod(t*" + scrollTextSpeed + @"\,h+th)";
            }         
   
            return "x="+x+":y="+y;
        }
        private string GetXArgText(string str)
        {
            if (str == TranslateHelper.Translate("Left"))
            {
                return "0";
            }
            else if (str == TranslateHelper.Translate("Center"))
            {
                return "w/2-tw/2";
            }
            else if (str == TranslateHelper.Translate("Right"))
            {
                return "w-tw";
            }

            return str;
        }

        private string GetYArgText(string str)
        {
            if (str == TranslateHelper.Translate("Top"))
            {
                return "0";
            }
            else if (str == TranslateHelper.Translate("Middle"))
            {
                return "h/2-th/2";
            }
            else if (str == TranslateHelper.Translate("Bottom"))
            {
                return "h-th";
            }

            return str;
        }

        private string GetXArgOverlay(string str)
        {
            if (str == TranslateHelper.Translate("Left"))
            {
                return "0";
            }
            else if (str == TranslateHelper.Translate("Center"))
            {
                return "W/2-w/2";
            }
            else if (str == TranslateHelper.Translate("Right"))
            {
                return "W-w";
            }

            return str;
        }

        private string GetYArgOverlay(string str)
        {
            if (str == TranslateHelper.Translate("Top"))
            {
                return "0";
            }
            else if (str == TranslateHelper.Translate("Middle"))
            {
                return "H/2-h/2";
            }
            else if (str == TranslateHelper.Translate("Bottom"))
            {
                return "H-h";
            }

            return str;
        }

        public JoinArgs GetJoinArgsDifferentTypeOld(string outputext, string outputparams, string firstPassArgs, string secondPassArgs,
            string videoBitRate, string videoFrameRate, string videoSize, string videoAspectRatio, bool videoTwoPass, bool videoDeinterlace,
            string audioBitRate, string audioSampleRate, string audioChannels, string audioVolume, bool audioNormalize, bool audioMute, bool copyMetadata,
            bool fadeIn, bool fadeOut, decimal fadeInSeconds, decimal fadeOutSeconds, bool replaceAudio, bool mixAudio, string mixAudioVolume, string mixAudioFile,
            DrawTextArgs drawTextArgs)
        {
            JoinArgs joinargs = new JoinArgs();

            if (videoBitRate != string.Empty) outputparams += " -b:v " + videoBitRate;
            if (videoFrameRate != string.Empty) outputparams += " -r " + GetFrameRate(videoFrameRate);
            if (videoSize != string.Empty) outputparams += " -s " + GetVideoSize(videoSize);
            if (videoAspectRatio != string.Empty) outputparams += " -aspect " + videoAspectRatio;
            if (audioBitRate != string.Empty) outputparams += " -b:a " + audioBitRate;
            if (audioSampleRate != string.Empty) outputparams += " -ar " + GetSampleRate(audioSampleRate);
            if (audioChannels != string.Empty) outputparams += " -ac " + audioChannels;
            if (audioMute) outputparams += " -an ";


            string metadata_args = "";

            if (copyMetadata) metadata_args = " -map 0 ";

            string outputparams_original = outputparams;

            bool has_filter_params = HasParameter("-vf", outputparams);

            outputparams = RemoveVideoFilterArgsFromArgs(outputparams);

            string audioVolumeParams = "";

            if (audioVolume != string.Empty)
            {
                if (audioVolume.IndexOf("%") > 0)
                {
                    audioVolume = audioVolume.Replace("%", "");

                    decimal decVol1 = decimal.Parse(audioVolume);
                    decimal decVol2 = (decimal)100;
                    decimal decVol = decVol1 / decVol2;

                    audioVolumeParams += " -filter:a \"volume=" + decVol.ToString() + "\"";
                }
                else
                {
                    audioVolumeParams += " -filter:a \"volume=" + audioVolume + "\"";
                }
            }

            string mixAudioVolumeParams = "";

            if (mixAudioVolume != string.Empty)
            {
                if (mixAudioVolume.IndexOf("%") > 0)
                {
                    mixAudioVolume = mixAudioVolume.Replace("%", "");

                    decimal decVol1 = decimal.Parse(mixAudioVolume);
                    decimal decVol2 = (decimal)100;
                    decimal decVol = decVol1 / decVol2;

                    mixAudioVolumeParams += ",volume=" + decVol.ToString();
                }
                else
                {
                    mixAudioVolumeParams += ",volume=" + mixAudioVolume;
                }
            }

            /*
            if (videoBitRate != string.Empty) outputparams += " -b:v " + videoBitRate;
            if (videoBitRate != string.Empty) outputparams += " -b:v " + videoBitRate;
            if (videoBitRate != string.Empty) outputparams += " -b:v " + videoBitRate;
            */

            List<string> lst = new List<string>();

            string args = "";

            int tdur = 0;

            int joindur = 0;

            if (fadeIn || fadeOut)
            {
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    FFMPEGInfo finfo = (FFMPEGInfo)dt.Rows[k]["videoinfo"];

                    string args_fade = " -i \"" + finfo.Filepath + "\" -vf \"";

                    if (fadeIn)
                    {
                        args_fade += "fade=t=in:st=" + FFMpegArgsHelperJoin.GetSecsTimeFromMsecs(0);
                        args_fade += ":d=" + fadeInSeconds.ToString("#0.0").Replace(",", ".");
                    }

                    if (fadeOut)
                    {
                        if (fadeIn)
                        {
                            args_fade += ",";
                        }

                        int fadeoutmsecs = (int)(fadeOutSeconds * 1000);
                        string fadeoutstart = FFMpegArgsHelperJoin.GetSecsTimeFromMsecs(finfo.DurationMsecs - fadeoutmsecs);

                        args_fade += "fade=t=out:st=" + fadeoutstart + ":d=" + fadeOutSeconds.ToString("#0.0").Replace(",", ".");
                    }

                    string fadefilepath = System.IO.Path.Combine(VideoThumbnail.ThumbnailsPath, Guid.NewGuid().ToString() + outputext);

                    if (k == 0)
                    {
                        args_fade += "\" " + outputparams + " " + metadata_args + " \"" + fadefilepath + "\" ";
                    }
                    else
                    {
                        args_fade += "\" " + outputparams + " \"" + fadefilepath + "\" ";
                    }

                    joinargs.ResizeFadeOutputArgs.Add(args_fade);
                    joinargs.ResizeOutputFilepaths.Add(fadefilepath);
                    joinargs.DurationMsecs += finfo.DurationMsecs;
                }
            }


            FFMPEGInfo firstinfo = null;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (k == 0)
                {
                    firstinfo = (FFMPEGInfo)dt.Rows[k]["videoinfo"];

                    joindur += firstinfo.DurationMsecs;

                    if (fadeIn || fadeOut)
                    {
                        args += " -i \"" + joinargs.ResizeOutputFilepaths[k] + "\" ";
                    }
                    else
                    {
                        args += " -i \"" + firstinfo.Filepath + "\" ";
                    }
                    //joinargs.DurationMsecs += firstinfo.DurationMsecs;

                    tdur += firstinfo.DurationMsecs;

                    joinargs.JoinFile = GetJoinFile(firstinfo.Filepath, outputext);

                }
                else
                {
                    FFMPEGInfo finfo = (FFMPEGInfo)dt.Rows[k]["videoinfo"];

                    joindur += finfo.DurationMsecs;

                    /*
                    if (firstinfo.VideoWidth != finfo.VideoWidth
                        || firstinfo.VideoHeight != finfo.VideoHeight
                        || firstinfo.VideoSAR !=finfo.VideoSAR
                        || firstinfo.VideoDAR !=finfo.VideoDAR
                        )
                    */
                    if (firstinfo.VideoWidth != finfo.displayVideoWidth
                        || firstinfo.VideoHeight != finfo.displayVideoHeight
                        || firstinfo.VideoSAR != finfo.VideoSAR
                        || firstinfo.VideoDAR != finfo.VideoDAR
                        )
                    {

                        string outpadfile = System.IO.Path.Combine(VideoThumbnail.ThumbnailsPath, Guid.NewGuid().ToString() + outputext);

                        decimal dw = (decimal)firstinfo.VideoWidth;
                        decimal dh = (decimal)firstinfo.VideoHeight;

                        decimal r1 = dw / dh;

                        //if (firstinfo.VideoWidth >= firstinfo.VideoHeight)
                        //{                            

                        //0decimal d1w = (decimal)finfo.VideoWidth;
                        //0decimal d1h = (decimal)finfo.VideoHeight;

                        decimal d1w = (decimal)finfo.displayVideoWidth;
                        decimal d1h = (decimal)finfo.displayVideoHeight;

                        decimal r2 = d1w / d1h;

                        //if (d1w >= d1h)
                        //10.2017 if (dw < dh)
                        if (false)
                        {
                            decimal dnh = dw / r2;
                            //decimal dnw = d1w;

                            int ih = (int)dnh;
                            //1int iw = Math.Min(finfo.VideoWidth, firstinfo.VideoWidth);
                            int iw = Math.Min(finfo.displayVideoWidth, firstinfo.VideoWidth);

                            /*
                            string argspad = " -i \"" + finfo.Filepath + "\" -c:a copy -vf scale=" + iw + ":" + ih +
                                ",pad=" + firstinfo.VideoWidth.ToString() + ":" + firstinfo.VideoHeight.ToString() +
                                ":color=black:x=(" + firstinfo.VideoWidth.ToString() + "/2-" +
                            iw + "/2):y=(" + firstinfo.VideoHeight.ToString() + "/2-" +
                                ih.ToString() + "/2) " + outputparams + " -y \"" + outpadfile + "\" ";
                            */

                            string inputfilepath = "";

                            if (fadeIn || fadeOut)
                            {
                                inputfilepath = joinargs.ResizeOutputFilepaths[k];
                            }
                            else
                            {
                                inputfilepath = finfo.Filepath;
                            }

                            string argspad = " -i \"" + inputfilepath + "\" -c:a copy -vf \"scale=" + iw + ":" + ih +
                                ",pad=" + firstinfo.VideoWidth.ToString() + ":" + firstinfo.VideoHeight.ToString() +
                                ":color=black:x=(" + firstinfo.VideoWidth.ToString() + "/2-" +
                            iw + "/2):y=(" + firstinfo.VideoHeight.ToString() + "/2-" +
                                //ih.ToString() + "/2),setsar="+firstinfo.VideoSAR+",setdar="+firstinfo.VideoDAR+"\" " + outputparams + " -y \"" + outpadfile + "\" ";
                                ih.ToString() + "/2),setsar=" + firstinfo.VideoSAR + "\" " + outputparams + metadata_args + " -y \"" + outpadfile + "\" ";

                            joinargs.ResizeFadeOutputArgs.Add(argspad);
                        }
                        else
                        {
                            decimal dnw = 0;
                            decimal dnh = 0;
                            int iw = 0;
                            int ih = 0;

                            if ((r1 >= r2 && r1 >= 1) || (r1 < r2 && r1 < 1))
                            {
                                dnw = dh * r2;
                                dnh = dw / r1;
                                iw = (int)dnw;
                                //ih = Math.Min(finfo.VideoHeight, firstinfo.VideoHeight);
                                ih = (int)dnh;
                            }
                            else
                            {
                                dnh = dw / r2;
                                dnw = dnh * r1;
                                iw = (int)dnw;
                                ih = (int)dnh;
                            }

                            string inputfilepath = "";

                            if (fadeIn || fadeOut)
                            {
                                inputfilepath = joinargs.ResizeOutputFilepaths[k];
                            }
                            else
                            {
                                inputfilepath = finfo.Filepath;
                            }

                            string argspad = " -i \"" + inputfilepath + "\" -c:a copy -vf \"scale=" + iw.ToString() + ":" + ih +
                                ",pad=" + firstinfo.VideoWidth.ToString() + ":" + firstinfo.VideoHeight.ToString() +
                                ":color=black:x=(" + firstinfo.VideoWidth.ToString() + "/2-" +
                                iw.ToString() + "/2):y=(" + firstinfo.VideoHeight.ToString() + "/2-" + ih + "/2)," +
                                //"setsar="+firstinfo.VideoSAR+",setdar="+firstinfo.VideoDAR+"\" "+                                
                                "setsar=" + firstinfo.VideoSAR + "\" " +
                              outputparams + metadata_args + " -y \"" + outpadfile + "\" ";

                            joinargs.ResizeFadeOutputArgs.Add(argspad);
                        }
                        /*}
                        else
                        {
                            
                            decimal d1w = (decimal)finfo.VideoWidth;
                            decimal d1h = (decimal)finfo.VideoHeight;

                            dh = dw * (d1w / d1h);
                            int ih = (int)dh;

                            string argspad = " -i \"" + finfo.Filepath + "\" -c:a copy -vf scale=" + finfo.VideoWidth.ToString() + ":" + ih.ToString() +
                                ",pad=width=" + firstinfo.VideoWidth.ToString() + ":height=" + firstinfo.VideoHeight.ToString() +
                                ":color=black:x=0:y=(" + firstinfo.VideoHeight.ToString() + "/2-" +
                                ih.ToString() + "/2) " + outputparams + " -y \"" + outpadfile + "\" ";

                            joinargs.DifOutputArgs.Add(argspad);
                        }
                        */

                        joinargs.ResizeOutputFilepaths.Add(outpadfile);

                        args += " -i \"" + outpadfile + "\" ";

                        joinargs.DurationMsecs += finfo.DurationMsecs;

                        tdur += finfo.DurationMsecs;

                    }
                    else
                    {

                        args += " -i \"" + finfo.Filepath + "\" ";

                        //joinargs.DurationMsecs += finfo.DurationMsecs;

                        tdur += finfo.DurationMsecs;
                    }
                }
            }

            args += " " + outputparams + metadata_args;

            args += " -filter_complex \"";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (audioMute)
                {
                    args += "[" + k.ToString() + ":v:0]";
                }
                else
                {
                    args += "[" + k.ToString() + ":v:0] [" + k.ToString() + ":a:0] ";
                }
            }

            if (audioMute)
            {
                args += "concat=n=" + (dt.Rows.Count).ToString() + ":v=1 [v]\" -map \"[v]\" -y ";
            }
            else
            {
                args += "concat=n=" + (dt.Rows.Count).ToString() + ":v=1:a=1 [v] [a]\" -map \"[v]\" -map \"[a]\" -y ";
            }

            if (has_filter_params || audioVolume != string.Empty || audioNormalize || videoDeinterlace)
            {
                joinargs.JoinArgsWithNoFilter = args;

                joinargs.JoinFileWithNoFilter = System.IO.Path.Combine(VideoThumbnail.ThumbnailsPath, Guid.NewGuid().ToString() + outputext);

                string args_last = " -i \"" + joinargs.JoinFileWithNoFilter + "\" " + outputparams_original + metadata_args + " -y ";

                if (audioNormalize)
                {
                    joinargs.NormalizeArgs1 = " -i \"" + joinargs.JoinFileWithNoFilter + metadata_args + "\" -af \"volumedetect\" -f null NUL ";

                    joinargs.NormalizeFile = System.IO.Path.Combine(VideoThumbnail.ThumbnailsPath, Guid.NewGuid().ToString() + outputext);

                    joinargs.NormalizeArgs2 = " -y -i \"" + joinargs.JoinFileWithNoFilter + metadata_args + "\" -af \"volume=" + "[REPLACE_MAXVOL]" + "dB\" -y ";

                    joinargs.DurationMsecs += 2 * joindur;

                }

                if (audioVolume != string.Empty)
                {
                    joinargs.AudioVolumeFile = System.IO.Path.Combine(VideoThumbnail.ThumbnailsPath, Guid.NewGuid().ToString() + outputext);

                    if (audioNormalize)
                    {
                        joinargs.AudioVolumeArgs = " -i \"" + joinargs.NormalizeFile + "\" " + outputparams + metadata_args + " " + audioVolumeParams + " -y ";

                        joinargs.AudioVolumeArgsNoNormalize = " -i \"" + joinargs.JoinFileWithNoFilter + "\" " + outputparams + metadata_args + " " + audioVolumeParams + " -y ";
                    }
                    else
                    {
                        joinargs.AudioVolumeArgs = " -i \"" + joinargs.JoinFileWithNoFilter + "\" " + outputparams + metadata_args + " " + audioVolumeParams + " -y ";
                    }

                    args_last = " -i \"" + joinargs.AudioVolumeFile + "\" " + outputparams_original + metadata_args + " -y ";

                    joinargs.DurationMsecs += joindur;
                }

                if (videoDeinterlace)
                {
                    joinargs.DeinterlaceFile = System.IO.Path.Combine(VideoThumbnail.ThumbnailsPath, Guid.NewGuid().ToString() + outputext);

                    if (audioNormalize && audioVolume == string.Empty)
                    {
                        joinargs.DeinterlaceArgs = " -i \"" + joinargs.NormalizeFile + "\" " + outputparams + metadata_args + " -vf yadif -y ";

                    }
                    else if (audioVolume != string.Empty)
                    {
                        joinargs.DeinterlaceArgs = " -i \"" + joinargs.AudioVolumeFile + "\" " + outputparams + metadata_args + " -vf yadif -y ";
                    }
                    else
                    {
                        joinargs.DeinterlaceArgs = " -i \"" + joinargs.JoinFileWithNoFilter + "\" " + outputparams + metadata_args + " -vf yadif -y ";
                    }

                    args_last = " -i \"" + joinargs.DeinterlaceFile + "\" " + outputparams_original + metadata_args + " -y ";

                    joinargs.DurationMsecs += joindur;
                }

                joinargs.Args = args_last;

                joinargs.DurationMsecs += tdur;

                joinargs.DurationMsecs += joindur;
            }
            else
            {
                joinargs.Args = args;

                joinargs.DurationMsecs += tdur;
            }

            if (replaceAudio)
            {
                joinargs.MixAudioJoinFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(joinargs.JoinFile), Guid.NewGuid().ToString() + outputext);

                joinargs.MixAudioArgs = " -i \"" + joinargs.MixAudioJoinFile + "\" -i \"" + mixAudioFile + "\" -af apad -shortest " + outputparams_original + metadata_args + " -c:v copy -y ";

                joinargs.DurationMsecs += joindur;
            }
            else if (mixAudio)
            {
                joinargs.MixAudioJoinFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(joinargs.JoinFile), Guid.NewGuid().ToString() + outputext);

                joinargs.MixAudioArgs = " -i \"" + joinargs.MixAudioJoinFile + "\" -i \"" + mixAudioFile + "\" -filter_complex apad,amix=inputs=2" + mixAudioVolumeParams + " -shortest " + outputparams_original + metadata_args + " -c:v copy -y ";

                joinargs.DurationMsecs += joindur;
            }

            if (drawTextArgs != null && drawTextArgs.drawText)
            {
                joinargs.DrawTextFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(joinargs.JoinFile), Guid.NewGuid().ToString() + outputext);

                joinargs.DurationMsecs += joindur;

                string shadowstr = "";

                string fontsdir = System.IO.Path.Combine(System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)).FullName, "fonts");

                string font = drawTextArgs.drawTextFont;

                if (!System.IO.File.Exists(drawTextArgs.drawTextFont))
                {
                    font = System.IO.Path.Combine(fontsdir, font);
                }

                font = font.Replace(@"\", @"\\\").Replace(":", @"\:");

                if (drawTextArgs.drawTextShadow)
                {
                    shadowstr = "shadowx=2:shadowy=2:shadowcolor=" + Module.HexConverter(drawTextArgs.drawTextShadowColor) + ":";
                }

                joinargs.DrawTextArgs = " -i \"" + joinargs.DrawTextFile + "\" -filter_complex \"drawtext=fontfile='" + font + "':" +
                    "fontcolor=" + Module.HexConverter(drawTextArgs.drawTextFontColor) +
                    ":x=" + drawTextArgs.drawTextX + ":y=" + drawTextArgs.drawTextY + ":fontsize=" + drawTextArgs.drawTextFontSize.ToString() + ":" + shadowstr + "text='" + drawTextArgs.drawTextText + "'\" " + outputparams_original + metadata_args + " -y ";
            }

            joinargs.DurationMsecs = joinargs.DurationMsecs / 100;

            return joinargs;
        }
        public bool AreOfameTypeVideos()
        {
            FFMPEGInfo finfofirst = null;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (k == 0)
                {
                    finfofirst = (FFMPEGInfo)dt.Rows[k]["videoinfo"];
                }
                else
                {
                    FFMPEGInfo finfo = (FFMPEGInfo)dt.Rows[k]["videoinfo"];

                    if (finfo.VideoEncoder != finfofirst.VideoEncoder
                        || finfo.VideoFrameRate != finfofirst.VideoFrameRate
                        || finfo.VideoSize != finfofirst.VideoSize
                        || finfo.VideoPixelFormat != finfofirst.VideoPixelFormat
                        || finfo.VideoBitRate != finfofirst.VideoBitRate
                        || finfo.AudioChannels != finfofirst.AudioChannels
                        || finfo.AudioEncoder != finfofirst.AudioEncoder
                        || finfo.AudioBitRate != finfofirst.AudioBitRate
                        || finfo.AudioSampleFormat != finfofirst.AudioSampleFormat
                        || finfo.AudioSamplingRate != finfofirst.AudioSamplingRate
                        || finfo.VideoSAR!=finfofirst.VideoSAR
                        || finfo.VideoDAR!=finfofirst.VideoDAR)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public JoinArgs GetJoinArgs(OutputFormatResult res)
        {
            if (res.quickJoin)
            {
                return GetJoinArgsSameType();
            }
            else
            {
                return GetJoinArgsDifferentType(res);
            }
        }

        public JoinArgs GetJoinArgs(string outputext, string outputparams,string firstPassArgs,string secondPassArgs,
            string videoBitRate,string videoFrameRate,string videoSize,string videoAspectRatio,bool videoTwoPass,bool videoDeinterlace,
            string audioBitRate,string audioSampleRate,string audioChannels,string audioVolume,bool audioNormalize,bool audioMute,bool copyMetadata,
            bool fadeIn, bool fadeOut, decimal fadeInSeconds,decimal fadeOutSeconds,bool replaceAudio,bool mixAudio,string mixVolume,string mixAudioFile,
            DrawTextArgs drawTextArgs,OverlayArgs overlayArgs,bool quickJoin)
        {
            //if (AreOfameTypeVideos())
            if (quickJoin)
            {
                return GetJoinArgsSameType();
            }
            else
            {
                return GetJoinArgsDifferentType(outputext, outputparams, firstPassArgs, secondPassArgs,
                    videoBitRate, videoFrameRate, videoSize, videoAspectRatio, videoTwoPass, videoDeinterlace,
            audioBitRate, audioSampleRate, audioChannels, audioVolume, audioNormalize, audioMute, copyMetadata,
            fadeIn, fadeOut, fadeInSeconds, fadeOutSeconds, replaceAudio, mixAudio, mixVolume, mixAudioFile,drawTextArgs,
            overlayArgs);
            }
        }

        public string GetJoinFilePrefix(string filepath, string ext, string prefix)
        {
            string fn = "";
            string joinfile = "";
            string outfolder = System.IO.Path.GetDirectoryName(filepath);

            if (Properties.Settings.Default.OutputFolderIndex != 0)
            {
                outfolder = Properties.Settings.Default.OutputFolder;
            }

            fn = System.IO.Path.GetFileNameWithoutExtension(filepath);

            joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

            string jfp = System.IO.Path.Combine(outfolder, joinfile + ext);

            if (System.IO.File.Exists(jfp))
            {
                int k = 1;
                bool found = false;

                while (!found)
                {
                    jfp = System.IO.Path.Combine(outfolder,
                        prefix.Replace("[N]", k.ToString()) + joinfile + ext);

                    if (!System.IO.File.Exists(jfp))
                    {
                        return jfp;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            else
            {
                return jfp;
            }

            return "-1";
        }
        public string GetJoinFileSuffix(string filepath, string ext,string suffix)
        {
            string fn = "";
            string joinfile = "";
            string outfolder = System.IO.Path.GetDirectoryName(filepath);

            if (Properties.Settings.Default.OutputFolderIndex != 0)
            {
                outfolder = Properties.Settings.Default.OutputFolder;
            }

            fn = System.IO.Path.GetFileNameWithoutExtension(filepath);

            joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

            string jfp = System.IO.Path.Combine(outfolder, joinfile + ext);

            if (System.IO.File.Exists(jfp))
            {
                int k = 1;
                bool found = false;

                while (!found)
                {
                    jfp = System.IO.Path.Combine(outfolder,
                        joinfile + suffix.Replace("[N]", k.ToString()) + ext);

                    if (!System.IO.File.Exists(jfp))
                    {
                        return jfp;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            else
            {
                return jfp;
            }

            return "-1";
        }

        public string GetJoinFileSkip(string filepath, string ext)
        {
            string fn = "";
            string joinfile = "";
            string outfolder = System.IO.Path.GetDirectoryName(filepath);

            if (Properties.Settings.Default.OutputFolderIndex != 0)
            {
                outfolder = Properties.Settings.Default.OutputFolder;
            }

            fn = System.IO.Path.GetFileNameWithoutExtension(filepath);

            joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

            string jfp = System.IO.Path.Combine(outfolder, joinfile + ext);

            if (!System.IO.File.Exists(jfp))
            {
                return jfp;
            }
            else
            {
                return "-1";
            }

        }
        public string GetJoinFile(string filepath,string ext)
        {
            if (frmMain.Instance.ExplicitOutputFilepath != string.Empty)
            {
                return frmMain.Instance.ExplicitOutputFilepath;
            }
            else
            {
                string fn = "";
                string joinfile = "";
                string outfolder=System.IO.Path.GetDirectoryName(filepath);

                if (Properties.Settings.Default.OutputFolderIndex!=0)
                {
                    outfolder=Properties.Settings.Default.OutputFolder;
                }
                
                fn = System.IO.Path.GetFileNameWithoutExtension(filepath);                

                joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

                if (Properties.Settings.Default.OutputWhenExists == 0)
                {
                    return System.IO.Path.Combine(outfolder, joinfile + ext);
                }
                else if (Properties.Settings.Default.OutputWhenExists == 1)
                {
                    return GetJoinFileSkip(filepath, ext);       
                }
                else if (Properties.Settings.Default.OutputWhenExists == 2)
                {
                    string jfp = System.IO.Path.Combine(outfolder, joinfile + ext);

                    if (!System.IO.File.Exists(jfp))
                    {
                        return jfp;
                    }
                    else
                    {
                        if (!frmMain.Instance.OutputFileActionRepeat)
                        {
                            frmOutputFileAsk f = new frmOutputFileAsk(filepath , outfolder,jfp);

                            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                return frmOutputFileAsk.CalculateOutputFileRepeatAction(filepath,
                                    jfp, outfolder);
                            }
                            else
                            {
                                return "-1";
                            }
                        }
                        else
                        {
                            return frmOutputFileAsk.CalculateOutputFileRepeatAction(filepath,jfp, outfolder);
                        }
                    }
                }
                else if (Properties.Settings.Default.OutputWhenExists == 3)
                {
                    return GetJoinFileSuffix(filepath, ext, Properties.Settings.Default.OutputSuffix);
                }
                else if (Properties.Settings.Default.OutputWhenExists == 4)
                {
                    return GetJoinFilePrefix(filepath, ext, Properties.Settings.Default.OutputPrefix);
                }
            }

            return "-1";
        }

        public JoinArgs GetJoinArgsSameType()
        {
            JoinArgs joinargs = new JoinArgs();

            string concatfile = System.IO.Path.Combine(VideoThumbnail.ThumbnailsPath, Guid.NewGuid().ToString() + ".txt");

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(concatfile))
            {
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    FFMPEGInfo finfo = (FFMPEGInfo)dt.Rows[k]["videoinfo"];

                    if (k == 0 || dt.Rows[k]["selected"].ToString() == bool.TrueString)
                    {
                        joinargs.InputFileForCopyEXIF = finfo.Filepath;
                    }

                    sw.WriteLine("file '" + finfo.Filepath + "'");

                    joinargs.DurationMsecs += finfo.DurationMsecs;

                    if (k == 0)
                    {
                        joinargs.JoinFile = GetJoinFile(finfo.Filepath,System.IO.Path.GetExtension(finfo.Filepath));
                    }
                }
            }

            string args = " -f concat -safe 0 -i \"" + concatfile + "\" -c copy -y ";

            joinargs.DurationMsecs = joinargs.DurationMsecs / 100;

            joinargs.Args = args;

            return joinargs;
        }

        private bool HasParameter(string parameter, string args)
        {
            return (args.IndexOf(" "+parameter+" ")>0);
        }

        private string RemoveVideoFilterArgsFromArgs(string args)
        {
            string str = RemoveParameterFromArgs("-vf", args);

            str = RemoveParameterFromArgs("-af", str);

            return str;
        }

        private string RemoveParameterFromArgs(string parameter,string args)
        {
            if (args.IndexOf(" "+parameter+" ") > 0)
            {
                string param = " " + parameter + " ";

                int spos1 = args.IndexOf(param);

                int spos = args.IndexOf(param) + param.Length;

                if (args.Substring(spos, 1) == "\"")
                {
                    int epos = args.IndexOf("\"", spos + 1);

                    return " "+args.Substring(0, spos1) + args.Substring(epos + 1);
                }
                else if (args.Substring(spos, 1) == "'")
                {
                    int epos = args.IndexOf("'", spos + 1);

                    return " "+args.Substring(0, spos1) + args.Substring(epos+1);
                }
                else
                {
                    int epos = args.IndexOf(" ", spos);

                    if (epos < 0)
                    {
                        epos = args.Length - 1;

                        return " "+args.Substring(0, spos1);
                    }
                    else
                    {
                        return " "+args.Substring(0, spos1) + args.Substring(epos);
                    }
                }
            }
            else
            {
                return args;
            }
        }

        public static string GetNormalizeArgs(string initial_args, string ffmpeg_output)
        {
            string maxvol="";

            using (System.IO.StringReader sr = new System.IO.StringReader(ffmpeg_output))
            {
                string line = null;

                while ((line = sr.ReadLine()) != null)
                {

                    if (line.Contains(" max_volume: "))
                    {
                        int spos = line.IndexOf(" max_volume: ") + " max_volume: ".Length;
                        int epos = line.IndexOf(" ", spos);

                        maxvol = line.Substring(spos, epos - spos);
                    }
                }

                if (maxvol != "0.0") // if it is not normalized
                {
                    if (maxvol.StartsWith("-"))
                    {
                        maxvol = maxvol.Substring(1);
                    }

                    return initial_args.Replace("[REPLACE_MAXVOL]", maxvol);
                }
                else
                {
                    return "";
                }
            }
        }
    }

    public class JoinArgs
    {
        public string Args = "";

        public List<string> ResizeOutputFilepaths = new List<string>();
        public List<string> FadeOutputFilepaths = new List<string>();
        public List<string> ResizeFadeOutputArgs = new List<string>();

        public string JoinArgsWithNoFilter = "";
        public string JoinFileWithNoFilter = "";

        public string AudioVolumeArgs = "";
        public string AudioVolumeArgsNoNormalize = "";
        public string AudioVolumeFile = "";

        public string NormalizeArgs1 = "";
        public string NormalizeArgs2 = "";
        public string NormalizeFile = "";

        public string DeinterlaceArgs = "";
        public string DeinterlaceFile = "";

        public int DurationMsecs = 0;
        public string JoinFile = "";

        public string MixAudioJoinFile = "";
        public string MixAudioArgs = "";

        public string DrawTextFile = "";
        public string DrawTextArgs = "";

        public List<string> InputVideoFiles = new List<string>();

        public List<string> InputFiles = new List<string>();

        public string InputFileForCopyEXIF = "";

        public OutputFormatResult OutputFormatResult = null;
    }

    
}


