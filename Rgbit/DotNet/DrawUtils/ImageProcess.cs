/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Rgbit.DotNet.DrawUtils
{
    /// <summary>
    /// Image Process utils.
    /// 
    /// TODO Make SwapRgb and SwapArgb Memory processing
    /// </summary>
    public class ImageProcess
    {
        /// <summary>
        /// Swap image rgb color channel.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <param name="rgb">The order of the new color channels, such as "grb".</param>
        /// <returns>Swaped image object</returns>
        public static Image SwapRgb(Image image, String rgb) {
            Bitmap bitmap = image.Clone() as Bitmap;
            
            Dictionary<char, Func<Color, byte>> map = new Dictionary<char, Func<Color, byte>>();
            
            map.Add('r', (p) => p.R);
            map.Add('g', (p) => p.G);
            map.Add('b', (p) => p.B);
            
            for (int x = 0; x < bitmap.Width; x++) {
                for (int y = 0; y < bitmap.Height; y++) {
                    Color pixel = bitmap.GetPixel(x, y);
                    bitmap.SetPixel(x, y, Color.FromArgb(
                        map[rgb[0]](pixel),
                        map[rgb[1]](pixel),
                        map[rgb[2]](pixel)));
                }
            }
            
            return bitmap.Clone() as Image;
        }
        
        /// <summary>
        /// Swap image argb color channel.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <param name="argb">The order of the new color channels, such as "agrb".</param>
        /// <returns>Swaped image object</returns>
        public static Image SwapArgb(Image image, string argb) {
            Bitmap bitmap = image.Clone() as Bitmap;
            
            Dictionary<char, Func<Color, byte>> map = new Dictionary<char, Func<Color, byte>>();
            
            map.Add('a', (p) => p.A);
            map.Add('r', (p) => p.R);
            map.Add('g', (p) => p.G);
            map.Add('b', (p) => p.B);
            
            for (int x = 0; x < bitmap.Width; x++) {
                for (int y = 0; y < bitmap.Height; y++) {
                    Color pixel = bitmap.GetPixel(x, y);
                    bitmap.SetPixel(x, y, Color.FromArgb(
                        map[argb[0]](pixel),
                        map[argb[1]](pixel),
                        map[argb[2]](pixel),
                        map[argb[3]](pixel)));
                }
            }
            
            return bitmap.Clone() as Image;
        }
        
        /// <summary>
        /// Get the grayscale image corresponding to the image.
        /// 
        /// Formula used: Gray = (R*299 + G*587 + B*114 + 500) / 1000
        /// </summary>
        public static Image Gray(Image image) {
            Bitmap bitmap = image.Clone() as Bitmap;
            
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bmpdata.Scan0;
            
            int bytes = bitmap.Width * bitmap.Height * 3;
            byte[] rgbValues = new byte[bytes];
            
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
            
            for (int i = 0; i < rgbValues.Length; i += 3) {
                int r = rgbValues[i], g = rgbValues[i + 1], b = rgbValues[i + 2];
                byte gray = (byte) ((r * 299 + g * 587 + b * 114 + 500) / 1000);
                rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = gray;
            }
            
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            
            bitmap.UnlockBits(bmpdata);
            return bitmap.Clone() as Image;
        }
        
        /// <summary>
        /// Get the inverted image corresponding to the image.
        /// </summary>
        public static Image Invert(Image image) {
            Bitmap bitmap = image.Clone() as Bitmap;
            
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bmpdata.Scan0;
            
            int bytes = bitmap.Width * bitmap.Height * 3;
            byte[] rgbValues = new byte[bytes];
            
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
            
            for (int i = 0; i < rgbValues.Length; i++) {
                rgbValues[i] = (byte) (rgbValues[i] ^ 0xFF);
            }
            
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            
            bitmap.UnlockBits(bmpdata);
            return bitmap.Clone() as Image;
        }
    }
}
