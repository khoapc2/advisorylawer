using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AdvisoryLawyer.Data.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public AdvisoryModel GetAdvisoryById(int id)
        {
            var advisory = _res.GetByID(id);
            var advisoryModel = _mapper.Map<AdvisoryModel>(advisory);
            return advisoryModel;
        }

        public List<AdvisoryModel> GetAllAdvisory()
        {
            var listAdvisory = _res.GetAllByIQueryable();
            var listAdvisoryModel = listAdvisory.ProjectTo<AdvisoryModel>(_mapper.ConfigurationProvider).ToList();
            return listAdvisoryModel;
        }
    }
}
