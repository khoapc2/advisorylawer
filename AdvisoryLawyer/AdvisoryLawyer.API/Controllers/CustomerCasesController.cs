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
        public ActionResult<IEnumerable<CustomerCaseModel>> GetAllCustomerCases()
        {
            return Ok(_service.GetAllCustomerCases());
        }

        //GET api/customer-cases/{id}
        [HttpGet("{id}", Name = "GetCustomerCaseById")]
        public ActionResult<CustomerCaseModel> GetCustomerCaseById(int id)
        {
            var categoryModel = _service.GetCustomerCaseById(id);
            if (categoryModel == null)
            {
                return BadRequest();
            }
            return Ok(categoryModel);
        }

        //POST api/customer-cases
        [HttpPost]
        public ActionResult<CustomerCaseModel> CreateCustomerCase(CustomerCaseRequest categoryRequest)
        {
            var categoryModel = _service.CreateCustomerCase(categoryRequest);
            if (categoryModel != null)
            {
                return CreatedAtRoute(nameof(GetCustomerCaseById)
                    , new { Id = categoryModel.Id }, categoryModel);
            }
            return BadRequest();
        }

        //PUT api/customer-cases/{id}
        [HttpPut("{id}")]
        public ActionResult<CustomerCaseModel> UpdateCustomerCase(int id, CustomerCaseRequest categoryRequest)
        {
            var categoryModel = _service.UpdateCustomerCase(id, categoryRequest);
            if (categoryModel != null)
            {
                return Ok(categoryModel);
            }
            return BadRequest();
        }

        //DELETE api/customer-cases/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomerCase(int id)
        {
            bool deleteStatus = _service.DeleteCustomerCase(id);
            if (deleteStatus)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

