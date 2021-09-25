using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.AdvisoryRequest;
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

        public AdvisoryModel CreateAdvisory(CreateAdvisoryRequest request)
        {
            var advisory= _mapper.Map<Advisory>(request);
            _res.Insert(advisory);
            _res.Save();
            return _mapper.Map<AdvisoryModel>(advisory); 
        }

        public bool DeleteAdvisory(int id)
        {
            if(GetAdvisoryById(id) == null)
            {
                return false;
            }
            _res.Delete(id);
            _res.Save();
            return true;
        }

        public AdvisoryModel GetAdvisoryById(int id)
        {
            var advisory = _res.GetByID(id);
            if (advisory == null)
                return null;
            var advisoryModel = _mapper.Map<AdvisoryModel>(advisory);
            var test = _mapper.Map<Advisory>(advisoryModel);

            return advisoryModel;
        }

        public List<AdvisoryModel> GetAllAdvisory()
        {
            var listAdvisory = _res.GetAll();
            var listAdvisoryModel = _mapper.Map<IEnumerable<AdvisoryModel>>(listAdvisory).ToList();
            return listAdvisoryModel;
        }

      

        public AdvisoryModel UpdateAdvisory(int id, UpdateAdvisoryRequest request)
        {
            var advisory = _res.GetByID(id);
            if (advisory == null)
            {
                return null;
            }
            advisory = _mapper.Map(request , advisory);
            _res.Update(advisory);
            _res.Save();

            return _mapper.Map<AdvisoryModel>(advisory);
        }


    }
}
