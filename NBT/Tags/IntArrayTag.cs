using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    /// <summary>
    /// Represents a tag that stores an array of integers.
    /// </summary>
    public class IntArrayTag : Tag
    {
        /// <summary>
        /// Gets or sets the array of integers.
        /// </summary>
        public int[] Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntArrayTag"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="value">The array of integers.</param>
        public IntArrayTag(string name, int[] value) : base(name, TagType.IntArray)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the integer at the specified index.
        /// </summary>
        /// <param name="index">The index of the integer.</param>
        /// <returns>The integer at the specified index.</returns>
        public int this[int index]
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
        /// Adds an integer to the end of the array.
        /// </summary>
        /// <param name="value">The integer to add.</param>
        public void Add(int value)
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
            StringBuilder builder = new StringBuilder("[I;");
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
            BinaryUtils.WriteIntArray(data, Value, context);
        }
    }
}