﻿using AdvisoryLawyer.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.CustomerRequest
{
    public class UpdateCustomerModelRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Sex? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
