using AdvisoryLawyer.Business.Requests.SlotRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.Models;
using AutoMapper;

namespace AdvisoryLawyer.Business.AutoMapper
{
    public class SlotMapper : Profile
    {
        public SlotMapper()
        {
            CreateMap<Slot, SlotModel>()
                .ForMember(d => d.id, s => s.MapFrom(s => s.Id))
                .ForMember(d => d.booking_id, s => s.MapFrom(s => s.BookingId))
                .ForMember(d => d.start_at, s => s.MapFrom(s => s.StartAt))
                .ForMember(d => d.end_at, s => s.MapFrom(s => s.EndAt))
                .ForMember(d => d.price, s => s.MapFrom(s => s.Price))
                .ForMember(d => d.lawyer_id, s => s.MapFrom(s => s.LawyerId))
                .ForMember(d => d.status, s => s.MapFrom(s => s.Status));

            CreateMap<SlotRequest, Slot>()
                .ForMember(d => d.BookingId, s => s.MapFrom(s => s.booking_id))
                .ForMember(d => d.StartAt, s => s.MapFrom(s => s.start_at))
                .ForMember(d => d.EndAt, s => s.MapFrom(s => s.end_at))
                .ForMember(d => d.Price, s => s.MapFrom(s => s.price))
                .ForMember(d => d.LawyerId, s => s.MapFrom(s => s.lawyer_id))
                .ForMember(d => d.Status, s => s.MapFrom(s => s.status));

            CreateMap<SlotRequest, SlotModel>();
        }
    }
}
