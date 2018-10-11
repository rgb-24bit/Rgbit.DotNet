/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Drawing;

namespace Rgbit.DotNet.DrawUtils
{
    /// <summary>
    /// Help with rectangular operations.
    /// </summary>
    public class RectangleHelper
    {
        /// <summary>
        /// Create a rectangle determined by two points.
        /// </summary>
        public static Rectangle CreateRectangleByTwoPoint(Point p1, Point p2) {
            // Determine the coordinates of the upper left corner
            int x = Math.Min(p1.X, p2.X);
            int y = Math.Min(p1.Y, p2.Y);
            
            // Determine the size of the rectangle
            int width = Math.Abs(p1.X - p2.X);
            int height = Math.Abs(p1.Y - p2.Y);
            
            return new Rectangle(x, y, width, height);
        }
        
        /// <summary>
        /// Convert a rectangle to an approximate square.
        /// </summary>
        /// <param name="isBigger">
        /// If true, the side length of the square is the larger of the original rectangle width
        /// and height, otherwise choose a smaller value.
        /// </param>
        public static Rectangle AsSquare(Rectangle rect, bool isBigger) {
            int width = isBigger ?
                Math.Max(rect.Width, rect.Height) : Math.Min(rect.Width, rect.Height);
            return new Rectangle(rect.X, rect.Y, width, width);
        }
    }
}
