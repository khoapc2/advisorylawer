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
