using System.Security.Cryptography;
using System.Text;

namespace ROMZOOM.Logic
{
    public static class Utils
    {
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
