using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.Requests.BookingRequest;
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
    public class BookingModule : Profile
    {
        public BookingModule()
        {
            CreateMap<Booking, BookingModel>().ReverseMap();
            CreateMap<CreateBookingRequest, Booking>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)BookingStatus.Active));
            CreateMap<UpdateBookingRequest, Booking>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)BookingStatus.Active)); 
        }
        
    }
}
