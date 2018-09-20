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
        
        public MCIPlayer(string target)
        {
            this.target = target;
        }
        
        /// <summary>
        /// Switch the target file to play.
        /// </summary>
        /// <param name="target">Target file.</param>
        /// <returns>The instance itself.</returns>
        public MCIPlayer swicthTarget(string target) {
            close();
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
        public bool execute(string command, StringBuilder returnData=null) {
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
        public string getErrorMessage() {
            StringBuilder errMsg = new StringBuilder(128);
            errorCode = mciGetErrorString(errorCode, errMsg, 128);
            return errMsg.ToString();
        }
        
        /// <summary>
        /// Open the target file and automatically call it when playing.
        /// </summary>
        /// <returns>Return true for success, false for failure.</returns>
        public bool open() {
            this.close();  // Look a little longer
 
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
        public bool close() {
            string command = "play " + target;
            errorCode = mciSendString(command, null, 0, IntPtr.Zero);
            return errorCode == 0;
        }
        
        /// <summary>
        /// Play target file.
        /// </summary>
        /// <param name="options">
        /// Playback options, use like play("repeat", "fast").
        /// 
        /// Refrence https://docs.microsoft.com/en-us/windows/desktop/multimedia/play
        /// </param>
        /// <returns>Return true for success, false for failure.</returns>
        public bool play(params string[] options) {
            if (open() == false) {  // Look a little longer
                return false;
            }
            
            StringBuilder sb = new StringBuilder(string.Format("play {0}", target));
            for (int i = 0; i < options.Length; ++i) {
                sb.AppendFormat(" {0}", options[i]);
            }
            
            errorCode = mciSendString(sb.ToString(), null, 0, IntPtr.Zero);
            
            if (errorCode != 0) {
                close();
            }
            
            return errorCode == 0;
        }
    }
}
