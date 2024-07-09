using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoWallpaperCreator
{
    public partial class frmMsgCheckBox : VideoWallpaperCreator.CustomForm
    {
        public enum MsgModeEnum
        {
            TestAdvised,
            OnTestStart,
            OnTestEnd
        }

        public MsgModeEnum MsgMode;

        public frmMsgCheckBox()
        {
            InitializeComponent();
        }

        public frmMsgCheckBox(MsgModeEnum msgmode,string msg):this()
        {
            MsgMode = msgmode;
            lblMsg.Text = msg;
            lblMsg.Left = this.ClientRectangle.Width / 2 - lblMsg.Width / 2;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkDoNotShowAgain.Checked)
            {
                if (MsgMode == MsgModeEnum.TestAdvised)
                {
                    Properties.Settings.Default.ShowMsgTest = false;
                }
                else if (MsgMode == MsgModeEnum.OnTestStart)
                {
                    Properties.Settings.Default.ShowMsgTestStart = false;
                }
                else if (MsgMode == MsgModeEnum.OnTestEnd)
                {
                    Properties.Settings.Default.ShowMsgTestEnd = false;
                }
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
