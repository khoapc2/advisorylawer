using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.CustomerCaseRequest
{
    public class CaseDocumentUpdate
    {
        [FromQuery(Name = "customer_case_id")]
        public int CustomerCaseId { get; set; }

        [FromQuery(Name = "document_ids")]
        public List<int> DocumentIds { get; set; }
    }
}
