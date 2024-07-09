using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace VideoWallpaperCreator
{
    class VideoConverterHelper
    {
    }

    public class GetJoinArgsResult
    {
        public int MoveToKAfterwards = -1;
        public List<string> JoinArgs = new List<string>();
        public List<int> JoinArgsRow = new List<int>();
        public List<string> JoinFilesToDelete = new List<string>();
        
    }

    public class GetSplitArgsResult
    {
        public int MoveToKAfterwards = -1;
        public List<string> SplitArgs = new List<string>();
        public List<int> SplitArgsRow = new List<int>();
        public List<string> SplitFilesToDelete = new List<string>();
    }

    public class KeyMessageFilter : IMessageFilter
    {
        private enum KeyMessages
        {
            WM_KEYFIRST = 0x100,
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_CHAR = 0x102,            
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105,
            WM_SYSCHAR = 0x0106,
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetParent(IntPtr hwnd);

        // We check the events agains this control to only handle
        // key event that happend inside this control.
        Control _control;

        public KeyMessageFilter()
        { }

        public KeyMessageFilter(Control c)
        {
            _control = c;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == (int)KeyMessages.WM_KEYDOWN)
            {
                if (_control != null)
                {
                    IntPtr hwnd = m.HWnd;
                    IntPtr handle = _control.Handle;
                    while (hwnd != IntPtr.Zero && handle != hwnd)
                    {
                        hwnd = GetParent(hwnd);
                    }
                    if (hwnd == IntPtr.Zero) // Didn't found the window. We are not interested in the event.
                        return false;
                }
                Keys key = (Keys)m.WParam;

                if (frmClip.Instance.ActiveControl is MaskedTextBox ||
                    frmClip.Instance.ActiveControl is ComboBox ||
                    frmClip.Instance.ActiveControl is MediaSegment)
                {
                    return false;
                }

                switch (key)
                {
                    case Keys.Left:

                        if ((Control.ModifierKeys & Keys.Shift) != Keys.Shift
                        && (Control.ModifierKeys & Keys.Control) != Keys.Control)
                        {
                            frmClip.Instance.tsbMoveBackMsec_Click(null, null);
                        }
                        else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift
                        && (Control.ModifierKeys & Keys.Control) == Keys.Control)
                        {
                            frmClip.Instance.tsbMoveBack3Min_Click(null, null);
                        }
                        else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                        {
                            frmClip.Instance.tsbMoveBack1Sec_Click(null, null);
                        }
                        else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                        {
                            frmClip.Instance.tsbMoveBack30Sec_Click(null, null);
                        }

                        return true;
                    case Keys.Right:
                        if ((Control.ModifierKeys & Keys.Shift) != Keys.Shift
                        && (Control.ModifierKeys & Keys.Control) != Keys.Control)
                        {
                            frmClip.Instance.tsbMoveForwardMsec_Click(null, null);
                        }
                        else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift
                        && (Control.ModifierKeys & Keys.Control) == Keys.Control)
                        {
                            frmClip.Instance.tsbMoveForward3Min_Click(null, null);
                        }
                        else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                        {
                            frmClip.Instance.tsbMoveForward1Sec_Click(null, null);
                        }
                        else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                        {
                            frmClip.Instance.tsbMoveForward30Sec_Click(null, null);
                        }

                        return true;
                        
                    default:

                        return false;
                }
            }
            return false;
        }
    }
}
