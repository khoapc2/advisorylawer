using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.LawyerRequest;
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
    public class LawyerService : ILawyerService
    {
        private IGenericRepository<Lawyer> _genericRepository;
        private IMapper _mapper;

        public LawyerService(IGenericRepository<Lawyer> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<LawyerModel> CreateLawyer(LawyerRequest lawyerRequest)
        {
            var lawyer = _mapper.Map<Lawyer>(lawyerRequest);
            await _genericRepository.InsertAsync(lawyer);
            await _genericRepository.SaveAsync();

            return _mapper.Map<LawyerModel>(lawyer);
        }

        public async Task<bool> DeleteLawyer(int id)
        {
            var lawyer = await _genericRepository.FindAsync(x => x.Id == id &&
            x.Status == (int)LawyerStatus.Active);
            if (lawyer != null)
            {
                await _genericRepository.DeleteAsync(id);
                await _genericRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public IPagedList<LawyerModel> GetAllLawyers(LawyerRequest filter,
            LawyerSortBy sortBy, OrderBy order, int pageIndex, int pageSize)
        {
            var listLawyers = _genericRepository.FindBy(x => x.Status == (int)LawyerStatus.Active);
            var listLawyersModel = (listLawyers.ProjectTo<LawyerModel>
                (_mapper.ConfigurationProvider)).DynamicFilter(_mapper.Map<LawyerModel>(filter));
            switch (sortBy.ToString())
            {
                case "Name":
                    if ("Asc".Equals(order.ToString()))
                    {
                        listLawyersModel = listLawyersModel.OrderBy(x => x.Name);
                    }
                    else
                    {
                        listLawyersModel = listLawyersModel.OrderByDescending(x => x.Name);
                    }
                    break;
                case "Description":
                    if ("Asc".Equals(order.ToString()))
                    {
                        listLawyersModel = listLawyersModel.OrderBy(x => x.Description);
                    }
                    else
                    {
                        listLawyersModel = listLawyersModel.OrderByDescending(x => x.Description);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList(listLawyersModel, pageIndex, pageSize);
        }

        public async Task<LawyerModel> GetDetailByEmail(string email)
        {
            var lawyer = await _genericRepository.FindByAsync(x => x.Email.Equals(email));
            return _mapper.Map<LawyerModel>(lawyer);
        }

        public async Task<LawyerModel> GetLawyerById(int id)
        {
            var lawyer = await _genericRepository.FindAsync(x => x.Id == id &&
            x.Status == (int)LawyerStatus.Active);
            if (lawyer != null)
            {
                return _mapper.Map<LawyerModel>(lawyer);
            }
            return null;
        }

        public async Task RemoveLawyerOutOfOffice(int id)
        {
            var lawyer = await _genericRepository.FindAsync(x => x.Id == id);
            lawyer.LawyerOfficeId = null;
            await _genericRepository.UpdateAsync(lawyer);
        }

        public async Task<LawyerModel> UpdateLawyer(LawyerUpdate lawyerUpdate)
        {
            var lawyer = await _genericRepository.FindAsync(x => x.Id == lawyerUpdate.Id &&
            x.Status == (int)LawyerStatus.Active);
            if (lawyer != null)
            {
                lawyer = _mapper.Map(lawyerUpdate, lawyer);
                await _genericRepository.SaveAsync();
                return _mapper.Map<LawyerModel>(lawyer);
            }
            return null;
        }

        public async Task<LawyerModel> UpdateLevelForLawyer(UpdateLevelForLawyerRequest request)
        {
            var lawyer = await _genericRepository.FindAsync(x => x.Id == request.LawyerId);
            if (lawyer != null)
            {
                lawyer.LevelId = request.LevelId;
                await _genericRepository.UpdateAsync(lawyer);
                return _mapper.Map<LawyerModel>(lawyer);
            }
            return null;
        }
    }
}
