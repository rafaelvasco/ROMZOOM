using System.IO;
using System.Linq;

namespace ROMZOOM.Logic
{
    public static class ImageFileValidator
    {
        public static string[] ValidImageFiles = {".png", ".jpg"};

        public static bool IsValid(string file_path)
        {
            return ValidImageFiles.Contains(Path.GetExtension(file_path));
        }
    }
}
