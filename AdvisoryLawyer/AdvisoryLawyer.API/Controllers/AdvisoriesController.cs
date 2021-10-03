using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.AdvisoryRequest;
using AdvisoryLawyer.Business.Requests.BookingRequest;
using AdvisoryLawyer.Business.ViewModel;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/v1/advisories")]
    [ApiController]
    public class AdvisoriesController : ControllerBase
    {
        private readonly IAdvisoryService _advisoryService;

        public AdvisoriesController(IAdvisoryService advisoryService)
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
        public IActionResult GetAllAdvisory([FromQuery]  AdvisoryModel fillter, AdvisorySortBy sortBy, OrderBy order,
            int pageIndex =1 , int pageSize = 1)
        {
            var listAdvisoryModel = _advisoryService.GetAllAdvisory(fillter, pageIndex,pageSize, sortBy, order);
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


