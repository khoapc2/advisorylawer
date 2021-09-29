using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class CaseItem
    {
        public int Id { get; set; }
        public int CustomerCaseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }

        public virtual CustomerCase CustomerCase { get; set; }
    }
}
