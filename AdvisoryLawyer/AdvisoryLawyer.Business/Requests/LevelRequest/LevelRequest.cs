using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.LevelRequest
{
    public class LevelRequest
    {
        public int? id { get; set; }
        [String]
        public string level_name { get; set; }
        public int? min_price { get; set; }
        public int? max_price { get; set; }
    }
}
