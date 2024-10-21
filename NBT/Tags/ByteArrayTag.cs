using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class ByteArrayTag : Tag
    {
        public byte[] Value;

        public ByteArrayTag(string name, byte[] value) : base(name, TagType.ByteArray)
        {
            Value = value;
        }

        public byte this[int index]
        {
            get
            {
                return Value[index];
            }
            set
            {
                Value[index] = value;
            }
        }

        public int Length
        {
            get
            {
                return Value.Length;
            }
        }

        public void Resize(int newSize)
        {
            Array.Resize(ref Value, newSize);
        }

        public void Add(byte value)
        {
            Resize(Length + 1);
            Value[Length - 1] = value;
        }

        public override string ToSNBT()
        {
            StringBuilder builder = new StringBuilder("[B;");
            for (int i = 0; i < Value.Length; i++)
            {
                builder.Append(Value[i]);
                if (i != Value.Length - 1)
                {
                    builder.Append(",");
                }
            }
            builder.Append("]");
            return builder.ToString();
        }

        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteByteArray(data, Value, context);
        }
    }
}