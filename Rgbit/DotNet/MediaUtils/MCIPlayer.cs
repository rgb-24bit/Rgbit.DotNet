/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rgbit.DotNet.MediaUtils
{
    /// <summary>
    /// Use MCI to playing multimedia devices and recording multimedia resource files.
    /// 
    /// Method related to playback behavior: Play, Stop, Pause, Resume.
    /// Ways to get song information: IsPlaying, GetCurentMilisecond, GetTotalLength.
    /// More methods: Execute, GetErrorMessage, SetPosition, SwicthTarget.
    /// 
    /// Reference https://docs.microsoft.com/en-us/windows/desktop/multimedia/mci
    /// Reference https://www.codeproject.com/Articles/63094/Simple-MCI-Player
    /// </summary>
    public class MCIPlayer
    {
        private string target;
        private int errorCode;
        
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand, StringBuilder strReturn,
                                                int iReturnLength, IntPtr hwndCallback);
        [DllImport("winmm.dll")]
        public static extern int mciGetErrorString(int errCode, StringBuilder errMsg, int buflen);
        
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
        /// Execute a Multimedia Command String.
        /// </summary>
        /// <param name="command">The Multimedia Command String to be executed.</param>
        /// <param name="returnData">
        /// Optional parameter to save the information returned after execution.
        /// </param>
        /// <returns>Return true for success, false for failure.</returns>
        public bool Execute(string command, StringBuilder returnData=null) {
            if (returnData == null) {
                errorCode = mciSendString(command, null, 0, IntPtr.Zero);
            } else {
                errorCode = mciSendString(command, returnData, returnData.Capacity, IntPtr.Zero);
            }
            return errorCode == 0;
        }
        
        /// <summary>
        /// Get the error message of the last action, the error code will be reset.
        /// </summary>
        /// <returns>Error message string.</returns>
        public string GetErrorMessage() {
            StringBuilder errMsg = new StringBuilder(128);
            errorCode = mciGetErrorString(errorCode, errMsg, 128);
            return errMsg.ToString();
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
            string command = "play " + target;
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
        /// Get the position of the song in milliseconds.
        /// </summary>
        public int GetCurentMilisecond() {
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
        /// Get the length of the song.
        /// </summary>
        public int GetTotalLength() {
            string command = string.Format("status {0} length", target);
            StringBuilder returnData = new StringBuilder(128);
            errorCode = mciSendString(command, returnData, 128, IntPtr.Zero);
            return int.Parse(returnData.ToString());
        }
    }
}
