using AdvisoryLawyer.Business.Requests.CategoryRequest;
using AdvisoryLawyer.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetAllCategories();
        CategoryModel GetCategoryById(int id);
        CategoryModel CreateCategory(CategoryRequest categoryRequest);
        CategoryModel UpdateCategory(int id, CategoryRequest categoryRequest);
        bool DeleteCategory(int id);
    }
}
