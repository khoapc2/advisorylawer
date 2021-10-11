using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.Requests.CustomerRequest;
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
    public class CustomerModule : Profile
    {
        public CustomerModule()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<CreateCustomerModelRequest, Customer>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)CustomerStatus.Active));
            CreateMap<UpdateCustomerModelRequest, Customer>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)CustomerStatus.Active));
        }

    }
}
