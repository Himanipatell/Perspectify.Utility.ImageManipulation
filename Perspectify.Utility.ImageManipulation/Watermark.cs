using ImageMagick;
using NetVips;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Image = NetVips.Image;

namespace Perspectify.Utility.ImageManipulation
{
    public static class Watermark
    {
		public static byte[] applyImage(byte[] image, byte[] watermarkImage)
		{
            byte[] output = null;
            NetVips.Image img = ByteToImg(image);

            using (var magicimage = new MagickImage(image))
            {
                using (var watermark = new MagickImage(watermarkImage))
                {
                    int width = (int)(img.Width * 0.8);
                    int height = (int)(img.Height * 0.8);
                    magicimage.Composite(watermark, width, height, CompositeOperator.Over);
                }
                //magicimage.Write(writePath);
                output = magicimage.ToByteArray();
            }
            return output;
        }
		public static byte[] applyText(byte[] image, string watermarkText)
		{
            Image img = ByteToImg(image);
            Stream stream = new MemoryStream(image);
            Bitmap bitmap = new Bitmap(stream);
            Bitmap tempBitMap = new Bitmap(bitmap, bitmap.Width, bitmap.Height);
            Graphics graphicsImage = Graphics.FromImage(tempBitMap);
            StringFormat stringformat1 = new StringFormat();
            stringformat1.Alignment = StringAlignment.Far;
            Color StringColor1 = ColorTranslator.FromHtml("#FFFFFF");
            int width = (int)(img.Width * 0.95);
            int height = (int)(img.Height * 0.95);
            graphicsImage.DrawString(watermarkText, new Font("arail", 40, FontStyle.Regular), new SolidBrush(StringColor1), new Point(width, height), stringformat1);
            // bitmap.Save(writePath);
            using (var ms = new MemoryStream())
            {
                tempBitMap.Save(ms, bitmap.RawFormat);
                return ms.ToArray();
            }
        }
        private static Image ByteToImg(byte[] byteArr)
        {
            var ms = new MemoryStream(byteArr);
            return Image.NewFromStream(ms);
        }
    }
}
