using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.CaseItemRequest;
using AdvisoryLawyer.Business.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ICaseItemService
    {
        Task<CaseItemModel> GetCaseItemById(int id);
        IPagedList<CaseItemModel> GetAllAdvisory(CaseItemModel flitter, int pageIndex,
           int pageSize, CaseItemSortBy sortBy, OrderBy order);
        Task<CaseItemModel> CreateCaseItem(CreateCaseItemRequest request);
        Task<CaseItemModel> UpdateCaseItem(int id, UpdateCaseItemRequest request);
        Task<bool> DeleteCaseItem(int id);
    }
}
