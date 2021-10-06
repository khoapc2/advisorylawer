using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.LevelRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/v1/levels")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ILevelService _service;

        public LevelsController(ILevelService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllLevels([FromQuery] LevelRequest request, LevelSortBy sort_by, OrderBy order_by, int page_index = 1, int page_size = 5)
        {
            try
            {
                var levelList = _service.GetAllLevels(request, sort_by, order_by, page_index, page_size);
                if (levelList != null)
                {
                    return Ok(levelList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetLevelByID")]
        public async Task<IActionResult> GetLevelByID(int id)
        {
            try
            {
                var level = await _service.GetLevelByID(id);
                return Ok(level);
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateLevel([FromBody] LevelRequest newLevel)
        {
            try
            {
                var level = await _service.CreateLevel(newLevel);
                return CreatedAtRoute(nameof(GetLevelByID), new { id = level.id }, level);
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLevel(int id, [FromBody] LevelRequest newLevel)
        {
            try
            {
                var level = await _service.UpdateLevel(id, newLevel);
                return Ok();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevel(int id)
        {
            try
            {
                await _service.DeleteLevel(id);
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
