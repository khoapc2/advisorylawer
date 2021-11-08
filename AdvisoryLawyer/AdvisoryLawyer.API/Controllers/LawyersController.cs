using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.LawyerOfficeRequest;
using AdvisoryLawyer.Business.Requests.LawyerRequest;
using AdvisoryLawyer.Business.Services;
using AdvisoryLawyer.Business.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/v1/lawyers")]
    [ApiController]
    public class LawyersController : ControllerBase
    {
        private readonly ILawyerService _service;
        private readonly IUserAccountService _userAccountService;
        private readonly IAgoraService _agoraService;

        public LawyersController(ILawyerService service, IUserAccountService userAccountService, IAgoraService agoraService)
        {
            _service = service;
            _userAccountService = userAccountService;
            _agoraService = agoraService;
        }

        //GET api/lawyers
        [HttpGet]
        public ActionResult<IEnumerable<LawyerModel>> GetAllLawyers([FromQuery] LawyerRequest filter, LawyerSortBy sort_by,
            OrderBy order_by, int page_index = 1, int page_size = 1)
        {
            try
            {
                var lawyers = _service.GetAllLawyers(filter, sort_by, order_by, page_index, page_size);
                if (lawyers != null)
                {
                    return Ok(lawyers);
                }
                return NoContent();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //GET api/lawyers/{id}
        [HttpGet("{id}", Name = "GetLawyerById")]
        public async Task<ActionResult<LawyerModel>> GetLawyerById(int id)
        {
            try
            {
                var lawyerModel = await _service.GetLawyerById(id);
                if (lawyerModel == null)
                {
                    return BadRequest();
                }
                return Ok(lawyerModel);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //POST api/lawyers
        [HttpPost]
        public async Task<ActionResult<LawyerModel>> CreateLawyer([FromBody] LawyerRequest lawyerRequest)
        {
            try
            {
                var lawyerModel = await _service.CreateLawyer(lawyerRequest);
                if (lawyerModel != null)
                {
                    return CreatedAtRoute(nameof(GetLawyerById)
                        , new { Id = lawyerModel.Id }, lawyerModel);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //PUT api/lawyers/{id}
        [HttpPut("update-lawyer")]
        public async Task<ActionResult<LawyerModel>> UpdateLawyer([FromBody] LawyerUpdate lawyerUpdate)
        {
            try
            {
                var lawyerModel = await _service.UpdateLawyer(lawyerUpdate);
                if (lawyerModel != null)
                {
                    return Ok(lawyerModel);
                }
                return BadRequest();
            }
            catch (Exception e) { return BadRequest(); }
        }

        //DELETE api/lawyers/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLawyer(int id)
        {
            try
            {
                bool deleteStatus = await _service.DeleteLawyer(id);
                if (deleteStatus)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("details")]
        public async Task<IActionResult> GetDetailByEmail([FromBody] EmailRequest request)
        {
            try
            {
                var lawyer = await _service.GetDetailByEmail(request.Email);
                return Ok(lawyer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("remove-out-of-office")]
        public async Task<IActionResult> RemoveLawyerOutOfOffice([FromBody] ID request)
        {
            try
            {
                await _service.RemoveLawyerOutOfOffice(request.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpPut("update-category-lawyer")]
        public async Task<IActionResult> UpdateCategoryLawyer([FromBody] LawyerCategoryUpdate request)
        {
            var categoryLawyer = await _service.UpdateCategoryLawyer(request);
            if (categoryLawyer == null)
            {
                return BadRequest();
            }
            return Ok(categoryLawyer);
        }

        [HttpPut("update-level")]
        public async Task<IActionResult> UpdateLevelForLawyer([FromBody] UpdateLevelForLawyerRequest request)
        {
            try
            {
                var lawyer = await _service.UpdateLevelForLawyer(request);
                if (lawyer != null) {

                    // send Firebase messaging
                    var userAccount = await _userAccountService.GetAccountByEmail(lawyer.Email);
                    var uid = userAccount.Uid;
                    var channelModel = await _agoraService.GetChannalByBookingID(1);
                    var channelName = channelModel.ChannelName;
                    string response = await SendFirebaseMessaging
                        .SendNotification(uid, "Văn phòng đã cập nhật thông tin của bạn",
                             "Bạn được cập nhật level", channelName);
                    //

                    return Ok(lawyer); 
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("add-to-office")]
        public async Task<IActionResult> AddLawyerToOffice([FromBody] AddLawyerToOfficeRequest request)
        {
            try
            {
                var lawyer = await _service.AddLawyerToOffice(request);
                if (lawyer != null) return Ok(lawyer);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
