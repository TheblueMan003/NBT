using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    /// <summary>
    /// Represents a tag that stores a 64-bit signed integer value.
    /// </summary>
    public class LongTag : Tag
    {
        /// <summary>
        /// Gets or sets the value of the LongTag.
        /// </summary>
        public long Value;

        /// <summary>
        /// Initializes a new instance of the LongTag class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the LongTag.</param>
        /// <param name="value">The value of the LongTag.</param>
        public LongTag(string name, long value) : base(name, TagType.Long)
        {
            Value = value;
        }

        /// <summary>
        /// Converts the LongTag to its string representation in SNBT format.
        /// </summary>
        /// <returns>The SNBT representation of the LongTag.</returns>
        public override string ToSNBT()
        {
            return $"{Value}l";
        }

        /// <summary>
        /// Writes the LongTag to the specified stream using the specified BinaryUtilsContext.
        /// </summary>
        /// <param name="data">The stream to write the LongTag to.</param>
        /// <param name="context">The BinaryUtilsContext to use for writing.</param>
        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteLong(data, Value, context);
        }
    }
}
