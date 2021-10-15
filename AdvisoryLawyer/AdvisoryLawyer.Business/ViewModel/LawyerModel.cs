using AdvisoryLawyer.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class LawyerModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Website { get; set; }
        public Sex? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Status { get; set; }
        public int? LawyerOfficeId { get; set; }
        public int? LevelId { get; set; }
    }
}
