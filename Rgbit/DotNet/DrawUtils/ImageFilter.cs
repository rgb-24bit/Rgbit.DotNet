/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Rgbit.DotNet.DrawUtils
{
    /// <summary>
    /// Description of ImageFilter.
    /// </summary>
    public class ImageFilter
    {
        public static Image Filter(Image image, int[] filter) {
            Bitmap bitmap = image.Clone() as Bitmap;

            // Locks the bitmap into system memory.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            
            int pixelSize = bitmap.RawFormat.Equals(ImageFormat.Png) ? 4 : 3;  // Unit pixel size
            int pb = 0, pg = 1, pr = 2;  // BGR
            
            unsafe {
                byte* start = (byte*) bmpdata.Scan0;
                
                // Calculate the offset
                Func<int, int, int> offset = (x, y) => {
                    return x * pixelSize + y * bmpdata.Stride;
                };
                
                for (int x = 1; x < bitmap.Width - 1; ++x) {
                    for (int y = 1; y < bitmap.Height - 1; ++y) {
                        int r = 0, g = 0, b = 0, index = 0;
                        
                        // Convolution calculation
                        for (int col = -1; col <= 1; ++col) {
                            for (int row = -1; row <= 1; ++row) {
                                byte* ptr = start + offset(x + col, y + row);
                                
                                r += ptr[pr] * filter[index];
                                g += ptr[pg] * filter[index];
                                b += ptr[pb] * filter[index];
                                
                                index++;
                            }
                        }
                        
                        // Processing overflow
                        r = Math.Max(0, Math.Min(255, r));
                        g = Math.Max(0, Math.Min(255, g));
                        b = Math.Max(0, Math.Min(255, b));
                        
                        // The pixel to be modified
                        byte* target = start + offset(x - 1, y - 1);
                        
                        target[pr] = (byte) r;
                        target[pg] = (byte) g;
                        target[pb] = (byte) b;
                    }
                }
            }
            
            bitmap.UnlockBits(bmpdata);
            return bitmap as Image;
        }
        
        public static Image EmbossFilter(Image image) {
            int[] filter = {1, 0, 0, 0, 0, 0, 0, 0, -1};
            return Filter(image, filter);
        }
        
        public static Image SoftenFilter(Image image) {
            int[] gauss = {1, 2, 1, 2, 4, 2, 1, 2, 1};
            return Filter(image, gauss);
        }
        
        public static Image SharpenFilter(Image image) {
            int[] laplacian = {-1, -1, -1, -1, 9, -1, -1, -1, -1};
            return Filter(image, laplacian);
        }
    }
}
