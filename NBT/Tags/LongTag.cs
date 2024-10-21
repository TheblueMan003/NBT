using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class LongTag : Tag
    {
        public long Value;

        public LongTag(string name, long value) : base(name, TagType.Long)
        {
            Value = value;
        }

        public override string ToSNBT()
        {
            return $"{Value}l";
        }

        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteLong(data, Value, context);
        }
    }
}
