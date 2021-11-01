using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class AgoraChannel
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int? BookingId { get; set; }
        public int? Status { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
