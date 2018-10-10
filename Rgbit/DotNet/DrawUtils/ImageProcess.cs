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
    /// Image Process utils.
    /// </summary>
    public class ImageProcess
    {
        /// <summary>
        /// Get the byte size of the unit pixel.
        /// </summary>
        /// <returns>Unit pixel size in bytes.</returns>
        private static int GetUnitPixelSize(Bitmap bitmap) {
            return Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
        }
        
        /// <summary>
        /// Swap image rgb color channel.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <param name="rgbOrder">The order of the new color channels, such as "grb".</param>
        /// <returns>Swaped image object</returns>
        public static Image SwapRgb(Image image, String rgbOrder) {
            Bitmap bitmap = image.Clone() as Bitmap;
            
            // Locks the bitmap into system memory.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            
            int pixelSize = GetUnitPixelSize(bitmap);
            int b = 0, g = 1, r = 2;  // BGR
            
            unsafe {
                byte* ptr = (byte*) bmpdata.Scan0;
                
                for (int row = 0; row < bitmap.Height; ++row) {
                    for (int col = 0; col < bitmap.Width; ++col) {
                        Dictionary<char, byte> map = new Dictionary<char, byte>() {
                            {'r', ptr[r]}, {'g', ptr[g]}, {'b', ptr[b]}
                        };
                        
                        ptr[r] = map[rgbOrder[0]];
                        ptr[g] = map[rgbOrder[1]];
                        ptr[b] = map[rgbOrder[2]];
                        
                        ptr += pixelSize;
                    }
                    // Handling byte alignment issues
                    ptr += bmpdata.Stride - bmpdata.Width * pixelSize;
                }
            }

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
            
            // Locks the bitmap into system memory.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            
            int pixelSize = GetUnitPixelSize(bitmap);
            int b = 0, g = 1, r = 2;  // BGR
            
            unsafe {
                byte* ptr = (byte*) bmpdata.Scan0;
                
                for (int row = 0; row < bitmap.Height; ++row) {
                    for (int col = 0; col < bitmap.Width; ++col) {
                        int gray = (ptr[r] * 299 + ptr[g] * 587 + ptr[b] * 114 + 500) / 1000;
                        
                        ptr[r] = ptr[g] = ptr[b] = (byte) gray;
                        
                        ptr += pixelSize;
                    }
                    // Handling byte alignment issues
                    ptr += bmpdata.Stride - bmpdata.Width * pixelSize;
                }
            }

            bitmap.UnlockBits(bmpdata);
            
            return bitmap as Image;
        }
        
        /// <summary>
        /// Get the inverted image corresponding to the image.
        /// </summary>
        public static Image Invert(Image image) {
            Bitmap bitmap = image.Clone() as Bitmap;
            
            // Locks the bitmap into system memory.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            
            int pixelSize = GetUnitPixelSize(bitmap);
            int b = 0, g = 1, r = 2;  // BGR
            
            unsafe {
                byte* ptr = (byte*) bmpdata.Scan0;
                
                for (int row = 0; row < bitmap.Height; ++row) {
                    for (int col = 0; col < bitmap.Width; ++col) {
                        ptr[r] ^= 255;
                        ptr[g] ^= 255;
                        ptr[b] ^= 255;
                        
                        ptr += pixelSize;
                    }
                    // Handling byte alignment issues
                    ptr += bmpdata.Stride - bmpdata.Width * pixelSize;
                }
            }

            bitmap.UnlockBits(bmpdata);
            
            return bitmap as Image;
        }
        
        /// <summary>
        /// Scale the image proportionally.
        /// </summary>
        /// <returns>Scaled picture object.</returns>
        public static Image Scale(Image image, float widthScale, float heightScale) {
            Image.GetThumbnailImageAbort callback = () => { return false; };
            
            int newWidth = (int) (image.Width * widthScale);
            int newHeight = (int) (image.Height * heightScale);

            return image.GetThumbnailImage(newWidth, newHeight, callback, IntPtr.Zero);
        }
        
        /// <summary>
        /// Rotates the Image.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <param name="degree">The degree of rotation.</param>
        /// <returns>Rotated Image object.</returns>
        public static Image Rotate(Image image, int degree) {
            // The performance of the RotateMultiple90 is better
            if (degree % 90 == 0) {
                return RotateMultiple90(image, degree);
            } else {
                return RotateTransform(image, degree);
            }
        }
        
        /// <summary>
        /// Rotates the Image.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <param name="degree">The degree of rotation should be a multiple of 90.</param>
        /// <returns>Rotated Image object.</returns>
        private static Image RotateMultiple90(Image image, int degree) {
            Image newImage = image.Clone() as Image;
            
            Dictionary<int, RotateFlipType> degreeMap = new Dictionary<int, RotateFlipType>() {
                {0, RotateFlipType.RotateNoneFlipNone},
                {90, RotateFlipType.Rotate90FlipNone},
                {180, RotateFlipType.Rotate180FlipNone},
                {270, RotateFlipType.Rotate270FlipNone}
            };
            
            newImage.RotateFlip(degreeMap[degree % 360]);
            
            return newImage;
        }
        
        /// <summary>
        /// Rotates the Image. Poor performance.
        /// 
        /// Refrence:
        /// https://stackoverflow.com/questions/2163829/how-do-i-rotate-a-picture-in-winforms
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <param name="degree">The degree of rotation.</param>
        /// <returns>Rotated Image object.</returns>
        private static Image RotateTransform(Image image, int degree) {
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            
            using (Graphics g = Graphics.FromImage(bitmap)) {
                // set the rotation point to the center of image
                g.TranslateTransform(bitmap.Width / 2f, bitmap.Height / 2f);
                
                g.RotateTransform(degree % 360);
                
                // move the image back
                g.TranslateTransform(-bitmap.Width / 2f, -bitmap.Height / 2f);
                
                g.DrawImage(image, new Point(0, 0));
            }
            
            return bitmap as Image;
        }
        
        /// <summary>
        /// Flip the image.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <param name="flipX">Whether to flip horizontally.</param>
        /// <param name="flipY">Whether to flip vertically.</param>
        /// <returns>Flip image object.</returns>
        public static Image Flip(Image image, bool flipX, bool flipY) {
            Image newImage = image.Clone() as Image;
            
            if (flipX == true) {
                newImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            
            if (flipY == true) {
                newImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }
            
            return newImage;
        }
        
        /// <summary>
        /// Intercept the rectangular portion of the image.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <returns>Truncated image object.</returns>
        public static Image ClipRectangle(Image image, int x, int y, int width, int height) {
            Bitmap bitmap = image.Clone() as Bitmap;
            
            Rectangle rect = new Rectangle(x, y, width, height);
            
            return bitmap.Clone(rect, bitmap.PixelFormat) as Image;
        }
        
        /// <summary>
        /// Intercept the elliptical portion of the image.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <param name="x">
        /// The x coordinate of the upper left corner of the rectangle where the ellipse is located.
        /// </param>
        /// <param name="y">
        /// The y coordinate of the upper left corner of the rectangle where the ellipse is located.
        /// </param>
        /// <param name="width">
        /// The width of the rectangle where the ellipse is located.
        /// </param>
        /// <param name="height">
        /// The height of the rectangle where the ellipse is located
        /// </param>
        /// <param name="backgroundColor">The color used to fill the blanks.</param>
        /// <returns>Truncated image object.</returns>
        public static Image ClipEllipse(Image image, int x, int y, int width, int height,
                                        Color backgroundColor) {
            // Get the corresponding rectangular area
            Image rectImage = ClipRectangle(image, x, y, width, height);
            Bitmap bitmap = rectImage.Clone() as Bitmap;
            
            using (Graphics g = Graphics.FromImage(bitmap)) {
                g.Clear(backgroundColor);
                
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, width, height);
                
                g.SetClip(path);
                g.DrawImage(rectImage, 0, 0);
            }

            return bitmap as Image;
        }
    }
}
