using AdvisoryLawyer.Business.Requests.CaseItemRequest;
using AdvisoryLawyer.Business.ViewModel;
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
        Task<List<CaseItemModel>> GetAllCaseItem();
        Task<CaseItemModel> CreateCaseItem(CreateCaseItemRequest request);
        Task<CaseItemModel> UpdateCaseItem(int id, UpdateCaseItemRequest request);
        Task<bool> DeleteCaseItem(int id);
    }
}
