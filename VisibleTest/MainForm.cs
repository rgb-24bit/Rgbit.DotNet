/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VisibleTest
{
    /// <summary>
    /// Test using the Windows window application.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        void MediaTestButtonClick(object sender, EventArgs e)
        {
            (new MediaTestForm()).ShowDialog();
        }
        
        void WinformsTestButtonClick(object sender, EventArgs e)
        {
            (new WinFormsTestForm()).ShowDialog();
        }
    }
}
