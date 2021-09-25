using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.AdvisoryRequest;
using AdvisoryLawyer.Business.ViewModel;
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
    public class AdvisoryController : ControllerBase
    {
        private readonly IAdvisoryService _advisoryService;

        public AdvisoryController(IAdvisoryService advisoryService)
        {
            _advisoryService = advisoryService;
        }

        [HttpGet("{id}", Name = "GetAdvisoryById")]
        public IActionResult GetAdvisoryById(int id)
        {
            var advisoryModel = _advisoryService.GetAdvisoryById(id);
            if (advisoryModel == null)
                return BadRequest();
            return Ok(advisoryModel);
        }

        [HttpGet]
        public IActionResult GetAllAdvisory()
        {
            var listAdvisoryModel = _advisoryService.GetAllAdvisory();
            return Ok(listAdvisoryModel);
        }

        [HttpPost]
        public IActionResult CreateAdvisory([FromBody] CreateAdvisoryRequest request)
        {
            var AdvisoryModel = _advisoryService.CreateAdvisory(request);
            return CreatedAtRoute(nameof(GetAdvisoryById), new { id = AdvisoryModel.Id }, AdvisoryModel
            );
        }

        [HttpPut]
        public IActionResult UpdateAdvisory([FromBody] UpdateAdvisoryRequest request)
        {
            var AdvisoryModel = _advisoryService.UpdateAdvisory(request);
            if (AdvisoryModel == null)
                return BadRequest();
            return Ok(AdvisoryModel);
        }

        [HttpDelete]
        public IActionResult DeleteAdvisory(int id)
        {
            var rs = _advisoryService.DeleteAdvisory(id);
            if (rs == false)
                return BadRequest();
            return Ok();
        }
    }
}

