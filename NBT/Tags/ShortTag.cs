using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    /// <summary>
    /// Represents a tag that stores a short value.
    /// </summary>
    public class ShortTag : Tag
    {
        /// <summary>
        /// Gets or sets the value of the short tag.
        /// </summary>
        public short Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortTag"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="value">The value of the tag.</param>
        public ShortTag(string name, short value) : base(name, TagType.Short)
        {
            Value = value;
        }

        /// <summary>
        /// Converts the short tag to its string representation in SNBT format.
        /// </summary>
        /// <returns>The string representation of the short tag in SNBT format.</returns>
        public override string ToSNBT()
        {
            return $"{Value}s";
        }

        /// <summary>
        /// Writes the short tag to the specified stream using the specified binary utils context.
        /// </summary>
        /// <param name="data">The stream to write the short tag to.</param>
        /// <param name="context">The binary utils context to use for writing.</param>
        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteShort(data, Value, context);
        }
    }
}
