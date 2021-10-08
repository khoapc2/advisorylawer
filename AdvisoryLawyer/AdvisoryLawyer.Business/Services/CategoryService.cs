using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.CategoryRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PagedList;
using Reso.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private IGenericRepository<Category> _genericRepository;
        private ICategoryLawyerOfficeService _categoryLawyerOfficeService;
        private ICategoryLawyerService _categoryLawyerService;
        private IMapper _mapper;

        public CategoryService(IGenericRepository<Category> genericRepository, IMapper mapper, 
            ICategoryLawyerOfficeService categoryLawyerOfficeService, ICategoryLawyerService categoryLawyerService)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _categoryLawyerOfficeService = categoryLawyerOfficeService;
            _categoryLawyerService = categoryLawyerService;
        }

        public IPagedList<CategoryModel> GetAllCategories(CategoryModel filter, CategorySortBy sortBy, 
            OrderBy order, int pageIndex, int pageSize)
        {
            var listCategories = _genericRepository.FindBy(x => x.Status == (int)CategoryStatus.Active);

            var listCategoriesModel = (listCategories.ProjectTo<CategoryModel>
                (_mapper.ConfigurationProvider)).DynamicFilter(filter);
            switch (sortBy.ToString())
            {
                case "Name":
                    if ("Asc".Equals(order.ToString()))
                    {
                        listCategoriesModel = listCategoriesModel.OrderBy(x => x.CategoryName);
                    }
                    else
                    {
                        listCategoriesModel = listCategoriesModel.OrderByDescending(x => x.CategoryName);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList(listCategoriesModel, pageIndex, pageSize);
        }

        public async Task<CategoryModel> GetCategoryById(int id)
        {
            var category = await _genericRepository.FindAsync(x => x.Id == id 
            && x.Status == (int)CategoryStatus.Active);
            if(category != null) 
            {
                return _mapper.Map<CategoryModel>(category);
            }
            return null;
        }

        public async Task<CategoryModel> CreateCategory(CategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            category.Status = (int)CategoryStatus.Active;
            await _genericRepository.InsertAsync(category);
            await _genericRepository.SaveAsync();
            await _categoryLawyerOfficeService.CreateCategoryLawyerOffice(category.Id, categoryRequest.LawyerOfficeIds);
            await _categoryLawyerService.CreateCategoryLawyer(category.Id, categoryRequest.LawyerIds);
            var categoryModel = _mapper.Map<CategoryModel>(category);
            categoryModel.LawyerOfficeIds = categoryRequest.LawyerOfficeIds;
            categoryModel.LawyerIds = categoryRequest.LawyerIds;
            return categoryModel;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _genericRepository.FindAsync(x => x.Id == id 
            && x.Status == (int)CategoryStatus.Active);
            var categoryLawyerOffice = await _categoryLawyerOfficeService.GetCategoryLawyerOffice(id);
            var categoryLawyer = await _categoryLawyerService.GetCategoryLawyer(id);
            if (category != null && categoryLawyerOffice == null && categoryLawyer == null)
            {
                category.Status = (int)CategoryStatus.InActive;
                await _genericRepository.UpdateAsync(category);
                await _genericRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public async Task<CategoryModel> UpdateCategory(int id, CategoryRequest categoryRequest)
        {
            var category = await _genericRepository.FindAsync(x => x.Id == id && 
            x.Status == (int)CategoryStatus.Active);
            if (category != null)
            {
                category = _mapper.Map(categoryRequest, category);
                await _genericRepository.SaveAsync();
                await _categoryLawyerOfficeService.UpdateCategoryLawyerOffice(id, categoryRequest.LawyerOfficeIds);
                await _categoryLawyerService.UpdateCategoryLawyer(id, categoryRequest.LawyerIds);
                
                var categoryModel = _mapper.Map<CategoryModel>(category); 
                categoryModel.LawyerOfficeIds = categoryRequest.LawyerOfficeIds;
                categoryModel.LawyerIds = categoryRequest.LawyerIds;
                return categoryModel;
            }
            return null;
        }

        
    }
}
