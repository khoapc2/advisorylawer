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
        [HttpGet("account")]
        public async Task<IActionResult> GetAccountByID([FromBody] ID request)
        {
            try
            {
                var userProfile = await _service.GetAccountByID(request.Id);
                return Ok(userProfile);
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetListAccount([FromQuery] UserAccountRequest request, UserAccountSortBy sort_by, OrderBy order_by, int page_index = 1, int page_size = 5)
        {
            try
            {
                var listAccount = _service.GetListAccount(request, sort_by, order_by, page_index, page_size);
                return Ok(listAccount);
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("change-status")]
        public async Task<IActionResult> ChangeAccountStatus([FromBody] ID request)
        {
            try
            {
                var currentStatus = await _service.ChangeAccountStatus(request.Id);
                return Ok(new { current_status = currentStatus });
            }
            catch (Exception ex)
            {
                //logging
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

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleRequest request)
        {
            try
            {
                var account = await _service.UpdateRole(request);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] UserAccountRequest request)
        {
            try
            {
                var account = await _service.CreateAccount(request);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
