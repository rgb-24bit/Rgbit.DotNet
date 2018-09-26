﻿/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

using Rgbit.DotNet.DrawUtils;

namespace VisibleTest
{
    /// <summary>
    /// Test image process using the Windows window application.
    /// </summary>
    public partial class ImageProcessTestForm : Form
    {
        public ImageProcessTestForm()
        {
            InitializeComponent();
        }
        
        void SelectFileButtonClick(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            srcImage.Load(openFileDialog.FileName);
        }
        
        void SwapRgbButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.SwapRgb(srcImage.Image, "gbr");
        }
        
        void SwapArgbButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.SwapArgb(srcImage.Image, "gbar");
        }
        
        void GrayButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.Gray(srcImage.Image);
        }
        
        void InvertButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.Invert(srcImage.Image);
        }
    }
}
