using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class ByteArrayTag : Tag
    {
        /// <summary>
        /// Gets or sets the value of the ByteArrayTag.
        /// </summary>
        public byte[] Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ByteArrayTag"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="value">The byte array value of the tag.</param>
        public ByteArrayTag(string name, byte[] value) : base(name, TagType.ByteArray)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the byte value at the specified index.
        /// </summary>
        /// <param name="index">The index of the byte value.</param>
        /// <returns>The byte value at the specified index.</returns>
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

        /// <summary>
        /// Gets the length of the byte array.
        /// </summary>
        public int Length
        {
            get
            {
                return Value.Length;
            }
        }

        /// <summary>
        /// Resizes the byte array to the specified new size.
        /// </summary>
        /// <param name="newSize">The new size of the byte array.</param>
        public void Resize(int newSize)
        {
            Array.Resize(ref Value, newSize);
        }

        /// <summary>
        /// Adds a byte value to the byte array.
        /// </summary>
        /// <param name="value">The byte value to add.</param>
        public void Add(byte value)
        {
            Resize(Length + 1);
            Value[Length - 1] = value;
        }

        /// <summary>
        /// Converts the byte array tag to its string representation in SNBT format.
        /// </summary>
        /// <returns>The string representation of the byte array tag in SNBT format.</returns>
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

        /// <summary>
        /// Writes the byte array tag to the specified stream using the specified binary utils context.
        /// </summary>
        /// <param name="data">The stream to write the byte array tag to.</param>
        /// <param name="context">The binary utils context to use for writing.</param>
        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteByteArray(data, Value, context);
        }
    }
}