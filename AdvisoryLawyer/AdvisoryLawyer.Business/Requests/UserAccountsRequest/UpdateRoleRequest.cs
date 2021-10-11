using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.UserAccountsRequest
{
    public class UpdateRoleRequest
    {
        [FromQuery(Name = "id")]
        public int Id { get; set; }
        [FromQuery(Name = "role")]
        public string Role { get; set; }
    }
}
