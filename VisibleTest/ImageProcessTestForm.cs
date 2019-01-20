/**
 * Copyright (c) 2018 - 2019 by rgb-24bit.
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
        private int degree = 0;
        
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

        void GrayButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.Gray(srcImage.Image);
        }
        
        void InvertButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.Invert(srcImage.Image);
        }
        
        void ClipRectButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.ClipRectangle(srcImage.Image, 40, 40, 400, 400);
        }
        
        void ClipEllipseButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.ClipEllipse(srcImage.Image, 40, 40, 400, 400,
                                                      SystemColors.Control);
        }
        
        void RotateButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.Rotate(srcImage.Image, degree++);
        }

        void AtomButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.Atomization(srcImage.Image);
        }
        
        void MosaicButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.Mosaic(srcImage.Image, 15);
        }
        
        void SoftenButtonClick(object sender, EventArgs e)
        {
             resImage.Image = ImageFilter.SoftenFilter(srcImage.Image);
        }
        
        void EmbossButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageFilter.EmbossFilter(srcImage.Image);
        }
        
        void SharpenButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageFilter.SharpenFilter(srcImage.Image);
        }
        
        void ClosetoButtonClick(object sender, EventArgs e)
        {
            resImage.Image = ImageProcess.CloseTo(resImage.Image, srcImage.Image, 0.1);
        }
    }
}
