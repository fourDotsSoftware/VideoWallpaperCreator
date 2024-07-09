using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoWallpaperCreator
{
    public partial class frmOutputFilepath : VideoWallpaperCreator.CustomForm
    {
        public frmOutputFilepath()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = Module.OpenFilesFilter;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilepath.Text = openFileDialog1.FileName;
            }

        }

        private void frmOutputFilepath_Load(object sender, EventArgs e)
        {
            txtFilepath.Text = frmMain.Instance.ExplicitOutputFilepath;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmMain.Instance.ExplicitOutputFilepath = txtFilepath.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}
