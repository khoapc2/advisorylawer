using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.Requests.CategoryRequest;
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
    public class CategoriesMapper : Profile
    {
        public CategoriesMapper()
        {
            CreateMap<Category, CategoryModel>()
                .ForMember(des => des.LawyerOfficeIds, opt => opt.MapFrom(
                src => src.CategoryLawyerOffices.Where(clo => clo.Status == (int)CategoryLawyerOfficeStatus.Active).Select(x => x.LawyerOfficeId)))
                .ForMember(des => des.LawyerIds, opt => opt.MapFrom(
                src => src.CategoryLawyers.Where(clo => clo.Status == (int)CategoryLawyerStatus.Active).Select(x => x.LawyerId)));
            CreateMap<CategoryRequest, Category>();
            CreateMap<CategoryRequest, CategoryModel>();
        }
    }
}
