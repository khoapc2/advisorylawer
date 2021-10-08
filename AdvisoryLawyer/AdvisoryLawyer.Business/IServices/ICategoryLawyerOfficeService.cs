using AdvisoryLawyer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ICategoryLawyerOfficeService
    {
        Task<bool> CreateCategoryLawyerOffice(int categoryIds, List<int> LawyerOffice);
        Task<bool> CreateCategoryLawyerOffice(List<int> categoryIds, int LawyerOffice);
        Task<bool> UpdateCategoryLawyerOffice(int categoryIds, List<int> LawyerOffice);
        Task<bool> DeleteCategoryLawyerOffice(int categoryIds);
        Task<CategoryLawyerOffice> GetCategoryLawyerOffice(int categoryId);
    }
}
