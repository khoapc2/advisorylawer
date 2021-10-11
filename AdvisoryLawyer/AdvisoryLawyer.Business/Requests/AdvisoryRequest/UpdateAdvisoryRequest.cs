using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.AdvisoryRequest
{
    public class UpdateAdvisoryRequest
    {
        public int CustomerId { get; set; }
        public int LawyerId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int BookingId { get; set; }
    }
}
