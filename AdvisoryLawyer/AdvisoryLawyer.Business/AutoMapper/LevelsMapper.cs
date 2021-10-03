using AdvisoryLawyer.Business.Requests.LevelRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.Models;
using AutoMapper;

namespace AdvisoryLawyer.Business.AutoMapper
{
    public class LevelsMapper : Profile
    {
        public LevelsMapper()
        {
            CreateMap<Level, LevelModel>()
                .ForMember(d => d.id, s => s.MapFrom(s => s.Id))
                .ForMember(d => d.level_name, s => s.MapFrom(s => s.LevelName))
                .ForMember(d => d.min_price, s => s.MapFrom(s => s.MinPrice))
                .ForMember(d => d.max_price, s => s.MapFrom(s => s.MaxPrice))
                .ForMember(d => d.status, s => s.MapFrom(s => s.Status));


            CreateMap<LevelRequest, Level>()
                .ForMember(d => d.LevelName, s => s.MapFrom(s => s.level_name))
                .ForMember(d => d.MinPrice, s => s.MapFrom(s => s.min_price))
                .ForMember(d => d.MaxPrice, s => s.MapFrom(s => s.max_price));

            CreateMap<LevelRequest, LevelModel>();
        }
    }
}
