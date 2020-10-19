using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProtoBuf;
using ROMZOOM.Logic;

namespace ROMZOOM.Model
{
    [ProtoContract]
    public class LibraryData
    {

        [ProtoMember(1)]
        public string RootPath { get; set; }

        [ProtoMember(2)]
        public Dictionary<PlatformId, Platform> Platforms { get; } = new Dictionary<PlatformId, Platform>();

        [ProtoMember(3)]
        public Dictionary<PlatformId, List<Rom>> Roms { get; } = new Dictionary<PlatformId, List<Rom>>();

        [ProtoMember(4)] 
        public Dictionary<int, Emulator> Emulators = new Dictionary<int, Emulator>();

        [ProtoMember(5)]
        public DateTime ModifyDate;

        [ProtoMember(6)]
        public Dictionary<int, byte[]> RomImageBank = new Dictionary<int, byte[]>();

        public Dictionary<int, Bitmap> RomImages = new Dictionary<int, Bitmap>();
    }

    public static class Library
    {
        public static string RootPath
        {
            get => _data.RootPath;
            set
            {
                _data.RootPath = value;
                _modify_time = DateTime.Now;
            }
        }

        public static Dictionary<PlatformId, Platform> Platforms => _data.Platforms;

        public static Dictionary<PlatformId, List<Rom>> Roms => _data.Roms;

        public static Dictionary<int, Emulator> Emulators => _data.Emulators;

        public static Dictionary<int, Bitmap> RomsImages => _data.RomImages;

        private static LibraryData _data;

        private static DateTime _modify_time;

        public static void Load()
        {
            var path = Path.Combine( Application.StartupPath, "library.bin");

            if (File.Exists(path))
            {
                using (var file = File.OpenRead(path))
                {
                    _data = Serializer.Deserialize<LibraryData>(file);
                    LoadRomImages();
                    _modify_time = _data.ModifyDate;
                }
            }
            else
            {
                _data = new LibraryData();

                Save();
            }
        }

        private static void LoadRomImages()
        {
            foreach (var rom_image_data in _data.RomImageBank)
            {
                using (var ms = new MemoryStream(rom_image_data.Value))
                {
                    var rom_image = new Bitmap(ms);

                    _data.RomImages.Add(rom_image_data.Key, rom_image);
                }
            }
        }

        public static void Save()
        {
            if (_data.ModifyDate != default && DateTime.Compare(_modify_time, _data.ModifyDate) <= 0)
            {
                return;
            }

            Messager.Emit((int) MessageCodes.LibraryModified);

            var path = Path.Combine(Application.StartupPath, "library.bin");

            _data.ModifyDate = _modify_time;

            using (var file = File.Open(path, FileMode.Create))
            {
                Serializer.Serialize(file, _data);
            }
        }

        public static bool ContainsPlatform(PlatformId platform_id)
        {
            return _data.Platforms.TryGetValue(platform_id, out _);
        }

        public static bool ContainsRom(PlatformId platform_id, Rom rom)
        {
            return _data.Roms.TryGetValue(platform_id, out _) && _data.Roms[platform_id].Contains(rom);
        }

        public static void AddPlatform(Platform platform)
        {
            _modify_time = DateTime.Now;
            _data.Platforms.Add(platform.PlatformId, platform);
            _data.Roms[platform.PlatformId] = new List<Rom>();
        }

        public static void AddRom(Rom rom)
        {
            _modify_time = DateTime.Now;
            _data.Roms[rom.PlatformId].Add(rom); 
        }

        public static void AddEmulator(Emulator emu)
        {
            _modify_time = DateTime.Now;
            _data.Emulators.Add(emu.Uid, emu);
        }

        public static void SetRomImage(Rom rom, string image_path)
        {
            Bitmap bitmap;

            using (var stream = File.OpenRead(image_path))
            {
                bitmap = new Bitmap(stream);
            }

            _modify_time = DateTime.Now;

            if (_data.RomImages.ContainsKey(rom.Md5))
            {
                _data.RomImages[rom.Md5].Dispose();
            }

            _data.RomImages[rom.Md5] = bitmap;
            _data.RomImageBank[rom.Md5] = Utils.BitmapToByteArray(bitmap);
        }

        public static void ReleaseResources()
        {
            foreach (var data_rom_image in _data.RomImages)
            {
                data_rom_image.Value.Dispose();
            }
        }

        public static void MarkDirty()
        {
            _modify_time = DateTime.Now;
        }

    }
}
