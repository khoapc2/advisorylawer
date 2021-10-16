using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.LawyerOfficeRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/v1/lawyer-offices")]
    [ApiController]
    public class LawyerOfficesController : ControllerBase
    {
        private readonly ILawyerOfficeService _service;

        public LawyerOfficesController(ILawyerOfficeService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetListLawyerOffice([FromQuery] LawyerOfficeRequest request, LawyerOfficeSortBy sort_by, OrderBy order_by, int page_index = 1, int page_size = 5)
        {
            try
            {
                var listLawyerOffice = _service.GetListLawyerOffice(request, sort_by, order_by, page_index, page_size);
                return Ok(listLawyerOffice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetLawyerOfficeByID")]
        public async Task<IActionResult> GetLawyerOfficeByID(int id)
        {
            try
            {
                var office = await _service.GetLawyerOfficeByID(id);
                return Ok(office);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateLawyerOffice([FromBody] LawyerOfficeRequest request)
        {
            try
            {
                var office = await _service.CreateLawyerOffice(request);
                return CreatedAtRoute(nameof(GetLawyerOfficeByID), new { id = office.Id }, office);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateSlot([FromBody] LawyerOfficeRequest request)
        {
            try
            {
                var office = await _service.UpdateLawyerOffice(request);
                return Ok(office);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteLawyerOffice([FromBody] ID request)
        { 
            try
            {
                await _service.DeleteLawyerOffice(request.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("details")]
        public async Task<IActionResult> GetDetailByEmail([FromBody] EmailRequest request)
        {
            try
            {
                var office = await _service.GetDetailByEmail(request.Email);
                return Ok(office);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
 