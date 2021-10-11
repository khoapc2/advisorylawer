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
            CreateMap<Lawyer, LawyerModel>();
            CreateMap<LawyerRequest, Lawyer>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)LawyerStatus.Active)); ;
            CreateMap<LawyerRequest, LawyerModel>();

            CreateMap<LawyerUpdate, Lawyer>();
        }
    }
}
