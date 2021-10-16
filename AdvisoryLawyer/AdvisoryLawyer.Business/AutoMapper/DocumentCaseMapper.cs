using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.Requests.DocumentCaseRequest;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.AutoMapper
{
    public class DocumentCaseCaseMapper : Profile
    {
        public DocumentCaseCaseMapper()
        {
            CreateMap<DocumentCaseRequest, DocumentCase>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)DocumentCaseStatus.Active)); ;

            CreateMap<DocumentCaseUpdate, DocumentCase>();
        }
    }
}
