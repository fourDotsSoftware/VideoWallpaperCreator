using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

namespace VideoWallpaperCreator
{
    public class VideoWallpaperMaker
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(
            UInt32 uiAction, UInt32 uiParam, String pvParam, UInt32 fWinIni);

        private static UInt32 SPI_SETDESKWALLPAPER = 20;

        private static UInt32 SPIF_UPDATEINIFILE = 0x1;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(
         [MarshalAs(UnmanagedType.LPTStr)] string lpClassName,
         [MarshalAs(UnmanagedType.LPTStr)] string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(
         IntPtr hWndChild,      // handle to window
         IntPtr hWndNewParent   // new parent window
         );

        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();


        static byte[] SliceMe(byte[] source, int pos)
        {
            byte[] destfoo = new byte[source.Length - pos];
            Array.Copy(source, pos, destfoo, 0, destfoo.Length);
            return destfoo;
        }

        public static void SaveOldWallpaper()
        {
            try
            {
                if (!System.IO.Directory.Exists(Module.AppDataDirectory))
                {
                    System.IO.Directory.CreateDirectory(Module.AppDataDirectory);
                }

                byte[] path = (byte[])Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop").GetValue("TranscodedImageCache");
                String wallpaper_file = Encoding.Unicode.GetString(SliceMe(path, 24)).TrimEnd("\0".ToCharArray());                                

                if (System.IO.File.Exists(wallpaper_file))
                {
                    if (wallpaper_file.ToLower() != System.IO.Path.Combine(Module.AppDataDirectory, "oldwallpaper.bmp").ToLower())
                    {
                        if (System.IO.File.Exists(System.IO.Path.Combine(Module.AppDataDirectory, "oldwallpaper.bmp")))
                        {
                            File.SetAttributes(System.IO.Path.Combine(Module.AppDataDirectory, "oldwallpaper.bmp"), FileAttributes.Normal);

                            System.IO.File.Delete(System.IO.Path.Combine(Module.AppDataDirectory, "oldwallpaper.bmp"));
                        }

                        System.IO.File.Copy(wallpaper_file, System.IO.Path.Combine(Module.AppDataDirectory, "oldwallpaper.bmp"));
                    }
                }
            }
            catch { }

        }

        public static void AddNonRegisteredWatermark()
        {
            string[] filez = System.IO.Directory.GetFiles(WallpaperImagesFolder);

            int max = filez.Length;

            decimal dmax = (decimal)max;
            decimal dpm = (decimal)frmProgress.Instance.progressBar1.Maximum;
            decimal dpc = (decimal)frmProgress.Instance.progressBar1.Value;
            decimal dto = dpm - dpc;
            decimal dpri = dto / dmax;

            Font fo=new Font(frmMain.Instance.Font.FontFamily,21,FontStyle.Bold);

            for (int k = 0; k < filez.Length; k++)
            {
                try
                {
                    System.Windows.Forms.Application.DoEvents();

                    System.IO.File.Copy(filez[k], filez[k] + ".bmp");

                    System.Windows.Forms.Application.DoEvents();

                    System.Drawing.Image img = System.Drawing.Image.FromFile(filez[k]+".bmp");

                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img))
                    {
                        string msg="Video Wallpaper Creator - Please buy !";

                        SizeF sz = g.MeasureString(msg, fo);

                        g.TextRenderingHint=System.Drawing.Text.TextRenderingHint.AntiAlias;

                        g.DrawString(msg, fo, Brushes.DarkBlue, (float)(img.Width - sz.Width), 0);
                    }

                    System.Windows.Forms.Application.DoEvents();

                    img.Save(filez[k]);

                    System.Windows.Forms.Application.DoEvents();

                    img.Dispose();
                    img = null;

                    File.SetAttributes(filez[k] + ".bmp", FileAttributes.Normal);
                    
                    System.IO.File.Delete(filez[k] + ".bmp");

                    try
                    {
                        decimal dnv = (k + 1) * dpri + dpc;
                        int inv = (int)dnv;

                        if (inv <= frmProgress.Instance.progressBar1.Maximum)
                        {
                            frmProgress.Instance.progressBar1.Value = inv;                            

                            decimal d1 = (decimal)frmProgress.Instance.progressBar1.Value;
                            decimal d2 = (decimal)frmProgress.Instance.progressBar1.Maximum;

                            decimal dprog = (d1 / d2) * 100;

                            int iprog = (int)dprog;

                            frmProgress.Instance.progressBar1.lblText = iprog.ToString() + "%";
                        }
                    }
                    catch { }

                    System.Windows.Forms.Application.DoEvents();
                }
                catch { }
            }

            fo.Dispose();
        }

        public static bool GetPlayingEnabled()
        {
            if (!System.IO.Directory.Exists(WallpaperImagesFolder)) return false;

            string[] filez = System.IO.Directory.GetFiles(WallpaperImagesFolder);

            return (filez.Length > 0);
        }

        public static string WallpaperImagesFolder=System.IO.Path.Combine(Module.AppDataDirectory, "images");

        public static void ClearImagesFolder()
        {
            string dir=System.IO.Path.Combine(Module.AppDataDirectory, "images");

            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }

            string[] filez = System.IO.Directory.GetFiles(dir);

            for (int k = 0; k < filez.Length; k++)
            {
                File.SetAttributes(filez[k], FileAttributes.Normal);

                System.IO.File.Delete(filez[k]);
            }
        }

        public static bool RestoreOldWallpaper()
        {
            string file = System.IO.Path.Combine(Module.AppDataDirectory, "oldwallpaper.bmp");

            if (!System.IO.File.Exists(file))
            {
                //3Module.ShowMessage("Error old Wallpaper file does not exist !");

                return false;
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, file, SPIF_UPDATEINIFILE);

            return true;
        }

        public static bool SetWallpaper(string file)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, file, SPIF_UPDATEINIFILE);

            return true;
        }

        public static VideoWallpaperArgs GetVideoWallpaperArgs(System.Data.DataTable dt,VideoWallpaperParameters vp)
        {
            VideoWallpaperMaker.SaveOldWallpaper();

            ClearImagesFolder();

            VideoWallpaperArgs va = new VideoWallpaperArgs();
            /*
            dt.Columns.Add("selected", typeof(bool));
            dt.Columns.Add("videoimg", typeof(Image));
            dt.Columns.Add("ind", typeof(int));
            dt.Columns.Add("durationmsecs", typeof(int));
            dt.Columns.Add("videoinfo", typeof(FFMPEGInfo));            
            */

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                int dur = (int)dt.Rows[k]["durationmsecs"];

                FFMPEGInfo finfo=(FFMPEGInfo)dt.Rows[k]["videoinfo"];

                va.TotalDuration += dur;

                string dir = System.IO.Path.Combine(Module.AppDataDirectory, "images");

                string args = " -i \"" + finfo.Filepath + "\" -filter_complex \"fps=" + vp.Fps.ToString() + ",scale=" + vp.Width + ":-1\" " +
                    "\""+System.IO.Path.Combine(dir,"image"+k.ToString()+"-%07d.bmp")+"\"";

                va.Args.Add(args);
            }

            va.TotalDuration = va.TotalDuration / 100;

            return va;
        }
    }

    public class VideoWallpaperArgs
    {
        public List<string> Args = new List<string>();
        public int TotalDuration = 0;
    }

    public class VideoWallpaperParameters
    {
        public int Fps = 0;
        public int Width = 0;
    }
}
