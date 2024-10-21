using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class ShortTag : Tag
    {
        public short Value;

        public ShortTag(string name, short value) : base(name, TagType.Short)
        {
            Value = value;
        }

        public override string ToSNBT()
        {
            return $"{Value}s";
        }

        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteShort(data, Value, context);
        }
    }
}
