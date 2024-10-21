using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class ByteTag : Tag
    {
        /// <summary>
        /// Gets or sets the value of the ByteTag.
        /// </summary>
        public byte Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ByteTag"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="value">The value of the tag.</param>
        public ByteTag(string name, byte value) : base(name, TagType.Byte)
        {
            Value = value;
        }

        /// <summary>
        /// Converts the ByteTag to its SNBT (Stringified NBT) representation.
        /// </summary>
        /// <returns>The SNBT representation of the ByteTag.</returns>
        public override string ToSNBT()
        {
            return $"{Value}b";
        }

        /// <summary>
        /// Writes the ByteTag to the specified stream using the specified binary utils context.
        /// </summary>
        /// <param name="data">The stream to write the ByteTag to.</param>
        /// <param name="context">The binary utils context to use for writing.</param>
        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteByte(data, Value, context);
        }
    }
}
