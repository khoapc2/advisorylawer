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
        Task<BookingModel> GetBookingById(int id);
        Task<List<BookingModel>> GetAllBooking();
        Task<BookingModel> CreateBooking(CreateBookingRequest request);
        Task<BookingModel> UpdateBooking(int id, UpdateBookingRequest request);
        Task<bool> DeleteBooking(int id);
    }
}
