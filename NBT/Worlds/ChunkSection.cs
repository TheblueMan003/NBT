using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Worlds
{
    public class ChunkSection
    {
        public ChunkStrid<string> Biomes;
        public ChunkStrid<BlockStates> Blocks;

        public void FillBiomes(string biomes)
        {
            Biomes.Fill(biomes);
        }

        public void FillBlocks(BlockStates blocks)
        {
            Blocks.Fill(blocks);
        }
    }
}
