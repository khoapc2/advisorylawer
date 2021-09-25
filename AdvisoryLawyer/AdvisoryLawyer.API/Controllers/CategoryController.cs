using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.UserAccountsRequest;
using AdvisoryLawyer.Business.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        //GET api/categories
        [HttpGet]
        public ActionResult <IEnumerable<CategoryModel>> GetAllCategories()
        {
            return Ok(_service.GetAllCategories());
        }

        //GET api/categories/{id}
        [HttpGet("{id}", Name = "GetCategoryById")]
        public ActionResult <CategoryModel> GetCategoryById(int id)
        {
            var categoryModel = _service.GetCategoryById(id);
            if(categoryModel == null)
            {
                return BadRequest();
            }
            return categoryModel;
        }

        //POST api/categories
        [HttpPost]
        public ActionResult<CategoryModel> CreateCategory(CategoryRequest categoryRequest)
        {
            var categoryModel = _service.CreateCategory(categoryRequest);
            if(categoryModel != null)
            {
                return CreatedAtRoute(nameof(GetCategoryById)
                    , new { Id = categoryModel.Id }, categoryModel);
            }
            return BadRequest();
        }

        //PUT api/categories/{id}
        [HttpPut("{id}")]
        public ActionResult<CategoryModel> UpdateCategory(int id, CategoryRequest categoryRequest)
        {
            var categoryModel = _service.UpdateCategory(id, categoryRequest);
            if (categoryModel != null)
            {
                return Ok(categoryModel);
            }
            return BadRequest();
        }

        //DELETE api/categories/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            bool deleteStatus = _service.DeleteCategory(id);
            if (deleteStatus)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
