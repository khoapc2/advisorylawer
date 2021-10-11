using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class Lawyer
    {
        public Lawyer()
        {
            Bookings = new HashSet<Booking>();
            CategoryLawyers = new HashSet<CategoryLawyer>();
            Slots = new HashSet<Slot>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public int? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Status { get; set; }
        public int? LawyerOfficeId { get; set; }
        public int? LevelId { get; set; }

        public virtual LawyerOffice LawyerOffice { get; set; }
        public virtual Level Level { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<CategoryLawyer> CategoryLawyers { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
