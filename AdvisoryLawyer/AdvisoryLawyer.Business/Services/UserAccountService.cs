using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using PagedList;
using AdvisoryLawyer.Business.Requests.UserAccountsRequest;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Enum;
using AutoMapper.QueryableExtensions;
using Reso.Core.Utilities;
using AdvisoryLawyer.Business.Requests.CustomerRequest;
using AdvisoryLawyer.Business.Requests.LawyerRequest;
using AdvisoryLawyer.Business.Requests.LawyerOfficeRequest;

namespace AdvisoryLawyer.Business.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IGenericRepository<UserAccount> _genericRepository;
        private readonly IMapper _mapper;
        private readonly ILawyerOfficeService _lawyerOfficeService;
        private readonly ILawyerService _lawyerService;
        private readonly ICustomerService _customerService;

        public UserAccountService(IGenericRepository<UserAccount> genericRepository, IMapper mapper,
            ILawyerOfficeService lawyerOfficeService, ILawyerService lawyerService, ICustomerService customerService)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _lawyerOfficeService = lawyerOfficeService;
            _lawyerService = lawyerService;
            _customerService = customerService;
        }

        public async Task<UserAccountModel> CheckGmail(string email, string fullname)
        {
            var account = await _genericRepository.FindAsync(u => u.Email.Equals(email));
            if (account == null)
            {
                var newAccount = new UserAccount
                {
                    Email = email,
                    Name = fullname,
                    Role = "undefined",
                    Status = 1
                };
                await _genericRepository.InsertAsync(newAccount);
                await _genericRepository.SaveAsync();
                return _mapper.Map<UserAccountModel>(newAccount);
            }
            else
            {
                if (account.Status != (int)UserAccountStatus.Active) return null;
                return _mapper.Map<UserAccountModel>(account);
            }
        }

        public async Task<UserAccountModel> GetAccountByID(int id)
        {
            var account = await _genericRepository.GetByIDAsync(id);
            return _mapper.Map<UserAccountModel>(account);
        }

        public IPagedList<UserAccountModel> GetListAccount(UserAccountRequest request, UserAccountSortBy sortBy, OrderBy orderBy, int pageIndex, int pageSize)
        {
            var accountList = _genericRepository.GetAllByIQueryable();
            if (accountList == null) return null;

            var accountModelList = accountList.ProjectTo<UserAccountModel>(_mapper.ConfigurationProvider).DynamicFilter(_mapper.Map<UserAccountModel>(request));

            switch (sortBy.ToString())
            {
                case "Name":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        accountModelList = accountModelList.OrderBy(u => u.Name);
                    }
                    else
                    {
                        accountModelList = accountModelList.OrderByDescending(u => u.Name);
                    }
                    break;
                case "Email":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        accountModelList = accountModelList.OrderBy(u => u.Email);
                    }
                    else
                    {
                        accountModelList = accountModelList.OrderByDescending(u => u.Email);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList(accountModelList, pageIndex, pageSize);
        }

        public async Task<int> ChangeAccountStatus(int id)
        {
            var account = await _genericRepository.GetByIDAsync(id);
            if(account.Status == (int)UserAccountStatus.Active)
            {
                account.Status = (int)UserAccountStatus.InActive;
            }
            else
            {
                account.Status = (int)UserAccountStatus.Active;
            }
            await _genericRepository.UpdateAsync(account);
            return account.Status;
        }

        public async Task<bool> RemoveAccount(string token)
        {
            var decode = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            var id = Convert.ToInt32(decode.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);

            if (id > 0)
            {
                var account = await _genericRepository.GetByIDAsync(id);
                account.Id = id;
                account.Status = (int)UserAccountStatus.InActive;
                await _genericRepository.UpdateAsync(account);
                return true;
            }
            return false;
        }

        public async Task<UserAccountModel> UpdateRole(UpdateRoleRequest request)
        {
            var account = await _genericRepository.GetByIDAsync(request.Id);
            account.Role = request.Role;
            await _genericRepository.UpdateAsync(account);

            if("customer".Equals(request.Role))
            {
                CreateCustomerModelRequest customer = new CreateCustomerModelRequest();
                customer.Name = request.Name;
                customer.Email = request.Email;
                customer.Sex = Sex.Unknown;
                await _customerService.CreateCustomerModel(customer);
            } 
            else if("lawyer".Equals(request.Role))
            {
                LawyerRequest lawyer = new LawyerRequest();
                lawyer.Name = request.Name;
                lawyer.Email = request.Email;
                lawyer.Sex = Sex.Unknown;
                lawyer.Status = 1;
                await _lawyerService.CreateLawyer(lawyer);
            }
            else if ("lawyer_office".Equals(request.Role))
            {
                LawyerOfficeRequest lawyerOffice = new LawyerOfficeRequest();
                lawyerOffice.Name = request.Name;
                lawyerOffice.Email = request.Email;
                lawyerOffice.Status = 1;
                await _lawyerOfficeService.CreateLawyerOffice(lawyerOffice);
            }
            return _mapper.Map<UserAccountModel>(account);
        }

        public async Task<UserAccountModel> CreateAccount(UserAccountRequest request)
        {
            var account = _mapper.Map<UserAccount>(request);
            await _genericRepository.InsertAsync(account);
            await _genericRepository.SaveAsync();

            if ("customer".Equals(account.Role))
            {
                CreateCustomerModelRequest customer = new CreateCustomerModelRequest();
                customer.Name = request.Name;
                customer.Email = request.Email;
                customer.Sex = Sex.Unknown;
                await _customerService.CreateCustomerModel(customer);
            }
            else if("lawyer".Equals(account.Role))
            {
                LawyerRequest lawyer = new LawyerRequest();
                lawyer.Name = request.Name;
                lawyer.Email = request.Email;
                lawyer.Sex = Sex.Unknown;
                lawyer.Status = 1;
                await _lawyerService.CreateLawyer(lawyer);
            }
            else if ("lawyer_office".Equals(account.Role))
            {
                LawyerOfficeRequest lawyerOffice = new LawyerOfficeRequest();
                lawyerOffice.Name = request.Name;
                lawyerOffice.Email = request.Email;
                lawyerOffice.Status = 1;
                await _lawyerOfficeService.CreateLawyerOffice(lawyerOffice);
            }
            return _mapper.Map<UserAccountModel>(account);
        }
    }
}
