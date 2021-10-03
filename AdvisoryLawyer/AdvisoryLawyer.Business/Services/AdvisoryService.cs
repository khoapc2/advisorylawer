using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.AdvisoryRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AdvisoryLawyer.Data.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Reso.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Linq.Dynamic.Core;
using AdvisoryLawyer.Business.Requests;

namespace AdvisoryLawyer.Business.Services
{
    public class AdvisoryService : IAdvisoryService
    {
        private readonly IGenericRepository<Advisory> _res;
        private readonly IMapper _mapper;
        public AdvisoryService(IGenericRepository<Advisory> res, IMapper mapper)
        {
            _res = res;
            _mapper = mapper;
        }

        public async Task<AdvisoryModel> CreateAdvisory(CreateAdvisoryRequest request)
        {
            var advisory= _mapper.Map<Advisory>(request);
            await _res.InsertAsync(advisory);
            await _res.SaveAsync();
            return _mapper.Map<AdvisoryModel>(advisory); 
        }

        public async Task<bool> DeleteAdvisory(int id)
        {
            var advisory = (await _res.FindAsync(x => x.Id == id && x.Status == (int)AdvisoryStatus.Active));
            if (advisory == null)
            {
                return false;
            }
            advisory.Status = 0;
            await _res.UpdateAsync(advisory);
            await _res.SaveAsync();
            return true;
        }

        public async Task<AdvisoryModel> GetAdvisoryById(int id)
        {
            var advisory = await _res.FindAsync(x => x.Id == id && x.Status == (int)AdvisoryStatus.Active);
            if (advisory == null)
                return null;
            var advisoryModel = _mapper.Map<AdvisoryModel>(advisory);
            var test = _mapper.Map<Advisory>(advisoryModel);

            return advisoryModel;
        }

        public IPagedList<AdvisoryModel> GetAllAdvisory(AdvisoryModel flitter, int pageIndex,
            int pageSize, AdvisorySortBy sortBy, OrderBy order)
        {
            var listAdvisory =  _res.FindBy(x => x.Status == (int)AdvisoryStatus.Active);
          
            var listAdvisoryModel = (listAdvisory.ProjectTo<AdvisoryModel>
                (_mapper.ConfigurationProvider)).DynamicFilter(flitter);
            switch (sortBy.ToString())
            {
                case "QuestionAnswer":
                    if (order.ToString() == "Asc")
                    {
                        listAdvisoryModel = (IQueryable<AdvisoryModel>)listAdvisoryModel.OrderBy(x => x.QuestionAnswer);
                    }
                    else
                    {
                        listAdvisoryModel = (IQueryable<AdvisoryModel>)listAdvisoryModel.OrderByDescending(x => x.QuestionAnswer);
                    }
                    break;
                case "StartAdvisory":
                    if (order.ToString() == "Asc")
                    {
                        listAdvisoryModel = (IQueryable<AdvisoryModel>)listAdvisoryModel.OrderBy(x => x.StartAdvisory);
                    }
                    else
                    {
                        listAdvisoryModel = (IQueryable<AdvisoryModel>)listAdvisoryModel.OrderByDescending(x => x.StartAdvisory);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList<AdvisoryModel>(listAdvisoryModel, pageIndex, pageSize);
        }



        public async Task<AdvisoryModel> UpdateAdvisory(int id, UpdateAdvisoryRequest request)
        {
            var advisory = await _res.FindAsync(x => x.Id == id && x.Status == (int)AdvisoryStatus.Active);
            if (advisory == null)
            {
                return null;
            }
            advisory = _mapper.Map(request , advisory);
            await _res.UpdateAsync(advisory);
            await _res.SaveAsync();

            return _mapper.Map<AdvisoryModel>(advisory);
        }


    }
}
