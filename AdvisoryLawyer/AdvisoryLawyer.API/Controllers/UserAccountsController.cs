using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.UserAccountsRequest;
using AdvisoryLawyer.Business.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/v1/user-accounts")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly IUserAccountService _service;
        private readonly ILogger<UserAccountsController> _logger;
        public UserAccountsController(IUserAccountService service, ILogger<UserAccountsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileByID(int id)
        {
            try
            {
                var userProfile = await _service.GetProfileByID(id);
                return Ok(userProfile);
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfileByID([FromHeader] string authorization)
        {
            try
            {
                var userProfile = await _service.GetProfileByID(authorization.Substring(7));
                if(userProfile != null) return Ok(userProfile);
                return NoContent();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllProfiles([FromQuery] UserAccountRequest request, UserAccountSortBy sort_by, OrderBy order_by, int page_index = 1, int page_size = 5)
        {
            try
            {
                var profiles = _service.GetAllProfiles(request, sort_by, order_by, page_index, page_size);
                return Ok(profiles);
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("change-status/{id}")]
        public async Task<IActionResult> ChangeAccountStatus(int id)
        {
            try
            {
                var currentStatus = await _service.ChangeAccountStatus(id);
                return Ok(new { current_status = currentStatus });
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromHeader] string authorization, [FromBody] UserAccountRequest request)
        {
            try
            {
                var profile = await _service.UpdateProfile(authorization.Substring(7), request);
                return Ok(profile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> RemoveAccount([FromHeader] string authorization)
        {
            try
            {
                var isDelete = await _service.RemoveAccount(authorization.Substring(7));
                if(isDelete) return Ok();
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
