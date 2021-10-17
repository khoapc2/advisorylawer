using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.LawyerRequest
{
    public class UpdateLevelForLawyerRequest
    {
        [FromQuery(Name = "lawyer_id")]
        public int LawyerId { get; set; }
        [FromQuery(Name = "level_id")]
        public int? LevelId { get; set; }
    }
}
