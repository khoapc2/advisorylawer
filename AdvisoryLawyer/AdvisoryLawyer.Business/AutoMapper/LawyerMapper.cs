using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.Requests.LawyerRequest;
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
    public class LawyerMapper : Profile
    {
        public LawyerMapper()
        {
            CreateMap<Lawyer, LawyerModel>()
                .ForMember(d => d.Sex, s => s.MapFrom(s => MappingSex(s.Sex)));
            CreateMap<LawyerRequest, Lawyer>()
                .ForMember(des => des.Status, opt => opt.MapFrom(src => (int)LawyerStatus.Active))
                .ForMember(d => d.Sex, s => s.MapFrom(s => (int)s.Sex));
            CreateMap<LawyerRequest, LawyerModel>();
            CreateMap<LawyerUpdate, Lawyer>()
                .ForMember(d => d.Sex, s => s.MapFrom(s => (int)s.Sex));
        }

        private static Sex MappingSex(int? i)
        {
            if (i == 2) return Sex.Male;
            else if (i == 1) return Sex.Female;
            return Sex.Unknown;
        }
    }
}
