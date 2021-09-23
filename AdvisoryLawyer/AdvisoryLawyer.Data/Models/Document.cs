using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class Document
    {
        public Document()
        {
            DocumentCases = new HashSet<DocumentCase>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<DocumentCase> DocumentCases { get; set; }
    }
}
