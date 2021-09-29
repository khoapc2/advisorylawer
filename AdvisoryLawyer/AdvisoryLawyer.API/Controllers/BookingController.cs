using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.BookingRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingLawyer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;

        public BookingController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        [HttpGet("{id}", Name = "GetBookingById")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var BookingModel = await _BookingService.GetBookingById(id);
            if (BookingModel == null)
                return BadRequest();
            return Ok(BookingModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooking()
        {
            var listBookingModel = await _BookingService.GetAllBooking();
            return Ok(listBookingModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            var BookingModel = await _BookingService.CreateBooking(request);
            return CreatedAtRoute(nameof(GetBookingById), new { id = BookingModel.Id }, BookingModel
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingRequest request)
        {
            var BookingModel = await _BookingService.UpdateBooking(id, request);
            if (BookingModel == null)
                return BadRequest();
            return Ok(BookingModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var rs = await _BookingService.DeleteBooking(id);
            if (rs == false)
                return BadRequest();
            return Ok();
        }
    }
}
