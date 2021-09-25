using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.BookingRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Services
{
    public class BookingService  : IBookingService
    {
        private readonly IGenericRepository<Booking> _res;
        private readonly IMapper _mapper;
        public BookingService(IGenericRepository<Booking> res, IMapper mapper)
        {
            _res = res;
            _mapper = mapper;
        }

        public BookingModel CreateBooking(CreateBookingRequest request)
        {
            var booking = _mapper.Map<Booking>(request);
            _res.Insert(booking);
            _res.Save();
            return _mapper.Map<BookingModel>(booking);
        }

        public bool DeleteBooking(int id)
        {
            if (GetBookingById(id) == null)
            {
                return false;
            }
            _res.Delete(id);
            _res.Save();
            return true;
        }

        public BookingModel GetBookingById(int id)
        {
            var booking = _res.GetByID(id);
            if (booking == null)
                return null;
            var bookingModel = _mapper.Map<BookingModel>(booking);
            return bookingModel;
        }

        public List<BookingModel> GetAllBooking()
        {
            var listBooking = _res.GetAll();
            var listBookingModel = _mapper.Map<IEnumerable<BookingModel>>(listBooking).ToList();
            return listBookingModel;
        }



        public BookingModel UpdateBooking(int id, UpdateBookingRequest request)
        {
            var booking = _res.GetByID(id);
            if (booking == null)
            {
                return null;
            }
            booking = _mapper.Map(request, booking);
            _res.Update(booking);
            _res.Save();

            return _mapper.Map<BookingModel>(booking);
        }


    }
}

