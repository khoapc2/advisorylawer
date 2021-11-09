using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.AgoraRequest;
using AdvisoryLawyer.Business.Services;
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
        private readonly IBookingService _bookingService;
        private readonly ILawyerService _lawyerService;
        private readonly IUserAccountService _userAccountService;
        private readonly ICustomerService _customerService;

        public AgoraController(IAgoraService service, ICustomerService customerService,
                                    ILawyerService lawyerService, IUserAccountService userAccountService, IBookingService bookingService)
        {
            _service = service;
            _bookingService = bookingService;
            _customerService = customerService;
            _lawyerService = lawyerService;
            _userAccountService = userAccountService;
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

        //[Authorize]
        [HttpPost("call")]
        public async Task<IActionResult> GetChannelByBookingID([FromBody] CallRequest callRequest)
        {
            try
            {
                var channelModel = await _service.GetChannalByBookingID(callRequest.BookingID);             
                var channelName = channelModel.ChannelName;

                var bookingModel = await _bookingService.GetBookingById(callRequest.BookingID);
                var role = callRequest.Role;
                var uid = "";
                var name = "";
                var lawyerID = bookingModel.LawyerId;
                var lawyer = await _lawyerService.GetLawyerById(lawyerID);
                var customerID = bookingModel.CustomerId;
                var customer = await _customerService.GetCustomerModelById(customerID);
                if (role == "customer")
                {
                    name = customer.Name;
                    var userAccount = await _userAccountService.GetAccountByEmail(lawyer.Email);
                    uid = userAccount.Uid;
                }
                else
                {
                    name = lawyer.Name;                  
                    var userAccount = await _userAccountService.GetAccountByEmail(customer.Email);                   
                    uid = userAccount.Uid;
                }

                // send Firebase messaging               
                string response = await SendFirebaseMessaging
                    .SendNotification(uid, name + " call you",
                         "Click to entry room", channelName);
                //
                return Ok(channelName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
