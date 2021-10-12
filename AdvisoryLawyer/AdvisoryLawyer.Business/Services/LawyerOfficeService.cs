using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.LawyerOfficeRequest;
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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Services
{
    public class LawyerOfficeService : ILawyerOfficeService
    {
        private readonly IGenericRepository<LawyerOffice> _genericRepository;
        private readonly IMapper _mapper;
        public LawyerOfficeService(IGenericRepository<LawyerOffice> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
    }

        public async Task<LawyerOfficeModel> CreateLawyerOffice(LawyerOfficeRequest request)
        {
            var office = _mapper.Map<LawyerOffice>(request);
            await _genericRepository.InsertAsync(office);
            await _genericRepository.SaveAsync();
            return _mapper.Map<LawyerOfficeModel>(office);
        }

        public async Task DeleteLawyerOffice(int id)
        {
            var office = await _genericRepository.GetByIDAsync(id);
            office.Status = (int)LawyerOfficeStatus.Active;
            await _genericRepository.UpdateAsync(office);
        }

        public async Task<LawyerOfficeModel> GetLawyerOfficeByID(int id)
        {
            var lawyerOffice = await _genericRepository.GetByIDAsync(id);
            return _mapper.Map<LawyerOfficeModel>(lawyerOffice);
        }

        public IPagedList<LawyerOfficeModel> GetListLawyerOffice(LawyerOfficeRequest request, LawyerOfficeSortBy sortBy, OrderBy orderBy, int pageIndex, int pageSize)
        {
            var listLawyerOffice = _genericRepository.GetAllByIQueryable();
            if (listLawyerOffice == null) return null;

            var listLawyerOfficeModel = listLawyerOffice.ProjectTo<LawyerOfficeModel>(_mapper.ConfigurationProvider).DynamicFilter(_mapper.Map<LawyerOfficeModel>(request));

            switch (sortBy.ToString())
            {
                case "Name":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderBy(u => u.Name);
                    }
                    else
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderByDescending(u => u.Name);
                    }
                    break;
                case "Email":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderBy(u => u.Email);
                    }
                    else
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderByDescending(u => u.Email);
                    }
                    break;
                case "Address":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderBy(u => u.Address);
                    }
                    else
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderByDescending(u => u.Address);
                    }
                    break;
                case "Location":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderBy(u => u.Location);
                    }
                    else
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderByDescending(u => u.Location);
                    }
                    break;
                case "PhoneNumber":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderBy(u => u.PhoneNumber);
                    }
                    else
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderByDescending(u => u.PhoneNumber);
                    }
                    break;
                default:
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderBy(u => u.Id);
                    }
                    else
                    {
                        listLawyerOfficeModel = listLawyerOfficeModel.OrderByDescending(u => u.Id);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList(listLawyerOfficeModel, pageIndex, pageSize);
        }

        public async Task<LawyerOfficeModel> UpdateLawyerOffice(LawyerOfficeRequest request)
        {
            var office = _mapper.Map<LawyerOffice>(request);
            office.Id = request.Id;
            await _genericRepository.UpdateAsync(office);
            return _mapper.Map<LawyerOfficeModel>(office);
        }
    }
}
