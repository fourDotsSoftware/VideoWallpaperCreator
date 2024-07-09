using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoWallpaperCreator
{
    public partial class frmSplitByParts : VideoWallpaperCreator.CustomForm
    {
        public frmSplitByParts()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void chkEqualParts_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEqualParts.Checked)
            {
                chkTime.Checked = false;
                chkFileSize.Checked = false;
            }
            else if (!chkTime.Checked)
            {
                chkEqualParts.Checked = true;
            }           
        }

        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTime.Checked)
            {
                chkEqualParts.Checked = false;
                chkFileSize.Checked = false;
            }
            else if (!chkEqualParts.Checked)
            {
                chkTime.Checked = true;
            }
        }

        private void chkFileSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFileSize.Checked)
            {
                chkTime.Checked = false;
                chkEqualParts.Checked = false;
            }
        }

        private void nudEqualParts_Enter(object sender, EventArgs e)
        {
            chkEqualParts.Checked = true;
        }

        private void mskTime_Enter(object sender, EventArgs e)
        {
            chkTime.Checked = true;
        }

        private void mskFilesize_Enter(object sender, EventArgs e)
        {
            chkFileSize.Checked = true;
        }

        private void frmSplitByParts_Load(object sender, EventArgs e)
        {
            cmbFilesize.SelectedIndex = 1;
        }

        private void txtFilesize_Enter(object sender, EventArgs e)
        {
            chkFileSize.Checked = true;
        }
    }
}
