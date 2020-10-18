using System;
using ProtoBuf;

namespace ROMZOOM.Model
{
    [ProtoContract]
    public class Platform : IEquatable<Platform>
    {
        [ProtoMember(1)]
        public PlatformId PlatformId { get; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public string Path { get; set; }

        [ProtoMember(4)]
        public int EmulatorId { get; set; }

        [ProtoMember(5)]
        public int LaunchArgId { get; set; }

        public Platform() {}

        public Platform(PlatformId platform_id, string name, string path)
        {
            PlatformId = platform_id;
            Path = path;
            Name = name;
            EmulatorId = 0;
            LaunchArgId = 0;
        }

        public static Platform All => new Platform(PlatformId.ALL, "ALL", null);

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(Platform other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return PlatformId == other.PlatformId;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Platform) obj);
        }

        public override int GetHashCode()
        {
            return (int) PlatformId;
        }
    }
}
