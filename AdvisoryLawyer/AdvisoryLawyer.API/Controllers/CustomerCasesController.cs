using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
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
    [Route("api/v1/customer-cases")]
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
        public ActionResult<IEnumerable<CustomerCaseModel>> GetAllCustomerCases([FromQuery] CustomerCaseRequest filter,
            CustomerCaseSortBy sort_by, OrderBy order_by, int page_index = 1, int page_size = 1)
        {
            try
            {
                var customerCases = _service.GetAllCustomerCases(filter, sort_by, order_by, page_index, page_size);
                if (customerCases != null)
                {
                    return Ok(customerCases);
                }
                return NoContent();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //GET api/customer-cases/{id}
        [HttpGet("{id}", Name = "GetCustomerCaseById")]
        public async Task<ActionResult<CustomerCaseModel>> GetCustomerCaseById(int id)
        {
            try
            {
                var customerCaseModel = await _service.GetCustomerCaseById(id);
                if (customerCaseModel == null)
                {
                    return BadRequest();
                }
                return Ok(customerCaseModel);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        //POST api/customer-cases
        [HttpPost]
        public async Task<ActionResult<CustomerCaseModel>> CreateCustomerCase(CustomerCaseRequest customerCaseRequest)
        {
            try
            {
                var customerCaseModel = await _service.CreateCustomerCase(customerCaseRequest);
                if (customerCaseModel != null)
                {
                    return CreatedAtRoute(nameof(GetCustomerCaseById)
                        , new { Id = customerCaseModel.Id }, customerCaseModel);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //PUT api/customer-cases/{id}
        [HttpPut("update-customer-case")]
        public async Task<ActionResult<CustomerCaseModel>> UpdateCustomerCase(CustomerCaseUpdate customerCaseUpdate)
        {
            try
            {
                var customerCaseModel = await _service.UpdateCustomerCase(customerCaseUpdate);
                if (customerCaseModel != null)
                {
                    return Ok(customerCaseModel);
                }
                return BadRequest();
            }
            catch (Exception e) { return BadRequest(); }
        }

        //DELETE api/customer-cases/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomerCase(int id)
        {
            try
            {
                bool deleteStatus = await _service.DeleteCustomerCase(id);
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

        [HttpPut("update-document_case")]
        public async Task<IActionResult> UpdateCategoryLawyerOffice([FromBody] CaseDocumentUpdate request)
        {
            try
            {
                var office = await _service.UpdateDocumentCase(request);
                return Ok(office);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

