using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.CaseItemRequest;
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
    public class CaseItemController : ControllerBase
    {
        private readonly ICaseItemService _caseItemService;

        public CaseItemController(ICaseItemService caseItemService)
        {
            _caseItemService = caseItemService;
        }

        [HttpGet("{id}", Name = "GetCaseItemById")]
        public IActionResult GetCaseItemById(int id)
        {
            var caseItemModel = _caseItemService.GetCaseItemById(id);
            if (caseItemModel == null)
                return BadRequest();
            return Ok(caseItemModel);
        }

        [HttpGet]
        public IActionResult GetAllBooking()
        {
            var listCaseItemModel = _caseItemService.GetAllCaseItem();
            return Ok(listCaseItemModel);
        }

        [HttpPost]
        public IActionResult CreateAdvisory([FromBody] CreateCaseItemRequest request)
        {
            var caseItemModel = _caseItemService.CreateCaseItem(request);
            return CreatedAtRoute(nameof(GetCaseItemById), new { id = caseItemModel.Id }, caseItemModel
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int id, [FromBody] UpdateCaseItemRequest request)
        {
            var caseItemModel = _caseItemService.UpdateCaseItem(id, request);
            if (caseItemModel == null)
                return BadRequest();
            return Ok(caseItemModel);
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var rs = _caseItemService.DeleteCaseItem(id);
            if (rs == false)
                return BadRequest();
            return Ok();
        }
    }
}
