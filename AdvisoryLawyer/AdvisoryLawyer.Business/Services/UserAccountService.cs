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

namespace AdvisoryLawyer.Business.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IGenericRepository<UserAccount> _genericRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly ILogger<UserAccountService> _logger;
        private readonly IMapper _mapper;

        public UserAccountService(IGenericRepository<UserAccount> genericRepository, 
                                IUserAccountRepository userAccountRepository, ILogger<UserAccountService> logger, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _userAccountRepository = userAccountRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<UserAccountModel> CheckGmail(string email, string fullname)
        {
            var account = await _genericRepository.FindAsync(u => u.Username.Equals(email) && u.Status == 1);
            if (account == null)
            {
                var newAccount = new UserAccount
                {
                    Username = email,
                    Name = fullname,
                    Role = "customer",
                    Status = 1
                };
                await _genericRepository.InsertAsync(newAccount);
                await _genericRepository.SaveAsync();
                return _mapper.Map<UserAccountModel>(newAccount);
            }
            else
            {
                return _mapper.Map<UserAccountModel>(account);
            }
        }

        public async Task<UserAccountModel> GetProfileByID(int id)
        {
            var userProfile = await _genericRepository.GetByIDAsync(id);
            return _mapper.Map<UserAccountModel>(userProfile);
        }

        public async Task<IPagedList<UserAccountModel>> GetAllProfiles(UserAccountRequest request, UserAccountSortBy sortBy, OrderBy orderBy, int pageIndex, int pageSize)
        {
            var userList = await _genericRepository.FindByAsync(u => u.Status == (int)UserAccountStatus.Active);
            if (userList == null) return null;

            var slotModelList = userList.AsQueryable().ProjectTo<UserAccountModel>(_mapper.ConfigurationProvider).DynamicFilter(_mapper.Map<UserAccountModel>(request));

            switch (sortBy.ToString())
            {
                case "Username":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        slotModelList = slotModelList.OrderBy(u => u.username);
                    }
                    else
                    {
                        slotModelList = slotModelList.OrderByDescending(u => u.username);
                    }
                    break;
                case "Role":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        slotModelList = slotModelList.OrderBy(u => u.role);
                    }
                    else
                    {
                        slotModelList = slotModelList.OrderByDescending(u => u.role);
                    }
                    break;
                case "Name":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        slotModelList = slotModelList.OrderBy(u => u.name);
                    }
                    else
                    {
                        slotModelList = slotModelList.OrderByDescending(u => u.name);
                    }
                    break;
                case "Address":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        slotModelList = slotModelList.OrderBy(u => u.address);
                    }
                    else
                    {
                        slotModelList = slotModelList.OrderByDescending(u => u.address);
                    }
                    break;
                case "Location":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        slotModelList = slotModelList.OrderBy(u => u.location);
                    }
                    else
                    {
                        slotModelList = slotModelList.OrderByDescending(u => u.location);
                    }
                    break;
                case "Sex":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        slotModelList = slotModelList.OrderBy(u => u.sex);
                    }
                    else
                    {
                        slotModelList = slotModelList.OrderByDescending(u => u.sex);
                    }
                    break;
                case "DateOfBirth":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        slotModelList = slotModelList.OrderBy(u => Convert.ToDateTime(u.date_of_birth));
                    }
                    else
                    {
                        slotModelList = slotModelList.OrderByDescending(u => Convert.ToDateTime(u.date_of_birth));
                    }
                    break;
                case "Level":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        slotModelList = slotModelList.OrderBy(u => u.level);
                    }
                    else
                    {
                        slotModelList = slotModelList.OrderByDescending(u => u.level);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList(slotModelList, pageIndex, pageSize);
        }

        public async Task ChangeAccountStatus(int id)
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
        }
    }
}
