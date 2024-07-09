using System;
using System.Collections.Generic;
using System.Text;
using GlowButton;
using System.Data;
using System.Diagnostics;

namespace VideoWallpaperCreator
{
    public class VideoPlayer
    {
        GlowButton.GlowButton fr;
        GlowButton.GlowButton ff;
        GlowButton.GlowButton play;
        GlowButton.GlowButton stop;
        GlowButton.GlowButton mute;
        MediaSlider.MediaSlider msvolume;
        MediaSlider.MediaSlider msposition;
        System.Windows.Forms.Label lblposition;
        System.Windows.Forms.PictureBox picplayer;
        System.Windows.Forms.Timer timPlayerPosition = new System.Windows.Forms.Timer();

        string duration = "";
        bool mouseup = true;

        enum PlayerStateEnum
        {
            Playing,
            Paused,
            Stopped
        }

        PlayerStateEnum PlayerState = PlayerStateEnum.Stopped;

        string filename;

        string lastOpenedFilepath = "";

        public Process ps = null;
        private bool player_has_started_once = false;
        string args_play = "";

        public VideoPlayer(GlowButton.GlowButton _fr, GlowButton.GlowButton _ff, GlowButton.GlowButton _play, GlowButton.GlowButton _stop,
            GlowButton.GlowButton _mute, MediaSlider.MediaSlider _msvolume, MediaSlider.MediaSlider _msposition, System.Windows.Forms.Label _lblposition,
            System.Windows.Forms.PictureBox _picplayer)
        {
            fr = _fr;
            ff = _ff;
            play = _play;
            stop = _stop;
            mute = _mute;
            msvolume = _msvolume;
            msposition = _msposition;
            lblposition = _lblposition;
            picplayer = _picplayer;

            play.Click += play_Click;
            msvolume.ValueChanged += msvolume_ValueChanged;
            stop.Click += stop_Click;
            fr.Click += fr_Click;
            ff.Click += ff_Click;
            mute.Click += mute_Click;
            msposition.MouseDown += msposition_MouseDown;
            msposition.MouseUp += msposition_MouseUp;

            timPlayerPosition.Tick+=timPlayerPosition_Tick;
            timPlayerPosition.Interval = 1000;
            timPlayerPosition.Enabled = true;

            CreateMPlayerProc();
        }

        void msposition_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseup = true;
        }

        void msposition_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mouseup)
            
            mouseup = false;

            decimal dmax = msposition.Maximum;
            decimal dx = (decimal)e.X;
            decimal dwidth = (decimal)msposition.ClientSize.Width - 15;

            // dmax dwidth
            //  ;    dx

            decimal dpos = dx * dmax / dwidth;

            msposition.Value =(int)dpos;
            
            SendCommand("seek " + msposition.Value + " 2 1");            
        }
               

        private void CreateMPlayerProc()
        {
            ps = new Process();

            //Path of Mplayer exe
            ps.StartInfo.FileName = "mplayer ";
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardInput = true;
            //-idle -input=/fifo";
            args_play = " -nofs -noquiet  -identify -slave ";
            args_play += "-nomouseinput -sub-fuzziness 1 ";

            //-wid will tell MPlayer to show output inisde our panel
            args_play += " -vo direct3d -ao dsound  -wid ";
            int id = (int)picplayer.Handle;
            args_play += id;

            
        }

        private void timPlayerPosition_Tick(object sender, EventArgs e)
        {
            if (PlayerState == PlayerStateEnum.Playing)
            {
                if (msposition.Value + 1 <= msposition.Maximum)
                {
                    msposition.Value = msposition.Value + 1;
                    TimeSpan ts = new TimeSpan(0, 0, msposition.Value);
                    lblposition.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2")
                        + " / " + duration;
                }
                else
                {
                    stop_Click(null, null);
                }
            }
        }
        void mute_Click(object sender, EventArgs e)
        {
            SendCommand("mute");
        }

        void ff_Click(object sender, EventArgs e)
        {
            int streampos = msposition.Value + 10;

            if (msposition.Value + 10 > msposition.Maximum)
            {
                streampos = msposition.Maximum;
            }

            string str = "";
            if (PlayerState == PlayerStateEnum.Paused)
            {
                str = "pausing ";
            }

            SendCommand(str + "seek 10 0");

            msposition.Value = streampos;            
        }

        void fr_Click(object sender, EventArgs e)
        {            
            int streampos = msposition.Value - 10;

            if (msposition.Value - 10 <0)
            {
                streampos = 0;
            }

            string str = "";
            if (PlayerState == PlayerStateEnum.Paused)
            {
                str = "pausing ";
            }

            //SendCommand("set_property stream_pos " + streampos.ToString());
            SendCommand(str+"seek -10 0");
            
            msposition.Value = streampos;        
        }

        public void stop_Click(object sender, EventArgs e)
        {            
            SendCommand("stop");
            msposition.Value = 0;
            play.Image = Properties.Resources.play;
            PlayerState = PlayerStateEnum.Stopped;
            ff.Enabled = false;
            fr.Enabled = false;
            stop.Enabled = false;

            if (frmMain.Instance.dgVideo.CurrentRow != null)
            {
                DataRowView drv=(DataRowView)frmMain.Instance.dgVideo.CurrentRow.DataBoundItem;

                DataRow dr = drv.Row;

                FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

                TimeSpan ts = new TimeSpan(0, 0, msposition.Value);
                lblposition.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") +
                    " / " + FFMpegArgsHelperJoin.GetStringFromTime(finfo.DurationMsecs);
            }
        }

        public void playvideo(string filepath)
        {
            if (filepath != lastOpenedFilepath)
            {
                stop_Click(null, null);
            }

            if (PlayerState != PlayerStateEnum.Playing)
            {
                if (PlayerState == PlayerStateEnum.Paused)
                {
                    play.Image = Properties.Resources.pause;
                    SendCommand("pause");
                    PlayerState = PlayerStateEnum.Playing;
                }
                else if (PlayerState == PlayerStateEnum.Stopped)
                {
                    lastOpenedFilepath = filepath;

                    FFMPEGInfo finfo = new FFMPEGInfo(filepath);
                    filename = "\"" + filepath + "\"";
                    OpenFile();
                    msposition.Value = 0;
                    msposition.Maximum = finfo.DurationMsecs / 1000;
                    PlayerState = PlayerStateEnum.Playing;
                    stop.Enabled = true;
                    ff.Enabled = true;
                    fr.Enabled = true;
                    play.Image = Properties.Resources.pause;

                    duration = FFMpegArgsHelperJoin.GetStringFromTime(finfo.DurationMsecs);
                }
            }
            else
            {
                play.Image = Properties.Resources.play;
                SendCommand("pause");
                PlayerState = PlayerStateEnum.Paused;
            }
        }

        public void play_Click(object sender, EventArgs e)
        {            
            if (frmMain.Instance.dgVideo.SelectedRows.Count>0)
            {
                DataRowView drv = (DataRowView)frmMain.Instance.dgVideo.SelectedRows[0].DataBoundItem;

                DataRow dr = drv.Row;

                FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

                string filepath = finfo.Filepath;

                playvideo(filepath);
            }
        }

        void msvolume_ValueChanged(object sender, EventArgs e)
        {            
            SendCommand("set_property volume " + msvolume.Value);
        }

        /// <summary>
        /// Send command to Mplayer
        /// </summary>
        /// <param name="cmd">Command to send</param>
        /// <returns>true is command is sent otherwise false</returns>
        bool SendCommand(string cmd)
        {
            try
            {
                if (player_has_started_once && ps != null && ps.HasExited == false)
                {
                    ps.StandardInput.Write(cmd + "\n");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        void OpenFile()
        {
            if (filename == null)
                return;
            //Close any current playing media file

            if (player_has_started_once)
            {
                try
                {
                    ps.Kill();
                }
                catch
                { }
            }
            try
            {
                ps.StartInfo.Arguments = args_play + " " + filename + "";
                ps.Start();
                player_has_started_once = true;
                SendCommand("set_property volume " + msvolume.Value);
            }
            catch (Exception ex)
            {
                Module.ShowError(ex);
            }
        }
    }
}
