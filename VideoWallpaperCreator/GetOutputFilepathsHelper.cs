using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace VideoWallpaperCreator
{
    class GetOutputFilepathsHelper
    {
        public static List<string> GetOutputFilepathsForSplitParts(bool chk_equal_parts, bool chk_time, bool chk_filesize, int num_equal_parts, string time_part, long filesize)
        {
            List<string> str = new List<string>();

            string format = frmClip.Instance.cmbOutputFormat.Text.Trim();
            int spos = format.IndexOf(" - ");

            if (spos >= 0)
            {
                format = format.Substring(0, spos);
            }

            if (chk_equal_parts)
            {
                //FileInfo fi=new FileInfo(frmClip.Instance.filepath);

                //int parts=(int)Math.Ceiling(((double)fi.Length/num_equal_parts));

                int parts = num_equal_parts;

                for (int k = 0; k < parts; k++)
                {

                    //if (Properties.Settings.Default.OutputFolder.Trim() == TranslateHelper.Translate("Same as Video Folder"))
                    if (Properties.Settings.Default.OutputFolderIndex==0)
                    {
                        if (format == TranslateHelper.Translate("Keep same Format as Source"))
                        {
                            str.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + System.IO.Path.GetExtension(frmClip.Instance.filepath)));
                        }
                        else
                        {
                            str.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + "." + format.ToLower()));
                        }
                    }
                    else
                    {
                        if (format == TranslateHelper.Translate("Keep same Format as Source"))
                        {
                            str.Add(System.IO.Path.Combine(Properties.Settings.Default.OutputFolder, System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + System.IO.Path.GetExtension(frmClip.Instance.filepath)));
                        }
                        else
                        {
                            str.Add(System.IO.Path.Combine(Properties.Settings.Default.OutputFolder, System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + "." + format.ToLower()));
                        }
                    }
                }
            }
            else if (chk_filesize)
            {
                long part_filesize = filesize;

                FileInfo fi = new FileInfo(frmClip.Instance.filepath);

                int parts = (int)(((double)fi.Length) / ((double)part_filesize));
                int parts_div = (int)(((double)fi.Length) % ((double)part_filesize));

                if (parts_div > 0)
                {
                    parts++;
                }

                for (int k = 0; k < parts; k++)
                {
                    //if (Properties.Settings.Default.OutputFolder.Trim() == TranslateHelper.Translate("Same as Video Folder"))
                    if (Properties.Settings.Default.OutputFolderIndex == 0)
                    {
                        if (format == TranslateHelper.Translate("Keep same Format as Source"))
                        {
                            str.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + System.IO.Path.GetExtension(frmClip.Instance.filepath)));
                        }
                        else
                        {
                            str.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + "." + format.ToLower()));
                        }
                    }
                    else
                    {
                        if (format == TranslateHelper.Translate("Keep same Format as Source"))
                        {
                            str.Add(System.IO.Path.Combine(Properties.Settings.Default.OutputFolder, System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + System.IO.Path.GetExtension(frmClip.Instance.filepath)));
                        }
                        else
                        {
                            str.Add(System.IO.Path.Combine(Properties.Settings.Default.OutputFolder, System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + "." + format.ToLower()));
                        }
                    }
                }
            }
            else if (chk_time)
            {
                int total_time = frmClip.Instance.LengthTotalMSecs;

                //int part_time=FFMpegArgsHelperJoin.GetTimeFromString(time_part);
                int part_time = TimeUpDownControl.StringToMsecs(time_part);

                int parts = (int)(((double)total_time) / ((double)part_time));
                int parts_div = (int)(((double)total_time) % ((double)part_time));

                if (parts_div > 0)
                {
                    parts++;
                }

                for (int k = 0; k < parts; k++)
                {
                    //if (Properties.Settings.Default.OutputFolder.Trim() == TranslateHelper.Translate("Same as Video Folder"))
                    if (Properties.Settings.Default.OutputFolderIndex == 0)
                    {
                        if (format == TranslateHelper.Translate("Keep same Format as Source"))
                        {
                            str.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + System.IO.Path.GetExtension(frmClip.Instance.filepath)));
                        }
                        else
                        {
                            str.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + "." + format.ToLower()));
                        }
                    }
                    else
                    {
                        if (format == TranslateHelper.Translate("Keep same Format as Source"))
                        {
                            str.Add(System.IO.Path.Combine(Properties.Settings.Default.OutputFolder, System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + System.IO.Path.GetExtension(frmClip.Instance.filepath)));
                        }
                        else
                        {
                            str.Add(System.IO.Path.Combine(Properties.Settings.Default.OutputFolder, System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k + 1).ToString() + "." + format.ToLower()));
                        }
                    }
                }


            }


            return str;
        }

        public static List<string> GetOutputFilepaths(bool join_clips,int segments_count)
        {
            List<string> str = new List<string>();

            string format = frmClip.Instance.cmbOutputFormat.Text.Trim();
            int spos = format.IndexOf(" - ");

            if (spos >= 0)
            {
                format = format.Substring(0, spos);
            }

            if (format == TranslateHelper.Translate("Keep same Format as Source"))
            {
                format = System.IO.Path.GetExtension(frmClip.Instance.filepath).Substring(1);
            }

            if (join_clips || frmClip.Instance.fplSegments.Controls.Count == 1)
            {
                //if (Properties.Settings.Default.OutputFolder.Trim() == TranslateHelper.Translate("Same as Video Folder"))
                if (Properties.Settings.Default.OutputFolderIndex == 0)
                {
                    str.Add(GetFinalOutputFilename(frmClip.Instance.filepath, System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), format));
                }
                else
                {
                    str.Add(GetFinalOutputFilename(frmClip.Instance.filepath, Properties.Settings.Default.OutputFolder, format));
                }
            }
            else
            {
                for (int k = 0; k < segments_count; k++)
                {
                    //if (Properties.Settings.Default.OutputFolder.Trim() == TranslateHelper.Translate("Same as Video Folder"))
                    if (Properties.Settings.Default.OutputFolderIndex == 0)
                    {
                        str.Add(GetFinalOutputFilename(frmClip.Instance.filepath, k + 1, System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), format));
                    }
                    else
                    {
                        str.Add(GetFinalOutputFilename(frmClip.Instance.filepath, k + 1, Properties.Settings.Default.OutputFolder, format));
                    }

                }

            }

            return str;
        }

        /*
        public static List<string> GetOutputFilepaths(bool join_clips)
        {
            List<string> str = new List<string>();

            string format = frmClip.Instance.cmbOutputFormat.Text.Trim();
            int spos = format.IndexOf(" - ");

            if (spos >= 0)
            {
                format = format.Substring(0, spos);
            }


            if (join_clips ||   frmClip.Instance.fplSegments.Controls.Count==1)
            {
                if (Properties.Settings.Default.OutputFolder.Trim() == TranslateHelper.Translate("Same as Video Folder"))
                {
                    if (Properties.Settings.Default.OutputFolder.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    {
                        str.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped" + System.IO.Path.GetExtension(frmClip.Instance.filepath)));
                    }
                    else
                    {
                        str.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped" + "." + format.ToLower()));
                    }
                }
                else
                {
                    if (Properties.Settings.Default.OutputFolder.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                    {
                        str.Add(System.IO.Path.Combine(Properties.Settings.Default.OutputFolder, System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped" + System.IO.Path.GetExtension(frmClip.Instance.filepath)));
                    }
                    else
                    {
                        str.Add(System.IO.Path.Combine(Properties.Settings.Default.OutputFolder, System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped" + "." + format.ToLower()));
                    }
                }
            }
            else
            {
                for (int k = 0; k < frmClip.Instance.fplSegments.Controls.Count; k++)
                {
                    if (Properties.Settings.Default.OutputFolder.Trim() == TranslateHelper.Translate("Same as Video Folder"))
                    {
                        if (Properties.Settings.Default.OutputFolder.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                        {
                            str.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k+1).ToString()+System.IO.Path.GetExtension(frmClip.Instance.filepath)));
                        }
                        else
                        {
                            str.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(frmClip.Instance.filepath), System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k+1).ToString()+"." + format.ToLower()));
                        }
                    }
                    else
                    {
                        if (Properties.Settings.Default.OutputFolder.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                        {
                            str.Add(System.IO.Path.Combine(Properties.Settings.Default.OutputFolder, System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" +(k+1).ToString()+ System.IO.Path.GetExtension(frmClip.Instance.filepath)));
                        }
                        else
                        {
                            str.Add(System.IO.Path.Combine(Properties.Settings.Default.OutputFolder, System.IO.Path.GetFileNameWithoutExtension(frmClip.Instance.filepath) + ".clipped-" + (k+1).ToString()+"." + format.ToLower()));
                        }
                    }
                }

            }

            return str;
        }*/

        public static string GetFinalOutputFilename(string filepath, string outputfolder, string format)
        {
            return GetFinalOutputFilename(filepath, -1, outputfolder, format);
        }

        public static string GetFinalOutputFilename(string filepath, int clipnum, string outputfolder, string format)
        {
            string newfilename = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", System.IO.Path.GetFileNameWithoutExtension(filepath));

            if (clipnum != -1)
            {
                newfilename = newfilename + ".part" + clipnum.ToString();
            }

            string final = "";

            if (format == TranslateHelper.Translate("Keep same Format as Source"))
            {
                final = System.IO.Path.Combine(outputfolder, newfilename + System.IO.Path.GetExtension(filepath));
            }
            else
            {
                final = System.IO.Path.Combine(outputfolder, newfilename + "." + format);
            }

            if (System.IO.File.Exists(final))
            {
                if (Properties.Settings.Default.OutputWhenExists == 0) // overwrite
                {
                    return final;
                }
                else if (Properties.Settings.Default.OutputWhenExists == 1)
                {
                    return "|||SKIP|||"+final;
                }
                else if (Properties.Settings.Default.OutputWhenExists == 2)
                {
                    //return "|||ASK|||";

                    if (!frmClip.Instance.OutputFileActionRepeat || (frmClip.Instance.OutputFileActionRepeat && frmOutputFileAsk.RepeatActionIndex == 2))
                    // if not repeat or for rename
                    {
                        frmOutputFileAsk fa = new frmOutputFileAsk(System.IO.Path.GetFileName(final), System.IO.Path.GetDirectoryName(final));

                        if (frmClip.Instance.OutputFileActionRepeat && frmOutputFileAsk.RepeatActionIndex == 2)
                        {
                            fa.rdRename.Checked = true;
                        }

                        if (fa.ShowDialog() == DialogResult.OK)
                        {
                            if (fa.rdSkip.Checked)
                            {
                                return "|||SKIP|||" + final;
                            }
                            else
                            {
                                return fa.txtNewFile.Text;
                            }
                        }
                    }
                    else
                    {
                        return frmOutputFileAsk.CalculateOutputFileRepeatAction(System.IO.Path.GetFileName(final), System.IO.Path.GetDirectoryName(final));
                    }
                }
                else if (Properties.Settings.Default.OutputWhenExists == 3) // suffix
                {
                    return GetFinalFilenameWithSuffix(final);
                }
                else if (Properties.Settings.Default.OutputWhenExists == 4) // prefix
                {
                    return GetFinalFilenameWithPrefix(final);
                }
            }

            return final;
        }

        public static string GetFinalFilenameWithSuffix(string filepath)
        {
            return GetFinalFilenameWithSuffix(filepath, Properties.Settings.Default.OutputSuffix);
        }

        public static string GetFinalFilenameWithSuffix(string filepath,string suffix)
        {
            string fw_ext = System.IO.Path.GetFileNameWithoutExtension(filepath);
            string ext = System.IO.Path.GetExtension(filepath);
            string folder = System.IO.Path.GetDirectoryName(filepath);

            int k = 1;

            string final = System.IO.Path.Combine(folder, fw_ext + suffix.Replace("[N]", k.ToString()) + ext);

            while (System.IO.File.Exists(final))
            {
                k++;

                final = System.IO.Path.Combine(folder, fw_ext + suffix.Replace("[N]", k.ToString()) + ext);
            }

            return final;
        }

        public static string GetFinalFilenameWithPrefix(string filepath)
        {
            return GetFinalFilenameWithPrefix(filepath, Properties.Settings.Default.OutputPrefix);
        }

        public static string GetFinalFilenameWithPrefix(string filepath,string prefix)
        {
            string fw_ext = System.IO.Path.GetFileNameWithoutExtension(filepath);
            string ext = System.IO.Path.GetExtension(filepath);
            string folder = System.IO.Path.GetDirectoryName(filepath);

            int k = 1;

            string final = System.IO.Path.Combine(folder, prefix.Replace("[N]", k.ToString()) + fw_ext + ext);

            while (System.IO.File.Exists(final))
            {
                k++;

                final = System.IO.Path.Combine(folder, prefix.Replace("[N]", k.ToString()) + fw_ext + ext);
            }

            return final;
        }
    }
}
