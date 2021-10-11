using Microsoft.AspNetCore.Mvc;
using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.LawyerOfficeRequest
{
    public class LawyerOfficeRequest
    {
        [FromQuery(Name = "id")]
        public int Id { get; set; }
        [FromQuery(Name = "name")]
        [String]
        public string Name { get; set; }
        [FromQuery(Name = "address")]
        [String]
        public string Address { get; set; }
        [FromQuery(Name = "location")]
        [String]
        public string Location { get; set; }
        [FromQuery(Name = "description")]
        public string Description { get; set; }
        [FromQuery(Name = "phone_number")]
        [String]
        public string PhoneNumber { get; set; }
        [FromQuery(Name = "website")]
        public string Website { get; set; }
        [FromQuery(Name = "email")]
        [String]
        public string Email { get; set; }
        [FromQuery(Name = "status")]
        public int Status { get; set; }
    }
}
