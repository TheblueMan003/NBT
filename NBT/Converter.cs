﻿using System.Text;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

//using SharpCompress.Compressors.Deflate;
using TheblueMan003.NBT.Tags;

namespace TheblueMan003.NBT
{
    public class Converter
    {
        /// <summary>
        /// Reads a Java NBT file and returns the parsed NBT data.
        /// </summary>
        /// <param name="path">The path to the Java NBT file.</param>
        /// <returns>The parsed NBT data.</returns>
        public static NBTData ReadJavaFile(string path)
        {
            using FileStream stream = new FileStream(path, FileMode.Open);

            var context = new BinaryUtilsContext(Endian.Big, Compression.GZIP, 0);
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

            var context = new BinaryUtilsContext(Endian.Little, Compression.None, 8);
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
            if (context.Compression == Compression.GZIP)
            {
                GZip.Decompress(data, stream, false);
            }
            else if (context.Compression == Compression.ZLIB)
            {
                var inflater = new InflaterInputStream(data);
                inflater.CopyTo(stream);
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

            var context = new BinaryUtilsContext(Endian.Big, Compression.GZIP, 0);
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

            var context = new BinaryUtilsContext(Endian.Little, Compression.None, 8);
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

            if (context.Compression == Compression.GZIP)
            {
                stream = new GZipOutputStream(data);
            }
            else if (context.Compression == Compression.ZLIB)
            {
                stream = new DeflaterOutputStream(data);
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
                TagType.Byte => new ByteTag(name, (sbyte)BinaryUtils.ReadByte(data, context)),
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
