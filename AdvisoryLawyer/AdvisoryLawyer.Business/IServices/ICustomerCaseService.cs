using AdvisoryLawyer.Business.Requests.CustomerCaseRequest;
using AdvisoryLawyer.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ICustomerCaseService
    {
        Task<IEnumerable<CustomerCaseModel>> GetAllCustomerCases();
        Task<CustomerCaseModel> GetCustomerCaseById(int id);
        Task<CustomerCaseModel> CreateCustomerCase(CustomerCaseRequest categoryRequest);
        Task<CustomerCaseModel> UpdateCustomerCase(int id, CustomerCaseRequest categoryRequest);
        Task<bool> DeleteCustomerCase(int id);
    }
}
