using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT
{
    public static class BinaryUtils
    {
        #region Int
        public static int ReadIntBigEndian(Stream data)
        {
            byte[] buffer = new byte[4];
            data.Read(buffer, 0, 4);
            return (buffer[0] << 24) | (buffer[1] << 16) | (buffer[2] << 8) | buffer[3];
        }

        public static int ReadIntLittleEndian(Stream data)
        {
            byte[] buffer = new byte[4];
            data.Read(buffer, 0, 4);
            return buffer[0] | (buffer[1] << 8) | (buffer[2] << 16) | (buffer[3] << 24);
        }

        public static int ReadInt(Stream data, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                return ReadIntLittleEndian(data);
            }
            else
            {
                return ReadIntBigEndian(data);
            }
        }

        public static void WriteIntBigEndian(Stream data, int value)
        {
            data.WriteByte((byte)((value >> 24) & 0xFF));
            data.WriteByte((byte)((value >> 16) & 0xFF));
            data.WriteByte((byte)((value >> 8) & 0xFF));
            data.WriteByte((byte)(value & 0xFF));
        }

        public static void WriteIntLittleEndian(Stream data, int value)
        {
            data.WriteByte((byte)(value & 0xFF));
            data.WriteByte((byte)((value >> 8) & 0xFF));
            data.WriteByte((byte)((value >> 16) & 0xFF));
            data.WriteByte((byte)((value >> 24) & 0xFF));
        }

        public static void WriteInt(Stream data, int value, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                WriteIntLittleEndian(data, value);
            }
            else
            {
                WriteIntBigEndian(data, value);
            }
        }
        #endregion

        #region Short
        public static short ReadShortBigEndian(Stream data)
        {
            byte[] buffer = new byte[2];
            data.Read(buffer, 0, 2);
            return (short)((buffer[0] << 8) | buffer[1]);
        }

        public static short ReadShortLittleEndian(Stream data)
        {
            byte[] buffer = new byte[2];
            data.Read(buffer, 0, 2);
            return (short)(buffer[0] | (buffer[1] << 8));
        }

        public static void WriteShortBigEndian(Stream data, short value)
        {
            data.WriteByte((byte)((value >> 8) & 0xFF));
            data.WriteByte((byte)(value & 0xFF));
        }

        public static void WriteShortLittleEndian(Stream data, short value)
        {
            data.WriteByte((byte)(value & 0xFF));
            data.WriteByte((byte)((value >> 8) & 0xFF));
        }

        public static void WriteShort(Stream data, short value, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                WriteShortLittleEndian(data, value);
            }
            else
            {
                WriteShortBigEndian(data, value);
            }
        }

        public static short ReadShort(Stream data, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                return ReadShortLittleEndian(data);
            }
            else
            {
                return ReadShortBigEndian(data);
            }
        }
        #endregion

        #region UShort
        public static ushort ReadUShortBigEndian(Stream data)
        {
            byte[] buffer = new byte[2];
            data.Read(buffer, 0, 2);
            return (ushort)((buffer[0] << 8) | buffer[1]);
        }

        public static ushort ReadUShortLittleEndian(Stream data)
        {
            byte[] buffer = new byte[2];
            data.Read(buffer, 0, 2);
            return (ushort)(buffer[0] | (buffer[1] << 8));
        }

        public static ushort ReadUShort(Stream data, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                return ReadUShortLittleEndian(data);
            }
            else
            {
                return ReadUShortBigEndian(data);
            }
        }

        public static void WriteUShortBigEndian(Stream data, ushort value)
        {
            data.WriteByte((byte)((value >> 8) & 0xFF));
            data.WriteByte((byte)(value & 0xFF));
        }

        public static void WriteUShortLittleEndian(Stream data, ushort value)
        {
            data.WriteByte((byte)(value & 0xFF));
            data.WriteByte((byte)((value >> 8) & 0xFF));
        }

        public static void WriteUShort(Stream data, ushort value, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                WriteUShortLittleEndian(data, value);
            }
            else
            {
                WriteUShortBigEndian(data, value);
            }
        }
        #endregion

        #region Long
        public static long ReadLongBigEndian(Stream data)
        {
            byte[] buffer = new byte[8];
            data.Read(buffer, 0, 8);
            return ((long)buffer[0] << 56) | ((long)buffer[1] << 48) | ((long)buffer[2] << 40) | ((long)buffer[3] << 32) | ((long)buffer[4] << 24) | ((long)buffer[5] << 16) | ((long)buffer[6] << 8) | (long)buffer[7];
        }

        public static long ReadLongLittleEndian(Stream data)
        {
            byte[] buffer = new byte[8];
            data.Read(buffer, 0, 8);
            return (long)buffer[0] | ((long)buffer[1] << 8) | ((long)buffer[2] << 16) | ((long)buffer[3] << 24) | ((long)buffer[4] << 32) | ((long)buffer[5] << 40) | ((long)buffer[6] << 48) | ((long)buffer[7] << 56);
        }

        public static long ReadLong(Stream data, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                return ReadLongLittleEndian(data);
            }
            else
            {
                return ReadLongBigEndian(data);
            }
        }

        public static void WriteLongBigEndian(Stream data, long value)
        {
            data.WriteByte((byte)((value >> 56) & 0xFF));
            data.WriteByte((byte)((value >> 48) & 0xFF));
            data.WriteByte((byte)((value >> 40) & 0xFF));
            data.WriteByte((byte)((value >> 32) & 0xFF));
            data.WriteByte((byte)((value >> 24) & 0xFF));
            data.WriteByte((byte)((value >> 16) & 0xFF));
            data.WriteByte((byte)((value >> 8) & 0xFF));
            data.WriteByte((byte)(value & 0xFF));
        }

        public static void WriteLongLittleEndian(Stream data, long value)
        {
            data.WriteByte((byte)(value & 0xFF));
            data.WriteByte((byte)((value >> 8) & 0xFF));
            data.WriteByte((byte)((value >> 16) & 0xFF));
            data.WriteByte((byte)((value >> 24) & 0xFF));
            data.WriteByte((byte)((value >> 32) & 0xFF));
            data.WriteByte((byte)((value >> 40) & 0xFF));
            data.WriteByte((byte)((value >> 48) & 0xFF));
            data.WriteByte((byte)((value >> 56) & 0xFF));
        }

        public static void WriteLong(Stream data, long value, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                WriteLongLittleEndian(data, value);
            }
            else
            {
                WriteLongBigEndian(data, value);
            }
        }
        #endregion


        #region Float
        public static float ReadFloatBigEndian(Stream data)
        {
            byte[] buffer = new byte[4];
            data.Read(buffer, 0, 4);
            return BitConverter.ToSingle(new byte[] { buffer[3], buffer[2], buffer[1], buffer[0] }, 0);
        }

        public static float ReadFloatLittleEndian(Stream data)
        {
            byte[] buffer = new byte[4];
            data.Read(buffer, 0, 4);
            return BitConverter.ToSingle(new byte[] { buffer[0], buffer[1], buffer[2], buffer[3] }, 0);
        }

        public static float ReadFloat(Stream data, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                return ReadFloatLittleEndian(data);
            }
            else
            {
                return ReadFloatBigEndian(data);
            }
        }

        public static void WriteFloatBigEndian(Stream data, float value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            data.WriteByte(buffer[3]);
            data.WriteByte(buffer[2]);
            data.WriteByte(buffer[1]);
            data.WriteByte(buffer[0]);
        }

        public static void WriteFloatLittleEndian(Stream data, float value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            data.WriteByte(buffer[0]);
            data.WriteByte(buffer[1]);
            data.WriteByte(buffer[2]);
            data.WriteByte(buffer[3]);
        }

        public static void WriteFloat(Stream data, float value, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                WriteFloatLittleEndian(data, value);
            }
            else
            {
                WriteFloatBigEndian(data, value);
            }
        }
        #endregion

        #region Double
        public static double ReadDoubleBigEndian(Stream data)
        {
            byte[] buffer = new byte[8];
            data.Read(buffer, 0, 8);
            return BitConverter.ToDouble(new byte[] { buffer[7], buffer[6], buffer[5], buffer[4], buffer[3], buffer[2], buffer[1], buffer[0] }, 0);
        }

        public static double ReadDoubleLittleEndian(Stream data)
        {
            byte[] buffer = new byte[8];
            data.Read(buffer, 0, 8);
            return BitConverter.ToDouble(new byte[] { buffer[0], buffer[1], buffer[2], buffer[3], buffer[4], buffer[5], buffer[6], buffer[7] }, 0);
        }

        public static double ReadDouble(Stream data, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                return ReadDoubleLittleEndian(data);
            }
            else
            {
                return ReadDoubleBigEndian(data);
            }
        }

        public static void WriteDoubleBigEndian(Stream data, double value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            data.WriteByte(buffer[7]);
            data.WriteByte(buffer[6]);
            data.WriteByte(buffer[5]);
            data.WriteByte(buffer[4]);
            data.WriteByte(buffer[3]);
            data.WriteByte(buffer[2]);
            data.WriteByte(buffer[1]);
            data.WriteByte(buffer[0]);
        }

        public static void WriteDoubleLittleEndian(Stream data, double value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            data.WriteByte(buffer[0]);
            data.WriteByte(buffer[1]);
            data.WriteByte(buffer[2]);
            data.WriteByte(buffer[3]);
            data.WriteByte(buffer[4]);
            data.WriteByte(buffer[5]);
            data.WriteByte(buffer[6]);
            data.WriteByte(buffer[7]);
        }

        public static void WriteDouble(Stream data, double value, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                WriteDoubleLittleEndian(data, value);
            }
            else
            {
                WriteDoubleBigEndian(data, value);
            }
        }
        #endregion

        #region String
        public static string ReadString(Stream data, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                ushort length = ReadUShortLittleEndian(data);
                byte[] buffer = new byte[length];
                data.Read(buffer, 0, length);
                return Encoding.UTF8.GetString(buffer);
            }
            else
            {
                ushort length = ReadUShortBigEndian(data);
                byte[] buffer = new byte[length];
                data.Read(buffer, 0, length);
                return Encoding.UTF8.GetString(buffer);
            }
        }

        public static void WriteString(Stream data, string value, BinaryUtilsContext context)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(value);
            if (context.IsLittleEndian)
            {
                WriteUShortLittleEndian(data, (ushort)buffer.Length);
            }
            else
            {
                WriteUShortBigEndian(data, (ushort)buffer.Length);
            }
            data.Write(buffer, 0, buffer.Length);
        }
        #endregion

        #region Byte Array
        public static byte[] ReadByteArray(Stream data, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                int length = ReadInt(data, context);
                byte[] buffer = new byte[length];
                data.Read(buffer, 0, length);
                return buffer;
            }
            else
            {
                int length = ReadInt(data, context);
                byte[] buffer = new byte[length];
                data.Read(buffer, 0, length);
                return buffer;
            }
        }

        public static void WriteByteArray(Stream data, byte[] value, BinaryUtilsContext context)
        {
            WriteInt(data, value.Length, context);
            data.Write(value, 0, value.Length);
        }
        #endregion

        #region Int Array
        public static int[] ReadIntArray(Stream data, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                int length = ReadInt(data, context);
                int[] result = new int[length];
                for (int i = 0; i < length; i++)
                {
                    result[i] = ReadIntLittleEndian(data);
                }
                return result;
            }
            else
            {
                int length = ReadInt(data, context);
                int[] result = new int[length];
                for (int i = 0; i < length; i++)
                {
                    result[i] = ReadIntBigEndian(data);
                }
                return result;
            }
        }

        public static void WriteIntArray(Stream data, int[] value, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                WriteInt(data, value.Length, context);
                for (int i = 0; i < value.Length; i++)
                {
                    WriteIntLittleEndian(data, value[i]);
                }
            }
            else
            {
                WriteInt(data, value.Length, context);
                for (int i = 0; i < value.Length; i++)
                {
                    WriteIntBigEndian(data, value[i]);
                }
            }
        }
        #endregion

        #region Long Array
        public static long[] ReadLongArray(Stream data, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                int length = ReadInt(data, context);
                long[] result = new long[length];
                for (int i = 0; i < length; i++)
                {
                    result[i] = ReadLongLittleEndian(data);
                }
                return result;
            }
            else
            {
                int length = ReadInt(data, context);
                long[] result = new long[length];
                for (int i = 0; i < length; i++)
                {
                    result[i] = ReadLongBigEndian(data);
                }
                return result;
            }
        }

        public static void WriteLongArray(Stream data, long[] value, BinaryUtilsContext context)
        {
            if (context.IsLittleEndian)
            {
                WriteInt(data, value.Length, context);
                for (int i = 0; i < value.Length; i++)
                {
                    WriteLongLittleEndian(data, value[i]);
                }
            }
            else
            {
                WriteInt(data, value.Length, context);
                for (int i = 0; i < value.Length; i++)
                {
                    WriteLongBigEndian(data, value[i]);
                }
            }
        }
        #endregion

        #region Byte
        public static byte ReadByte(Stream data, BinaryUtilsContext context)
        {
            return (byte)data.ReadByte();
        }

        public static void WriteByte(Stream data, byte value, BinaryUtilsContext context)
        {
            data.WriteByte(value);
        }
        #endregion
    }
}
