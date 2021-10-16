using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests
{
    public class EmailRequest
    {
        [FromQuery(Name = "email")]
        public string Email { get; set; }
    }
}
