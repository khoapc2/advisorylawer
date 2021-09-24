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
    class UserAccountsMapper : Profile
    {
        public UserAccountsMapper()
        {
            CreateMap<UserAccount, UserAccountModel>();
        }
    }
}
