﻿using AdvisoryLawyer.Business.Requests.CustomerCaseRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.AutoMapper
{
    public class CustomerCaseMapper : Profile
    {
        public CustomerCaseMapper()
        {
            CreateMap<CustomerCase, CustomerCaseModel>();
            CreateMap<CustomerCaseRequest, CustomerCase>();
        }
    }
}
