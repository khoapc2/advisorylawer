using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.CategoryRequest;
using AdvisoryLawyer.Business.Requests.CustomerCaseRequest;
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
    public class CustomerCaseService : ICustomerCaseService
    {
        private IGenericRepository<CustomerCase> _genericRepository;
        private IMapper _mapper;

        public CustomerCaseService(IGenericRepository<CustomerCase> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<CustomerCaseModel> CreateCustomerCase(CustomerCaseRequest customerCaseRequest)
        {
            var customerCase = _mapper.Map<CustomerCase>(customerCaseRequest);
            await _genericRepository.InsertAsync(customerCase);
            await _genericRepository.SaveAsync();

            return _mapper.Map<CustomerCaseModel>(customerCase);
        }

        public async Task<bool> DeleteCustomerCase(int id)
        {
            var customerCase = await _genericRepository.FindAsync(x => x.Id == id &&
            x.Status == (int)CustomerCaseStatus.Active);
            if (customerCase != null)
            {
                await _genericRepository.DeleteAsync(id);
                await _genericRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public IPagedList<CustomerCaseModel> GetAllCustomerCases(CustomerCaseRequest filter,
            CustomerCaseSortBy sortBy, OrderBy order, int pageIndex, int pageSize)
        {
            var listCustomerCases = _genericRepository.FindBy(x => x.Status == (int)CustomerCaseStatus.Active);
            var listCustomerCasesModel = (listCustomerCases.ProjectTo<CustomerCaseModel>
                (_mapper.ConfigurationProvider)).DynamicFilter(_mapper.Map<CustomerCaseModel>(filter));
            switch (sortBy.ToString())
            {
                case "Name":
                    if ("Asc".Equals(order.ToString()))
                    {
                        listCustomerCasesModel = listCustomerCasesModel.OrderBy(x => x.Name);
                    }
                    else
                    {
                        listCustomerCasesModel = listCustomerCasesModel.OrderByDescending(x => x.Name);
                    }
                    break;
                case "Description":
                    if ("Asc".Equals(order.ToString()))
                    {
                        listCustomerCasesModel = listCustomerCasesModel.OrderBy(x => x.Description);
                    }
                    else
                    {
                        listCustomerCasesModel = listCustomerCasesModel.OrderByDescending(x => x.Description);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList(listCustomerCasesModel, pageIndex, pageSize);
        }

        public async Task<CustomerCaseModel> GetCustomerCaseById(int id)
        {
            var customerCase = await _genericRepository.FindAsync(x => x.Id == id &&
            x.Status == (int)CustomerCaseStatus.Active);
            if (customerCase != null)
            {
                return _mapper.Map<CustomerCaseModel>(customerCase);
            }
            return null;
        }

        public async Task<CustomerCaseModel> UpdateCustomerCase(CustomerCaseUpdate customerCaseUpdate)
        {
            var customerCase = await _genericRepository.FindAsync(x => x.Id == customerCaseUpdate.Id &&
            x.Status == (int)CustomerCaseStatus.Active);
            if (customerCase != null)
            {
                customerCase = _mapper.Map(customerCaseUpdate, customerCase);
                await _genericRepository.SaveAsync();
                return _mapper.Map<CustomerCaseModel>(customerCase);
            }
            return null;
        }
    }
}
