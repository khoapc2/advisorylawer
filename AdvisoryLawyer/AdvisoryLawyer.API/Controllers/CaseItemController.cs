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
        private readonly ICaseItemService _CaseItemService;

        public CaseItemController(ICaseItemService CaseItemService)
        {
            _CaseItemService = CaseItemService;
        }

        [HttpGet("{id}", Name = "GetCaseItemById")]
        public async Task<IActionResult> GetCaseItemById(int id)
        {
            var CaseItemModel = await _CaseItemService.GetCaseItemById(id);
            if (CaseItemModel == null)
                return BadRequest();
            return Ok(CaseItemModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCaseItem()
        {
            var listCaseItemModel = await _CaseItemService.GetAllCaseItem();
            return Ok(listCaseItemModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCaseItem([FromBody] CreateCaseItemRequest request)
        {
            var CaseItemModel = await _CaseItemService.CreateCaseItem(request);
            return CreatedAtRoute(nameof(GetCaseItemById), new { id = CaseItemModel.Id }, CaseItemModel
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCaseItem(int id, [FromBody] UpdateCaseItemRequest request)
        {
            var CaseItemModel = await _CaseItemService.UpdateCaseItem(id, request);
            if (CaseItemModel == null)
                return BadRequest();
            return Ok(CaseItemModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCaseItem(int id)
        {
            var rs = await _CaseItemService.DeleteCaseItem(id);
            if (rs == false)
                return BadRequest();
            return Ok();
        }
    }
}
