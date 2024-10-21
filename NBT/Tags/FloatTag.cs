using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class FloatTag : Tag
    {
        public float Value;

        public FloatTag(string name, float value) : base(name, TagType.Float)
        {
            Value = value;
        }

        public override string ToSNBT()
        {
            return $"{Value}f";
        }

        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteFloat(data, Value, context);
        }
    }
}
