using AdvisoryLawyer.Business.Enum;
using Microsoft.AspNetCore.Mvc;
using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.LawyerRequest
{
    public class LawyerRequest
    {
      
        [FromQuery(Name = "name")]
        [String]
        public string? Name { get; set; }

        [FromQuery(Name = "email")]
        [String]
        public string? Email { get; set; }

        [FromQuery(Name = "address")]
        [String]
        public string? Address { get; set; }

        [FromQuery(Name = "location")]
        [String]
        public string? Location { get; set; }

        [FromQuery(Name = "description")]
        [String]
        public string? Description { get; set; }

        [FromQuery(Name = "phone_number")]
        [String]
        public string? PhoneNumber { get; set; }

        [FromQuery(Name = "website")]
        [String]
        public string? Website { get; set; }

        [FromQuery(Name = "sex")]
        [String]
        public Sex? Sex { get; set; }

        [FromQuery(Name = "date_of_birth")]
        [String]
        public DateTime? DateOfBirth { get; set; }

        [FromQuery(Name = "status")]
        [String]
        public int? Status { get; set; }

        [FromQuery(Name = "lawyer_office_id")]
        [String]
        public int? LawyerOfficeId { get; set; }

        [FromQuery(Name = "level_id")]
        [String]
        public int? LevelId { get; set; }
        [Contain]
        public List<int> CategoryIds { get; set; }
    }
}
