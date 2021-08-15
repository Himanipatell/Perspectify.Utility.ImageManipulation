using NetVips;
using System;
using System.IO;
using static NetVips.Enums;

namespace Perspectify.Utility.ImageManipulation
{
    public static class Compression
    {
        public static byte[] compress(string image)
        {
            byte[] originalBytes = null;
            byte[] compressedBytes = null;
            try
            {
              
                originalBytes = System.Convert.FromBase64String(image);
                
                Image img = Image.TiffloadBuffer(originalBytes);
                img.Tiffsave("C:\\Users\\HIMANI\\Pictures\\Compress Image\\Compress\\2.jpg", ForeignTiffCompression.Jpeg);
                compressedBytes=img.TiffsaveBuffer(ForeignTiffCompression.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured");
            }
            return compressedBytes;
        }
        private static Image ByteToImg(byte[] byteArr)
        {
            var ms = new MemoryStream(byteArr);
            return Image.NewFromStream(ms);
        }
    }
}
