using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public class DoubleTag : Tag
    {
        /// <summary>
        /// Gets or sets the value of the DoubleTag.
        /// </summary>
        public double Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleTag"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the DoubleTag.</param>
        /// <param name="value">The value of the DoubleTag.</param>
        public DoubleTag(string name, double value) : base(name, TagType.Double)
        {
            Value = value;
        }

        /// <summary>
        /// Converts the DoubleTag to its string representation in SNBT format.
        /// </summary>
        /// <returns>The string representation of the DoubleTag in SNBT format.</returns>
        public override string ToSNBT()
        {
            return $"{Value}d";
        }

        /// <summary>
        /// Writes the DoubleTag to the specified stream using the specified binary utils context.
        /// </summary>
        /// <param name="data">The stream to write the DoubleTag to.</param>
        /// <param name="context">The binary utils context to use for writing.</param>
        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteDouble(data, Value, context);
        }
    }
}
