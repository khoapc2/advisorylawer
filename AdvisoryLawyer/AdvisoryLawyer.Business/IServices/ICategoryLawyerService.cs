using AdvisoryLawyer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ICategoryLawyerService
    {
        Task<bool> CreateCategoryLawyer(int categoryIds, List<int> LawyerIds);
        Task<bool> CreateCategoryLawyer(List<int> categoryIds, int LawyerId);
        Task<bool> UpdateCategoryLawyer(int categoryIds, List<int> LawyerIds);
        Task<bool> DeleteCategoryLawyer(int categoryIds);
        Task<CategoryLawyer> GetCategoryLawyer(int categoryId);
        Task<bool> UpdateLawyerCategory(int Id, List<int> CategoryIds);
    }
}
