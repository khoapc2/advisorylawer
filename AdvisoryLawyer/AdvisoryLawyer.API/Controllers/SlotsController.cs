using AdvisoryLawyer.Business.IServices;
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
    [Route("api/slots")]
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
        public IActionResult GetAllSlot()
        {
            try
            {
                var slotList = _service.GetAllSlot();
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
        public IActionResult GetSlotByID(int id)
        {
            try
            {
                var slot = _service.GetSlotByID(id);
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
        public IActionResult CreateSlot([FromBody] SlotRequest newSlot)
        {
            try
            {
                var slot = _service.CreateSlot(newSlot);
                if(slot != null)
                {
                    return CreatedAtRoute(nameof(GetSlotByID), new { Id = slot.Id }, slot);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateSlot(int id, [FromBody] SlotRequest newSlot)
        {
            try
            {
                var slot = _service.UpdateSlot(id, newSlot);
                if (slot != null) return Ok(slot);
                return BadRequest();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("{id}")] 
        public IActionResult DeleteSlot(int id)
        {
            try
            {
                var isDelete = _service.DeleteSlot(id);
                if (isDelete) return Ok();
                return BadRequest();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }
    }
}
