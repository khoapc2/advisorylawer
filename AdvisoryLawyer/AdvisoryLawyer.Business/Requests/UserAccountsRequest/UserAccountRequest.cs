using AdvisoryLawyer.Business.Enum;
using Microsoft.AspNetCore.Mvc;
using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.UserAccountsRequest
{
    public class UserAccountRequest
    {
        [FromQuery(Name = "id")]
        public int? Id { get; set; }
        [String]
        [FromQuery(Name = "name")]
        public string? Name { get; set; }
        [String]
        [FromQuery(Name = "email")]
        public string Email { get; set; }
        [FromQuery(Name = "role")]
        public string Role { get; set; }
        [FromQuery(Name = "status")]
        public int? Status { get; set; }
    }
}
