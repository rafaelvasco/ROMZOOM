using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using DamienG.Security.Cryptography;

namespace ROMZOOM.Logic
{
    public static class Utils
    {
        public static Bitmap LoadBitmapFromFile(string file_path)
        {
            Bitmap orig = new Bitmap(file_path);

            Bitmap converted = new Bitmap(orig.Width, orig.Height, PixelFormat.Format32bppPArgb);

            using (Graphics g = Graphics.FromImage(converted))
            {
                g.DrawImage(orig, new Rectangle(0, 0, converted.Width, converted.Height));
            }

            orig.Dispose();

            return converted;
        }

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

        public static string CalcHash(string value)
        {
            return CalcHash(Encoding.ASCII.GetBytes(value));
        }


        public static string CalcHash(byte[] bytes)
        {
            var crc32 = new Crc32();

            byte[] crc = crc32.ComputeHash(bytes);

            return BitConverter.ToString(crc).Replace("-", string.Empty).ToLower();

           
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
