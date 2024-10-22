using System.Security.Cryptography.X509Certificates;
using TheblueMan003.NBT;
using TheblueMan003.NBT.Worlds;

namespace UnitTest
{
    [TestClass]
    public class RegionTest
    {
        [TestMethod]
        public void NBTParse()
        {
            var region = Region.ReadFromFile("Resources/r.0.0.mca");

            var chunk = region.GetChunk(0, 0);
            var block = chunk.GetBlock(0, -64, 0);

            Assert.AreEqual("minecraft:bedrock", block.ToString());
        }
    }
}