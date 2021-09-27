using AdvisoryLawyer.Business.Requests.SlotRequest;
using AdvisoryLawyer.Business.ViewModel;
using System.Collections.Generic;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ISlotService
    {
        public IEnumerable<SlotModel> GetAllSlot();
        public SlotModel GetSlotByID(int id);
        public SlotModel CreateSlot(SlotRequest level);
        public SlotModel UpdateSlot(int id, SlotRequest level);
        public bool DeleteSlot(int id);
    }
}
