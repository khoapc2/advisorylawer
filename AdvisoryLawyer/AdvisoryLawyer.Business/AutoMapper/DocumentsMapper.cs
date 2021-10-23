using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.Requests.DocumentRequest;
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
    public class DocumentsMapper : Profile
    {
        public DocumentsMapper()
        {
            CreateMap<Document, DocumentModel>().ForMember(des => des.CustomerCaseIds, opt => opt.MapFrom(
                src => src.DocumentCases.Where(x => x.Status == (int)DocumentCaseStatus.Active).
                Select(x => x.CustomerCaseId))); ;
            CreateMap<DocumentRequest, Document>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)DocumentStatus.Active)); ;
            CreateMap<DocumentRequest, DocumentModel>();

            CreateMap<DocumentUpdate, Document>();
        }
    }
}
