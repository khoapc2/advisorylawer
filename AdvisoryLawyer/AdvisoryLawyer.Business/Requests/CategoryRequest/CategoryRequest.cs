using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdvisoryLawyer.Business.Requests.CategoryRequest
{
    public class CategoryRequest
    {
        [String]
        [FromQuery(Name = "category_name")]
        public string CategoryName { get; set; }
        [Contain]
        public List<int> LawyerIds { get; set; }
        [Contain]
        public List<int> LawyerOfficeIds { get; set; }
    }

}
