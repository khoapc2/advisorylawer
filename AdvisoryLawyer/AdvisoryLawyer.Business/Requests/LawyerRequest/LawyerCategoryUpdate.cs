using Microsoft.AspNetCore.Mvc;
using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.LawyerRequest
{
    public class LawyerCategoryUpdate
    {
        [FromQuery(Name = "lawyer_id")]
        public int Id { get; set; }

        [FromQuery(Name = "category_ids")]
        public List<int> CategoryIds { get; set; }
    }
}
