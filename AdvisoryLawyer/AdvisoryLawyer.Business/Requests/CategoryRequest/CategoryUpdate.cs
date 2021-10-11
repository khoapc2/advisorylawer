using Microsoft.AspNetCore.Mvc;
using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.CategoryRequest
{
    public class CategoryUpdate
    {
        [FromQuery(Name = "id")]
        public int Id { get; set; }

        [String]
        [FromQuery(Name = "category_name")]
        public string CategoryName { get; set; }
    }
}
