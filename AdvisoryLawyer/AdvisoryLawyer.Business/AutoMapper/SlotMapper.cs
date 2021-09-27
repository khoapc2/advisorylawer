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
            CreateMap<Slot, SlotModel>();
            CreateMap<SlotRequest, Slot>();
        }
    }
}
