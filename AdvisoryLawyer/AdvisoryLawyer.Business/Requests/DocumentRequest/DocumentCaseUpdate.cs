using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.DocumentRequest
{
    public class DocumentCaseUpdate
    {
        [FromQuery(Name = "lawyer_id")]
        public int DocumentId { get; set; }

        [FromQuery(Name = "category_ids")]
        public List<int> CustomerCaseIds { get; set; }
    }
}
