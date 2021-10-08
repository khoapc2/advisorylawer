using Microsoft.AspNetCore.Mvc;
using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.CustomerCaseRequest
{
    public class CustomerCaseRequest
    {
        [FromQuery(Name = "name")]
        [String]
        public string Name { get; set; }

        [FromQuery(Name = "description")]
        [String]
        public string Description { get; set; }
    }
}
