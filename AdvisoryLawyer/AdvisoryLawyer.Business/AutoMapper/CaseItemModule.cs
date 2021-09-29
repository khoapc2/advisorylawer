using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AdvisoryLawyer.Business.Requests.CaseItemRequest;
using AdvisoryLawyer.Business.Enum;

namespace AdvisoryLawyer.Business.AutoMapper
{
    public class CaseItemModule : Profile
    {
        public CaseItemModule()
        {
            CreateMap<CaseItem, CaseItemModel>().ReverseMap();
            CreateMap<CreateCaseItemRequest, CaseItem>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)CaseItemStatus.Active)); 
            CreateMap<UpdateCaseItemRequest, CaseItem>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)CaseItemStatus.Active)); ;
        }
    }
}
