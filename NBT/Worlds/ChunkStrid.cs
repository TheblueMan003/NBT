using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Worlds
{
    public class ChunkStrid<T> where T : class
    {
        public ulong[] Indexes;
        public T[] Palettes;
        private int bitsPerBlock;

        public ChunkStrid(ulong[] indexes, T[] palettes)
        {
            Indexes = indexes;
            Palettes = palettes;

            bitsPerBlock = Math.Max(4, (int)Math.Ceiling(Math.Log2(Palettes.Length)));
        }

        public ChunkStrid(long[] indexes, T[] palettes)
        {
            Indexes = new ulong[indexes.Length];
            for (int i = 0; i < indexes.Length; i++)
                Indexes[i] = (ulong)indexes[i];
            Palettes = palettes;

            bitsPerBlock = Math.Max(4, (int)Math.Ceiling(Math.Log2(Palettes.Length)));
        }

        public T Get(int x, int y, int z)
        {
            if (x < 0 || x >= 16 || y < 0 || y >= 16 || z < 0 || z >= 16)
                throw new IndexOutOfRangeException("The x, y, and z values must be between 0 and 15");

            int index = (y << 8) | (z << 4) | x;

            int indexIndex = index * bitsPerBlock / 64;
            int indexOffset = index * bitsPerBlock % 64;

            ulong value = (Indexes[indexIndex] >> indexOffset) & ((1UL << bitsPerBlock) - 1);

            return Palettes[value];
        }

        public void Fill(T value)
        {
            Indexes = new ulong[256];
            Palettes = new T[] { value };
            bitsPerBlock = 4;
        }

        public void Set(int x, int y, int z, T value)
        {
            if (x < 0 || x >= 16 || y < 0 || y >= 16 || z < 0 || z >= 16)
                throw new IndexOutOfRangeException("The x, y, and z values must be between 0 and 15");

            int paletteIndex = Array.IndexOf(Palettes, value);
            if (paletteIndex == -1)
            {
                Array.Resize(ref Palettes, Palettes.Length + 1);
                Palettes[Palettes.Length - 1] = value;

                var oldBitsPerBlock = bitsPerBlock;
                bitsPerBlock = Math.Max(4, (int)Math.Ceiling(Math.Log2(Palettes.Length)));

                if (oldBitsPerBlock != bitsPerBlock)
                {
                    ulong[] oldIndexes = Indexes;
                    Indexes = new ulong[(4096 * bitsPerBlock) / 64];
                    for (int i = 0; i < 256; i++)
                    {
                        int oldIndexIndex = i * oldBitsPerBlock / 64;
                        int oldIndexOffset = i * oldBitsPerBlock % 64;

                        ulong oldValue = (oldIndexes[oldIndexIndex] >> oldIndexOffset) & ((1UL << oldBitsPerBlock) - 1);

                        int newIndexIndex = i * bitsPerBlock / 64;
                        int newIndexOffset = i * bitsPerBlock % 64;

                        ulong mask = ((1UL << oldBitsPerBlock) - 1) << oldIndexOffset;
                        Indexes[newIndexIndex] = (Indexes[newIndexIndex] & ~mask) | (oldValue << newIndexOffset);
                    }
                }
                paletteIndex = Array.IndexOf(Palettes, value);
            }

            // Set
            {
                int index = (y << 8) | (z << 4) | x;

                int indexIndex = index * bitsPerBlock / 64;
                int indexOffset = index * bitsPerBlock % 64;

                ulong mask = ((1UL << bitsPerBlock) - 1) << indexOffset;
                Indexes[indexIndex] = (Indexes[indexIndex] & ~mask) | ((ulong)paletteIndex << indexOffset);
            }
        }
    }
}