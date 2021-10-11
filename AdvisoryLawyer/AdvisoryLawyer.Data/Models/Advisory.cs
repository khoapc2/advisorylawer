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
        public string Question { get; set; }
        public string Answer { get; set; }
        public int BookingId { get; set; }
        public int Status { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
