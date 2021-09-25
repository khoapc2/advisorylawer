using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.UserAccountsRequest;
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

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            var categories = _genericRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryModel>>(categories);
        }

        public CategoryModel GetCategoryById(int id)
        {
            var category = _genericRepository.GetByID(id);
            if(category != null) 
            {
                return _mapper.Map<CategoryModel>(category);
            }
            return null;
        }

        public CategoryModel CreateCategory(CategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            _genericRepository.Insert(category);
            _genericRepository.Save();

            return _mapper.Map<CategoryModel>(category);
        }

        public bool DeleteCategory(int id)
        {
            var category = _genericRepository.GetByID(id);
            if(category != null)
            {
                _genericRepository.Delete(id);
                _genericRepository.Save();
                return true;
            }
            return false;
        }

        public CategoryModel UpdateCategory(int id, CategoryRequest categoryRequest)
        {
            var category = _genericRepository.GetByID(id);
            if (category != null)
            {
                category = _mapper.Map(categoryRequest, category);
                _genericRepository.Save();
                return _mapper.Map<CategoryModel>(category);
            }
            return null;
        }


    }
}
