/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;

namespace Rgbit.DotNet.TimeUtils
{
    /// <summary>
    /// Time and date formatting.
    /// </summary>
    public class TimeFormat
    {
        /// <summary>
        /// Convert millisecond values to MM:SS format.
        /// </summary>
        public static string MilisecondToMMSS(int milisecond) {
            int second = milisecond / 1000;
            return string.Format("{0:D2}:{1:D2}", second / 60, second % 60);
        }
    }
}
