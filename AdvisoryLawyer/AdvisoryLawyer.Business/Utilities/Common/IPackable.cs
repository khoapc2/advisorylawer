using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Utilities.Common
{
    public interface IPackable
    {
        ByteBuf marshal(ByteBuf outBuf);
    }
}
