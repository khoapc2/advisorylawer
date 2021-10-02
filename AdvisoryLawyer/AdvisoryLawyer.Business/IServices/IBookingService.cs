using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.AdvisoryRequest;
using AdvisoryLawyer.Business.Requests.BookingRequest;
using AdvisoryLawyer.Business.ViewModel;
using PagedList;
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
        IPagedList<BookingModel> GetAllAdvisory(BookingModel flitter, int pageIndex,
           int pageSize, BookingSortBy sortBy, OrderBy order);
        Task<BookingModel> CreateBooking(CreateBookingRequest request);
        Task<BookingModel> UpdateBooking(int id, UpdateBookingRequest request);
        Task<bool> DeleteBooking(int id);
    }
}
