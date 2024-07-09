using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoWallpaperCreator
{
    public partial class frmSaveFrameImage : VideoWallpaperCreator.CustomForm
    {
        public frmSaveFrameImage()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveFrameOriginalSize=rdOriginalSize.Checked;

            Properties.Settings.Default.SaveFrameWidth=(int)nudWidth.Value;
            Properties.Settings.Default.SaveFrameHeight=(int)nudHeight.Value;

            Properties.Settings.Default.SaveFrameHeightChk = chkHeight.Checked;
            Properties.Settings.Default.SaveFrameWidthChk = chkWidth.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void rdOriginalSize_CheckedChanged(object sender, EventArgs e)
        {
            if (rdOriginalSize.Checked)
            {
                SetEnabled(false);
            }
        }

        private void SetEnabled(bool enabled)
        {
            chkWidth.Enabled = enabled;
            chkHeight.Enabled = enabled;
            nudWidth.Enabled = enabled;
            nudHeight.Enabled = enabled;
        }

        private void rdCustomSize_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCustomSize.Checked)
            {
                SetEnabled(true);
            }
        }

        private void frmSaveFrameImage_Load(object sender, EventArgs e)
        {
            rdOriginalSize.Checked = Properties.Settings.Default.SaveFrameOriginalSize;
            rdCustomSize.Checked = !Properties.Settings.Default.SaveFrameOriginalSize;

            nudWidth.Value = Properties.Settings.Default.SaveFrameWidth;
            nudHeight.Value = Properties.Settings.Default.SaveFrameHeight;

            chkHeight.Checked = Properties.Settings.Default.SaveFrameHeightChk;
            chkWidth.Checked = Properties.Settings.Default.SaveFrameWidthChk;
        }

        private void chkWidth_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkHeight.Checked && !chkWidth.Checked)
            {
                chkWidth.Checked = true;
            }
        }

        private void chkHeight_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkWidth.Checked && !chkHeight.Checked)
            {
                chkHeight.Checked = true;
            }
        }
    }
}
