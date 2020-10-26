using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ROMZOOM.Logic
{
    public static class ImageDownloader
    {
        public static async Task<Bitmap> Download(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return null;
            }

            if (!ImageFileValidator.IsValid(uri))
            {
                return null;
            }

            using (var client = new WebClient())
            {
                var temp_output_path = Path.Combine(Path.GetTempPath(), Path.GetFileName(uri));

                await client.DownloadFileTaskAsync(new Uri(uri), temp_output_path);

                if (!File.Exists(temp_output_path)) return null;

                var bitmap = Utils.LoadBitmapFromFile(temp_output_path);

                return bitmap;

            }
        }

    }
}
