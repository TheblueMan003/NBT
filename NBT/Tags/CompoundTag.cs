using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    /// <summary>
    /// Represents a compound tag in NBT format.
    /// </summary>
    public class CompoundTag : Tag
    {
        /// <summary>
        /// Gets or sets the dictionary of tags contained in the compound tag.
        /// </summary>
        public Dictionary<string, Tag> Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompoundTag"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the compound tag.</param>
        /// <param name="value">The dictionary of tags contained in the compound tag.</param>
        public CompoundTag(string name, Dictionary<string, Tag> value) : base(name, TagType.Compound)
        {
            Value = value;
        }

        /// <summary>
        /// Converts the compound tag to its SNBT (Stringified NBT) representation.
        /// </summary>
        /// <returns>The SNBT representation of the compound tag.</returns>
        public override string ToSNBT()
        {
            if (Value.Count == 0)
            {
                return "{}";
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            foreach (KeyValuePair<string, Tag> tag in Value)
            {
                builder.Append($"{tag.Key}:{tag.Value.ToSNBT()},");

            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append("}");
            return builder.ToString();
        }

        /// <summary>
        /// Writes the compound tag to the specified stream using the specified binary utils context.
        /// </summary>
        /// <param name="data">The stream to write the compound tag to.</param>
        /// <param name="context">The binary utils context.</param>
        public override void Write(Stream data, BinaryUtilsContext context)
        {
            foreach (KeyValuePair<string, Tag> tag in Value)
            {
                BinaryUtils.WriteByte(data, (byte)tag.Value.Type, context);
                BinaryUtils.WriteString(data, tag.Key, context);
                tag.Value.Write(data, context);
            }
            BinaryUtils.WriteByte(data, 0, context);
        }

        /// <summary>
        /// Adds a tag with the specified key to the compound tag.
        /// </summary>
        /// <param name="key">The key of the tag to add.</param>
        /// <param name="tag">The tag to add.</param>
        public void Add(string key, Tag tag)
        {
            Value.Add(key, tag);
        }

        public void Add(string key, int value)
        {
            Add(key, Converter.ToTag(value));
        }

        public void Add(string key, string value)
        {
            Add(key, Converter.ToTag(value));
        }

        public void Add(string key, byte value)
        {
            Add(key, Converter.ToTag(value));
        }

        public void Add(string key, short value)
        {
            Add(key, Converter.ToTag(value));
        }

        public void Add(string key, long value)
        {
            Add(key, Converter.ToTag(value));
        }

        public void Add(string key, float value)
        {
            Add(key, Converter.ToTag(value));
        }

        public void Add(string key, double value)
        {
            Add(key, Converter.ToTag(value));
        }

        public void Add(string key, byte[] value)
        {
            Add(key, Converter.ToTag(value));
        }

        public void Add(string key, int[] value)
        {
            Add(key, Converter.ToTag(value));
        }

        public void Add(string key, long[] value)
        {
            Add(key, Converter.ToTag(value));
        }

        public void Add(string key, List<int> value)
        {
            Add(key, Converter.ToTag(value));
        }

        public void Add(string key, List<long> value)
        {
            Add(key, Converter.ToTag(value));
        }

        /// <summary>
        /// Removes the tag with the specified key from the compound tag.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        public void Remove(string key)
        {
            Value.Remove(key);
        }
    }
}
