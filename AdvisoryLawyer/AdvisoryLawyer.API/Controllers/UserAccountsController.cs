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
                await _service.ChangeAccountStatus(id);
                return Ok();
            }
            catch (Exception ex)
            {
                //logging
                return BadRequest(ex.Message);
            }
        }


    }
}
