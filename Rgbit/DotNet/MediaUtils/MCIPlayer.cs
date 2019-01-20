/**
 * Copyright (c) 2018 - 2019 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Text;

namespace Rgbit.DotNet.MediaUtils
{
    /// <summary>
    /// Use MCI to playing multimedia devices and recording multimedia resource files.
    /// 
    /// Method related to playback behavior: Play, Stop, Pause, Resume.
    /// Ways to get song information: IsPlaying, GetPosition, GetTotalLength.
    /// Ways to get and set song volume: GetVolume, SetVolume. 
    /// More methods: Execute, GetErrorMessage, SetPosition, SwicthTarget.
    /// 
    /// Reference https://www.codeproject.com/Articles/63094/Simple-MCI-Player
    /// </summary>
    public class MCIPlayer : MCIBasic
    {
        private string target;
        
        public MCIPlayer(string target) {
            this.target = target;
        }
        
        /// <summary>
        /// Switch the target file to play.
        /// </summary>
        /// <param name="target">Target file.</param>
        /// <returns>The instance itself.</returns>
        public MCIPlayer SwicthTarget(string target) {
            this.Close();
            this.target = target;
            return this;
        }

        /// <summary>
        /// Open the target file and automatically call it when playing.
        /// </summary>
        /// <returns>Return true for success, false for failure.</returns>
        private bool Open() {
            this.Close();  // Look a little longer
            
            string command = string.Format("open {0} type mpegvideo", target);
            errorCode = mciSendString(command, null, 0, IntPtr.Zero);
            
            if (errorCode != 0) {
                command = string.Format("open {0}", target);
                errorCode = mciSendString(command, null, 0, IntPtr.Zero);           
            }  
            return errorCode == 0;
        }
        
        /// <summary>
        /// Turn off playback,
        /// </summary>
        /// <returns>Return true for success, false for failure.</returns>
        private bool Close() {
            string command = string.Format("close {0}", target);
            errorCode = mciSendString(command, null, 0, IntPtr.Zero);
            return errorCode == 0;
        }
        
        /// <summary>
        /// The play command starts playing a device.
        /// </summary>
        /// <param name="options">
        /// Playback options, use like play("repeat", "fast").
        /// 
        /// Refrence https://docs.microsoft.com/en-us/windows/desktop/multimedia/play
        /// </param>
        /// <returns>Return true for success, false for failure.</returns>
        public bool Play(params string[] options) {
            if (Open() == false) {  // Look a little longer
                return false;
            }
            
            StringBuilder sb = new StringBuilder(string.Format("play {0}", target));
            for (int i = 0; i < options.Length; ++i) {
                sb.AppendFormat(" {0}", options[i]);
            }
            
            errorCode = mciSendString(sb.ToString(), null, 0, IntPtr.Zero);
            
            if (errorCode != 0) {
                this.Close();
            }
            
            return errorCode == 0;
        }
        
        /// <summary>
        /// The stop command stops playback.
        /// 
        /// Turn off music, please use this method instead of Close.
        /// </summary>
        /// <returns>Return true for success, false for failure.</returns>
        public bool Stop() {
            String command = string.Format("stop {0}", target);
            errorCode = mciSendString(command, null, 0, IntPtr.Zero);
            return errorCode == 0;
        }
        
        /// <summary>
        /// The pause command pauses playing.
        /// </summary>
        /// <returns>Return true for success, false for failure.</returns>
        public bool Pause() {
            String command = string.Format("pause {0}", target);
            errorCode = mciSendString(command, null, 0, IntPtr.Zero);
            return errorCode == 0;
        }
        
        /// <summary>
        /// The resume command continues playing on a device
        /// that has been paused using the pause command.
        /// </summary>
        /// <returns>Return true for success, false for failure.</returns>
        public bool Resume() {
            String command = string.Format("resume {0}", target);
            errorCode = mciSendString(command, null, 0, IntPtr.Zero);
            return errorCode == 0;
        }
        
        /// <summary>
        /// Determine if the current media is playing.
        /// </summary>
        public bool IsPlaying() {
            string command = string.Format("status {0} mode", target);
            StringBuilder returnData = new StringBuilder(128);
            errorCode = mciSendString(command, returnData, 128, IntPtr.Zero);
            
            if(returnData.ToString().Contains("playing")) {
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        /// Get the length of the song.
        /// </summary>
        public int GetTotalLength() {
            string command = string.Format("status {0} length", target);
            StringBuilder returnData = new StringBuilder(128);
            errorCode = mciSendString(command, returnData, 128, IntPtr.Zero);
            return int.Parse(returnData.ToString());
        }
        
        /// <summary>
        /// Get the position of the song in milliseconds.
        /// </summary>
        public int GetPosition() {
            string command = string.Format("status {0} position", target);
            StringBuilder returnData = new StringBuilder(128);
            errorCode = mciSendString(command, returnData, 128, IntPtr.Zero);
            return int.Parse(returnData.ToString());
        }
        
        /// <summary>
        /// Set the position of the song in milliseconds.
        /// </summary>
        /// <param name="miliseconds">The position of the song in milliseconds.</param>
        /// <returns>Return true for success, false for failure.</returns>
        public bool SetPosition(int miliseconds) {
            if (IsPlaying()) {
                string command = string.Format("play {0} from {1}", target, miliseconds);
                errorCode = mciSendString(command, null, 0, IntPtr.Zero);
            } else {
                string command = string.Format("seek {0} to {1}", target, miliseconds);
                errorCode = mciSendString(command, null, 0, IntPtr.Zero);
            }
            return errorCode == 0;
        }

        /// <summary>
        /// Get the average volume to the left and right speaker.
        /// </summary>
        public int GetVolume() {
            string command = string.Format("status {0} volume", target);
            StringBuilder returnData = new StringBuilder(128);
            errorCode = mciSendString(command, returnData, 128, IntPtr.Zero);
            return int.Parse(returnData.ToString());
        }
        
        /// <summary>
        /// Set the average volume to the left and right speaker.
        /// </summary>
        /// <param name="volume">The volume, the range is [0, 1000].</param>
        /// <returns>Return true for success, false for failure.</returns>
        public bool SetVolume(int volume) {
            if (volume >= 0 && volume <= 1000) {
                string command = string.Format("setaudio {0} volume to {1}", target, volume);
                errorCode = mciSendString(command, null, 0, IntPtr.Zero);
                return errorCode == 0;
            }
            return false;
        }
    }
}
