using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using NAudio.Wave;
using NAudio;

namespace VideoWallpaperCreator
{
    class AudioWaveformImage
    {
        public Bitmap ThumbnailImage = null;
        public string ImageFilepath = "";

        public AudioWaveformImage(string filepath, int framenum, string time_position, int width, int height)
        {
            try
            {
                string iotempfile = "";

                if (!frmClip.Instance.picMain.dicAudioFiles.ContainsKey(framenum))
                {
                    Process psImage = new Process();

                    if (!System.IO.Directory.Exists(VideoThumbnail.ThumbnailsPath))
                    {
                        System.IO.Directory.CreateDirectory(VideoThumbnail.ThumbnailsPath);
                    }

                    iotempfile = System.IO.Path.Combine(VideoThumbnail.ThumbnailsPath, Guid.NewGuid().ToString() + ".wav");

                    int audioframesecs = PicStoryboardWave.StoryboardAudioMsecsWidth / 1000;

                    psImage.StartInfo.FileName = "ffmpeg ";
                    psImage.StartInfo.CreateNoWindow = true;
                    psImage.StartInfo.UseShellExecute = false;
                    psImage.StartInfo.RedirectStandardInput = true;
                    psImage.StartInfo.RedirectStandardOutput = true;
                    psImage.StartInfo.Arguments = " -ss " + time_position + " -t " + audioframesecs + " -i \"" + filepath + "\" -vn -y \"" + iotempfile + "\"";
                    psImage.Start();
                    psImage.WaitForExit();

                    if (!psImage.HasExited)
                    {
                        psImage.Kill();
                    }

                    psImage.Dispose();

                    frmClip.Instance.picMain.dicAudioFiles.Add(framenum, iotempfile);
                }
                else
                {
                    iotempfile = frmClip.Instance.picMain.dicAudioFiles[framenum];
                }

                Bitmap img = ImageFromAudioFile(iotempfile, width, height);

                if (img != null)
                {
                    ThumbnailImage = (Bitmap)((Image)img).Clone();
                }
                img.Dispose();
                img = null;

                GC.Collect();

                System.Threading.Thread.Sleep(100);
            }
            catch { }
            finally
            {
                //frmClip.Instance.Cursor = null;
            }
        }

        public Bitmap ImageFromAudioFile(string filepath, int width, int height)
        {
            WaveStream WaveStream = new NAudio.Wave.WaveFileReader(filepath);

            if (WaveStream == null) return null;

            int bytesPerSample;
            long WaveLength = -1;
            decimal SamplesPerPixel = 128;

            WaveStream.Position = 0;

            WaveLength = WaveStream.Length;

            WaveFormat WaveFormat = WaveStream.WaveFormat;

            bytesPerSample = (WaveFormat.BitsPerSample / 8) * WaveFormat.Channels;

            int BytesPerPixel = (int)(SamplesPerPixel * (WaveFormat.BitsPerSample / 8) * WaveFormat.Channels);

            try
            {
                lock (WaveStream)
                {
                    Bitmap bmp = new Bitmap(width, height);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        int bytesRead;

                        byte[] waveData = new byte[BytesPerPixel];

                        long wbStep = BytesPerPixel;

                        long wbLen = WaveStream.Length;

                        int asp = Math.Abs(0);
                        long wbPos = asp * wbStep;

                        using (Pen linePen = new Pen(Color.DarkBlue, 1))
                        {
                            for (float x = asp; x < asp + width; x += 1)
                            {
                                short low = 0;
                                short high = 0;

                                long wbEnd = wbPos + wbStep;

                                if (wbEnd > wbLen)
                                {
                                    wbEnd = wbLen;
                                }

                                if (wbEnd < wbPos) break;

                                long len = wbEnd - wbPos;
                                len = len - len % WaveFormat.BlockAlign;

                                WaveStream.Position = wbPos;

                                WaveStream.Read(waveData, 0, (int)len);

                                float lowPercent;
                                float highPercent;

                                for (int n = 0; n < len; n += 2)
                                {
                                    short sample = BitConverter.ToInt16(waveData, n);

                                    if (sample < low) low = sample;
                                    if (sample > high) high = sample;
                                }

                                lowPercent = ((((float)low) - short.MinValue) / ushort.MaxValue);
                                highPercent = ((((float)high) - short.MinValue) / ushort.MaxValue);

                                g.DrawLine(linePen, x - asp, height * lowPercent, x - asp, height * highPercent);

                                wbPos += len;
                            }
                        }
                    }

                    ImageFilepath = VideoThumbnail.ThumbnailsPath + "\\" + Guid.NewGuid() + ".bmp";
                    bmp.Save(ImageFilepath);

                    return bmp;
                }
            }
            catch (Exception ex)
            {
                //Module.ShowError(ex);

                return null;
            }
            finally
            {

            }
        }
    }
}
