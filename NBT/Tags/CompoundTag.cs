using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class CompoundTag : Tag
    {
        public Dictionary<string, Tag> Value = new Dictionary<string, Tag>();

        public CompoundTag(string name, Dictionary<string, Tag> value) : base(name, TagType.Compound)
        {
            Value = value;
        }

        public override string ToSNBT()
        {
            if (Value.Count == 0)
            {
                return "{}";
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            foreach (KeyValuePair<string, Tag> tag in Value)
            {
                builder.Append($"{tag.Key}:{tag.Value.ToSNBT()},");
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append("}");
            return builder.ToString();
        }

        public override void Write(Stream data, BinaryUtilsContext context)
        {
            foreach (KeyValuePair<string, Tag> tag in Value)
            {
                BinaryUtils.WriteByte(data, (byte)tag.Value.Type, context);
                BinaryUtils.WriteString(data, tag.Key, context);
                tag.Value.Write(data, context);
            }
            BinaryUtils.WriteByte(data, 0, context);
        }
    }
}
