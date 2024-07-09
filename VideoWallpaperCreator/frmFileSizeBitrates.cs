using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace VideoWallpaperCreator
{
    public partial class frmFileSizeBitrates : VideoWallpaperCreator.CustomForm
    {
        public frmFileSizeBitrates()
        {
            InitializeComponent();
        }

        private void frmFileSizeBitrates_Load(object sender, EventArgs e)
        {
            cmbSizeType.SelectedIndex = 0;

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.VideoOptionsFile);

                XmlNodeList nolos = doc.SelectNodes("//Format");

                for (int k = 0; k < nolos.Count; k++)
                {
                    cmbFormats.Items.Add(nolos[k].InnerText);
                }
            }
            catch
            {
                Module.ShowError("Error ! Could not load Video Options File !");
            }
            
         
            int idur=(int)(frmMain.Instance.CurrentTotalJoinDuration/1000);
            lblDuration.Text = idur.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            decimal decvb = decimal.Round(nudVideoBitrate.Value, 2);
            decimal decab = decimal.Round(nudAudioBitrate.Value, 2);
            Properties.Settings.Default.OFVideoBitrate = decvb.ToString()+"k";
            Properties.Settings.Default.OFAudioBitrate = decab.ToString()+"k";
            Properties.Settings.Default.OFTwoPass = true;

            string format = cmbFormats.Text;

            if (format.IndexOf("|") > 0)
            {
                int epos = format.IndexOf("|");

                format = format.Substring(0, epos);
            }

            format = format;

            if (Properties.Settings.Default.OF1stPassParameters.IndexOf(" -f ") < 0)
            {
                Properties.Settings.Default.OF1stPassParameters += " -f " + format;
            }
            else
            {
                int fspos = Properties.Settings.Default.OF1stPassParameters.IndexOf(" -f ") + " -f ".Length;
                int fepos = Properties.Settings.Default.OF1stPassParameters.IndexOf(" ", fspos);

                if (fepos >= 0)
                {
                    Properties.Settings.Default.OF1stPassParameters =
                        Properties.Settings.Default.OF1stPassParameters.Substring(0, fspos)
                        + format + Properties.Settings.Default.OF1stPassParameters.Substring(fepos);
                }
                else
                {
                    Properties.Settings.Default.OF1stPassParameters =
                        Properties.Settings.Default.OF1stPassParameters.Substring(0, fspos)
                        + format;
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CalculateBitrates()
        {
            decimal filesize = nudFileSize.Value;

            if (cmbSizeType.SelectedIndex == 0)
            {
                filesize = filesize * 1024;
            }
            else if (cmbSizeType.SelectedIndex == 1)
            {
                filesize = filesize * 1024 * 1024;
            }

            filesize = filesize * 8;

            int duration = frmMain.Instance.CurrentTotalJoinDuration;
            duration = duration / 1000;

            decimal decduration = (decimal)duration;

            decimal bitrate = filesize / decduration;

            if (chkVideoBitrate.Checked)
            {
                try
                {
                    nudVideoBitrate.Value = bitrate - nudAudioBitrate.Value;
                }
                catch
                {
                    Module.ShowMessage("Error. Incorrect values.");
                }
            }
            else
            {
                try
                {
                    nudAudioBitrate.Value = bitrate - nudVideoBitrate.Value;
                }
                catch
                {
                    Module.ShowMessage("Error. Incorrect values.");
                }
            }
        }

        private void btnCalculateBitrates_Click(object sender, EventArgs e)
        {
            CalculateBitrates();
            btnSetBitrates.Enabled = true;
        }

        private void chkVideoBitrate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVideoBitrate.Checked)
            {
                chkAudioBitrate.Checked = false;
            }
        }

        private void chkAudioBitrate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAudioBitrate.Checked)
            {
                chkVideoBitrate.Checked = false;
            }
        }
    }
}
