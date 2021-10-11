using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.CustomerRequest;
using AdvisoryLawyer.Business.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ICustomerService
    {
        Task<CustomerModel> GetCustomerModelById(int id);
        IPagedList<CustomerModel> GetAllAdvisory(CustomerModel flitter, int pageIndex,
           int pageSize, CustomerModelSortBy sortBy, OrderBy order);
        Task<CustomerModel> CreateCustomerModel(CreateCustomerModelRequest request);
        Task<CustomerModel> UpdateCustomerModel(int id, UpdateCustomerModelRequest request);
        Task<bool> DeleteCustomerModel(int id);
    }
}
