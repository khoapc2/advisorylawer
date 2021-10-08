using AdvisoryLawyer.Business.Requests.SlotRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using System;
using System.Globalization;

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
                .ForMember(d => d.start_at_formatted, s => s.MapFrom(s => ConvertDateTimeToString(s.StartAt)))
                .ForMember(d => d.end_at, s => s.MapFrom(s => s.EndAt))
                .ForMember(d => d.end_at_formatted, s => s.MapFrom(s => ConvertDateTimeToString(s.EndAt)))
                .ForMember(d => d.price, s => s.MapFrom(s => s.Price))
                .ForMember(d => d.lawyer_id, s => s.MapFrom(s => s.LawyerId))
                .ForMember(d => d.status, s => s.MapFrom(s => s.Status));

            CreateMap<SlotRequest, Slot>()
                .ForMember(d => d.BookingId, s => s.MapFrom(s => s.booking_id))
                .ForMember(d => d.StartAt, s => s.MapFrom(s => DateTime.ParseExact(s.start_at_formatted, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)))
                .ForMember(d => d.EndAt, s => s.MapFrom(s => DateTime.ParseExact(s.end_at_formatted, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Price, s => s.MapFrom(s => s.price))
                .ForMember(d => d.LawyerId, s => s.MapFrom(s => s.lawyer_id))
                .ForMember(d => d.Status, s => s.MapFrom(s => s.status));

            CreateMap<SlotRequest, SlotModel>();
        }

        private static string ConvertDateTimeToString(DateTime? date)
        {
            if (date != null) return date?.ToString("dd/MM/yyyy HH:mm");
            return null;
        }
    }
}
