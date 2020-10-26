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
                    PlatformId.GBC, new List<string>() { ".gbc" }
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
                },
                {
                    PlatformId._3DS, new List<string> { ".3ds" }
                },
                {
                    PlatformId.ARCADE, new List<string> { ".zip" }
                },
                {
                    PlatformId.CPS1, new List<string> { ".zip" }
                },
                {
                    PlatformId.CPS2, new List<string> { ".zip" }
                },
                {
                    PlatformId.CPS3, new List<string> { ".zip" }
                },
                {
                    PlatformId.DOS, new List<string> { ".exe" }
                },
                {
                    PlatformId.GC, new List<string> { ".izo", ".gcz" }
                },
                {
                    PlatformId.N64, new List<string> { ".n64", ".z64" }
                },
                {
                    PlatformId.NDS, new List<string> { ".nds" }
                },
                {
                    PlatformId.NEOGEO, new List<string> { ".zip" }
                },
                {
                    PlatformId.PC98, new List<string> { ".hdi" }
                },
                {
                    PlatformId.PCENGINE, new List<string> { ".pce" }
                },
                {
                    PlatformId.PCENGINECD, new List<string> { ".cue" }
                },
                {
                    PlatformId.PS2, new List<string> { ".iso" }
                },
                {
                    PlatformId.PS3, new List<string> { ".zzz" }
                },
                {
                    PlatformId.PSP, new List<string> { ".iso", ".cso" }
                },
                {
                    PlatformId.SHARPX68000, new List<string> { ".dim" }
                },
                {
                    PlatformId.SWITCH, new List<string> { ".xci" }
                },
                {
                    PlatformId.WII, new List<string> { ".iso", ".gcz", ".wbfs" }
                },
                {
                    PlatformId.WIIU, new List<string> { ".rpx" }
                },
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
                    var platform = new Platform(platform_id, PlatformIdMethods.GetDisplayName(platform_id),
                        child_dir.FullName);

                    result.Platforms.Add(platform);
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
              

                case "nes":
                case "nintendo":
                case "famicom":
                    return PlatformId.NES;

                case "gba":
                case "gameboyadvance":
                    return PlatformId.GBA;

                case "gbc":
                case "gameboycolor":
                    return PlatformId.GBC;

                case "snes":
                case "supernintendo":
                case "supernes":
                case "supernintendoentertainmentsystem":
                case "superfamicom":

                    return PlatformId.SNES;

                case "ds":
                case "nintendods":
                case "nds":

                    return PlatformId.NDS;

                case "3ds":
                case "nintendo3ds":
                case "n3ds":

                    return PlatformId._3DS;

                case "gc":
                case "gamecube":
                case "nintendogamecube":

                    return PlatformId.GC;

                case "n64":
                case "nintendo64":
                case "64":

                    return PlatformId.N64;


                case "switch":
                case "nintendoswitch":
                case "nswitch":

                    return PlatformId.SWITCH;

                case "wii":
                case "nintendowii":

                    return PlatformId.WII;

                case "wiiu":
                case "nintendowiiu":

                    return PlatformId.WIIU;

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

                case "ps2":
                case "playstation2":
                case "play2":
                case "playtwo":
                case "playstationtwo":
                    return PlatformId.PS2;

                case "psp":
                case "playstationportable":
                    return PlatformId.PSP;


                case "arcade":

                    return PlatformId.ARCADE;

                case "neogeo":

                    return PlatformId.NEOGEO;

                case "cps3":

                    return PlatformId.CPS3;

                case "cps2":

                    return PlatformId.CPS2;

                case "cps1":

                    return PlatformId.CPS1;

               
                case "pcengine":
                case "pce":

                    return PlatformId.PCENGINE;

                case "pcenginecd":
                case "pcecd":

                    return PlatformId.PCENGINECD;


                case "sharpx68000":
                case "sharpx68":

                    return PlatformId.SHARPX68000;



                case "dos":

                    return PlatformId.DOS;

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
