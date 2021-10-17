using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.LawyerRequest;
using AdvisoryLawyer.Business.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/v1/lawyers")]
    [ApiController]
    public class LawyersController : ControllerBase
    {
        private readonly ILawyerService _service;
        public LawyersController(ILawyerService service)
        {
            _service = service;
        }

        //GET api/lawyers
        [HttpGet]
        public ActionResult<IEnumerable<LawyerModel>> GetAllLawyers([FromQuery] LawyerRequest filter, LawyerSortBy sort_by,
            OrderBy order_by, int page_index = 1, int page_size = 1)
        {
            return Ok(_service.GetAllLawyers(filter, sort_by, order_by, page_index, page_size));
        }

        //GET api/lawyers/{id}
        [HttpGet("{id}", Name = "GetLawyerById")]
        public async Task<ActionResult<LawyerModel>> GetLawyerById(int id)
        {
            var lawyerModel = await _service.GetLawyerById(id);
            if (lawyerModel == null)
            {
                return BadRequest();
            }
            return Ok(lawyerModel);
        }

        //POST api/lawyers
        [HttpPost]
        public async Task<ActionResult<LawyerModel>> CreateLawyer(LawyerRequest lawyerRequest)
        {
            var lawyerModel = await _service.CreateLawyer(lawyerRequest);
            if (lawyerModel != null)
            {
                return CreatedAtRoute(nameof(GetLawyerById)
                    , new { Id = lawyerModel.Id }, lawyerModel);
            }
            return BadRequest();
        }

        //PUT api/lawyers/{id}
        [HttpPut("update-lawyer")]
        public async Task<ActionResult<LawyerModel>> UpdateLawyer(LawyerUpdate lawyerUpdate)
        {
            var lawyerModel = await _service.UpdateLawyer(lawyerUpdate);
            if (lawyerModel != null)
            {
                return Ok(lawyerModel);
            }
            return BadRequest();
        }

        //DELETE api/lawyers/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLawyer(int id)
        {
            bool deleteStatus = await _service.DeleteLawyer(id);
            if (deleteStatus)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("details")]
        public async Task<IActionResult> GetDetailByEmail([FromBody] EmailRequest request)
        {
            try
            {
                var lawyer = await _service.GetDetailByEmail(request.Email);
                return Ok(lawyer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("remove-out-of-office")]
        public async Task<IActionResult> RemoveLawyerOutOfOffice([FromBody] ID request)
        {
            try
            {
                await _service.RemoveLawyerOutOfOffice(request.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpPut("update-level")]
        public async Task<IActionResult> UpdateLevelForLawyer([FromBody] UpdateLevelForLawyerRequest request)
        {
            try
            {
                var lawyer = await _service.UpdateLevelForLawyer(request);
                if (lawyer != null) return Ok(lawyer);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
