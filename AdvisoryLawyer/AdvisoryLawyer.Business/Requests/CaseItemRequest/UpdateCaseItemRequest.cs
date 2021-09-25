using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.CaseItemRequest
{
    public class UpdateCaseItemRequest
    {
        public int CustomerCaseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
