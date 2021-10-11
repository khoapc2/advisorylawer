using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.LevelRequest;
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
    public class LevelService : ILevelService
    {
        private readonly IGenericRepository<Level> _genericRepository;
        private readonly IMapper _mapper;

        public LevelService(IGenericRepository<Level> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<LevelModel> CreateLevel(LevelRequest level)
        {
            var newLevel = _mapper.Map<Level>(level);
            await _genericRepository.InsertAsync(newLevel);
            await _genericRepository.SaveAsync();
            return _mapper.Map<LevelModel>(newLevel);
        }

        public async Task DeleteLevel(int id)
        {
            await _genericRepository.DeleteAsync(id);
            await _genericRepository.SaveAsync();
        }

        public IPagedList<LevelModel> GetAllLevels(LevelRequest request, LevelSortBy sortBy, OrderBy orderBy, int pageIndex, int pageSize)
        {
            var levelList = _genericRepository.FindBy(l => l.Status == (int)LevelStatus.Active);
            if (levelList == null) return null;

            var levelModelList = levelList.ProjectTo<LevelModel>(_mapper.ConfigurationProvider).DynamicFilter(_mapper.Map<LevelModel>(request));

            switch (sortBy.ToString())
            {
                case "MinPrice":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        levelModelList = levelModelList.OrderBy(l => l.min_price);
                    }
                    else
                    {
                        levelModelList = levelModelList.OrderByDescending(l => l.min_price);
                    }
                    break;
                case "MaxPrice":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        levelModelList = levelModelList.OrderBy(l => l.max_price);
                    }
                    else
                    {
                        levelModelList = levelModelList.OrderByDescending(l => l.max_price);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList(levelModelList, pageIndex, pageSize);
        }

        public async Task<LevelModel> GetLevelByID(int id)
        {
            var level = await _genericRepository.GetByIDAsync(id);
            return _mapper.Map<LevelModel>(level);
        }

        public async Task<LevelModel> UpdateLevel(LevelRequest level)
        {
            var newLevel = _mapper.Map<Level>(level);
            await _genericRepository.UpdateAsync(newLevel);
            return _mapper.Map<LevelModel>(newLevel);
        }
    }
}
