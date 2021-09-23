using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class Advisory
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int LawyerId { get; set; }
        public string QuestionAnswer { get; set; }
        public DateTime? StartAdvisory { get; set; }
        public TimeSpan? TimeAdvisory { get; set; }

        public virtual UserAccount Customer { get; set; }
        public virtual UserAccount Lawyer { get; set; }
    }
}
