using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.BookingRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{id}", Name = "GetBookingById")]
        public IActionResult GetBookingById(int id)
        {
            var bookingModel = _bookingService.GetBookingById(id);
            if (bookingModel == null)
                return BadRequest();
            return Ok(bookingModel);
        }

        [HttpGet]
        public IActionResult GetAllBooking()
        {
            var listBookingModel = _bookingService.GetAllBooking();
            return Ok(listBookingModel);
        }

        [HttpPost]
        public IActionResult CreateAdvisory([FromBody] CreateBookingRequest request)
        {
            var BookingModel = _bookingService.CreateBooking(request);
            return CreatedAtRoute(nameof(GetBookingById), new { id = BookingModel.Id }, BookingModel
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int id, [FromBody] UpdateBookingRequest request)
        {
            var BookingModel = _bookingService.UpdateBooking(id, request);
            if (BookingModel == null)
                return BadRequest();
            return Ok(BookingModel);
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var rs = _bookingService.DeleteBooking(id);
            if (rs == false)
                return BadRequest();
            return Ok();
        }
    }
}
