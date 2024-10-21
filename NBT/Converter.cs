using System.IO.Compression;
using System.Text;
using ICSharpCode.SharpZipLib.GZip;
using TheblueMan003.NBT.Tags;

namespace TheblueMan003.NBT
{
    public class Converter
    {
        /// <summary>
        /// Converts a list of strings to a ListTag of StringTags.
        /// </summary>
        /// <param name="value">The list of strings to convert.</param>
        /// <returns>The converted ListTag of StringTags.</returns>
        public static Tag ToNBT(List<string> value)
        {
            List<Tag> tags = new List<Tag>();
            foreach (string s in value)
            {
                tags.Add(new StringTag("", s));
            }
            return new ListTag("", tags, TagType.String);
        }

        /// <summary>
        /// Converts a string to a StringTag.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The converted StringTag.</returns>
        public static Tag ToTag(string value)
        {
            return new StringTag("", value);
        }

        /// <summary>
        /// Converts an integer to an IntTag.
        /// </summary>
        /// <param name="value">The integer to convert.</param>
        /// <returns>The converted IntTag.</returns>
        public static Tag ToTag(int value)
        {
            return new IntTag("", value);
        }

        /// <summary>
        /// Converts an array of integers to an IntArrayTag.
        /// </summary>
        /// <param name="value">The array of integers to convert.</param>
        /// <returns>The converted IntArrayTag.</returns>
        public static Tag ToTag(int[] value)
        {
            return new IntArrayTag("", value);
        }

        /// <summary>
        /// Converts a list of integers to an IntArrayTag.
        /// </summary>
        /// <param name="value">The list of integers to convert.</param>
        /// <returns>The converted IntArrayTag.</returns>
        public static Tag ToTag(List<int> value)
        {
            return new IntArrayTag("", value.ToArray());
        }

        /// <summary>
        /// Converts a long integer to a LongTag.
        /// </summary>
        /// <param name="value">The long integer to convert.</param>
        /// <returns>The converted LongTag.</returns>
        public static Tag ToTag(long value)
        {
            return new LongTag("", value);
        }

        /// <summary>
        /// Converts an array of long integers to a LongArrayTag.
        /// </summary>
        /// <param name="value">The array of long integers to convert.</param>
        /// <returns>The converted LongArrayTag.</returns>
        public static Tag ToTag(long[] value)
        {
            return new LongArrayTag("", value);
        }

        /// <summary>
        /// Converts a list of long integers to a LongArrayTag.
        /// </summary>
        /// <param name="value">The list of long integers to convert.</param>
        /// <returns>The converted LongArrayTag.</returns>
        public static Tag ToTag(List<long> value)
        {
            return new LongArrayTag("", value.ToArray());
        }

        /// <summary>
        /// Converts a float to a FloatTag.
        /// </summary>
        /// <param name="value">The float to convert.</param>
        /// <returns>The converted FloatTag.</returns>
        public static Tag ToTag(float value)
        {
            return new FloatTag("", value);
        }

        /// <summary>
        /// Converts a double to a DoubleTag.
        /// </summary>
        /// <param name="value">The double to convert.</param>
        /// <returns>The converted DoubleTag.</returns>
        public static Tag ToTag(double value)
        {
            return new DoubleTag("", value);
        }

        /// <summary>
        /// Converts a byte to a ByteTag.
        /// </summary>
        /// <param name="value">The byte to convert.</param>
        /// <returns>The converted ByteTag.</returns>
        public static Tag ToTag(byte value)
        {
            return new ByteTag("", value);
        }

        /// <summary>
        /// Converts an array of bytes to a ByteArrayTag.
        /// </summary>
        /// <param name="value">The array of bytes to convert.</param>
        /// <returns>The converted ByteArrayTag.</returns>
        public static Tag ToTag(byte[] value)
        {
            return new ByteArrayTag("", value);
        }

        /// <summary>
        /// Converts a list of bytes to a ByteArrayTag.
        /// </summary>
        /// <param name="value">The list of bytes to convert.</param>
        /// <returns>The converted ByteArrayTag.</returns>
        public static Tag ToTag(List<byte> value)
        {
            return new ByteArrayTag("", value.ToArray());
        }

        /// <summary>
        /// Converts a boolean value to a ByteTag.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>The converted ByteTag.</returns>
        public static Tag ToTag(bool value)
        {
            return new ByteTag("", (byte)(value ? 1 : 0));
        }

        /// <summary>
        /// Converts a list of tags to a ListTag.
        /// </summary>
        /// <param name="value">The list of tags to convert.</param>
        /// <returns>The converted ListTag.</returns>
        public static Tag ToTag(List<Tag> value)
        {
            return new ListTag("", value, value[0].Type);
        }

        /// <summary>
        /// Converts a dictionary of string-tag pairs to a CompoundTag.
        /// </summary>
        /// <param name="value">The dictionary of string-tag pairs to convert.</param>
        /// <returns>The converted CompoundTag.</returns>
        public static Tag ToTag(Dictionary<string, Tag> value)
        {
            return new CompoundTag("", value);
        }

        /// <summary>
        /// Reads a Java NBT file and returns the parsed NBT data.
        /// </summary>
        /// <param name="path">The path to the Java NBT file.</param>
        /// <returns>The parsed NBT data.</returns>
        public static NBTData ReadJavaFile(string path)
        {
            using FileStream stream = new FileStream(path, FileMode.Open);

            var context = new BinaryUtilsContext(Endian.Big, true, 0);
            return ParseFromStream(stream, context);
        }

        /// <summary>
        /// Reads a Bedrock NBT file and returns the parsed NBT data.
        /// </summary>
        /// <param name="path">The path to the Bedrock NBT file.</param>
        /// <returns>The parsed NBT data.</returns>
        public static NBTData ReadBedrockFile(string path)
        {
            using FileStream stream = new FileStream(path, FileMode.Open);

            var context = new BinaryUtilsContext(Endian.Little, false, 8);
            return ParseFromStream(stream, context);
        }

        /// <summary>
        /// Parses NBT data from a stream using the specified context.
        /// </summary>
        /// <param name="data">The stream containing the NBT data.</param>
        /// <param name="context">The context for parsing the NBT data.</param>
        /// <returns>The parsed NBT data.</returns>
        public static NBTData ParseFromStream(Stream data, BinaryUtilsContext context)
        {
            Stream stream = new MemoryStream();
            if (context.Compressed)
            {
                GZip.Decompress(data, stream, false);
            }
            else
            {
                data.CopyTo(stream);
            }

            var nbt = new NBTData();

            stream.Seek(0, SeekOrigin.Begin);
            if (context.HeaderSize > 0)
            {
                nbt.Version = BinaryUtils.ReadInt(data, context);
                stream.Seek(context.HeaderSize, SeekOrigin.Begin);
            }

            Tag? tag = Parse(stream, context);
            if (tag == null)
            {
                throw new InvalidDataException("Invalid NBT data");
            }
            nbt.Data = tag;
            return nbt;
        }

        /// <summary>
        /// Writes the NBT data to a Java NBT file.
        /// </summary>
        /// <param name="path">The path to the Java NBT file.</param>
        /// <param name="nbt">The NBT data to write.</param>
        public static void WriteToJavaFile(string path, NBTData nbt)
        {
            using FileStream stream = new FileStream(path, FileMode.Create);

            var context = new BinaryUtilsContext(Endian.Big, true, 0);
            WriteToStream(nbt, stream, context);
        }

        /// <summary>
        /// Writes the NBT data to a Bedrock NBT file.
        /// </summary>
        /// <param name="path">The path to the Bedrock NBT file.</param>
        /// <param name="nbt">The NBT data to write.</param>
        public static void WriteToBedrockFile(string path, NBTData nbt)
        {
            using FileStream stream = new FileStream(path, FileMode.Create);

            var context = new BinaryUtilsContext(Endian.Little, false, 8);
            WriteToStream(nbt, stream, context);
        }

        /// <summary>
        /// Writes the NBT data to a stream using the specified context.
        /// </summary>
        /// <param name="nbt">The NBT data to write.</param>
        /// <param name="data">The stream to write the NBT data to.</param>
        /// <param name="context">The context for writing the NBT data.</param>
        public static void WriteToStream(NBTData nbt, Stream data, BinaryUtilsContext context)
        {
            Stream stream = data;
            Tag tag = nbt.Data;

            if (context.Compressed)
            {
                stream = new GZipOutputStream(data);
            }

            if (context.HeaderSize > 0)
            {
                BinaryUtils.WriteInt(stream, nbt.Version, context);
            }
            for (int i = 4; i < context.HeaderSize; i++)
            {
                stream.WriteByte(0);
            }

            BinaryUtils.WriteByte(stream, (byte)tag.Type, context);
            BinaryUtils.WriteString(stream, tag.Name, context);
            tag.Write(stream, context);
            stream.Flush();
            stream.Close();
        }

        private static Tag? Parse(Stream data, BinaryUtilsContext context)
        {
            TagType type = ParseTagType(data);
            if (type == TagType.End)
            {
                return null;
            }

            string name = BinaryUtils.ReadString(data, context);
            return ParseSimpleType(data, context, type, name);
        }

        private static Tag? ParseSimpleType(Stream data, BinaryUtilsContext context, TagType type, string name)
        {
            return type switch
            {
                TagType.Byte => new ByteTag(name, BinaryUtils.ReadByte(data, context)),
                TagType.Short => new ShortTag(name, BinaryUtils.ReadShort(data, context)),
                TagType.Int => new IntTag(name, BinaryUtils.ReadInt(data, context)),
                TagType.Long => new LongTag(name, BinaryUtils.ReadLong(data, context)),
                TagType.Float => new FloatTag(name, BinaryUtils.ReadFloat(data, context)),
                TagType.Double => new DoubleTag(name, BinaryUtils.ReadDouble(data, context)),
                TagType.ByteArray => new ByteArrayTag(name, BinaryUtils.ReadByteArray(data, context)),
                TagType.String => new StringTag(name, BinaryUtils.ReadString(data, context)),
                TagType.List => ParseListTag(name, data, context),
                TagType.Compound => ParseCompoundTag(name, data, context),
                TagType.IntArray => new IntArrayTag(name, BinaryUtils.ReadIntArray(data, context)),
                TagType.LongArray => new LongArrayTag(name, BinaryUtils.ReadLongArray(data, context)),
                _ => null
            };
        }

        private static ListTag ParseListTag(string name, Stream data, BinaryUtilsContext context)
        {
            TagType type = ParseTagType(data);
            int length = BinaryUtils.ReadInt(data, context);
            List<Tag> tags = new List<Tag>(length);
            for (int i = 0; i < length; i++)
            {
                tags.Add(ParseSimpleType(data, context, type, "") ?? throw new Exception("Invalid NBT data"));
            }
            return new ListTag(name, tags, type);
        }

        private static CompoundTag ParseCompoundTag(string name, Stream data, BinaryUtilsContext context)
        {
            Dictionary<string, Tag> tags = new Dictionary<string, Tag>();
            while (true)
            {
                Tag? tag = Parse(data, context);
                if (tag == null)
                {
                    break;
                }
                tags.Add(tag.Name, tag);
            }
            return new CompoundTag(name, tags);
        }

        private static TagType ParseTagType(Stream data)
        {
            byte type = (byte)data.ReadByte();
            return (TagType)type;
        }
    }
}
