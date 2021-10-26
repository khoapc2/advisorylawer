using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Utilities.Media
{
    public enum Privileges
    {
        kJoinChannel = 1,
        kPublishAudioStream = 2,
        kPublishVideoStream = 3,
        kPublishDataStream = 4,
        kRtmLogin = 1000
    }
}
