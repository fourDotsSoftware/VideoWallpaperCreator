using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace VideoWallpaperCreator
{
    public partial class frmBatchResult : VideoWallpaperCreator.CustomForm
    {
        public frmBatchResult()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void tvSuccess_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string file = e.Node.Text;

            System.Diagnostics.Process.Start(file);
        }

        private void cmsVideos_Opening(object sender, CancelEventArgs e)
        {
            if (tvSuccess.SelectedNode == null)
            {
                e.Cancel = true;
            }
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = tvSuccess.SelectedNode.Text;

            System.Diagnostics.Process.Start(filepath);
        }

        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = tvSuccess.SelectedNode.Text;

            string args = string.Format("/e, /select, \"{0}\"", filepath);

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);
        }

        private void copyFullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = tvSuccess.SelectedNode.Text;

            Clipboard.Clear();

            Clipboard.SetText(filepath);
        }

        private void videoInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = tvSuccess.SelectedNode.Text;

            frmVideoInfo f = new frmVideoInfo(filepath);

            f.ShowDialog();
        }

        private void tvSuccess_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                TreeViewHitTestInfo hiti = tvSuccess.HitTest(e.X, e.Y);

                if (hiti.Node != null)
                {
                    tvSuccess.SelectedNode = hiti.Node;
                }
                else
                {
                    tvSuccess.SelectedNode = null;
                }

            }
        }

        private void tvSuccess_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null)
            {
                tvSuccess.SelectedNode = e.Node;
            }
        }
    }
}
