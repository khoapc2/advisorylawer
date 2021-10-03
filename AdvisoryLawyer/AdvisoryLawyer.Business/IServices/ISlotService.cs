using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.SlotRequest;
using AdvisoryLawyer.Business.ViewModel;
using PagedList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ISlotService
    {
        public Task<IPagedList<SlotModel>> GetAllSlot(SlotRequest request, SlotSortBy sortBy, OrderBy orderBy, int pageIndex, int pageSize);
        public Task<SlotModel> GetSlotByID(int id);
        public Task<SlotModel> CreateSlot(SlotRequest level);
        public Task<SlotModel> UpdateSlot(int id, SlotRequest level);
        public Task DeleteSlot(int id);
    }
}
