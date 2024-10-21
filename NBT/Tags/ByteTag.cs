using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class ByteTag : Tag
    {
        public byte Value;

        public ByteTag(string name, byte value) : base(name, TagType.Byte)
        {
            Value = value;
        }

        public override string ToSNBT()
        {
            return $"{Value}b";
        }

        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteByte(data, Value, context);
        }
    }
}
