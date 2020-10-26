using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
        public Dictionary<string, RomImageData> RomImageBank = new Dictionary<string, RomImageData>();

        public Dictionary<string, Bitmap> RomImages = new Dictionary<string, Bitmap>();
    }

    [ProtoContract]
    public class RomImageData
    {
        [ProtoMember(1)]
        public byte[] ImageData { get; set; }
        
        [ProtoMember(2)]
        public int Width { get; set; }

        [ProtoMember(3)]
        public int Height { get; set; }

        [ProtoMember(4)]
        public PixelFormat PixelFormat { get; set; }
    }

    public static class Library
    {
        public static string RootPath
        {
            get => _data.RootPath;
            set
            {
                _data.RootPath = value;
                MarkDirty();
            }
        }

        public static Dictionary<PlatformId, Platform> Platforms => _data.Platforms;

        public static Dictionary<PlatformId, List<Rom>> Roms => _data.Roms;

        public static Dictionary<int, Emulator> Emulators => _data.Emulators;

        public static Dictionary<string, Bitmap> RomsImages => _data.RomImages;

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
                var rom_image = Utils.ByteArrayToBitmap(rom_image_data.Value.ImageData, rom_image_data.Value.Width,
                    rom_image_data.Value.Height, rom_image_data.Value.PixelFormat);

                _data.RomImages.Add(rom_image_data.Key, rom_image);
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
            
            _data.Platforms.Add(platform.PlatformId, platform);
            _data.Roms[platform.PlatformId] = new List<Rom>();

            MarkDirty();
        }

        public static void RemovePlatform(Platform platform)
        {
            List<Rom> to_remove = new List<Rom>(_data.Roms.Count);

            foreach (var rom in _data.Roms[platform.PlatformId])
            {
                to_remove.Add(rom);
            }

            foreach (var rom in to_remove)
            {
                RemoveRom(rom);
            }

            _data.Roms.Remove(platform.PlatformId);

            _data.Platforms.Remove(platform.PlatformId);

            MarkDirty();
        }

        public static void AddRom(Rom rom)
        {
            
            _data.Roms[rom.PlatformId].Add(rom); 

            MarkDirty();
        }

        public static void RemoveRom(Rom rom)
        {
            
            _data.Roms[rom.PlatformId].Remove(rom);

            if (_data.RomImages.ContainsKey(rom.Hash))
            {
                _data.RomImages[rom.Hash].Dispose();
                _data.RomImages.Remove(rom.Hash);
                _data.RomImageBank.Remove(rom.Hash);
            }

            MarkDirty();

        }

        public static void AddEmulator(Emulator emu)
        {
            MarkDirty();
            _data.Emulators.Add(emu.Uid, emu);
        }

        public static void SetRomImage(Rom rom, Bitmap bitmap)
        {
            if (_data.RomImages.ContainsKey(rom.Hash))
            {
                _data.RomImages[rom.Hash].Dispose();
            }

            _data.RomImages[rom.Hash] = bitmap;
            _data.RomImageBank[rom.Hash] = new RomImageData()
            {
                ImageData = Utils.BitmapToByteArray(bitmap),
                Width = bitmap.Width,
                Height = bitmap.Height,
                PixelFormat = bitmap.PixelFormat
            };

            MarkDirty();
        }

        public static void SetRomImage(Rom rom, string image_path)
        {
            Bitmap bitmap = Utils.LoadBitmapFromFile(image_path);

            SetRomImage(rom, bitmap);
        }

        public static void Clear()
        {
            _data.Platforms.Clear();
            _data.Emulators.Clear();

            _data.Roms.Clear();

            ClearImages();

            MarkDirty();
        }

        public static void ClearImages()
        {
            _data.RomImageBank.Clear();

            ReleaseRomImages();

            _data.RomImages.Clear();

            MarkDirty();
        }

        public static void ClearRomImage(Rom rom)
        {
            _data.RomImageBank.Remove(rom.Hash);
            _data.RomImages[rom.Hash].Dispose();
            _data.RomImages.Remove(rom.Hash);

            MarkDirty();
        }

        public static void ReleaseRomImages()
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
