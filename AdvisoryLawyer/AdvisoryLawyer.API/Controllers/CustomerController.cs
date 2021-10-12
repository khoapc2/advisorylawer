using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.CustomerRequest;
using AdvisoryLawyer.Business.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;

        public CustomersController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var CustomerModel = await _CustomerService.GetCustomerModelById(id);
            if (CustomerModel == null)
                return BadRequest();
            return Ok(CustomerModel);
        }

        [HttpGet]
        public IActionResult GetAllCustomer([FromQuery] CustomerModel flitter, CustomerModelSortBy sortBy, OrderBy order,
            int pageIndex = 1, int pageSize = 1)
        {
            var listCustomerModel = _CustomerService.GetAllAdvisory(flitter, pageIndex, pageSize,
                sortBy, order);
            return Ok(listCustomerModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerModelRequest request)
        {
            var CustomerModel = await _CustomerService.CreateCustomerModel(request);
            return CreatedAtRoute(nameof(GetCustomerById), new { id = CustomerModel.Id }, CustomerModel
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerModelRequest request)
        {
            var CustomerModel = await _CustomerService.UpdateCustomerModel(id, request);
            if (CustomerModel == null)
                return BadRequest();
            return Ok(CustomerModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var rs = await _CustomerService.DeleteCustomerModel(id);
            if (rs == false)
                return BadRequest();
            return Ok();
        }
    }
}
