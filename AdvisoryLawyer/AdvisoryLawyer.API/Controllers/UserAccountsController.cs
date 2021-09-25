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
        [HttpPost]
        public ActionResult Login([FromBody] LoginRequest account)
        {
            try
            {
                var token = _service.Login(account.Username, account.Password);
                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(new {token = token});
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
        [HttpGet("profile")]
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



    }
}
