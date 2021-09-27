using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.SlotRequest;
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
    public class SlotService : ISlotService
    {
        private readonly IGenericRepository<Slot> _genericRepository;
        private readonly IMapper _mapper;

        public SlotService(IGenericRepository<Slot> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public SlotModel CreateSlot(SlotRequest slot)
        {
            var newSlot = _mapper.Map<Slot>(slot);
            _genericRepository.Insert(newSlot);
            _genericRepository.Save();
            return _mapper.Map<SlotModel>(newSlot);
        }

        public bool DeleteSlot(int id)
        {
            _genericRepository.Delete(id);
            _genericRepository.Save();
            return true;
        }

        public IEnumerable<SlotModel> GetAllSlot()
        {
            var slotList = _genericRepository.GetAll();
            if (slotList != null) return _mapper.Map<IEnumerable<SlotModel>>(slotList).ToList();
            return null;
        }

        public SlotModel GetSlotByID(int id)
        {
            var slot = _genericRepository.GetByID(id);
            return _mapper.Map<SlotModel>(slot);
        }

        public SlotModel UpdateSlot(int id, SlotRequest slot)
        {
            var newSlot = _mapper.Map<Slot>(slot);
            newSlot.Id = id;
            _genericRepository.Update(newSlot);
            _genericRepository.Save();
            return _mapper.Map<SlotModel>(newSlot);
        }
    }
}
