using System.Security.Cryptography.X509Certificates;
using TheblueMan003.NBT;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NBTParse()
        {
            var nbt = Converter.ReadJavaFile("Resources/level.dat");
            Console.WriteLine(nbt.ToSNBT());
            Converter.WriteToJavaFile("Resources/level2.dat", nbt);
            var nbt2 = Converter.ReadJavaFile("Resources/level2.dat");
            Assert.IsNotNull(nbt);
        }
    }
}