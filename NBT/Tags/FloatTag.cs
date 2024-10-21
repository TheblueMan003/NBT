using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    /// <summary>
    /// Represents a tag that stores a single-precision floating-point value.
    /// </summary>
    public class FloatTag : Tag
    {
        /// <summary>
        /// Gets or sets the value of the FloatTag.
        /// </summary>
        public float Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatTag"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="value">The value of the tag.</param>
        public FloatTag(string name, float value) : base(name, TagType.Float)
        {
            Value = value;
        }

        /// <summary>
        /// Converts the FloatTag to its string representation in SNBT format.
        /// </summary>
        /// <returns>The FloatTag value as a string in SNBT format.</returns>
        public override string ToSNBT()
        {
            return $"{Value}f";
        }

        /// <summary>
        /// Writes the FloatTag value to the specified stream using the specified binary utils context.
        /// </summary>
        /// <param name="data">The stream to write the value to.</param>
        /// <param name="context">The binary utils context to use for writing.</param>
        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteFloat(data, Value, context);
        }
    }
}
