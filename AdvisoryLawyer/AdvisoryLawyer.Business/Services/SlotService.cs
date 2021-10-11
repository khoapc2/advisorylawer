using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.SlotRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PagedList;
using Reso.Core.Utilities;
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

        public async Task<SlotModel> CreateSlot(SlotRequest slot)
        {
            var newSlot = _mapper.Map<Slot>(slot);
            await _genericRepository.InsertAsync(newSlot);
            await _genericRepository.SaveAsync();
            return _mapper.Map<SlotModel>(newSlot);
        }

        public async Task DeleteSlot(int id)
        {
            await _genericRepository.DeleteAsync(id);
            await _genericRepository.SaveAsync();
        }

        public IPagedList<SlotModel> GetAllSlot(SlotRequest request, SlotSortBy sortBy, OrderBy orderBy, int pageIndex, int pageSize)
        {
            var slotList = _genericRepository.FindBy(s => s.Status == (int)SlotStatus.Active);
            if (slotList == null) return null;

            var slotModelList = slotList.ProjectTo<SlotModel>(_mapper.ConfigurationProvider).DynamicFilter(_mapper.Map<SlotModel>(request));

            switch (sortBy.ToString())
            {
                case "StartAt":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        slotModelList = slotModelList.OrderBy(s => s.start_at);
                    }
                    else
                    {
                        slotModelList = slotModelList.OrderByDescending(s => s.start_at);
                    }
                    break;
                case "EndAt":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        slotModelList = slotModelList.OrderBy(s => s.end_at);
                    }
                    else
                    {
                        slotModelList = slotModelList.OrderByDescending(s => s.end_at);
                    }
                    break;
                case "Price":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        slotModelList = slotModelList.OrderBy(s => s.price);
                    }
                    else
                    {
                        slotModelList = slotModelList.OrderByDescending(s => s.price);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList(slotModelList, pageIndex, pageSize);
        }

        public async Task<SlotModel> GetSlotByID(int id)
        {
            var slot = await _genericRepository.GetByIDAsync(id);
            return _mapper.Map<SlotModel>(slot);
        }

        public async Task<SlotModel> UpdateSlot(SlotRequest slot)
        {
            var newSlot = _mapper.Map<Slot>(slot);
            await _genericRepository.UpdateAsync(newSlot);
            return _mapper.Map<SlotModel>(newSlot);
        }
    }
}
