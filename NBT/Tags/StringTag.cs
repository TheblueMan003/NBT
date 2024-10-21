using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    /// <summary>
    /// Represents a tag that stores a string value.
    /// </summary>
    public class StringTag : Tag
    {
        /// <summary>
        /// Gets or sets the string value.
        /// </summary>
        public string Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringTag"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="value">The string value.</param>
        public StringTag(string name, string value) : base(name, TagType.String)
        {
            Value = value;
        }

        /// <summary>
        /// Converts the tag to its stringified NBT representation.
        /// </summary>
        /// <returns>The stringified NBT representation of the tag.</returns>
        public override string ToSNBT()
        {
            return $"\"{Value}\"";
        }

        /// <summary>
        /// Writes the tag to the specified stream using the specified binary utils context.
        /// </summary>
        /// <param name="data">The stream to write the tag to.</param>
        /// <param name="context">The binary utils context.</param>
        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteString(data, Value, context);
        }
    }
}
