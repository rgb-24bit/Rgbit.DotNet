/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

namespace VisibleTest
{
    partial class MainForm
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
            this.mediaTestButton = new System.Windows.Forms.Button();
            this.winformsTestButton = new System.Windows.Forms.Button();
            this.imageProcessTestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mediaTestButton
            // 
            this.mediaTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mediaTestButton.Location = new System.Drawing.Point(12, 12);
            this.mediaTestButton.Name = "mediaTestButton";
            this.mediaTestButton.Size = new System.Drawing.Size(103, 35);
            this.mediaTestButton.TabIndex = 0;
            this.mediaTestButton.Text = "Media Test";
            this.mediaTestButton.UseVisualStyleBackColor = true;
            this.mediaTestButton.Click += new System.EventHandler(this.MediaTestButtonClick);
            // 
            // winformsTestButton
            // 
            this.winformsTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winformsTestButton.Location = new System.Drawing.Point(121, 12);
            this.winformsTestButton.Name = "winformsTestButton";
            this.winformsTestButton.Size = new System.Drawing.Size(103, 35);
            this.winformsTestButton.TabIndex = 1;
            this.winformsTestButton.Text = "WinForms Test";
            this.winformsTestButton.UseVisualStyleBackColor = true;
            this.winformsTestButton.Click += new System.EventHandler(this.WinformsTestButtonClick);
            // 
            // imageProcessTestButton
            // 
            this.imageProcessTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageProcessTestButton.Location = new System.Drawing.Point(230, 12);
            this.imageProcessTestButton.Name = "imageProcessTestButton";
            this.imageProcessTestButton.Size = new System.Drawing.Size(103, 35);
            this.imageProcessTestButton.TabIndex = 2;
            this.imageProcessTestButton.Text = "ImageProcess Test";
            this.imageProcessTestButton.UseVisualStyleBackColor = true;
            this.imageProcessTestButton.Click += new System.EventHandler(this.ImageProcessTestButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 353);
            this.Controls.Add(this.imageProcessTestButton);
            this.Controls.Add(this.winformsTestButton);
            this.Controls.Add(this.mediaTestButton);
            this.Name = "MainForm";
            this.Text = "VisibleTest";
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Button imageProcessTestButton;
        private System.Windows.Forms.Button winformsTestButton;
        private System.Windows.Forms.Button mediaTestButton;
    }
}
