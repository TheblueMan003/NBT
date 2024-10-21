using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TheblueMan003.NBT.BinaryUtils;

namespace TheblueMan003.NBT
{
    public class BinaryUtilsContext
    {
        public Endian Endian;
        public bool Compressed;
        public int HeaderSize;

        public bool IsLittleEndian => Endian == Endian.Little;
        public bool IsBigEndian => Endian == Endian.Big;

        public BinaryUtilsContext(Endian endian, bool compressed, int headerSize)
        {
            Endian = endian;
            Compressed = compressed;
            HeaderSize = headerSize;
        }
    }
}
