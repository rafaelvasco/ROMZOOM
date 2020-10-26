
using System.Collections.Generic;

namespace ROMZOOM.Model
{
    public enum PlatformId
    {
        UNKNOWN,
        ARCADE,
        CPS1,
        CPS2,
        CPS3,
        NEOGEO,
        DOS,
        N64,
        NDS,
        _3DS,
        SNES,
        NES,
        GBA,
        GBC,
        PSX,
        GENESIS,
        GC,
        PC98,
        PCENGINE,
        PCENGINECD,
        SHARPX68000,
        SWITCH,
        PS2,
        PS3,
        PSP,
        WIIU,
        WII,
        ALL
    }



    public static class PlatformIdMethods {

        private static readonly Dictionary<PlatformId, string> _dictionary = new Dictionary<PlatformId, string>
        {
            { PlatformId.NES, "NINTENDO" },
            { PlatformId.SNES, "SUPER NINTENDO" },
            { PlatformId.GENESIS, "GENESIS" },
            { PlatformId.GBA, "NINTENDO GAMEBOY ADVANCE" },
            { PlatformId.GBC, "NINTENDO GAMEBOY COLOR" },
            { PlatformId.PSX, "PLAYSTATION ONE" },

            { PlatformId.ARCADE, "ARCADE" },
            { PlatformId.CPS1, "CPS-1" },
            { PlatformId.CPS2, "CPS-2" },
            { PlatformId.CPS3, "CPS-3" },
            { PlatformId.NEOGEO, "NEOGEO" },
            { PlatformId.DOS, "DOS" },
            { PlatformId.N64, "NINTENDO 64" },
            { PlatformId.NDS, "NINTENDO DS" },
            { PlatformId._3DS, "NINTENDO 3DS" },

            { PlatformId.GC, "GAME CUBE" },
            { PlatformId.PC98, "PC-98" },
            { PlatformId.PCENGINE, "PC-ENGINE" },
            { PlatformId.PCENGINECD, "PC-ENGINE CD" },
            { PlatformId.SHARPX68000, "SHARP X68000" },
            { PlatformId.SWITCH, "NINTENDO SWITCH" },
            { PlatformId.PS2, "PLAYSTATION 2" },
            { PlatformId.PS3, "PLAYSTATION 3" },
            { PlatformId.PSP, "PLAYSTATION PORTABLE" },
            { PlatformId.WIIU, "NINTENDO WIIU" },
            { PlatformId.WII, "NINTENDO WII" },

        };

        public static List<PlatformId> GetAllValid()
        {
            return new List<PlatformId>()
            {
                PlatformId.NES,
                PlatformId.SNES,
                PlatformId.GENESIS,
                PlatformId.GBA,
                PlatformId.GBC,
                PlatformId.PSX,

                PlatformId.ARCADE,
                PlatformId.CPS1, 
                PlatformId.CPS2, 
                PlatformId.CPS3,
                PlatformId.NEOGEO, 
                PlatformId.DOS, 
                PlatformId.N64,
                PlatformId.NDS, 
                PlatformId._3DS,

                PlatformId.GC, 
                PlatformId.PC98, 
                PlatformId.PCENGINE, 
                PlatformId.PCENGINECD, 
                PlatformId.SHARPX68000, 
                PlatformId.SWITCH,
                PlatformId.PS2, 
                PlatformId.PS3, 
                PlatformId.PSP, 
                PlatformId.WIIU,
                PlatformId.WII
            };
        }

        public static string GetDisplayName(PlatformId platform_id)
        {
            return _dictionary[platform_id];
        }
    }
}
