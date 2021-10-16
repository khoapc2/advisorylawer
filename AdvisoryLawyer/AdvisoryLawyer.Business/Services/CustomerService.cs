using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.CustomerRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PagedList;
using Reso.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _res;
        private readonly IMapper _mapper;
        public CustomerService(IGenericRepository<Customer> res, IMapper mapper)
        {
            _res = res;
            _mapper = mapper;
        }

        public async Task<CustomerModel> CreateCustomerModel(CreateCustomerModelRequest request)
        {
            var Customer = _mapper.Map<Customer>(request);
            await _res.InsertAsync(Customer);
            await _res.SaveAsync();
            return _mapper.Map<CustomerModel>(Customer);
        }

        public async Task<bool> DeleteCustomerModel(int id)
        {
            var Customer = (await _res.FindByAsync(x => x.Id == id && x.Status == (int)CustomerStatus.Active)).FirstOrDefault();
            if (Customer == null)
            {
                return false;
            }
            Customer.Status = 0;
            await _res.UpdateAsync(Customer);
            await _res.SaveAsync();
            return true;
        }

        public async Task<CustomerModel> GetCustomerModelById(int id)
        {
            var Customer = (await _res.FindByAsync(x => x.Id == id && x.Status == (int)CustomerStatus.Active)).FirstOrDefault();
            if (Customer == null)
                return null;
            var CustomerModel = _mapper.Map<CustomerModel>(Customer);
            var test = _mapper.Map<Customer>(CustomerModel);

            return CustomerModel;
        }

        public IPagedList<CustomerModel> GetAllAdvisory(CustomerModel flitter, int pageIndex,
           int pageSize, CustomerModelSortBy sortBy, OrderBy order)
        {
            var listCustomer = _res.FindBy(x => x.Status == (int)AdvisoryStatus.Active);

            var listCustomerModel = (listCustomer.ProjectTo<CustomerModel>
                (_mapper.ConfigurationProvider)).DynamicFilter(flitter);
            switch (sortBy.ToString())
            {
                case "Name":
                    if (order.ToString() == "Asc")
                    {
                        listCustomerModel = (IQueryable<CustomerModel>)listCustomerModel.OrderBy(x => x.Name);
                    }
                    else
                    {
                        listCustomerModel = (IQueryable<CustomerModel>)listCustomerModel.OrderByDescending(x => x.Name);
                    }
                    break;
                case "Address":
                    if (order.ToString() == "Asc")
                    {
                        listCustomerModel = (IQueryable<CustomerModel>)listCustomerModel.OrderBy(x => x.Address);
                    }
                    else
                    {
                        listCustomerModel = (IQueryable<CustomerModel>)listCustomerModel.OrderByDescending(x => x.Address);
                    }
                    break;
                case "Email":
                    if (order.ToString() == "Asc")
                    {
                        listCustomerModel = (IQueryable<CustomerModel>)listCustomerModel.OrderBy(x => x.Email);
                    }
                    else
                    {
                        listCustomerModel = (IQueryable<CustomerModel>)listCustomerModel.OrderByDescending(x => x.Email);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList<CustomerModel>(listCustomerModel, pageIndex, pageSize);
        }



        public async Task<CustomerModel> UpdateCustomerModel(int id, UpdateCustomerModelRequest request)
        {
            var listCustomer = await _res.FindByAsync(x => x.Id == id && x.Status == (int)CustomerStatus.Active);
            var Customer = listCustomer.FirstOrDefault();
            if (Customer == null)
            {
                return null;
            }
            Customer = _mapper.Map(request, Customer);
            await _res.UpdateAsync(Customer);
            await _res.SaveAsync();

            return _mapper.Map<CustomerModel>(Customer);
        }

        public async Task<CustomerModel> GetDetailByEmail(string email)
        {
            var customer = await _res.FindByAsync(x => x.Email.Equals(email));
            return _mapper.Map<CustomerModel>(customer);
        }
    }
}
