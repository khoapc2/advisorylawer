using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.CategoryRequest;
using AdvisoryLawyer.Business.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        //GET api/categories
        [HttpGet]

        public IActionResult GetAllCategories([FromQuery] CategoryModel filter, CategorySortBy sort_by, 
            OrderBy order_by, int page_index = 1, int page_size = 1)
        {
            return Ok(_service.GetAllCategories(filter, sort_by, order_by, page_index, page_size));
        }

        //GET api/categories/{id}
        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult <CategoryModel>> GetCategoryById(int id)
        {
            var categoryModel = await _service.GetCategoryById(id);
            if(categoryModel == null)
            {
                return BadRequest();
            }
            return Ok(categoryModel);
        }

        //POST api/categories
        [HttpPost]
        public async Task<ActionResult<CategoryModel>> CreateCategory(CategoryRequest categoryRequest)
        {
            var categoryModel = await _service.CreateCategory(categoryRequest);
            if(categoryModel != null)
            {
                return CreatedAtRoute(nameof(GetCategoryById)
                    , new { Id = categoryModel.Id }, categoryModel);
            }
            return BadRequest();
        }

        //PUT api/categories/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryModel>> UpdateCategory(int id, CategoryRequest categoryRequest)
        {
            var categoryModel = await _service.UpdateCategory(id, categoryRequest);
            if (categoryModel != null)
            {
                return Ok(categoryModel);
            }
            return BadRequest();
        }

        //DELETE api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            bool deleteStatus = await _service.DeleteCategory(id);
            if (deleteStatus)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
