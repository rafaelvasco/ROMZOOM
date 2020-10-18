using System;
using System.Collections.Generic;
using ProtoBuf;

namespace ROMZOOM.Model
{
    [ProtoContract]
    public class LaunchArg
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public string Arg { get; set; }

        public int Uid { get; }

        public LaunchArg() {}

        public LaunchArg(string name, string arg)
        {
            Uid = Guid.NewGuid().GetHashCode();
            Name = name;
            Arg = arg;
        }
    }

    [ProtoContract]
    public class Emulator : IEquatable<Emulator>
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public string Path { get; set; }

        [ProtoMember(3)]
        public Dictionary<int, LaunchArg> LaunchArgs { get; set; }

        [ProtoMember(4)]
        public int Uid { get; }

        public Emulator()
        {
            LaunchArgs = new Dictionary<int, LaunchArg>();

            Uid = Guid.NewGuid().GetHashCode();
        }

        public Emulator(Emulator emulator)
        {
            Name = emulator.Name;
            Uid = emulator.Uid;
            Path = emulator.Path;
            LaunchArgs = new Dictionary<int, LaunchArg>();

            foreach (var emulator_launch_arg in emulator.LaunchArgs)
            {
                LaunchArgs.Add(emulator_launch_arg.Key, new LaunchArg(emulator_launch_arg.Value.Name, emulator_launch_arg.Value.Arg));
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(Emulator other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Uid == other.Uid;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Emulator) obj);
        }

        public override int GetHashCode()
        {
            return Uid;
        }

    }
}
