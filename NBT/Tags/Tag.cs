using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Tags
{
    public abstract class Tag
    {
        public string Name;
        public TagType Type;

        public Tag(string name, TagType type)
        {
            this.Name = name;
            Type = type;
        }

        public abstract string ToSNBT();

        public abstract void Write(Stream data, BinaryUtilsContext context);
    }
}
