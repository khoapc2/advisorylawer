using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class CategoryLawyerOffice
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int LawyerOfficeId { get; set; }

        public virtual Category Category { get; set; }
        public virtual UserAccount LawyerOffice { get; set; }
    }
}
