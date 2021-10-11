using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.Requests.LawyerOfficeRequest;
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
    public class LawyerOfficeMapper : Profile
    {
        public LawyerOfficeMapper()
        {
            CreateMap<LawyerOffice, LawyerOfficeModel>(); ;

            CreateMap<LawyerOfficeRequest, LawyerOffice>()
                .ForMember(d => d.Status, s => s.MapFrom(s => (int)LawyerOfficeStatus.Active));

            CreateMap<LawyerOfficeRequest, LawyerOfficeModel>();
        }
    }
}
