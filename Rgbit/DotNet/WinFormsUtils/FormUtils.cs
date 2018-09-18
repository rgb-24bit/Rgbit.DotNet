/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Rgbit.DotNet.WinFormsUtils
{
    /// <summary>
    /// Utilities for Form.
    /// </summary>
    public class FormUtils
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        
        /// <summary>
        /// Practical mouse moves Form without borders.
        /// </summary>
        /// <param name="form">The form to be moved.</param>
        public static void FormMourseMove(Form form) {
            ReleaseCapture();
            SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        
        /// <summary>
        /// Practical mouse moves Form without borders.
        /// </summary>
        public static void FormMouseMoveHandle(object sender, EventArgs e) {
            FormMourseMove((Form) sender);
        }
    }
}
