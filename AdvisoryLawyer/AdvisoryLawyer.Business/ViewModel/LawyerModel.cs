using AdvisoryLawyer.Business.Enum;
using Reso.Core.Attributes;
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
        [String]
        public string? Name { get; set; }
        [String]
        public string? Email { get; set; }
        [String]
        public string? Address { get; set; }
        [String]
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Website { get; set; }
        public Sex? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Status { get; set; }
        public int? LawyerOfficeId { get; set; }
        public int? LevelId { get; set; }

        public string? DateOfBirthFormatted { get; set; }

        public string LawyerOfficeName { get; set; }
        public string Level { get; set; }
    }
}
