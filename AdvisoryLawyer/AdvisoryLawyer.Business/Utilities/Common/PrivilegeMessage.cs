using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Utilities.Common
{
    public class PrivilegeMessage : IPackable
    {
        public uint salt;
        public uint ts;
        public Dictionary<ushort, uint> messages;
        public PrivilegeMessage()
        {
            salt = (uint) new Random().Next();
            TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
            ts = (uint)(t.TotalSeconds + 24 * 3600);
            messages = new Dictionary<ushort, uint>();
        }

        public ByteBuf marshal(ByteBuf outBuf)
        {
            return outBuf.put(salt).put(ts).putIntMap(messages);
        }

        public void unmarshal(ByteBuf inBuf)
        {
            this.salt = inBuf.readInt();
            this.ts = inBuf.readInt();
            this.messages = inBuf.readIntMap();
        }
    }
}
