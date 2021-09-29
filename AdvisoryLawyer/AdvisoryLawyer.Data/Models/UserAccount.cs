using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            AdvisoryCustomers = new HashSet<Advisory>();
            AdvisoryLawyers = new HashSet<Advisory>();
            Bookings = new HashSet<Booking>();
            CategoryLawyerOffices = new HashSet<CategoryLawyerOffice>();
            CategoryLawyers = new HashSet<CategoryLawyer>();
            InverseLawyerOffice = new HashSet<UserAccount>();
            Slots = new HashSet<Slot>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public bool? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Status { get; set; }
        public int? LawyerOfficeId { get; set; }
        public int? LevelId { get; set; }

        public virtual UserAccount LawyerOffice { get; set; }
        public virtual Level Level { get; set; }
        public virtual ICollection<Advisory> AdvisoryCustomers { get; set; }
        public virtual ICollection<Advisory> AdvisoryLawyers { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<CategoryLawyerOffice> CategoryLawyerOffices { get; set; }
        public virtual ICollection<CategoryLawyer> CategoryLawyers { get; set; }
        public virtual ICollection<UserAccount> InverseLawyerOffice { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
