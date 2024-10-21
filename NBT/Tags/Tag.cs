using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    /// <summary>
    /// Represents a base class for all NBT tags.
    /// </summary>
    public abstract class Tag
    {
        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        public string Name;

        /// <summary>
        /// Gets the type of the tag.
        /// </summary>
        public TagType Type { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tag"/> class with the specified name and type.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="type">The type of the tag.</param>
        public Tag(string name, TagType type)
        {
            this.Name = name;
            Type = type;
        }

        /// <summary>
        /// Converts the tag to its string representation in SNBT format.
        /// </summary>
        /// <returns>The string representation of the tag in SNBT format.</returns>
        public abstract string ToSNBT();

        /// <summary>
        /// Writes the tag to the specified stream using the specified binary utils context.
        /// </summary>
        /// <param name="data">The stream to write the tag to.</param>
        /// <param name="context">The binary utils context to use for writing.</param>
        public abstract void Write(Stream data, BinaryUtilsContext context);

        /// <summary>
        /// Gets the string value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The string value of the tag at the specified path.</returns>
        public string GetString(string path)
        {
            return GetTag(path).ToSNBT();
        }

        /// <summary>
        /// Gets the integer value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The integer value of the tag at the specified path.</returns>
        public int GetInt(string path)
        {
            return ((IntTag)GetTag(path)).Value;
        }

        /// <summary>
        /// Gets the long value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The long value of the tag at the specified path.</returns>
        public long GetLong(string path)
        {
            return ((LongTag)GetTag(path)).Value;
        }

        /// <summary>
        /// Gets the short value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The short value of the tag at the specified path.</returns>
        public short GetShort(string path)
        {
            return ((ShortTag)GetTag(path)).Value;
        }

        /// <summary>
        /// Gets the byte value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The byte value of the tag at the specified path.</returns>
        public byte GetByte(string path)
        {
            return ((ByteTag)GetTag(path)).Value;
        }

        /// <summary>
        /// Gets the float value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The float value of the tag at the specified path.</returns>
        public float GetFloat(string path)
        {
            return ((FloatTag)GetTag(path)).Value;
        }

        /// <summary>
        /// Gets the double value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The double value of the tag at the specified path.</returns>
        public double GetDouble(string path)
        {
            return ((DoubleTag)GetTag(path)).Value;
        }

        /// <summary>
        /// Gets the boolean value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The boolean value of the tag at the specified path.</returns>
        public bool GetBool(string path)
        {
            return ((ByteTag)GetTag(path)).Value == 1;
        }

        /// <summary>
        /// Gets the list tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The list tag at the specified path.</returns>
        public ListTag GetList(string path)
        {
            return (ListTag)GetTag(path);
        }

        /// <summary>
        /// Gets the compound tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The compound tag at the specified path.</returns>
        public CompoundTag GetCompound(string path)
        {
            return (CompoundTag)GetTag(path);
        }

        /// <summary>
        /// Gets the byte array value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The byte array value of the tag at the specified path.</returns>
        public byte[] GetByteArray(string path)
        {
            return ((ByteArrayTag)GetTag(path)).Value;
        }

        /// <summary>
        /// Gets the integer array value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The integer array value of the tag at the specified path.</returns>
        public int[] GetIntArray(string path)
        {
            return ((IntArrayTag)GetTag(path)).Value;
        }

        /// <summary>
        /// Gets the long array value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The long array value of the tag at the specified path.</returns>
        public long[] GetLongArray(string path)
        {
            return ((LongArrayTag)GetTag(path)).Value;
        }

        /// <summary>
        /// Sets the integer value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new integer value.</param>
        public void SetInt(string path, int value)
        {
            ((IntTag)GetTag(path)).Value = value;
        }

        /// <summary>
        /// Sets the long value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new long value.</param>
        public void SetLong(string path, long value)
        {
            ((LongTag)GetTag(path)).Value = value;
        }

        /// <summary>
        /// Sets the short value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new short value.</param>
        public void SetShort(string path, short value)
        {
            ((ShortTag)GetTag(path)).Value = value;
        }

        /// <summary>
        /// Sets the byte value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new byte value.</param>
        public void SetByte(string path, byte value)
        {
            ((ByteTag)GetTag(path)).Value = value;
        }

        /// <summary>
        /// Sets the float value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new float value.</param>
        public void SetFloat(string path, float value)
        {
            ((FloatTag)GetTag(path)).Value = value;
        }

        /// <summary>
        /// Sets the double value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new double value.</param>
        public void SetDouble(string path, double value)
        {
            ((DoubleTag)GetTag(path)).Value = value;
        }

        /// <summary>
        /// Sets the boolean value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new boolean value.</param>
        public void SetBool(string path, bool value)
        {
            ((ByteTag)GetTag(path)).Value = (byte)(value ? 1 : 0);
        }

        /// <summary>
        /// Sets the list tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new list tag.</param>
        public void SetList(string path, ListTag value)
        {
            GetTag(path).Type = TagType.List;
            ((ListTag)GetTag(path)).Value = value.Value;
        }

        /// <summary>
        /// Sets the compound tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new compound tag.</param>
        public void SetCompound(string path, CompoundTag value)
        {
            GetTag(path).Type = TagType.Compound;
            ((CompoundTag)GetTag(path)).Value = value.Value;
        }

        /// <summary>
        /// Sets the byte array value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new byte array value.</param>
        public void SetByteArray(string path, byte[] value)
        {
            ((ByteArrayTag)GetTag(path)).Value = value;
        }

        /// <summary>
        /// Sets the integer array value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new integer array value.</param>
        public void SetIntArray(string path, int[] value)
        {
            ((IntArrayTag)GetTag(path)).Value = value;
        }

        /// <summary>
        /// Sets the long array value of the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <param name="value">The new long array value.</param>
        public void SetLongArray(string path, long[] value)
        {
            ((LongArrayTag)GetTag(path)).Value = value;
        }

        /// <summary>
        /// Gets the tag at the specified path.
        /// </summary>
        /// <param name="path">The path to the tag.</param>
        /// <returns>The tag at the specified path.</returns>
        public Tag GetTag(string path)
        {
            string name = path.Contains(".") ? path.Substring(0, path.IndexOf('.')) : path;
            string rest = path.Contains(".") ? path.Substring(path.IndexOf('.') + 1) : "";
            switch (Type)
            {
                case TagType.Compound:
                    var compound = (CompoundTag)this;
                    if (!compound.Value.ContainsKey(name))
                    {
                        throw new Exception("Path not found: " + path);
                    }

                    if (rest == "")
                    {
                        return compound.Value[name];
                    }
                    else
                    {
                        return compound.Value[name].GetTag(rest);
                    }

                case TagType.List:
                    var list = (ListTag)this;
                    int index;
                    if (!int.TryParse(name, out index))
                    {
                        throw new Exception("Path not found");
                    }
                    if (index < 0 || index >= list.Value.Count)
                    {
                        throw new Exception("Index out of bounds");
                    }
                    if (rest == "")
                    {
                        return list.Value[index];
                    }
                    else
                    {
                        return list.Value[index].GetTag(rest);
                    }

                default:
                    if (rest == "")
                    {
                        return this;
                    }
                    else
                    {
                        throw new Exception("Path not found");
                    }
            }
        }
    }
}
