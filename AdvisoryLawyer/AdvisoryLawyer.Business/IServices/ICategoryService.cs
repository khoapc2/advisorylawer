﻿using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.CategoryRequest;
using AdvisoryLawyer.Business.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ICategoryService
    {
        IPagedList<CategoryModel> GetAllCategories(CategoryModel filter,
            CategorySortBy sortBy, OrderBy order, int pageIndex, int pageSize);
        Task<CategoryModel> GetCategoryById(int id);
        Task<CategoryModel> CreateCategory(CategoryRequest categoryRequest);
        Task<CategoryModel> UpdateCategory(int id, CategoryRequest categoryRequest);
        Task<bool> DeleteCategory(int id);
    }
}
