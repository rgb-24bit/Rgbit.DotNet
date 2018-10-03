/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

using Rgbit.DotNet.MediaUtils;
using Rgbit.DotNet.TimeUtils;

namespace VisibleTest
{
    /// <summary>
    /// Test MediaUtils using the Windows window application.
    /// </summary>
    public partial class MediaTestForm : Form
    {
        MCIPlayer player = null;
        
        public MediaTestForm()
        {
            InitializeComponent();
        }
        
        void SelectFileButtonClick(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            player = new MCIPlayer(openFileDialog.FileName);
            
            // progress bar
            posTrackBar.Minimum = 0;
            posTrackBar.Maximum = player.GetTotalLength();
        }
        
        void PlayButtonClick(object sender, EventArgs e)
        {
            if (player.Play() == false) {
                MessageBox.Show(player.GetErrorMessage());
            } else {
                timer.Enabled = true;
                
                // volume bar
                volumeTrackBar.Value = player.GetVolume();
            }
        }
        
        void PauseButtonClick(object sender, EventArgs e)
        {
            if (player.Pause() == false) {
                MessageBox.Show(player.GetErrorMessage());
            } else {
                timer.Enabled = false;
            }
        }
        
        void RemuseButtonClick(object sender, EventArgs e)
        {
            if (player.Resume() == false) {
                MessageBox.Show(player.GetErrorMessage());
            } else {
                timer.Enabled = true;
            }
        }
        
        void StopButtonClick(object sender, EventArgs e)
        {
            if (player.Stop() == false) {
                MessageBox.Show(player.GetErrorMessage());
            } else {
                timer.Enabled = false;
            }
        }
        
        void TimerTick(object sender, EventArgs e)
        {
            string current = TimeFormat.MilisecondToMMSS(player.GetPosition());
            string total = TimeFormat.MilisecondToMMSS(player.GetTotalLength());
            timeLabel.Text = string.Format("{0}/{1}", current, total);
            
            posTrackBar.Value = player.GetPosition();
        }
        
        void TrackBarScroll(object sender, EventArgs e)
        {
            player.SetVolume(volumeTrackBar.Value);
        }
        
        void PosTrackBarScroll(object sender, EventArgs e)
        {
            player.SetPosition(posTrackBar.Value);
        }
    }
}
