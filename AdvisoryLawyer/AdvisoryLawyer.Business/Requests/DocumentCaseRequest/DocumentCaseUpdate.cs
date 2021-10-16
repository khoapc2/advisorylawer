using Microsoft.AspNetCore.Mvc;
using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.DocumentCaseRequest
{
    public class DocumentCaseUpdate
    {
        [FromQuery(Name = "id")]
        [String]
        public int Id { get; set; }

        [FromQuery(Name = "customer_case_id")]
        [String]
        public int CustomerCaseId { get; set; }

        [FromQuery(Name = "document_id")]
        [String]
        public int DocumentId { get; set; }

        [FromQuery(Name = "status")]
        [String]
        public int Status { get; set; }
    }
}
