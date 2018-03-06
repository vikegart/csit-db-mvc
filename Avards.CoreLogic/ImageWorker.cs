using System;
using System.IO;
using System.Drawing;


namespace Avards.CoreLogic
{
   public static class ImageWorker
    {
        public static Image Resize(Image sourceImage, int newWidth, int maxHeight, bool reduceOnly)
        {
            if (reduceOnly && sourceImage.Width <= newWidth)
            {
                newWidth = sourceImage.Width;
            }

            int newHeight = sourceImage.Height * newWidth / sourceImage.Width;
            if (newHeight > maxHeight)
            {
                newWidth = sourceImage.Width * maxHeight / sourceImage.Height;
                newHeight = maxHeight;
            }

            Image newImage = sourceImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);
            return newImage;
        }

        public static byte[] ResizeImage(byte[] sourceImageByte, int newWidth, int maxHeight, bool reduceOnly)
        {
            MemoryStream ms = new MemoryStream(sourceImageByte);
            ImageConverter converter = new ImageConverter();
            Image image = Image.FromStream(ms);
            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            if (reduceOnly && image.Width <= newWidth)
            {
                newWidth = image.Width;
            }

            int newHeight = image.Height * newWidth / image.Width;
            if (newHeight > maxHeight)
            {
                newWidth = image.Width * maxHeight / image.Height;
                newHeight = maxHeight;
            }
            image = image.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);
            return (byte[])converter.ConvertTo(image, typeof(byte[]));
        }
    }
}
