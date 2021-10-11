using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.Requests.UserAccountsRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.AutoMapper
{
    public class UserAccountsMapper : Profile
    {
        public UserAccountsMapper()
        {
            CreateMap<UserAccount, UserAccountModel>(); ;

            CreateMap<UserAccountRequest, UserAccount>()
                .ForMember(d => d.Status, s => s.MapFrom(s => (int)UserAccountStatus.Active)); 

            CreateMap<UserAccountRequest, UserAccountModel>();

        }

        private static string ConvertDateTimeToString(DateTime? date)
        {
            if(date != null) return date?.ToString("yyyy-MM-dd");
            return null;
        }
    }
}
