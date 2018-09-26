/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

using Rgbit.DotNet.WinFormsUtils;

namespace VisibleTest
{
    /// <summary>
    /// Test WinFormsUtils using the Windows window application.
    /// </summary>
    public partial class WinFormsTestForm : Form
    {
        public WinFormsTestForm()
        {
            InitializeComponent();
        }
        
        void WinFormsTestFormMouseMove(object sender, MouseEventArgs e)
        {
            // FormMoveWithMouse Test
            FormUtils.FormMoveWithMouse(this);
        }
        
        void WinFormsTestFormLoad(object sender, EventArgs e)
        {
            // back and fore color test
            ControlUtils.ControlBackColorAutoChange(backColorLabel);
            ControlUtils.ControlForceColorAutoChange(foreColorLabel);
            
            ControlUtils.ControlBackColorAutoChange(closeLabel);
        }
        
        void CloseLabelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
