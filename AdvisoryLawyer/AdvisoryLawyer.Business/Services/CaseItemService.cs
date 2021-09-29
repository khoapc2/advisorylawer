using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.CaseItemRequest;
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
    public class CaseItemService : ICaseItemService
    {
        private readonly IGenericRepository<CaseItem> _res;
        private readonly IMapper _mapper;
        public CaseItemService(IGenericRepository<CaseItem> res, IMapper mapper)
        {
            _res = res;
            _mapper = mapper;
        }

        public async Task<CaseItemModel> CreateCaseItem(CreateCaseItemRequest request)
        {
            var CaseItem = _mapper.Map<CaseItem>(request);
            await _res.InsertAsync(CaseItem);
            await _res.SaveAsync();
            return _mapper.Map<CaseItemModel>(CaseItem);
        }

        public async Task<bool> DeleteCaseItem(int id)
        {
            var CaseItem = (await _res.FindByAsync(x => x.Id == id && x.Status == (int)CaseItemStatus.Active)).FirstOrDefault();
            if (CaseItem == null)
            {
                return false;
            }
            CaseItem.Status = 0;
            await _res.UpdateAsync(CaseItem);
            await _res.SaveAsync();
            return true;
        }

        public async Task<CaseItemModel> GetCaseItemById(int id)
        {
            var CaseItem = (await _res.FindByAsync(x => x.Id == id && x.Status == (int)CaseItemStatus.Active)).FirstOrDefault();
            if (CaseItem == null)
                return null;
            var CaseItemModel = _mapper.Map<CaseItemModel>(CaseItem);
            var test = _mapper.Map<CaseItem>(CaseItemModel);

            return CaseItemModel;
        }

        public async Task<List<CaseItemModel>> GetAllCaseItem()
        {
            var listCaseItem = await _res.FindByAsync(x => x.Status == (int)CaseItemStatus.Active);
            var listCaseItemModel = _mapper.Map<IEnumerable<CaseItemModel>>(listCaseItem).ToList();
            return listCaseItemModel;
        }



        public async Task<CaseItemModel> UpdateCaseItem(int id, UpdateCaseItemRequest request)
        {
            var listCaseItem = await _res.FindByAsync(x => x.Id == id && x.Status == (int)CaseItemStatus.Active);
            var CaseItem = listCaseItem.FirstOrDefault();
            if (CaseItem == null)
            {
                return null;
            }
            CaseItem = _mapper.Map(request, CaseItem);
            await _res.UpdateAsync(CaseItem);
            await _res.SaveAsync();

            return _mapper.Map<CaseItemModel>(CaseItem);
        }


    }
}


