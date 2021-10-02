
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Business.Requests.BookingRequest;
using AdvisoryLawyer.Business.Enum;
using PagedList;
using AdvisoryLawyer.Business.Requests;
using AutoMapper.QueryableExtensions;
using Reso.Core.Utilities;

namespace BookingLawyer.Business.Services
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

        public async Task<BookingModel> CreateBooking(CreateBookingRequest request)
        {
            var Booking = _mapper.Map<Booking>(request);
            await _res.InsertAsync(Booking);
            await _res.SaveAsync();
            return _mapper.Map<BookingModel>(Booking);
        }

        public async Task<bool> DeleteBooking(int id)
        {
            var Booking = (await _res.FindByAsync(x => x.Id == id && x.Status == (int)BookingStatus.Active)).FirstOrDefault();
            if (Booking == null)
            {
                return false;
            }
            Booking.Status = 0;
            await _res.UpdateAsync(Booking);
            await _res.SaveAsync();
            return true;
        }

        public async Task<BookingModel> GetBookingById(int id)
        {
            var Booking = (await _res.FindByAsync(x => x.Id == id && x.Status == (int)BookingStatus.Active)).FirstOrDefault();
            if (Booking == null)
                return null;
            var BookingModel = _mapper.Map<BookingModel>(Booking);
            var test = _mapper.Map<Booking>(BookingModel);

            return BookingModel;
        }

        public IPagedList<BookingModel> GetAllAdvisory(BookingModel flitter, int pageIndex,
           int pageSize, BookingSortBy sortBy, OrderBy order)
        {
            var listBooking = _res.FindBy(x => x.Status == (int)AdvisoryStatus.Active);

            var listBookingModel = (listBooking.ProjectTo<BookingModel>
                (_mapper.ConfigurationProvider)).DynamicFilter(flitter);
            switch (sortBy.ToString())
            {
                case "BookingDate":
                    if (order.ToString() == "Asc")
                    {
                        listBookingModel = (IQueryable<BookingModel>)listBookingModel.OrderBy(x => x.BookingDate);
                    }
                    else
                    {
                        listBookingModel = (IQueryable<BookingModel>)listBookingModel.OrderByDescending(x => x.BookingDate);
                    }
                    break;
                case "TotalPrice":
                    if (order.ToString() == "Asc")
                    {
                        listBookingModel = (IQueryable<BookingModel>)listBookingModel.OrderBy(x => x.TotalPrice);
                    }
                    else
                    {
                        listBookingModel = (IQueryable<BookingModel>)listBookingModel.OrderByDescending(x => x.TotalPrice);
                    }
                    break;
                case "PayDate":
                    if (order.ToString() == "Asc")
                    {
                        listBookingModel = (IQueryable<BookingModel>)listBookingModel.OrderBy(x => x.PayDate);
                    }
                    else
                    {
                        listBookingModel = (IQueryable<BookingModel>)listBookingModel.OrderByDescending(x => x.PayDate);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList<BookingModel>(listBookingModel, pageIndex, pageSize);
        }



        public async Task<BookingModel> UpdateBooking(int id, UpdateBookingRequest request)
        {
            var listBooking = await _res.FindByAsync(x => x.Id == id && x.Status == (int)BookingStatus.Active);
            var Booking = listBooking.FirstOrDefault();
            if (Booking == null)
            {
                return null;
            }
            Booking = _mapper.Map(request, Booking);
            await _res.UpdateAsync(Booking);
            await _res.SaveAsync();

            return _mapper.Map<BookingModel>(Booking);
        }
    }
}

