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
            CreateMap<Category, CategoryModel>();
          
            CreateMap<CategoryRequest, Category>().ForMember(des
                => des.Status, opt => opt.MapFrom(src => (int)CategoryStatus.Active)); ;

            CreateMap<CategoryRequest, CategoryModel>();


        }
    }
}
