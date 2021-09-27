using AdvisoryLawyer.Business.IServices;
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
    [Route("api/user-accounts")]
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

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest account)
        {
            try
            {
                var token = _service.Login(account.Username, account.Password);
                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(new { token = token });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("UserAccountsController_Login: " + ex.Message);
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetProfileByID([FromHeader] string authorization)
        {
            try
            {
                var userProfile = _service.GetProfileByID(authorization.Substring(7));
                return Ok(userProfile);
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("all-profile")]
        public IActionResult GetAllProfiles()
        {
            try
            {
                var profiles = _service.GetAllProfiles();
                return Ok(profiles);
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPut("change-password")]
        public IActionResult ChangePassword([FromHeader] string authorization, [FromBody] JsonElement body)
        {
            try
            {
                var newPassword = body.GetProperty("newPassword").GetString();
                bool isChange = _service.ChangePassword(authorization.Substring(7), newPassword);
                if(isChange)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("change-status/{id}")]
        public IActionResult ChangeAccountStatus(int id)
        {
            try
            {
                bool isChange = _service.ChangeAccountStatus(id);
                if (isChange) return Ok();
                return BadRequest();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest(ex.Message);
            }
        }


    }
}
