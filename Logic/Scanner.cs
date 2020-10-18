using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ROMZOOM.Model;

namespace ROMZOOM.Logic
{
    public class PlatformScanResult
    {
        public List<DirectoryInfo> UnrecognizedDirectories { get; set; }

        public List<Platform> Platforms { get; set; }

        public PlatformScanResult()
        {
            UnrecognizedDirectories = new List<DirectoryInfo>();

            Platforms = new List<Platform>();
        }
    }

    public static class Scanner
    {
        private static readonly Dictionary<PlatformId, List<string>> SupportedRomExtensions =
            new Dictionary<PlatformId, List<string>>()
            {
                {
                    PlatformId.GBA, new List<string> {".gba"}
                },
                {
                    PlatformId.GENESIS, new List<string> { ".gen", ".bin", ".md" }
                },
                {
                    PlatformId.NES, new List<string> { ".nes" }
                },
                {
                    PlatformId.SNES, new List<string> { ".sfc", ".smc" }
                },
                {
                    PlatformId.PSX, new List<string> { ".cue" }
                }
            };


        public static PlatformScanResult ScanPlatforms(string roms_folder)
        {
            var result = new PlatformScanResult();

            var dir = new DirectoryInfo(roms_folder);

            foreach (var child_dir in dir.EnumerateDirectories())
            {
                var platform_id = TryToInferPlatformId(child_dir.Name);

                if (platform_id != PlatformId.UNKNOWN)
                {
                    if (!Library.ContainsPlatform(platform_id))
                    {
                        var platform = new Platform(platform_id, PlatformIdDefaultDisplayNames.Get(platform_id),
                            child_dir.FullName);

                        result.Platforms.Add(platform);
                    }
                }
                else
                {
                    result.UnrecognizedDirectories.Add(child_dir);
                }
            }

            return result;
        }

        private static PlatformId TryToInferPlatformId(string folder_name)
        {
            var normalized_folder_name = 
                Regex
                .Replace(folder_name.ToLower(), @"\s+", "")
                .Replace(@"[^A-Z]+", "");
                
            switch (normalized_folder_name)
            {
                case "snes":
                case "supernintendo":
                case "supernes":
                case "supernintendoentertainmentsystem":
                case "superfamicom":

                    return PlatformId.SNES;

                case "nes":
                case "nintendo":
                case "famicom":
                    return PlatformId.NES;

                case "gba":
                case "gameboyadvance":
                    return PlatformId.GBA;

                case "genesis":
                case "megadrive":
                    return PlatformId.GENESIS;

                case "psx":
                case "ps1":
                case "playstation":
                case "psone":
                case "playstation1":
                case "playstationone":
                    return PlatformId.PSX;

                default: return PlatformId.UNKNOWN;
            }
        }

        public static List<Rom> ScanRoms(Platform platform)
        {
            var root_dir = new DirectoryInfo(platform.Path);
            var stack = new Stack<DirectoryInfo>();

            var result_roms = new List<Rom>();

            stack.Push(root_dir);

            while (stack.Count > 0)
            {
                var cur_node = stack.Pop();

                var node_dir_info = cur_node;

                foreach (var directory in node_dir_info.GetDirectories())
                {
                    stack.Push(directory);
                }

                var files = node_dir_info
                    .GetFiles()
                    .Where(file => SupportedRomExtensions[platform.PlatformId].Any(ext => ext.Equals(file.Extension.ToLower())))
                    .ToList();

                foreach (var file_info in files)
                {
                    var rom = new Rom(platform.PlatformId, file_info.Name, file_info.FullName);

                    if (!Library.ContainsRom(platform.PlatformId, rom))
                    {
                        result_roms.Add(rom);
                    }
                }
            }

            return result_roms;

        }

    }
}
