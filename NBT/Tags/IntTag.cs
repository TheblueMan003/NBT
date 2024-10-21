using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class IntTag : Tag
    {
        public int Value;

        public IntTag(string name, int value) : base(name, TagType.Int)
        {
            Value = value;
        }

        public override string ToSNBT()
        {
            return $"{Value}";
        }

        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteInt(data, Value, context);
        }
    }
}
