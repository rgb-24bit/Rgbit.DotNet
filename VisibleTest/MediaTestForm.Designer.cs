/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

namespace VisibleTest
{
    partial class MediaTestForm
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
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.remuseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.posTrackBar = new System.Windows.Forms.TrackBar();
            this.processLabel = new System.Windows.Forms.Label();
            this.volumeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectFileButton.Location = new System.Drawing.Point(12, 12);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(90, 38);
            this.SelectFileButton.TabIndex = 0;
            this.SelectFileButton.Text = "Select File";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButtonClick);
            // 
            // playButton
            // 
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Location = new System.Drawing.Point(108, 12);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(90, 38);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.PlayButtonClick);
            // 
            // pauseButton
            // 
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pauseButton.Location = new System.Drawing.Point(204, 12);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(90, 38);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButtonClick);
            // 
            // remuseButton
            // 
            this.remuseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remuseButton.Location = new System.Drawing.Point(300, 12);
            this.remuseButton.Name = "remuseButton";
            this.remuseButton.Size = new System.Drawing.Size(90, 38);
            this.remuseButton.TabIndex = 3;
            this.remuseButton.Text = "Remuse";
            this.remuseButton.UseVisualStyleBackColor = true;
            this.remuseButton.Click += new System.EventHandler(this.RemuseButtonClick);
            // 
            // stopButton
            // 
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Location = new System.Drawing.Point(396, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(90, 38);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // timeLabel
            // 
            this.timeLabel.Location = new System.Drawing.Point(602, 319);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(100, 23);
            this.timeLabel.TabIndex = 5;
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.LargeChange = 100;
            this.volumeTrackBar.Location = new System.Drawing.Point(108, 297);
            this.volumeTrackBar.Maximum = 1000;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(474, 45);
            this.volumeTrackBar.SmallChange = 100;
            this.volumeTrackBar.TabIndex = 6;
            this.volumeTrackBar.Scroll += new System.EventHandler(this.TrackBarScroll);
            // 
            // posTrackBar
            // 
            this.posTrackBar.Location = new System.Drawing.Point(108, 246);
            this.posTrackBar.Name = "posTrackBar";
            this.posTrackBar.Size = new System.Drawing.Size(474, 45);
            this.posTrackBar.TabIndex = 7;
            this.posTrackBar.Scroll += new System.EventHandler(this.PosTrackBarScroll);
            // 
            // processLabel
            // 
            this.processLabel.Location = new System.Drawing.Point(2, 246);
            this.processLabel.Name = "processLabel";
            this.processLabel.Size = new System.Drawing.Size(100, 45);
            this.processLabel.TabIndex = 8;
            this.processLabel.Text = "进度";
            this.processLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // volumeLabel
            // 
            this.volumeLabel.Location = new System.Drawing.Point(2, 297);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(100, 45);
            this.volumeLabel.TabIndex = 9;
            this.volumeLabel.Text = "音量";
            this.volumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MediaTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 351);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.processLabel);
            this.Controls.Add(this.posTrackBar);
            this.Controls.Add(this.volumeTrackBar);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.remuseButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.SelectFileButton);
            this.Name = "MediaTestForm";
            this.Text = "MediaTestForm";
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.Label processLabel;
        private System.Windows.Forms.TrackBar posTrackBar;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button remuseButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
