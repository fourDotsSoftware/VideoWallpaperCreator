using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace VideoCutterJoinerExpert
{
    public partial class StoryboardThumbnail : UserControl
    {
        public int Time = 0;
        private string _TimeString = "";

        public int ZoomIntervalMsecs = -1;
        public int DifWithNextFrame = 0;

        public int ControlIndex = -1;

        public string TimeString
        {
            get
            {
                return _TimeString;
            }
            set
            {
                _TimeString = value;
                lblPos.Text = value;
            }
        }

        public StoryboardThumbnail()
        {
            InitializeComponent();

            foreach (Control co in this.Controls)
            {
                co.Enter += co_Enter;
            }
        }

        void co_Enter(object sender, EventArgs e)
        {
            frmClip.Instance.lblScrollPos.Visible = false;
        }

        public void UpdateImage()
        {
            try
            {
                if (this.picThumbnail.Image == null)
                {
                    VideoThumbnail vt = new VideoThumbnail(frmClip.Instance.filepath, TimeString);
                    this.picThumbnail.Image = vt.ThumbnailImage;
                }
            }
            catch { }
        }

        private void StoryboardThumbnail_Load(object sender, EventArgs e)
        {
            this.picThumbnail.Cursor = Cursors.Hand;
            this.picThumbnail.Click += picThumbnail_Click;

            this.lblPos.Cursor = Cursors.Hand;
            this.lblPos.Click += picThumbnail_Click;
        }

        void picThumbnail_Click(object sender, EventArgs e)
        {
            frmClip.Instance.msPositionValue = this.Time;
            
            frmClip.Instance.SeekPosition();
        }        

        private void setClipStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClip.Instance.msPositionValue = this.Time;
            frmClip.Instance.btnSetClipStart_Click(null, null);
        }

        private void setClipEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClip.Instance.msPositionValue = this.Time;
            frmClip.Instance.btnSetEnd_Click(null, null);
        }
    }
}
