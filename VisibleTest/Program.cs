/**
 * Copyright (c) 2018 - 2019 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Windows.Forms;

namespace VisibleTest
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        
    }
}
