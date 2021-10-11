using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class LawyerOffice
    {
        public LawyerOffice()
        {
            CategoryLawyerOffices = new HashSet<CategoryLawyerOffice>();
            Lawyers = new HashSet<Lawyer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }

        public virtual ICollection<CategoryLawyerOffice> CategoryLawyerOffices { get; set; }
        public virtual ICollection<Lawyer> Lawyers { get; set; }
    }
}
