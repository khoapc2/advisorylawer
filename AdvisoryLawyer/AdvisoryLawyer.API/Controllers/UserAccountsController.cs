using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.UserAccountsRequest;
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
        public ActionResult<string> Login([FromBody] LoginRequest account)
        {
            try
            {
                var token = _service.Login(account.Username, account.Password);
                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(token);
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

    }
}
