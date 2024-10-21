using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    /// <summary>
    /// Represents a list tag in NBT format.
    /// </summary>
    public class ListTag : Tag
    {
        /// <summary>
        /// Gets or sets the list of tags.
        /// </summary>
        public List<Tag> Value;

        /// <summary>
        /// Gets or sets the subtype of the list.
        /// </summary>
        public TagType Subtype;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListTag"/> class with the specified name, value, and subtype.
        /// </summary>
        /// <param name="name">The name of the list tag.</param>
        /// <param name="value">The list of tags.</param>
        /// <param name="subtype">The subtype of the list.</param>
        public ListTag(string name, List<Tag> value, TagType subtype) : base(name, TagType.List)
        {
            Value = value;
            Subtype = subtype;
        }

        /// <summary>
        /// Converts the list tag to its SNBT (Stringified NBT) representation.
        /// </summary>
        /// <returns>The SNBT representation of the list tag.</returns>
        public override string ToSNBT()
        {
            if (Value.Count == 0)
            {
                return "[]";
            }
            StringBuilder sb = new StringBuilder("[");
            foreach (Tag tag in Value)
            {
                sb.Append(tag.ToSNBT());
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// Writes the list tag to the specified stream using the specified binary utils context.
        /// </summary>
        /// <param name="data">The stream to write the list tag to.</param>
        /// <param name="context">The binary utils context.</param>
        public override void Write(Stream data, BinaryUtilsContext context)
        {
            BinaryUtils.WriteByte(data, (byte)Subtype, context);
            BinaryUtils.WriteInt(data, Value.Count, context);
            foreach (Tag tag in Value)
            {
                tag.Write(data, context);
            }
        }

        /// <summary>
        /// Adds a tag to the list.
        /// </summary>
        /// <param name="tag">The tag to add.</param>
        public void Add(Tag tag)
        {
            if (tag.Type != Subtype)
            {
                throw new ArgumentException("Tag type does not match list subtype");
            }
            Value.Add(tag);
        }

        /// <summary>
        /// Adds an integer value to the list.
        /// </summary>
        /// <param name="value">The integer value to add.</param>
        public void Add(int value)
        {
            Add(Converter.ToTag(value));
        }

        /// <summary>
        /// Adds a long value to the list.
        /// </summary>
        /// <param name="value">The long value to add.</param>
        public void Add(long value)
        {
            Add(Converter.ToTag(value));
        }

        /// <summary>
        /// Adds a float value to the list.
        /// </summary>
        /// <param name="value">The float value to add.</param>
        public void Add(float value)
        {
            Add(Converter.ToTag(value));
        }

        /// <summary>
        /// Adds a double value to the list.
        /// </summary>
        /// <param name="value">The double value to add.</param>
        public void Add(double value)
        {
            Add(Converter.ToTag(value));
        }

        /// <summary>
        /// Adds a string value to the list.
        /// </summary>
        /// <param name="value">The string value to add.</param>
        public void Add(string value)
        {
            Add(Converter.ToTag(value));
        }

        /// <summary>
        /// Adds a byte array value to the list.
        /// </summary>
        /// <param name="value">The byte array value to add.</param>
        public void Add(byte[] value)
        {
            Add(Converter.ToTag(value));
        }

        /// <summary>
        /// Adds an integer array value to the list.
        /// </summary>
        /// <param name="value">The integer array value to add.</param>
        public void Add(int[] value)
        {
            Add(Converter.ToTag(value));
        }

        /// <summary>
        /// Adds a long array value to the list.
        /// </summary>
        /// <param name="value">The long array value to add.</param>
        public void Add(long[] value)
        {
            Add(Converter.ToTag(value));
        }
    }
}
