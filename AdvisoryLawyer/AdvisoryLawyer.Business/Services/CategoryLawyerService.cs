﻿using AdvisoryLawyer.Business.Enum;
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
    public class CategoryLawyerService : ICategoryLawyerService
    {
        private readonly IGenericRepository<CategoryLawyer> _res;

        public CategoryLawyerService(IGenericRepository<CategoryLawyer> res)
        {
            _res = res;
        }
        public async Task<bool> CreateCategoryLawyer(int categoryId, List<int> LawyerIds)
        {

            foreach (var LawyerId in LawyerIds)
            {
                var CategoryLawyer = new CategoryLawyer()
                {
                    CategoryId = categoryId,
                    LawyerId = LawyerId,
                    Status = (int)CategoryLawyerStatus.Active
                };
                await _res.InsertAsync(CategoryLawyer);
            }
            await _res.SaveAsync();
            return true;
        }

        public Task<bool> CreateCategoryLawyer(List<int> categoryIds, int Lawyer)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCategoryLawyer(int categoryId)
        {
            var listCategoryoffice = (List<CategoryLawyer>)await _res.FindByAsync(x => x.CategoryId == categoryId);
            foreach (var categoryOffice in listCategoryoffice)
            {
                categoryOffice.Status = (int)CategoryLawyerStatus.InActive;
                await _res.UpdateAsync(categoryOffice);
            }
            await _res.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateCategoryLawyer(int categoryId, List<int> LawyerIds)
        {
            await DeleteCategoryLawyer(categoryId);
            if (LawyerIds.Contains(0) == true)
            {
                return true;
            }
            await CreateCategoryLawyer(categoryId, LawyerIds);
            return true;
        }

        public async Task<CategoryLawyer> GetCategoryLawyer(int categoryId)
        {
            return await _res.FindAsync(x => x.CategoryId == categoryId & x.Status == (int)CategoryLawyerStatus.Active);
        }
    }
}
