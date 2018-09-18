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
        /// Use ControlPaint.LightLight to lighten the foreground of the control.
        /// </summary>
        /// <param name="ctrl">Control object.</param>
        public static void ControlForeColorLight(Control ctrl) {
            ctrl.ForeColor = ControlPaint.LightLight(ctrl.ForeColor);
        }
        
        /// <summary>
        /// Use ControlPaint.DarkDark to darken the foreground of the control.
        /// </summary>
        /// <param name="ctrl">Control object.</param>
        public static void ControlForeColorDark(Control ctrl) {
            ctrl.ForeColor = ControlPaint.DarkDark(ctrl.ForeColor);
        }
        
        /// <summary>
        /// Make the foreground color of the control change automatically, like a button.
        /// </summary>
        /// <param name="ctrl">Control object.</param>
        public static void ControlForceColorAutoChange(Control ctrl) { 
            ctrl.MouseEnter += new EventHandler(
                (sender, e) => ControlForeColorDark((Control) sender));
            ctrl.MouseLeave += new EventHandler(
                (sender, e) => ControlForeColorLight((Control) sender));
        }
        
        /// <summary>
        /// Use ControlPaint.LightLight to lighten the background of the control.
        /// </summary>
        /// <param name="ctrl">Control object.</param>
        public static void ControlBackColorLight(Control ctrl) {
            ctrl.BackColor = ControlPaint.LightLight(ctrl.BackColor);
        }
        
        /// <summary>
        /// Use ControlPaint.DarkDark to darken the background of the control.
        /// </summary>
        /// <param name="ctrl">Control object.</param>
        public static void ControlBackColorDark(Control ctrl) {
            ctrl.BackColor = ControlPaint.DarkDark(ctrl.BackColor);
        }
        
        /// <summary>
        /// Make the background color of the control change automatically, like a button.
        /// </summary>
        /// <param name="ctrl">Control object.</param>
        public static void ControlBackColorAutoChange(Control ctrl) {
            ctrl.MouseEnter += new EventHandler(
               (sender, e) => ControlBackColorDark((Control) sender));
            ctrl.MouseLeave += new EventHandler(
               (sender, e) => ControlBackColorLight((Control) sender));
        }
    }
}
