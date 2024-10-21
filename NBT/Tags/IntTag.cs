using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    /// <summary>
    /// Represents an integer tag in NBT format.
    /// </summary>
    public class IntTag : Tag
    {
        /// <summary>
        /// Gets or sets the value of the integer tag.
        /// </summary>
        public int Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntTag"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the integer tag.</param>
        /// <param name="value">The value of the integer tag.</param>
        public IntTag(string name, int value) : base(name, TagType.Int)
        {
            Value = value;
        }

        /// <summary>
        /// Converts the integer tag to its string representation in SNBT format.
        /// </summary>
        /// <returns>The string representation of the integer tag in SNBT format.</returns>
        public override string ToSNBT()
        {
            return $"{Value}";
        }

        /// <summary>
        /// Writes the integer tag to the specified stream using the specified binary utils context.
        /// </summary>
        /// <param name="data">The stream to write the integer tag to.</param>
        /// <param name="context">The binary utils context to use for writing.</param>
        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteInt(data, Value, context);
        }
    }
}
