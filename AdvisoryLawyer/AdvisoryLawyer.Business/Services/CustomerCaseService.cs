using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.CustomerCaseRequest;
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
            var customerCase = await _genericRepository.GetByIDAsync(id);
            if (customerCase != null)
            {
                await _genericRepository.DeleteAsync(id);
                await _genericRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CustomerCaseModel>> GetAllCustomerCases()
        {
            var customerCases = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerCaseModel>>(customerCases);
        }

        public async Task<CustomerCaseModel> GetCustomerCaseById(int id)
        {
            var customerCase = await _genericRepository.GetByIDAsync(id);
            if (customerCase != null)
            {
                return _mapper.Map<CustomerCaseModel>(customerCase);
            }
            return null;
        }

        public async Task<CustomerCaseModel> UpdateCustomerCase(int id, CustomerCaseRequest customerCaseRequest)
        {
            var customerCase = await _genericRepository.GetByIDAsync(id);
            if (customerCase != null)
            {
                customerCase = _mapper.Map(customerCaseRequest, customerCase);
                await _genericRepository.SaveAsync();
                return _mapper.Map<CustomerCaseModel>(customerCase);
            }
            return null;
        }
    }
}
