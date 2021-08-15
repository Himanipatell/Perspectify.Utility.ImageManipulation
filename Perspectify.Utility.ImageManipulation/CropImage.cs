using NetVips;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static NetVips.Enums;

namespace Perspectify.Utility.ImageManipulation
{
    public static class CropImage
    {
        public static byte[] crop(byte[] image, float widthFraction, float heightFraction)
        {
            Image img = ByteToImg(image);
            Image croppedImage = img.Smartcrop((int)(img.Width * widthFraction), (int)(img.Height * heightFraction), Interesting.Centre);
            return croppedImage.JpegsaveBuffer();
        }
        private static Image ByteToImg(byte[] byteArr)
        {
            var ms = new MemoryStream(byteArr);
            return Image.NewFromStream(ms);
        }
    }
}
