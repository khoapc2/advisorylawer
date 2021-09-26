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
        public CustomerCaseModel CreateCustomerCase(CustomerCaseRequest customerCaseRequest)
        {
            var customerCase = _mapper.Map<CustomerCase>(customerCaseRequest);
            _genericRepository.Insert(customerCase);
            _genericRepository.Save();

            return _mapper.Map<CustomerCaseModel>(customerCase);
        }

        public bool DeleteCustomerCase(int id)
        {
            var customerCase = _genericRepository.GetByID(id);
            if (customerCase != null)
            {
                _genericRepository.Delete(id);
                _genericRepository.Save();
                return true;
            }
            return false;
        }

        public IEnumerable<CustomerCaseModel> GetAllCustomerCases()
        {
            var customerCases = _genericRepository.GetAll();
            return _mapper.Map<IEnumerable<CustomerCaseModel>>(customerCases);
        }

        public CustomerCaseModel GetCustomerCaseById(int id)
        {
            var customerCase = _genericRepository.GetByID(id);
            if (customerCase != null)
            {
                return _mapper.Map<CustomerCaseModel>(customerCase);
            }
            return null;
        }

        public CustomerCaseModel UpdateCustomerCase(int id, CustomerCaseRequest customerCaseRequest)
        {
            var customerCase = _genericRepository.GetByID(id);
            if (customerCase != null)
            {
                customerCase = _mapper.Map(customerCaseRequest, customerCase);
                _genericRepository.Save();
                return _mapper.Map<CustomerCaseModel>(customerCase);
            }
            return null;
        }
    }
}
