using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
