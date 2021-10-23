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
                .ForMember(d => d.Sex, s => s.MapFrom(s => MappingSex(s.Sex)))
                .ForMember(d => d.Level, s => s.MapFrom(s => s.Level.LevelName))
                .ForMember(d => d.LawyerOfficeName, s => s.MapFrom(s => s.LawyerOffice.Name))
                .ForMember(d => d.DateOfBirthFormatted, s => s.MapFrom(s => ConvertDateTimeToString(s.DateOfBirth)))
            .ForMember(des => des.CategoryIds, opt => opt.MapFrom(
                src => src.CategoryLawyers.Where(x => x.Status == (int)CategoryLawyerStatus.Active).
                Select(x => x.CategoryId)));

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

        private static string ConvertDateTimeToString(DateTime? date)
        {
            if (date != null) return date?.ToString("yyyy-MM-dd");
            return null;
        }
    }
}
