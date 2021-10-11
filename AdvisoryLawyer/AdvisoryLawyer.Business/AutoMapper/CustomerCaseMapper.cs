using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.Requests.CustomerCaseRequest;
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
            CreateMap<CustomerCaseRequest, CustomerCase>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)CustomerCaseStatus.Active)); ;
            CreateMap<CustomerCaseRequest, CustomerCaseModel>();

            CreateMap<CustomerCaseUpdate, CustomerCase>();
        }
    }
}
