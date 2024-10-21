using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class DoubleTag : Tag
    {
        public double Value;

        public DoubleTag(string name, double value) : base(name, TagType.Double)
        {
            Value = value;
        }

        public override string ToSNBT()
        {
            return $"{Value}d";
        }

        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteDouble(data, Value, context);
        }
    }
}
