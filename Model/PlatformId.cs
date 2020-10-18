
using System.Collections.Generic;

namespace ROMZOOM.Model
{
    public enum PlatformId
    {
        UNKNOWN,
        SNES,
        NES,
        GBA,
        PSX,
        GENESIS,
        ALL
    }

    public static class PlatformIdDefaultDisplayNames {

        private static readonly Dictionary<PlatformId, string> _dictionary = new Dictionary<PlatformId, string>
        {
            { PlatformId.NES, "NES" },
            { PlatformId.SNES, "SNES" },
            { PlatformId.GENESIS, "GENESIS" },
            { PlatformId.GBA, "GBA" },
            { PlatformId.PSX, "PSX" }
        };

        public static string Get(PlatformId platform_id)
        {
            return _dictionary[platform_id];
        }
    }
}
