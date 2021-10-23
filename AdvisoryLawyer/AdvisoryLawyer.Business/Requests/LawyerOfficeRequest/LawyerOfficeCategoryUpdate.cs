using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.LawyerOfficeRequest
{
    public class LawyerOfficeCategoryUpdate
    {
        [FromQuery(Name = "lawyer_office_id")]
        public int Id { get; set; }

        [FromQuery(Name = "category_ids")]
        public List<int> CategoryIds { get; set; }
    }
}
