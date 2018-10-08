﻿/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

namespace VisibleTest
{
    partial class ImageProcessTestForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.srcImage = new System.Windows.Forms.PictureBox();
            this.resImage = new System.Windows.Forms.PictureBox();
            this.swapRgbButton = new System.Windows.Forms.Button();
            this.swapArgbButton = new System.Windows.Forms.Button();
            this.grayButton = new System.Windows.Forms.Button();
            this.invertButton = new System.Windows.Forms.Button();
            this.clipRectButton = new System.Windows.Forms.Button();
            this.clipEllipseButton = new System.Windows.Forms.Button();
            this.rotateButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.srcImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resImage)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectFileButton.Location = new System.Drawing.Point(292, 12);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(90, 38);
            this.SelectFileButton.TabIndex = 1;
            this.SelectFileButton.Text = "Select File";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButtonClick);
            // 
            // srcImage
            // 
            this.srcImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.srcImage.Location = new System.Drawing.Point(12, 12);
            this.srcImage.Name = "srcImage";
            this.srcImage.Size = new System.Drawing.Size(254, 340);
            this.srcImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.srcImage.TabIndex = 2;
            this.srcImage.TabStop = false;
            // 
            // resImage
            // 
            this.resImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resImage.Location = new System.Drawing.Point(407, 12);
            this.resImage.Name = "resImage";
            this.resImage.Size = new System.Drawing.Size(254, 340);
            this.resImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resImage.TabIndex = 3;
            this.resImage.TabStop = false;
            // 
            // swapRgbButton
            // 
            this.swapRgbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.swapRgbButton.Location = new System.Drawing.Point(292, 56);
            this.swapRgbButton.Name = "swapRgbButton";
            this.swapRgbButton.Size = new System.Drawing.Size(90, 38);
            this.swapRgbButton.TabIndex = 4;
            this.swapRgbButton.Text = "Swap Rgb";
            this.swapRgbButton.UseVisualStyleBackColor = true;
            this.swapRgbButton.Click += new System.EventHandler(this.SwapRgbButtonClick);
            // 
            // swapArgbButton
            // 
            this.swapArgbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.swapArgbButton.Location = new System.Drawing.Point(292, 100);
            this.swapArgbButton.Name = "swapArgbButton";
            this.swapArgbButton.Size = new System.Drawing.Size(90, 38);
            this.swapArgbButton.TabIndex = 5;
            this.swapArgbButton.Text = "Swap Argb";
            this.swapArgbButton.UseVisualStyleBackColor = true;
            this.swapArgbButton.Click += new System.EventHandler(this.SwapArgbButtonClick);
            // 
            // grayButton
            // 
            this.grayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grayButton.Location = new System.Drawing.Point(292, 144);
            this.grayButton.Name = "grayButton";
            this.grayButton.Size = new System.Drawing.Size(90, 38);
            this.grayButton.TabIndex = 6;
            this.grayButton.Text = "Gray";
            this.grayButton.UseVisualStyleBackColor = true;
            this.grayButton.Click += new System.EventHandler(this.GrayButtonClick);
            // 
            // invertButton
            // 
            this.invertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invertButton.Location = new System.Drawing.Point(292, 188);
            this.invertButton.Name = "invertButton";
            this.invertButton.Size = new System.Drawing.Size(90, 38);
            this.invertButton.TabIndex = 7;
            this.invertButton.Text = "Invert";
            this.invertButton.UseVisualStyleBackColor = true;
            this.invertButton.Click += new System.EventHandler(this.InvertButtonClick);
            // 
            // clipRectButton
            // 
            this.clipRectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clipRectButton.Location = new System.Drawing.Point(292, 232);
            this.clipRectButton.Name = "clipRectButton";
            this.clipRectButton.Size = new System.Drawing.Size(90, 38);
            this.clipRectButton.TabIndex = 8;
            this.clipRectButton.Text = "ClipRect";
            this.clipRectButton.UseVisualStyleBackColor = true;
            this.clipRectButton.Click += new System.EventHandler(this.ClipRectButtonClick);
            // 
            // clipEllipseButton
            // 
            this.clipEllipseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clipEllipseButton.Location = new System.Drawing.Point(292, 276);
            this.clipEllipseButton.Name = "clipEllipseButton";
            this.clipEllipseButton.Size = new System.Drawing.Size(90, 38);
            this.clipEllipseButton.TabIndex = 9;
            this.clipEllipseButton.Text = "ClipEllipse";
            this.clipEllipseButton.UseVisualStyleBackColor = true;
            this.clipEllipseButton.Click += new System.EventHandler(this.ClipEllipseButtonClick);
            // 
            // rotateButton
            // 
            this.rotateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotateButton.Location = new System.Drawing.Point(292, 320);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(90, 38);
            this.rotateButton.TabIndex = 10;
            this.rotateButton.Text = "Rotate";
            this.rotateButton.UseVisualStyleBackColor = true;
            this.rotateButton.Click += new System.EventHandler(this.RotateButtonClick);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // ImageProcessTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 364);
            this.Controls.Add(this.rotateButton);
            this.Controls.Add(this.clipEllipseButton);
            this.Controls.Add(this.clipRectButton);
            this.Controls.Add(this.invertButton);
            this.Controls.Add(this.grayButton);
            this.Controls.Add(this.swapArgbButton);
            this.Controls.Add(this.swapRgbButton);
            this.Controls.Add(this.resImage);
            this.Controls.Add(this.srcImage);
            this.Controls.Add(this.SelectFileButton);
            this.Name = "ImageProcessTestForm";
            this.Text = "ImageProcessTest";
            ((System.ComponentModel.ISupportInitialize)(this.srcImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resImage)).EndInit();
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button rotateButton;
        private System.Windows.Forms.Button clipEllipseButton;
        private System.Windows.Forms.Button clipRectButton;
        private System.Windows.Forms.Button invertButton;
        private System.Windows.Forms.Button grayButton;
        private System.Windows.Forms.Button swapArgbButton;
        private System.Windows.Forms.Button swapRgbButton;
        private System.Windows.Forms.PictureBox resImage;
        private System.Windows.Forms.PictureBox srcImage;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
