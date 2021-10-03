using AdvisoryLawyer.Business.IServices;
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
        public IActionResult GetAllLevels()
        {
            try
            {
                var levelList = _service.GetAllLevels();
                if(levelList != null)
                {
                    return Ok(levelList);
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
        [HttpGet("{id}", Name = "GetLevelByID")]
        public IActionResult GetLevelByID(int id)
        {
            try
            {
                var level = _service.GetLevelByID(id);
                if (level != null) return Ok(level);
                return BadRequest();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateLevel([FromBody] LevelRequest newLevel)
        {
            try
            {
                var level = _service.CreateLevel(newLevel);
                if (level != null) return CreatedAtRoute(nameof(GetLevelByID), new { Id = level.Id }, level);
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
        public IActionResult UpdateLevel(int id, [FromBody] LevelRequest newLevel)
        {
            try
            {
                var level = _service.UpdateLevel(id, newLevel);
                if (level != null) return Ok();
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
        public IActionResult DeleteLevel(int id)
        {
            try
            {
                bool isDelete = _service.DeleteLevel(id);
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
