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

        public CaseItemModel CreateCaseItem(CreateCaseItemRequest request)
        {
            var caseItem = _mapper.Map<CaseItem>(request);
            _res.Insert(caseItem);
            _res.Save();
            return _mapper.Map<CaseItemModel>(caseItem);
        }

        public bool DeleteCaseItem(int id)
        {
            if (GetCaseItemById(id) == null)
            {
                return false;
            }
            _res.Delete(id);
            _res.Save();
            return true;
        }

        public CaseItemModel GetCaseItemById(int id)
        {
            var caseItem = _res.GetByID(id);
            if (caseItem == null)
                return null;
            var caseItemModel = _mapper.Map<CaseItemModel>(caseItem);

            return caseItemModel;
        }

        public List<CaseItemModel> GetAllCaseItem()
        {
            var listCaseItem = _res.GetAll();
            var listAdvisoryModel = _mapper.Map<IEnumerable<CaseItemModel>>(listCaseItem).ToList();
            return listAdvisoryModel;
        }

        public CaseItemModel UpdateCaseItem(int id, UpdateCaseItemRequest request)
        {
            var caseItem = _res.GetByID(id);
            if (caseItem == null)
            {
                return null;
            }
            caseItem = _mapper.Map(request, caseItem);
            _res.Update(caseItem);
            _res.Save();

            return _mapper.Map<CaseItemModel>(caseItem);
        }
    }
}

