using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheblueMan003.NBT.Tags;

namespace TheblueMan003.NBT.Worlds
{
    /// <summary>
    /// Represents the state of a block in a world.
    /// </summary>
    public class BlockStates
    {
        /// <summary>
        /// Implicitly converts a string to a <see cref="BlockStates"/> object by parsing the string.
        /// </summary>
        /// <param name="key">The string to parse.</param>
        /// <returns>The parsed <see cref="BlockStates"/> object.</returns>
        public static implicit operator BlockStates(string key) => ParseFromString(key);

        /// <summary>
        /// Implicitly converts a <see cref="BlockStates"/> object to a string.
        /// </summary>
        /// <param name="key">The <see cref="BlockStates"/> object to convert.</param>
        /// <returns>The string representation of the <see cref="BlockStates"/> object.</returns>
        public static implicit operator string(BlockStates key) => key.ToString();

        /// <summary>
        /// The name of the block.
        /// </summary>
        public string Name;

        /// <summary>
        /// The properties of the block.
        /// </summary>
        public Dictionary<string, string> Properties = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockStates"/> class from a <see cref="Tag"/> object.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> object containing the block state data.</param>
        public BlockStates(Tag tag)
        {
            Name = (string)tag["Name"];
            if (tag.Contains("Properties"))
            {
                foreach (var property in tag["Properties"])
                {
                    Properties.Add(property.Name, (string)property);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockStates"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the block.</param>
        public BlockStates(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockStates"/> class with the specified name and properties.
        /// </summary>
        /// <param name="name">The name of the block.</param>
        /// <param name="properties">The properties of the block.</param>
        public BlockStates(string name, Dictionary<string, string> properties)
        {
            Name = name;
            Properties = properties;
        }

        /// <summary>
        /// Parses a string representation of a <see cref="BlockStates"/> object.
        /// </summary>
        /// <param name="value">The string representation to parse.</param>
        /// <returns>The parsed <see cref="BlockStates"/> object.</returns>
        public static BlockStates ParseFromString(string value)
        {
            if (value.Contains("["))
            {
                var name = value.Substring(0, value.IndexOf("["));
                var properties = value.Substring(value.IndexOf("[") + 1, value.Length - value.IndexOf("[") - 2).Split(',');
                var dict = new Dictionary<string, string>();
                foreach (var property in properties)
                {
                    var split = property.Split('=');
                    dict.Add(split[0], split[1]);
                }
                return new BlockStates(name, dict);
            }
            else
            {
                return new BlockStates(value);
            }
        }

        /// <summary>
        /// Returns a string representation of the <see cref="BlockStates"/> object.
        /// </summary>
        /// <returns>The string representation of the <see cref="BlockStates"/> object.</returns>
        public override string ToString()
        {
            if (Properties.Count == 0)
            {
                return Name;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Name);
                sb.Append("[");
                foreach (var property in Properties)
                {
                    sb.Append(property.Key);
                    sb.Append("=");
                    sb.Append(property.Value);
                    sb.Append(",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]");
                return sb.ToString();
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="BlockStates"/> object.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="BlockStates"/> object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current <see cref="BlockStates"/> object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is BlockStates blockStates)
            {
                if (Name != blockStates.Name)
                {
                    return false;
                }
                if (Properties.Count != blockStates.Properties.Count)
                {
                    return false;
                }
                foreach (var property in Properties)
                {
                    if (!blockStates.Properties.ContainsKey(property.Key) || blockStates.Properties[property.Key] != property.Value)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the hash code for the current <see cref="BlockStates"/> object.
        /// </summary>
        /// <returns>The hash code for the current <see cref="BlockStates"/> object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Properties);
        }
    }
}
