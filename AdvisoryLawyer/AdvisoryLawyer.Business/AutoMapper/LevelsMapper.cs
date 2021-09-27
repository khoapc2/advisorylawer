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
            CreateMap<Level, LevelModel>();
            CreateMap<LevelRequest, Level>();
        }
    }
}
