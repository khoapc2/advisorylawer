using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.LawyerRequest
{
    public class AddLawyerToOfficeRequest
    {
        public int OfficeId { get; set; }
        public string LawyerEmail { get; set; }
    }
}
