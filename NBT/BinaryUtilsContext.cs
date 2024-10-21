using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TheblueMan003.NBT.BinaryUtils;

namespace TheblueMan003.NBT
{
    /// <summary>
    /// Represents the context for binary utilities.
    /// </summary>
    public class BinaryUtilsContext
    {
        /// <summary>
        /// Gets or sets the endianess of the binary data.
        /// </summary>
        public Endian Endian;

        /// <summary>
        /// Gets or sets a value indicating whether the binary data is compressed.
        /// </summary>
        public bool Compressed;

        /// <summary>
        /// Gets or sets the size of the header in the binary data.
        /// </summary>
        public int HeaderSize;

        /// <summary>
        /// Gets a value indicating whether the binary data is in little endian format.
        /// </summary>
        public bool IsLittleEndian => Endian == Endian.Little;

        /// <summary>
        /// Gets a value indicating whether the binary data is in big endian format.
        /// </summary>
        public bool IsBigEndian => Endian == Endian.Big;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryUtilsContext"/> class.
        /// </summary>
        /// <param name="endian">The endianess of the binary data.</param>
        /// <param name="compressed">A value indicating whether the binary data is compressed.</param>
        /// <param name="headerSize">The size of the header in the binary data.</param>
        public BinaryUtilsContext(Endian endian, bool compressed, int headerSize)
        {
            Endian = endian;
            Compressed = compressed;
            HeaderSize = headerSize;
        }
    }
}
