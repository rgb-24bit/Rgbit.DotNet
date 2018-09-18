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
        /// Use ControlPaint.LightLight to lighten the foreground of the control.
        /// </summary>
        public static void ControlForeColorLightHandle(object sender, EventArgs e) {
            ControlForeColorLight((Control) sender);
        }
        
        /// <summary>
        /// Use ControlPaint.DarkDark to darken the foreground of the control.
        /// </summary>
        public static void ControlForeColorDarkHandle(object sender, EventArgs e) {
            ControlForeColorDark((Control) sender);
        }
        
        /// <summary>
        /// Make the foreground color of the control change automatically, like a button.
        /// </summary>
        /// <param name="ctrl">Control object.</param>
        public static void ControlForceColorAutoChange(Control ctrl) {
            ctrl.MouseEnter += new EventHandler(ControlForeColorDarkHandle);
            ctrl.MouseLeave += new EventHandler(ControlForeColorLightHandle);
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
        /// Use ControlPaint.LightLight to lighten the background of the control.
        /// </summary>
        public static void ControlBackColorLightHandle(object sender, EventArgs e) {
            ControlBackColorLight((Control) sender);
        }
        
        /// <summary>
        /// Use ControlPaint.DarkDark to darken the background of the control.
        /// </summary>
        public static void ControlBackColorDarkHandle(object sender, EventArgs e) {
            ControlBackColorDark((Control) sender);
        }
        
        /// <summary>
        /// Make the background color of the control change automatically, like a button.
        /// </summary>
        /// <param name="ctrl">Control object.</param>
        public static void ControlBackColorAutoChange(Control ctrl) {
            ctrl.MouseEnter += new EventHandler(ControlBackColorDarkHandle);
            ctrl.MouseLeave += new EventHandler(ControlBackColorLightHandle);
        }
    }
}
