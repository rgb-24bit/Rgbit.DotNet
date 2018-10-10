/**
 * Copyright (c) 2018 by rgb-24bit.
 * License MIT, see LICENSE for more details.
 */

using System;
using System.Drawing;

namespace Rgbit.DotNet.DrawUtils
{
    /// <summary>
    /// A layer of packaging on <see cref="ImageProcess"></see> for easy multi-image
    /// processing at the same time.
    /// 
    /// <example>
    /// <code>
    /// Image result = ImageProcessFactory.newFactory(image)
    ///     .Invert()
    ///     .Gray()
    ///     .SwapRgb("gbr")
    ///     .getResult();
    /// </code>
    /// </example>
    /// 
    /// </summary>
    public class ImageProcessFactory
    {
        private Image image;
        
        /// <summary>
        /// Private constructor, instance creation should use the method newFactory.
        /// </summary>
        /// <param name="image">The image object to be processed by this factory.</param>
        private ImageProcessFactory(Image image) {
            this.image = image;
        }
        
        /// <summary>
        /// Create an ImageProcessFactory instance.
        /// </summary>
        /// <param name="image">The image object to be processed by this factory, not null.</param>
        /// <returns>ImageProcessFactory instance.</returns>
        public static ImageProcessFactory newFactory(Image image) {
            if (image == null) {
                throw new ArgumentNullException("image", "Image cannot be empty !");
            }
            return new ImageProcessFactory(image);
        }
        
        /// <summary>
        /// Return processing result.
        /// </summary>
        /// <returns>Processed image object.</returns>
        public Image getResult() {
            return this.image;
        }
        
        /// <summary>
        /// Swap image rgb color channel.
        /// </summary>
        /// <returns>Current factory instance itself.</returns>
        public ImageProcessFactory SwapRgb(String rgbOrder) {
            this.image = ImageProcess.SwapRgb(this.image, rgbOrder);
            return this;
        }
  
        /// <summary>
        /// Get the grayscale image corresponding to the image.
        /// </summary>
        /// <returns>Current factory instance itself.</returns>
        public ImageProcessFactory Gray() {
            this.image = ImageProcess.Gray(this.image);
            return this;         
        }
        
        /// <summary>
        /// Get the inverted image corresponding to the image.
        /// </summary>
        /// <returns>Current factory instance itself.</returns>
        public ImageProcessFactory Invert() {
            this.image = ImageProcess.Invert(this.image);
            return this;
        }
        
        /// <summary>
        /// Scale the image proportionally.
        /// </summary>
        /// <returns>Current factory instance itself.</returns>
        public ImageProcessFactory Scale(float widthScale, float heightScale) {
            this.image = ImageProcess.Scale(this.image, widthScale, heightScale);
            return this;
        }
        
        /// <summary>
        /// Rotates the Image.
        /// </summary>
        /// <returns>Current factory instance itself.</returns>
        public ImageProcessFactory Rotate(int degree) {
            this.image = ImageProcess.Rotate(this.image, degree);
            return this;
        }
        
        /// <summary>
        /// Flip the image.
        /// </summary>
        /// <returns>Current factory instance itself.</returns>
        public ImageProcessFactory Flip(bool flipX, bool flipY) {
            this.image = ImageProcess.Flip(this.image, flipX, flipY);
            return this;
        }
        
        /// <summary>
        /// Intercept the rectangular portion of the image.
        /// </summary>
        /// <returns>Current factory instance itself.</returns>
        public ImageProcessFactory ClipRectangle(int x, int y, int width, int height) {
            this.image = ImageProcess.ClipRectangle(this.image, x, y, width, height);
            return this;
        }
        
        /// <summary>
        /// Intercept the elliptical portion of the image.
        /// </summary>
        /// <returns>Current factory instance itself.</returns>
        public ImageProcessFactory ClipEllipse(int x, int y, int width, int height, 
                                               Color backgroundColor) {
            this.image = ImageProcess.ClipEllipse(this.image, x, y, width, height, backgroundColor);
            return this;
        }
    }
}
