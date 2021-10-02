using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.CaseItemRequest;
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

        public IPagedList<CaseItemModel> GetAllAdvisory(CaseItemModel flitter, int pageIndex,
           int pageSize, CaseItemSortBy sortBy, OrderBy order)
        {
            var listCaseItem = _res.FindBy(x => x.Status == (int)AdvisoryStatus.Active);

            var listCaseItemModel = (listCaseItem.ProjectTo<CaseItemModel>
                (_mapper.ConfigurationProvider)).DynamicFilter(flitter);
            switch (sortBy.ToString())
            {
                case "Name":
                    if (order.ToString() == "Asc")
                    {
                        listCaseItemModel = (IQueryable<CaseItemModel>)listCaseItemModel.OrderBy(x => x.Name);
                    }
                    else
                    {
                        listCaseItemModel = (IQueryable<CaseItemModel>)listCaseItemModel.OrderByDescending(x => x.Name);
                    }
                    break;
                case "EventDate":
                    if (order.ToString() == "Asc")
                    {
                        listCaseItemModel = (IQueryable<CaseItemModel>)listCaseItemModel.OrderBy(x => x.EventDate);
                    }
                    else
                    {
                        listCaseItemModel = (IQueryable<CaseItemModel>)listCaseItemModel.OrderByDescending(x => x.EventDate);
                    }
                    break;
                case "CreateDate":
                    if (order.ToString() == "Asc")
                    {
                        listCaseItemModel = (IQueryable<CaseItemModel>)listCaseItemModel.OrderBy(x => x.CreateDate);
                    }
                    else
                    {
                        listCaseItemModel = (IQueryable<CaseItemModel>)listCaseItemModel.OrderByDescending(x => x.CreateDate);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList<CaseItemModel>(listCaseItemModel, pageIndex, pageSize);
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


