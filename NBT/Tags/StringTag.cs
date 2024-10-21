using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class StringTag : Tag
    {
        public string Value;

        public StringTag(string name, string value) : base(name, TagType.String)
        {
            Value = value;
        }

        public override string ToSNBT()
        {
            return $"\"{Value}\"";
        }

        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteString(data, Value, context);
        }
    }
}
