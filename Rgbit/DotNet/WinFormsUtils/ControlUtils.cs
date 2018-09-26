/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Windows.Forms;

namespace Rgbit.DotNet.WinFormsUtils
{
    /// <summary>
    /// Utilities for Control.
    /// </summary>
    public class ControlUtils
    {   
        /// <summary>
        /// Make the foreground color of the control change automatically.
        /// 
        /// Not working very well for bright colors.
        /// </summary>
        /// <param name="ctrl">Control object.</param>
        public static void ControlForceColorAutoChange(Control ctrl) { 
            Action<object, EventArgs> ControlForeColorLight = (sender, e) => {
                Control ctrls = (Control) sender;
                ctrls.ForeColor = ControlPaint.LightLight(ctrls.ForeColor);
            };
            
             Action<object, EventArgs> ControlForeColorDark = (sender, e) => {
                Control ctrls = (Control) sender;
                ctrls.ForeColor = ControlPaint.DarkDark(ctrls.ForeColor);
            };
            
            ctrl.MouseEnter += new EventHandler(ControlForeColorDark);
            ctrl.MouseLeave += new EventHandler(ControlForeColorLight);
        }

        /// <summary>
        /// Make the background color of the control change automatically.
        /// 
        /// Not working very well for bright colors.
        /// </summary>
        /// <param name="ctrl">Control object.</param>
        public static void ControlBackColorAutoChange(Control ctrl) {
            Action<object, EventArgs> ControlBackColorLight = (sender, e) => {
                Control ctrls = (Control) sender;
                ctrls.BackColor = ControlPaint.LightLight(ctrls.BackColor);
            };
            
             Action<object, EventArgs> ControlBackColorDark = (sender, e) => {
                Control ctrls = (Control) sender;
                ctrls.BackColor = ControlPaint.DarkDark(ctrls.BackColor);
            };
            
            ctrl.MouseEnter += new EventHandler(ControlBackColorDark);
            ctrl.MouseLeave += new EventHandler(ControlBackColorLight);
        }
    }
}
