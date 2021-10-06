using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class Slot
    {
        public int Id { get; set; }
        public int? BookingId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int Price { get; set; }
        public int LawyerId { get; set; }
        public int? Status { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual UserAccount Lawyer { get; set; }
    }
}
