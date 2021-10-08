using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.CategoryRequest
{
    public class CategoryRequest
    {
        public string CategoryName { get; set; }
        public List<int> LawyerIds { get; set; }
        public List<int> LawyerOfficeIds { get; set; }
    }
}
