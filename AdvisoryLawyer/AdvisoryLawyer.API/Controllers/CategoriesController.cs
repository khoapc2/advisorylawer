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
            try
            {
                var categories = _service.GetAllCategories(filter, sort_by, order_by, page_index, page_size);
                if (categories != null)
                {
                   return Ok(categories);
                }
                return NoContent();
                
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        //GET api/categories/{id}
        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult <CategoryModel>> GetCategoryById(int id)
        {
            try
            {
                var categoryModel = await _service.GetCategoryById(id);
                if (categoryModel == null)
                {
                    return BadRequest();
                }
                return Ok(categoryModel);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        //POST api/categories
        [HttpPost]
        public async Task<ActionResult<CategoryModel>> CreateCategory(CategoryRequest categoryRequest)
        {
            try
            {
                    var categoryModel = await _service.CreateCategory(categoryRequest);
                    if (categoryModel != null)
                    {
                        return CreatedAtRoute(nameof(GetCategoryById), new
                        {
                            Id = categoryModel.Id
                        }, categoryModel);
                    }
                    return BadRequest();
                
            }
            catch (Exception e) {
                return BadRequest(); 
            }
        }

        //PUT api/categories/{id}
        [HttpPut("update-category")]
        public async Task<ActionResult<CategoryModel>> UpdateCategory(CategoryUpdate categoryUpdate)
        {
            try
            {
                var categoryModel = await _service.UpdateCategory(categoryUpdate);
                if (categoryModel != null)
                {
                    return Ok(categoryModel);
                }
                return BadRequest();
            }
            catch (Exception e) { return BadRequest(); }
        }

        [HttpPut("update-categoryLawyer")]
        public async Task<ActionResult<CategoryModel>> UpdateCategoryLawyer(CategoryLawyerUpdate categoryUpdate)
        {
            try
            {
                var categoryModel = await _service.UpdateCategoryLawyer(categoryUpdate);
                if (categoryModel != null)
                {
                    return Ok(categoryModel);
                }
                return BadRequest();
            }
            catch (Exception e) { return BadRequest(); }
        }

        [HttpPut("update-categoryLawyerOffice")]
        public async Task<ActionResult<CategoryModel>> UpdateCategoryLawyerOffice(CategoryLawyerOfficeUpdate categoryUpdate)
        {
            try
            {
                var categoryModel = await _service.UpdateCategoryOfficeLawyer(categoryUpdate);
                if (categoryModel != null)
                {
                    return Ok(categoryModel);
                }
                return BadRequest();
            }
            catch (Exception e) { return BadRequest(); }
        }


        //DELETE api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                bool deleteStatus = await _service.DeleteCategory(id);
                if (deleteStatus)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
