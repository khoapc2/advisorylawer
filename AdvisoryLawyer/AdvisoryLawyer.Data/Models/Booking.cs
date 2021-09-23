using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Slots = new HashSet<Slot>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime BookingDate { get; set; }
        public string PaymentMethod { get; set; }
        public int TotalPrice { get; set; }
        public DateTime? PayDate { get; set; }
        public int? Status { get; set; }
        public int CustomerCaseId { get; set; }

        public virtual UserAccount Customer { get; set; }
        public virtual CustomerCase CustomerCase { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
