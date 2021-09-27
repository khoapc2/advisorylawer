using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class UserAccountModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        //public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public bool? Sex { get; set; }
        public string? DateOfBirth { get; set; }
        public int Status { get; set; }
        public string? LawyerOfficeName { get; set; }
        public string? Level { get; set; }
    }
}
