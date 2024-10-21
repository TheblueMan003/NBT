using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    /// <summary>
    /// Represents a tag that stores an array of long values.
    /// </summary>
    public class LongArrayTag : Tag
    {
        /// <summary>
        /// Gets or sets the array of long values.
        /// </summary>
        public long[] Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="LongArrayTag"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="value">The array of long values.</param>
        public LongArrayTag(string name, long[] value) : base(name, TagType.LongArray)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the long value at the specified index.
        /// </summary>
        /// <param name="index">The index of the long value.</param>
        /// <returns>The long value at the specified index.</returns>
        public long this[int index]
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
        /// Gets the length of the array.
        /// </summary>
        public int Length
        {
            get
            {
                return Value.Length;
            }
        }

        /// <summary>
        /// Resizes the array to the specified size.
        /// </summary>
        /// <param name="newSize">The new size of the array.</param>
        public void Resize(int newSize)
        {
            Array.Resize(ref Value, newSize);
        }

        /// <summary>
        /// Adds a long value to the end of the array.
        /// </summary>
        /// <param name="value">The long value to add.</param>
        public void Add(long value)
        {
            Resize(Length + 1);
            Value[Length - 1] = value;
        }

        /// <summary>
        /// Converts the tag to its string representation in SNBT format.
        /// </summary>
        /// <returns>The string representation of the tag in SNBT format.</returns>
        public override string ToSNBT()
        {
            StringBuilder builder = new StringBuilder("[L;");
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
        /// Writes the tag to the specified stream using the specified binary utils context.
        /// </summary>
        /// <param name="data">The stream to write the tag to.</param>
        /// <param name="context">The binary utils context to use.</param>
        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteLongArray(data, Value, context);
        }
    }
}