using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AdvisoryLawyer.Business.Requests.CaseItemRequest;

namespace AdvisoryLawyer.Business.AutoMapper
{
    public class CaseItemModule : Profile
    {
        public CaseItemModule()
        {
            CreateMap<CaseItem, CaseItemModel>().ReverseMap();
            CreateMap<CreateCaseItemRequest, CaseItem>();
            CreateMap<UpdateCaseItemRequest, CaseItem>();
        }
    }
}
