using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Worlds
{
    public class Region
    {
        public List<Chunk> Chunks = new List<Chunk>();
        public Dictionary<Vector2Int, Chunk> ChunksDict = new Dictionary<Vector2Int, Chunk>();

        public static Region ReadFromFile(string path)
        {
            var region = new Region();

            var context = new BinaryUtilsContext(Endian.Big, Compression.None, 0);
            int[] offsets = new int[1024];
            byte[] sectorsCounts = new byte[1024];
            int[] timestamps = new int[1024];

            using (var file = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                for (int i = 0; i < 1024; i++)
                {
                    int offset = BinaryUtils.ReadInt24(file, context);
                    byte sectorCount = BinaryUtils.ReadByte(file, context);

                    offsets[i] = offset;
                    sectorsCounts[i] = sectorCount;
                }
                for (int i = 0; i < 1024; i++)
                {
                    int timestamp = BinaryUtils.ReadInt(file, context);
                    timestamps[i] = timestamp;
                }

                for (int i = 0; i < 1024; i++)
                {
                    int offset = offsets[i];
                    byte sectorCount = sectorsCounts[i];

                    if (offset == 0 || sectorCount == 0)
                    {
                        continue;
                    }

                    file.Seek(offset * 4096L, System.IO.SeekOrigin.Begin);

                    Chunk chunk = ReadChunk(offset, sectorCount, timestamps[i], file, context);
                    region.Chunks.Add(chunk);
                    region.ChunksDict[new Vector2Int(chunk.RegionX, chunk.RegionZ)] = chunk;
                }
            }

            return region;
        }

        private static Chunk ReadChunk(int offset, int sectorCount, int timestamp, Stream stream, BinaryUtilsContext context)
        {
            int length = BinaryUtils.ReadInt(stream, context) - 1;
            byte compression = BinaryUtils.ReadByte(stream, context);

            byte[] data = new byte[length];
            int size = stream.Read(data, 0, length);

            if (size != length)
            {
                throw new Exception("Failed to read chunk data");
            }

            Stream stream1 = new MemoryStream(data);

            var nbt = Converter.ParseFromStream(stream1, new BinaryUtilsContext(Endian.Big, (Compression)compression, 0));

            return new Chunk(offset, timestamp, (Compression)compression, nbt);
        }

        public Chunk? GetChunk(int x, int z)
        {
            var pos = new Vector2Int(x, z);
            if (ChunksDict.ContainsKey(pos))
            {
                return ChunksDict[pos];
            }
            return null;
        }
    }
}
