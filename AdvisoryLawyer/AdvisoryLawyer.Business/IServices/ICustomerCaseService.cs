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
        IEnumerable<CustomerCaseModel> GetAllCustomerCases();
        CustomerCaseModel GetCustomerCaseById(int id);
        CustomerCaseModel CreateCustomerCase(CustomerCaseRequest categoryRequest);
        CustomerCaseModel UpdateCustomerCase(int id, CustomerCaseRequest categoryRequest);
        bool DeleteCustomerCase(int id);
    }
}
