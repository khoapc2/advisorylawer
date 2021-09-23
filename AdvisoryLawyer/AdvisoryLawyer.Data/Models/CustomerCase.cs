using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class CustomerCase
    {
        public CustomerCase()
        {
            Bookings = new HashSet<Booking>();
            CaseItems = new HashSet<CaseItem>();
            DocumentCases = new HashSet<DocumentCase>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<CaseItem> CaseItems { get; set; }
        public virtual ICollection<DocumentCase> DocumentCases { get; set; }
    }
}
