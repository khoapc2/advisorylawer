using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.LevelRequest
{
    public class LevelRequest
    {
        public string LevelName { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}
