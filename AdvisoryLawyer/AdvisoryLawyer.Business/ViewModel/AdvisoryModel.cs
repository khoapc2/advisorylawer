using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class AdvisoryModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int LawyerId { get; set; }
        public int QuestionAnswer { get; set; }
        public DateTime? StartAdvisory { get; set; }
        public DateTime? TimeAdvisory { get; set; }
    }
}
