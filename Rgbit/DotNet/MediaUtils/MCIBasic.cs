/**
 * Copyright (c) 2018 - 2019 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rgbit.DotNet.MediaUtils
{
    /// <summary>
    /// Provide basic functions for accessing the MCI interface.
    /// 
    /// Reference https://docs.microsoft.com/en-us/windows/desktop/multimedia/mci
    /// </summary>
    public class MCIBasic
    {
        protected int errorCode;
        
        [DllImport("winmm.dll")]
        protected static extern int mciSendString(string strCommand, StringBuilder strReturn,
                                                int iReturnLength, IntPtr hwndCallback);
        [DllImport("winmm.dll")]
        protected static extern int mciGetErrorString(int errCode, StringBuilder errMsg, int buflen);
        
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
    }
}
