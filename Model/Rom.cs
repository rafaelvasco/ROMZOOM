using System;
using ProtoBuf;
using ROMZOOM.Logic;

namespace ROMZOOM.Model
{
    [ProtoContract]
    public class Rom : IEquatable<Rom>
    {
        [ProtoMember(1)]
        public PlatformId PlatformId { get; }

        [ProtoMember(2)]
        public string Name { get; }

        [ProtoMember(3)]
        public string Path { get;  }

        [ProtoMember(4)]
        public int Md5 { get; }

        [ProtoMember(5)]
        public int TimesPlayed { get; set; }



        public Rom() {}

        public Rom(PlatformId platform_id, string name, string path)
        {
            PlatformId = platform_id;
            Name = name;
            Path = path;

            Md5 = Utils.CreateMD5(Path).GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }


        public bool Equals(Rom other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Md5 == other.Md5;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rom) obj);
        }

        public override int GetHashCode()
        {
            return Md5;
        }
    }
}
