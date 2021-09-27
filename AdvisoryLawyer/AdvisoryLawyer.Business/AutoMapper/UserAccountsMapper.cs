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
    public class UserAccountsMapper : Profile
    {
        public UserAccountsMapper()
        {
            CreateMap<UserAccount, UserAccountModel>().ForMember(
                destination => destination.Level, source => source.MapFrom(source => source.Level.LevelName)).ForMember(
                destination => destination.LawyerOfficeName, source => source.MapFrom(source => source.LawyerOffice.Name))
                .ForMember(destination => destination.DateOfBirth, source => source.MapFrom(source => ConvertDateTimeToString(source.DateOfBirth)));
        }

        private string ConvertDateTimeToString(DateTime? date)
        {
            return date?.ToString("dd/MM/yyyy");
        }
    }
}
