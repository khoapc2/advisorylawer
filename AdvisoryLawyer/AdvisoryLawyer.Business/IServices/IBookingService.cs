using AdvisoryLawyer.Business.Requests.AdvisoryRequest;
using AdvisoryLawyer.Business.Requests.BookingRequest;
using AdvisoryLawyer.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface IBookingService
    {
        BookingModel GetBookingById(int id);
        List<BookingModel> GetAllBooking();
        BookingModel CreateBooking(CreateBookingRequest request);
        BookingModel UpdateBooking(int id, UpdateBookingRequest request);
        bool DeleteBooking(int id);
    }
}
