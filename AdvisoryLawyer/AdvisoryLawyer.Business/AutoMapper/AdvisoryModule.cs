using AdvisoryLawyer.Business.Requests.AdvisoryRequest;
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
    public class AdvisoryModule : Profile
    {
        public AdvisoryModule()
        {
            CreateMap<Advisory, AdvisoryModel>();
            CreateMap<AdvisoryModel, Advisory>();
            CreateMap<CreateAdvisoryRequest, Advisory>();
            CreateMap<UpdateAdvisoryRequest, Advisory>();
        }
    }
}
