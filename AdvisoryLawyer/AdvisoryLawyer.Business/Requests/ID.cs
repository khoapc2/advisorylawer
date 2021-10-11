using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests
{
    public class ID
    {
        [FromQuery(Name = "id")]
        public int Id { get; set; }
    }
}
