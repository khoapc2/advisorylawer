using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.SlotRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/v1/slots")]
    [ApiController]
    public class SlotsController : ControllerBase
    {
        private readonly ISlotService _service;

        public SlotsController(ISlotService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllSlot([FromQuery] SlotRequest request, SlotSortBy sort_by, OrderBy order_by, int page_index = 1, int page_size = 5)
        {
            try
            {
                var slotList = await _service.GetAllSlot(request, sort_by, order_by, page_index, page_size);
                if (slotList != null) return Ok(slotList);
                return NoContent();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetSlotByID")]
        public async Task<IActionResult> GetSlotByID(int id)
        {
            try
            {
                var slot = await _service.GetSlotByID(id);
                return Ok(slot);
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateSlot([FromBody] SlotRequest newSlot)
        {
            try
            {
                var slot = await _service.CreateSlot(newSlot);
                return CreatedAtRoute(nameof(GetSlotByID), new { id = slot.id }, slot);
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlot(int id, [FromBody] SlotRequest newSlot)
        {
            try
            {
                var slot = await _service.UpdateSlot(id, newSlot);
                return Ok(slot);
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteSlot(int id)
        {
            try
            {
                await _service.DeleteSlot(id);
                return Ok();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }
    }
}
