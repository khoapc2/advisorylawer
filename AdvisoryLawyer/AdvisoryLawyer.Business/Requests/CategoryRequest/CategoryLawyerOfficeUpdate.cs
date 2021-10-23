using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.CategoryRequest
{
    public class CategoryLawyerOfficeUpdate
    {
        [FromQuery(Name = "category_id")]
        public int Id { get; set; }
        [FromQuery(Name = "lawyer_office_ids")]
        public List<int> CategoryLawyerOfficeIds { get; set; }
    }
}
