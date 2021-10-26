using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.AgoraRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/v1/agora")]
    [ApiController]
    public class AgoraController : ControllerBase
    {
        private readonly IAgoraService _service;

        public AgoraController(IAgoraService service)
        {
            _service = service;
        }

        //[Authorize]
        [HttpPost] 
        public IActionResult GetChannel([FromBody] AgoraRequest request)
        {
            try
            {
                var rs = _service.GetChannel(request);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
