using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.AuthenticationRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/v1/authentications")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationsController(IAuthenticationService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginWithGmail([FromBody] AuthenticationRequest request)
        {
            try
            {
                var data = await _service.LoginWithGmail(request.IdToken);
                if(data == null) return BadRequest();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
