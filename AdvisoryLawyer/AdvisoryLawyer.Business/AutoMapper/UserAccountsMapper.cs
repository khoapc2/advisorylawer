using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.Requests.UserAccountsRequest;
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
            CreateMap<UserAccount, UserAccountModel>()
                .ForMember(d => d.id, s => s.MapFrom(s => s.Id))
                .ForMember(d => d.username, s => s.MapFrom(s => s.Username))
                .ForMember(d => d.role, s => s.MapFrom(s => s.Role))
                .ForMember(d => d.name, s => s.MapFrom(s => s.Name))
                .ForMember(d => d.address, s => s.MapFrom(s => s.Address))
                .ForMember(d => d.location, s => s.MapFrom(s => s.Location))
                .ForMember(d => d.description, s => s.MapFrom(s => s.Description))
                .ForMember(d => d.phone_number, s => s.MapFrom(s => s.PhoneNumber))
                .ForMember(d => d.website, s => s.MapFrom(s => s.Website))
                .ForMember(d => d.email, s => s.MapFrom(s => s.Email))
                .ForMember(d => d.sex, s => s.MapFrom(s => s.Sex == true ? UserAccountSex.Male : UserAccountSex.Female))
                .ForMember(d => d.status, s => s.MapFrom(s => s.Status))
                .ForMember(d => d.level, s => s.MapFrom(s => s.Level.LevelName))
                .ForMember(d => d.level_id, s => s.MapFrom(s => s.LevelId))
                .ForMember(d => d.lawyer_office_name, s => s.MapFrom(s => s.LawyerOffice.Name))
                .ForMember(d => d.lawyer_office_id, s => s.MapFrom(s => s.LawyerOfficeId))
                .ForMember(d => d.date_of_birth, s => s.MapFrom(s => s.DateOfBirth));
                //.ForMember(d => d.date_of_birth_formated, s => s.MapFrom(s => ConvertDateTimeToString(s.DateOfBirth)));

            CreateMap<UserAccountRequest, UserAccount>()
                .ForMember(d => d.Username, s => s.MapFrom(s => s.username))
                .ForMember(d => d.Role, s => s.MapFrom(s => s.role))
                .ForMember(d => d.Name, s => s.MapFrom(s => s.name))
                .ForMember(d => d.Address, s => s.MapFrom(s => s.address))
                .ForMember(d => d.Location, s => s.MapFrom(s => s.location))
                .ForMember(d => d.Description, s => s.MapFrom(s => s.description))
                .ForMember(d => d.PhoneNumber, s => s.MapFrom(s => s.phone_number))
                .ForMember(d => d.Website, s => s.MapFrom(s => s.website))
                .ForMember(d => d.Email, s => s.MapFrom(s => s.email))
                .ForMember(d => d.Sex, s => s.MapFrom(s => s.sex == UserAccountSex.Male ? true : false))
                .ForMember(d => d.Status, s => s.MapFrom(s => s.status))
                .ForMember(d => d.LevelId, s => s.MapFrom(s => s.level_id))
                .ForMember(d => d.LawyerOfficeId, s => s.MapFrom(s => s.lawyer_office_id))
                .ForMember(d => d.DateOfBirth, s => s.MapFrom(s => s.date_of_birth ?? Convert.ToDateTime(s.date_of_birth_formated)));

            CreateMap<UserAccountRequest, UserAccountModel>();
        }

        private string ConvertDateTimeToString(DateTime? date)
        {
            return date?.ToString("dd/MM/yyyy");
        }
    }
}
