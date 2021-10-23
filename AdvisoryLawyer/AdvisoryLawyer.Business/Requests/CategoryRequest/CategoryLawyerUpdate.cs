using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.CategoryRequest
{
    public class CategoryLawyerUpdate
    {
        [FromQuery(Name = "category_id")]
        public int Id { get; set; }
        [FromQuery(Name = "lawyer_ids")]
        public List<int> CategoryLawyerIds { get; set; }
    }
}
