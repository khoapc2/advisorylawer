﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class AuthenticationModel
    {
        public int? id { get; set; }
        public string token { get; set; }
        public string display_name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string Uid { get; set; }
    }
}
