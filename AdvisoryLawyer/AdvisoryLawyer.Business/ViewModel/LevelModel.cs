using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class LevelModel
    {
        public int? id { get; set; }
        public string level_name { get; set; }
        public int? min_price { get; set; }
        public int? max_price { get; set; }
        public int? status { get; set; }
    }
}
