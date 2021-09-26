using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class LevelModel
    {
        public int Id { get; set; }
        public string LevelName { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

    }
}
