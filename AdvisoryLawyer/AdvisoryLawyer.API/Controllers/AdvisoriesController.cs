using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.AdvisoryRequest;
using AdvisoryLawyer.Business.Requests.BookingRequest;
using AdvisoryLawyer.Business.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class advisoriesController : ControllerBase
    {
        private readonly IAdvisoryService _advisoryService;

        public advisoriesController(IAdvisoryService advisoryService)
        {
            _advisoryService = advisoryService;
        }

        [HttpGet("{id}", Name = "GetAdvisoryById")]
        public async Task<IActionResult> GetAdvisoryById(int id)
        {
            var advisoryModel =  await _advisoryService.GetAdvisoryById(id);
            if (advisoryModel == null)
                return BadRequest();
            return Ok(advisoryModel);
        }

        [HttpGet]
        public IActionResult GetAllAdvisory([FromQuery] AdvisoryModel fillter,int pageIndex, string sortBy, string order)
        {
            var listAdvisoryModel = _advisoryService.GetAllAdvisory(fillter, pageIndex, sortBy, order);
            return Ok(listAdvisoryModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvisory([FromBody] CreateAdvisoryRequest request)
        {
            var AdvisoryModel = await _advisoryService.CreateAdvisory(request);
            return CreatedAtRoute(nameof(GetAdvisoryById), new { id = AdvisoryModel.Id }, AdvisoryModel
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdvisory(int id, [FromBody] UpdateAdvisoryRequest request)
        {
            var AdvisoryModel = await _advisoryService.UpdateAdvisory(id, request);
            if (AdvisoryModel == null)
                return BadRequest();
            return Ok(AdvisoryModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdvisory(int id)
        {
            var rs = await _advisoryService.DeleteAdvisory(id);
            if (rs == false)
                return BadRequest();
            return Ok();
        }
    }
}


