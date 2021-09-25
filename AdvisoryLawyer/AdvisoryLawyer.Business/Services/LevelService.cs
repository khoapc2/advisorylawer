using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.LevelRequest;
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
    public class LevelService : ILevelService
    {
        private readonly IGenericRepository<Level> _genericRepository;
        private readonly IMapper _mapper;

        public LevelService(IGenericRepository<Level> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public LevelModel CreateLevel(LevelRequest level)
        {
            try
            {
                var newLevel = _mapper.Map<Level>(level);
                _genericRepository.Insert(newLevel);
                _genericRepository.Save();
                return _mapper.Map<LevelModel>(newLevel);
            }
            catch (Exception ex)
            {
                //logging
                return null;
            }
        }

        public bool DeleteLevel(int id)
        {
            try
            {
                _genericRepository.Delete(id);
                _genericRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public IEnumerable<LevelModel> GetAllLevels()
        {
            try
            {
                var levelList = _genericRepository.GetAll();
                if(levelList != null)
                {
                    return _mapper.Map<IEnumerable<LevelModel>>(levelList).ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                //logging
                return null;
            }
        }

        public LevelModel GetLevelByID(int id)
        {
            try
            {
                var level = _genericRepository.GetByID(id);
                return _mapper.Map<LevelModel>(level);
            }
            catch (Exception ex) 
            {
                //logging
                return null;
            }
        }

        public LevelModel UpdateLevel(int id, LevelRequest level)
        {
            try
            {
                var newLevel = _mapper.Map<Level>(level);
                newLevel.Id = id;
                _genericRepository.Update(newLevel);
                _genericRepository.Save();
                return _mapper.Map<LevelModel>(newLevel);
            }
            catch (Exception ex)
            {
                //logging
                return null;
            }
        }
    }
}
