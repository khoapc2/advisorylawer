using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.AdvisoryRequest
{
    public class CreateAdvisoryRequest
    {
        public int CustomerId { get; set; }
        public int LawyerId { get; set; }
        public string QuestionAnswer { get; set; }
        public DateTime? StartAdvisory { get; set; }
        public TimeSpan? TimeAdvisory { get; set; }
       
    }
}
