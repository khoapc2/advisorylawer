using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class DocumentCase
    {
        public int Id { get; set; }
        public int CustomerCaseId { get; set; }
        public int DocumentId { get; set; }

        public virtual CustomerCase CustomerCase { get; set; }
        public virtual Document Document { get; set; }
    }
}
