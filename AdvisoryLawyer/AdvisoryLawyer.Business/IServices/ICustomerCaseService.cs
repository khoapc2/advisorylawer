using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.CustomerCaseRequest;
using AdvisoryLawyer.Business.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ICustomerCaseService
    {
        IPagedList<CustomerCaseModel> GetAllCustomerCases(CustomerCaseRequest filter,
            CustomerCaseSortBy sortBy, OrderBy order, int pageIndex, int pageSize);
        Task<CustomerCaseModel> GetCustomerCaseById(int id);
        Task<CustomerCaseModel> CreateCustomerCase(CustomerCaseRequest categoryRequest);
        Task<CustomerCaseModel> UpdateCustomerCase(int id, CustomerCaseRequest categoryRequest);
        Task<bool> DeleteCustomerCase(int id);
    }
}
