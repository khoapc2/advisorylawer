using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.Requests.CategoryRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using Newtonsoft.Json;
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
            CreateMap<Category, CategoryModel>().ForMember(des => des.LawyerIds, opt => opt.MapFrom(
                src => src.CategoryLawyers.Where(x => x.Status == (int)CategoryLawyerStatus.Active).Select(x => x.LawyerId)
                )).

                ForMember(des => des.LawyerOfficeIds, opt => opt.MapFrom(
                src => src.CategoryLawyerOffices.Where(x => x.Status == (int)CategoryLawyerOfficeStatus.Active).
                Select(x => x.LawyerOfficeId)
                ));
          
            CreateMap<CategoryRequest, Category>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)CategoryStatus.Active)); ;

            CreateMap<CategoryRequest, CategoryModel>();

            CreateMap<CategoryUpdate, Category>();

        }
    }
}
