using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdvisoryLawyer.Business.Requests.CategoryRequest
{
    public class CategoryRequest
    {
        [String]
        [FromQuery(Name = "category_name")]
        public string CategoryName { get; set; }

    }

}
