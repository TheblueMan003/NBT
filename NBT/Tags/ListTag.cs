using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class ListTag : Tag
    {
        public List<Tag> Value;
        public TagType Subtype;

        public ListTag(string name, List<Tag> value, TagType subtype) : base(name, TagType.List)
        {
            Value = value;
            Subtype = subtype;
        }

        public override string ToSNBT()
        {
            if (Value.Count == 0)
            {
                return "[]";
            }
            StringBuilder sb = new StringBuilder("[");
            foreach (Tag tag in Value)
            {
                sb.Append(tag.ToSNBT());
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }

        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteByte(data, (byte)Subtype, context);
            BinaryUtils.WriteInt(data, Value.Count, context);
            foreach (Tag tag in Value)
            {
                tag.Write(data, context);
            }
        }
    }
}
