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
                .ForMember(d => d.sex, s => s.MapFrom(s => s.Sex))
                .ForMember(d => d.status, s => s.MapFrom(s => s.Status))
                .ForMember(d => d.level, s => s.MapFrom(s => s.Level.LevelName))
                .ForMember(d => d.lawyer_office_name, s => s.MapFrom(s => s.LawyerOffice.Name))
                .ForMember(d => d.date_of_birth, s => s.MapFrom(s => ConvertDateTimeToString(s.DateOfBirth)));
        }

        private string ConvertDateTimeToString(DateTime? date)
        {
            return date?.ToString("dd/MM/yyyy");
        }
    }
}
