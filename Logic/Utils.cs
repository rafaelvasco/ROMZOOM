using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace ROMZOOM.Logic
{
    public static class Utils
    {
        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {

            BitmapData bmpdata = null;

            try
            {
                bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
                int numbytes = bmpdata.Stride * bitmap.Height;
                byte[] bytedata = new byte[numbytes];
                IntPtr ptr = bmpdata.Scan0;

                Marshal.Copy(ptr, bytedata, 0, numbytes);

                return bytedata;
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }

        }

        public static Bitmap ByteArrayToBitmap(byte[] data, int width, int  height, PixelFormat pixel_format)
        {
            Bitmap bmp = new Bitmap( width, height, pixel_format);  

            BitmapData bmpData = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),   
                ImageLockMode.WriteOnly, bmp.PixelFormat);
 
            Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
                
            bmp.UnlockBits(bmpData);

            return bmp;
        }


        public static string CreateMD5(byte[] byte_array)
        {
            using (var md5 = MD5.Create())
            {
                byte[] hash_bytes = md5.ComputeHash(byte_array);

                var sb = new StringBuilder();

                for (int i = 0; i < hash_bytes.Length; ++i)
                {
                    sb.Append(hash_bytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public static string CreateMD5(string input)
        {
            byte[] input_bytes = Encoding.ASCII.GetBytes(input);

            return CreateMD5(input_bytes);
        }

        public static float Clamp(float value, float min, float max)
        {
            return (value > max) ? max : ((value < min) ? min : value);
        }

        public static int Clamp(int value, int min, int max)
        {
            return (value > max) ? max : ((value < min) ? min : value);
        }
    }
}
