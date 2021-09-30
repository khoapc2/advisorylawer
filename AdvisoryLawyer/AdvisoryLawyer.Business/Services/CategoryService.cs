using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.CategoryRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
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
        private IMapper _mapper;

        public CategoryService(IGenericRepository<Category> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            var categories = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryModel>>(categories);
        }

        public async Task<CategoryModel> GetCategoryById(int id)
        {
            var category = await _genericRepository.GetByIDAsync(id);
            if(category != null) 
            {
                return _mapper.Map<CategoryModel>(category);
            }
            return null;
        }

        public async Task<CategoryModel> CreateCategory(CategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            await _genericRepository.InsertAsync(category);
            await _genericRepository.SaveAsync();

            return _mapper.Map<CategoryModel>(category);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _genericRepository.GetByIDAsync(id);
            if(category != null)
            {
                await _genericRepository.DeleteAsync(id);
                await _genericRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public async Task<CategoryModel> UpdateCategory(int id, CategoryRequest categoryRequest)
        {
            var category = await _genericRepository.GetByIDAsync(id);
            if (category != null)
            {
                category = _mapper.Map(categoryRequest, category);
                await _genericRepository.SaveAsync();
                return _mapper.Map<CategoryModel>(category);
            }
            return null;
        }


    }
}
