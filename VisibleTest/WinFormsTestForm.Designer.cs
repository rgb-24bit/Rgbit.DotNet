/**
 * Copyright (c) 2018 - 2019 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

namespace VisibleTest
{
    partial class WinFormsTestForm
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
            this.backColorLabel = new System.Windows.Forms.Label();
            this.foreColorLabel = new System.Windows.Forms.Label();
            this.closeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backColorLabel
            // 
            this.backColorLabel.BackColor = System.Drawing.SystemColors.Highlight;
            this.backColorLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.backColorLabel.Location = new System.Drawing.Point(13, 13);
            this.backColorLabel.Name = "backColorLabel";
            this.backColorLabel.Size = new System.Drawing.Size(100, 23);
            this.backColorLabel.TabIndex = 0;
            this.backColorLabel.Text = "Back Color";
            this.backColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // foreColorLabel
            // 
            this.foreColorLabel.BackColor = System.Drawing.SystemColors.Control;
            this.foreColorLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.foreColorLabel.ForeColor = System.Drawing.Color.Blue;
            this.foreColorLabel.Location = new System.Drawing.Point(119, 13);
            this.foreColorLabel.Name = "foreColorLabel";
            this.foreColorLabel.Size = new System.Drawing.Size(100, 23);
            this.foreColorLabel.TabIndex = 1;
            this.foreColorLabel.Text = "Fore Color";
            this.foreColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeLabel
            // 
            this.closeLabel.BackColor = System.Drawing.SystemColors.Highlight;
            this.closeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.closeLabel.Location = new System.Drawing.Point(364, 13);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(100, 23);
            this.closeLabel.TabIndex = 2;
            this.closeLabel.Text = "Close";
            this.closeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeLabel.Click += new System.EventHandler(this.CloseLabelClick);
            // 
            // WinFormsTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 357);
            this.Controls.Add(this.closeLabel);
            this.Controls.Add(this.foreColorLabel);
            this.Controls.Add(this.backColorLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinFormsTestForm";
            this.Text = "WinFormsTestForm";
            this.Load += new System.EventHandler(this.WinFormsTestFormLoad);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinFormsTestFormMouseMove);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Label closeLabel;
        private System.Windows.Forms.Label foreColorLabel;
        private System.Windows.Forms.Label backColorLabel;
    }
}
