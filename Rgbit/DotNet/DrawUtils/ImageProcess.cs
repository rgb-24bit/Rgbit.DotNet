/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Rgbit.DotNet.DrawUtils
{
    /// <summary>
    /// Image Process utils.
    /// </summary>
    public class ImageProcess
    {
        /// <summary>
        /// Determine whether the image format is one of the limited formats.
        /// </summary>
        /// <param name="bitmap">Picture object.</param>
        /// <param name="formats">Image Format.</param>
        /// <returns>Return true in qualified format, false otherwise.</returns>
        private static bool CheckImageFormat(Bitmap bitmap, params ImageFormat[] formats) {
            foreach (ImageFormat format in formats) {
                if (bitmap.RawFormat.Equals(format)) {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Swap image rgb color channel.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <param name="rgbOrder">The order of the new color channels, such as "grb".</param>
        /// <returns>Swaped image object</returns>
        public static Image SwapRgb(Image image, String rgbOrder) {
            Bitmap bitmap = image.Clone() as Bitmap;
            
            if (!CheckImageFormat(bitmap, ImageFormat.Bmp, ImageFormat.Jpeg, ImageFormat.Png)) {
                throw new ArgumentException("Unsuported format, only support for bmp, jpg or png");
            }
            
            // Locks the bitmap into system memory.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bmpdata.Scan0;
            
            // Declare an array to hold the bytes of the bitmap.
            int totalPixels = Math.Abs(bmpdata.Stride) * bitmap.Height;
            byte[] rgbValues = new byte[totalPixels];
            
            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, totalPixels);
            
            int b = 0, g = 1, r = 2;  // BGR
            int increase = CheckImageFormat(bitmap, ImageFormat.Png) ? 4 : 3;  // PNG is BGRA

            for (int i = 0; i < totalPixels; i += increase) {
                Dictionary<char, byte> map = new Dictionary<char, byte>() {
                    {'r', rgbValues[r + i]},
                    {'g', rgbValues[g + i]},
                    {'b', rgbValues[b + i]}
                };
                
                rgbValues[r + i] = map[rgbOrder[0]];
                rgbValues[g + i] = map[rgbOrder[1]];
                rgbValues[b + i] = map[rgbOrder[2]];
            }
            
            Marshal.Copy(rgbValues, 0, ptr, totalPixels);
            bitmap.UnlockBits(bmpdata);
            
            return bitmap.Clone() as Image;
        }
        
        /// <summary>
        /// Swap image argb color channel.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <param name="argbOrder">The order of the new color channels, such as "agrb".</param>
        /// <returns>Swaped image object</returns>
        public static Image SwapArgb(Image image, string argbOrder) {
            Bitmap bitmap = image.Clone() as Bitmap;
            
            if (!CheckImageFormat(bitmap, ImageFormat.Png)) {
                throw new ArgumentException("Unsuported format, only support png");
            }
            
            // Locks the bitmap into system memory.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bmpdata.Scan0;
            
            // Declare an array to hold the bytes of the bitmap.
            int totalPixels = Math.Abs(bmpdata.Stride) * bitmap.Height;
            byte[] rgbValues = new byte[totalPixels];
            
            // Copy the ARGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, totalPixels);
            
            int b = 0, g = 1, r = 2, a = 3;  // BGRA

            for (int i = 0; i < totalPixels; i += 4) {
                Dictionary<char, byte> map = new Dictionary<char, byte>() {
                    {'r', rgbValues[r + i]},
                    {'g', rgbValues[g + i]},
                    {'b', rgbValues[b + i]},
                    {'a', rgbValues[a + i]}
                };
                
                rgbValues[r + i] = map[argbOrder[0]];
                rgbValues[g + i] = map[argbOrder[1]];
                rgbValues[b + i] = map[argbOrder[2]];
                rgbValues[a + i] = map[argbOrder[3]];
            }
            
            Marshal.Copy(rgbValues, 0, ptr, totalPixels);
            bitmap.UnlockBits(bmpdata);
            
            return bitmap.Clone() as Image;
        }
        
        /// <summary>
        /// Get the grayscale image corresponding to the image.
        /// 
        /// Formula used: Gray = (R*299 + G*587 + B*114 + 500) / 1000
        /// </summary>
        public static Image Gray(Image image) {
            Bitmap bitmap = image.Clone() as Bitmap;
            
            if (!CheckImageFormat(bitmap, ImageFormat.Bmp, ImageFormat.Jpeg, ImageFormat.Png)) {
                throw new ArgumentException("Unsuported format, only support for bmp, jpg or png");
            }
            
            // Locks the bitmap into system memory.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bmpdata.Scan0;
            
            // Declare an array to hold the bytes of the bitmap.
            int totalPixels = Math.Abs(bmpdata.Stride) * bitmap.Height;
            byte[] rgbValues = new byte[totalPixels];
            
            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, totalPixels);
            
            int b = 0, g = 1, r = 2;  // BGR
            int increase = CheckImageFormat(bitmap, ImageFormat.Png) ? 4 : 3;  // PNG is BGRA
            
            for (int i = 0; i < totalPixels; i += increase) {
                int rv = rgbValues[r + i], gv = rgbValues[g + i], bv = rgbValues[b + i];
                byte gray = (byte) ((rv * 299 + gv * 587 + bv * 114 + 500) / 1000);
                rgbValues[r + i] = rgbValues[g + i] = rgbValues[b + i] = gray;
            }
            
            Marshal.Copy(rgbValues, 0, ptr, totalPixels);
            bitmap.UnlockBits(bmpdata);
            
            return bitmap.Clone() as Image;
        }
        
        /// <summary>
        /// Get the inverted image corresponding to the image.
        /// </summary>
        public static Image Invert(Image image) {
            Bitmap bitmap = image.Clone() as Bitmap;
            
            if (!CheckImageFormat(bitmap, ImageFormat.Bmp, ImageFormat.Jpeg, ImageFormat.Png)) {
                throw new ArgumentException("Unsuported format, only support for bmp, jpg or png");
            }
            
            // Locks the bitmap into system memory.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr ptr = bmpdata.Scan0;
            
            // Declare an array to hold the bytes of the bitmap.
            int totalPixels = Math.Abs(bmpdata.Stride) * bitmap.Height;
            byte[] rgbValues = new byte[totalPixels];
            
            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, totalPixels);
            
            int b = 0, g = 1, r = 2;  // BGR
            int increase = CheckImageFormat(bitmap, ImageFormat.Png) ? 4 : 3;  // PNG is BGRA
            
            for (int i = 0; i < totalPixels; i += increase) {
                rgbValues[r + i] ^= 0xFF;  // x + (x ^ 0xFF) = 0xFF
                rgbValues[g + i] ^= 0xFF;
                rgbValues[b + i] ^= 0xFF;
            }
            
            Marshal.Copy(rgbValues, 0, ptr, totalPixels);
            bitmap.UnlockBits(bmpdata);
            
            return bitmap.Clone() as Image;
        }
    }
}
