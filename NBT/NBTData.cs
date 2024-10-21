using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheblueMan003.NBT.Tags;

namespace TheblueMan003.NBT
{
    public class NBTData
    {
        public int Version;
        public Tag Data;

        public string ToSNBT()
        {
            return Data.ToSNBT();
        }
    }
}
