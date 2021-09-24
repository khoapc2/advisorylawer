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
        CategoryModel CreateCategory(CategoryModel categoryModel);
        void UpdateCategory(int id, CategoryModel categoryModel);
        void DeleteCategory(int id);
    }
}
