using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Worlds
{
    public class Chunk
    {
        public int RegionX => X & 31;
        public int RegionZ => Z & 31;

        public int X => Data["xPos"];
        public int Z => Data["zPos"];

        public int Offset;
        public int Timestamp;

        public Compression Compression;

        public NBTData Data;

        public Dictionary<int, ChunkSection> Sections = new Dictionary<int, ChunkSection>();

        public Chunk(int offset, int timestamp, Compression compression, NBTData data)
        {
            Offset = offset;
            Timestamp = timestamp;
            Compression = compression;
            Data = data;

            LoadData();
        }

        public Chunk(int x, int y)
        {
            Offset = x | (y << 8);
            Timestamp = 0;
            Compression = Compression.ZLIB;

            Data = new NBTData();
        }

        private void LoadData()
        {
            foreach (var sectionData in Data["sections"])
            {
                var section = new ChunkSection();
                if (sectionData.Contains("Y"))
                {
                    Sections.Add((sbyte)sectionData["Y"], section);
                }
                else
                {
                    Sections.Add(0, section);
                }

                // Load Blocks
                if (sectionData.Contains("block_states"))
                {
                    var state = sectionData["block_states.palette"].Select(x => new BlockStates(x)).ToArray() ?? throw new Exception("No palette found");
                    if (sectionData.Contains("block_states.data"))
                    {
                        section.Blocks = new ChunkStrid<BlockStates>((long[])sectionData["block_states.data"], state);
                    }
                    else
                    {
                        section.Blocks = new ChunkStrid<BlockStates>(new ulong[256], state);
                    }
                }
                else
                {
                    section.Blocks = new ChunkStrid<BlockStates>(new ulong[256], new BlockStates[1] { new BlockStates("minecraft:air") });
                }

                // Load Biomes
                if (sectionData.Contains("biomes"))
                {
                    var biomes = sectionData["biomes.palette"].Select(x => (string)x).ToArray();
                    if (sectionData.Contains("biomes.data"))
                    {
                        section.Biomes = new ChunkStrid<string>((long[])sectionData["biomes.data"], biomes);
                    }
                    else
                    {
                        section.Biomes = new ChunkStrid<string>(new ulong[256], biomes);
                    }
                }
                else
                {
                    section.Biomes = new ChunkStrid<string>(new ulong[256], new string[1] { "minecraft:plains" });
                }
            }
        }

        public void CreateNewSection(int y)
        {
            if (Sections.ContainsKey(y))
            {
                throw new Exception("Section already exists");
            }

            var section = new ChunkSection();
            Sections.Add(y, section);

            section.Blocks = new ChunkStrid<BlockStates>(new ulong[256], new BlockStates[1] { new BlockStates("minecraft:air") });
            section.Biomes = new ChunkStrid<string>(new ulong[256], new string[1] { "minecraft:plains" });
        }

        public ChunkSection GetSection(int y)
        {
            if (!Sections.ContainsKey(y))
            {
                return null;
            }
            return Sections[y];
        }

        public ChunkSection GetOrCreateSection(int y)
        {
            if (!Sections.ContainsKey(y))
            {
                CreateNewSection(y);
            }
            return GetSection(y);
        }

        public void SetBlock(int x, int y, int z, string block)
        {

        }

        public BlockStates GetBlock(int x, int y, int z)
        {
            if (!Sections.ContainsKey(y >> 4))
            {
                return new BlockStates("minecraft:air");
            }
            return GetOrCreateSection(y >> 4).Blocks.Get(x, y & 15, z);
        }

        public string GetBiome(int x, int y, int z)
        {
            if (!Sections.ContainsKey(y >> 4))
            {
                return "minecraft:plains";
            }
            return GetOrCreateSection(y >> 4).Biomes.Get(x, y & 15, z);
        }
    }
}
