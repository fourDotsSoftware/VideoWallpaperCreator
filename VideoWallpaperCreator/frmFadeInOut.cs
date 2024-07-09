using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoWallpaperCreator
{
    public partial class frmFadeInOut : VideoWallpaperCreator.CustomForm
    {
        

        public frmFadeInOut()
        {
            InitializeComponent();
        }

        private void chkFadeInSecs_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFadeInSecs.Checked)
            {
                chkFadeInFrames.Checked = false;
            }

            if (!chkFadeInSecs.Checked)
            {
                if (!chkFadeInFrames.Checked)
                {
                    chkFadeInSecs.Checked = true;
                }
            }
            
        }

        private void chkFadeOutSeconds_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFadeOutSeconds.Checked)
            {
                chkFadeOutFrames.Checked = false;
            }

            if (!chkFadeOutSeconds.Checked)
            {
                if (!chkFadeOutFrames.Checked)
                {
                    chkFadeOutSeconds.Checked = true;
                }
            }
        }

        private void chkFadeInFrames_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFadeInFrames.Checked)
            {
                chkFadeInSecs.Checked = false;
            }

            if (!chkFadeInFrames.Checked)
            {
                if (!chkFadeInSecs.Checked)
                {
                    chkFadeInFrames.Checked = true;
                }
            }
        }

        private void chkFadeOutFrames_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFadeOutFrames.Checked)
            {
                chkFadeOutSeconds.Checked = false;
            }

            if (!chkFadeOutFrames.Checked)
            {
                if (!chkFadeOutSeconds.Checked)
                {
                    chkFadeOutFrames.Checked = true;
                }
            }
        }

        private void chkFadeIn_CheckedChanged(object sender, EventArgs e)
        {
            chkFadeInSecs.Enabled = chkFadeIn.Checked;
            chkFadeInFrames.Enabled = chkFadeIn.Checked;
            nudFadeInFrames.Enabled = chkFadeIn.Checked;
            nudFadeInSeconds.Enabled = chkFadeIn.Checked;

        }

        private void chkFadeOut_CheckedChanged(object sender, EventArgs e)
        {
            chkFadeOutSeconds.Enabled = chkFadeOut.Checked;
            chkFadeOutFrames.Enabled = chkFadeOut.Checked;
            nudFadeOutFrames.Enabled = chkFadeOut.Checked;
            nudFadeOutSeconds.Enabled = chkFadeOut.Checked;
        }

        private void frmFadeInOut_Load(object sender, EventArgs e)
        {
            chkFadeIn.Checked = Properties.Settings.Default.FadeIn; 
            chkFadeOut.Checked = Properties.Settings.Default.FadeOut;
            chkFadeInSecs.Checked = Properties.Settings.Default.FadeInSeconds;
            nudFadeInSeconds.Value = Properties.Settings.Default.FadeInSecondsVal;
            chkFadeOutSeconds.Checked = Properties.Settings.Default.FadeOutSeconds;
            nudFadeOutSeconds.Value = Properties.Settings.Default.FadeOutSecondsVal;
            chkFadeInFrames.Checked = Properties.Settings.Default.FadeInFrames;
            nudFadeInFrames.Value = Properties.Settings.Default.FadeInFramesVal;
            chkFadeOutFrames.Checked = Properties.Settings.Default.FadeOutFrames;
            nudFadeOutFrames.Value = Properties.Settings.Default.FadeOutFramesVal;
            chkFadeSeparate.Checked = Properties.Settings.Default.FadeSeparately;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FadeIn = chkFadeIn.Checked;
            Properties.Settings.Default.FadeOut=chkFadeOut.Checked;
            Properties.Settings.Default.FadeInSeconds=chkFadeInSecs.Checked;
            Properties.Settings.Default.FadeInSecondsVal=nudFadeInSeconds.Value;
            Properties.Settings.Default.FadeOutSeconds=chkFadeOutSeconds.Checked;
            Properties.Settings.Default.FadeOutSecondsVal=nudFadeOutSeconds.Value;
            Properties.Settings.Default.FadeInFrames=chkFadeInFrames.Checked;
            Properties.Settings.Default.FadeInFramesVal=(int)nudFadeInFrames.Value;
            Properties.Settings.Default.FadeOutFrames=chkFadeOutFrames.Checked;
            Properties.Settings.Default.FadeOutFramesVal=(int)nudFadeOutFrames.Value;
            Properties.Settings.Default.FadeSeparately=chkFadeSeparate.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            chkFadeIn.Checked = true;
            chkFadeOut.Checked = true;
            nudFadeInFrames.Value = (decimal)5;
            nudFadeInSeconds.Value = (decimal)2.0;
            nudFadeOutFrames.Value = (decimal)5;
            nudFadeOutSeconds.Value = (decimal)2.0;
            chkFadeInFrames.Checked = false;
            chkFadeInSecs.Checked = true;
            chkFadeOutFrames.Checked = false;
            chkFadeOutSeconds.Checked = true;
            chkFadeSeparate.Checked = false;
        }
    }
}
