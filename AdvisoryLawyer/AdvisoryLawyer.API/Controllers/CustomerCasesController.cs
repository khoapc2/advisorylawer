using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.CustomerCaseRequest;
using AdvisoryLawyer.Business.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/customer-cases")]
    [ApiController]
    public class CustomerCasesController : ControllerBase
    {
        private readonly ICustomerCaseService _service;
        public CustomerCasesController(ICustomerCaseService service)
        {
            _service = service;
        }

        //GET api/customer-cases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCaseModel>>> GetAllCustomerCases()
        {
            return Ok(await _service.GetAllCustomerCases());
        }

        //GET api/customer-cases/{id}
        [HttpGet("{id}", Name = "GetCustomerCaseById")]
        public async Task<ActionResult<CustomerCaseModel>> GetCustomerCaseById(int id)
        {
            var categoryModel = await _service.GetCustomerCaseById(id);
            if (categoryModel == null)
            {
                return BadRequest();
            }
            return Ok(categoryModel);
        }

        //POST api/customer-cases
        [HttpPost]
        public async Task<ActionResult<CustomerCaseModel>> CreateCustomerCase(CustomerCaseRequest categoryRequest)
        {
            var categoryModel = await _service.CreateCustomerCase(categoryRequest);
            if (categoryModel != null)
            {
                return CreatedAtRoute(nameof(GetCustomerCaseById)
                    , new { Id = categoryModel.Id }, categoryModel);
            }
            return BadRequest();
        }

        //PUT api/customer-cases/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerCaseModel>> UpdateCustomerCase(int id, CustomerCaseRequest categoryRequest)
        {
            var categoryModel = await _service.UpdateCustomerCase(id, categoryRequest);
            if (categoryModel != null)
            {
                return Ok(categoryModel);
            }
            return BadRequest();
        }

        //DELETE api/customer-cases/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomerCase(int id)
        {
            bool deleteStatus = await _service.DeleteCustomerCase(id);
            if (deleteStatus)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

