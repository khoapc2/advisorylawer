using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Services
{
    public class CategoryLawyerOfficeService : ICategoryLawyerOfficeService
    {
        private readonly IGenericRepository<CategoryLawyerOffice> _res;

        public CategoryLawyerOfficeService(IGenericRepository<CategoryLawyerOffice> res)
        {
            _res = res;
        }
        public async Task<bool> CreateCategoryLawyerOffice(int categoryId, List<int> LawyerOfficeIds)
        {       
            foreach(var lawyerofficeId in LawyerOfficeIds)
            {
                var CategoryLawyerOffice = new CategoryLawyerOffice()
                {
                    CategoryId = categoryId,
                    LawyerOfficeId = lawyerofficeId,
                    Status = (int)CategoryLawyerOfficeStatus.Active
                };
                await _res.InsertAsync(CategoryLawyerOffice);
            }
            await _res.SaveAsync();
            return true;
        }

        public async Task<bool> CreateCategoryLawyerOffice(List<int> categoryIds, int LawyerOffice)
        {
            foreach (var categoryId in categoryIds)
            {
                var CategoryLawyerOffice = new CategoryLawyerOffice()
                {
                    CategoryId = categoryId,
                    LawyerOfficeId = LawyerOffice,
                    Status = (int)CategoryLawyerOfficeStatus.Active
                };
                await _res.InsertAsync(CategoryLawyerOffice);
            }
            await _res.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var listCategoryoffice = (List<CategoryLawyerOffice>)await _res.FindByAsync(x => x.CategoryId == categoryId);
            foreach(var categoryOffice in listCategoryoffice)
            {
                categoryOffice.Status = (int)CategoryLawyerOfficeStatus.InActive;
                await _res.UpdateAsync(categoryOffice);
            }
            await _res.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteLawyerOffice (int lawyerOfficeId)
        {
            var listCategoryoffice = (List<CategoryLawyerOffice>)await _res.FindByAsync(x => x.LawyerOfficeId == lawyerOfficeId);
            foreach (var categoryOffice in listCategoryoffice)
            {
                categoryOffice.Status = (int)CategoryLawyerOfficeStatus.InActive;
                await _res.UpdateAsync(categoryOffice);
            }
            await _res.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateCategoryLawyerOffice(int categoryId, List<int> LawyerOfficeIds)
        {
            await DeleteCategory(categoryId);
            if (LawyerOfficeIds.Contains(0) == true)
            { 
                return true;
            }
            await CreateCategoryLawyerOffice(categoryId, LawyerOfficeIds);
            return true;
        }

        public async Task<CategoryLawyerOffice> GetCategoryLawyerOffice(int categoryId)
        {
            return await _res.FindAsync(x => x.CategoryId == categoryId & x.Status == (int)CategoryLawyerOfficeStatus.Active);
        }

        public async Task<bool> UpdateLawyerOfficeCategory(int LawyerOffice, List<int> categoryIds)
        {
            await DeleteLawyerOffice(LawyerOffice);
            await CreateCategoryLawyerOffice(categoryIds, LawyerOffice);
            return true;
        }
    }
}
