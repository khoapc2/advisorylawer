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
        CaseItemModel GetCaseItemById(int id);
        List<CaseItemModel> GetAllCaseItem();
        CaseItemModel CreateCaseItem(CreateCaseItemRequest request);
        CaseItemModel UpdateCaseItem(int id, UpdateCaseItemRequest request);
        bool DeleteCaseItem(int id);
    }
}
