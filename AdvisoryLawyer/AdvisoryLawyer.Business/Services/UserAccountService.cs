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
            var account = await _genericRepository.FindAsync(u => u.Username.Equals(email));
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
                if (account.Status != (int)UserAccountStatus.Active) return null;
                return _mapper.Map<UserAccountModel>(account);
            }
        }

        public async Task<UserAccountModel> GetProfileByID(int id)
        {
            var userProfile = await _genericRepository.GetByIDAsync(id);
            return _mapper.Map<UserAccountModel>(userProfile);
        }

        public IPagedList<UserAccountModel> GetAllProfiles(UserAccountRequest request, UserAccountSortBy sortBy, OrderBy orderBy, int pageIndex, int pageSize)
        {
            //var userList = _genericRepository.FindBy(u => u.Status == (int)UserAccountStatus.Active);
            var userList = _genericRepository.GetAllByIQueryable();
            if (userList == null) return null;

            var userModelList = userList.ProjectTo<UserAccountModel>(_mapper.ConfigurationProvider).DynamicFilter(_mapper.Map<UserAccountModel>(request));

            switch (sortBy.ToString())
            {
                case "Username":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        userModelList = userModelList.OrderBy(u => u.username);
                    }
                    else
                    {
                        userModelList = userModelList.OrderByDescending(u => u.username);
                    }
                    break;
                case "Role":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        userModelList = userModelList.OrderBy(u => u.role);
                    }
                    else
                    {
                        userModelList = userModelList.OrderByDescending(u => u.role);
                    }
                    break;
                case "Name":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        userModelList = userModelList.OrderBy(u => u.name);
                    }
                    else
                    {
                        userModelList = userModelList.OrderByDescending(u => u.name);
                    }
                    break;
                case "Address":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        userModelList = userModelList.OrderBy(u => u.address);
                    }
                    else
                    {
                        userModelList = userModelList.OrderByDescending(u => u.address);
                    }
                    break;
                case "Location":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        userModelList = userModelList.OrderBy(u => u.location);
                    }
                    else
                    {
                        userModelList = userModelList.OrderByDescending(u => u.location);
                    }
                    break;
                case "Sex":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        userModelList = userModelList.OrderBy(u => u.sex);
                    }
                    else
                    {
                        userModelList = userModelList.OrderByDescending(u => u.sex);
                    }
                    break;
                case "DateOfBirth":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        userModelList = userModelList.OrderBy(u => u.date_of_birth);
                    }
                    else
                    {
                        userModelList = userModelList.OrderByDescending(u => u.date_of_birth);
                    }
                    break;
                case "Level":
                    if ("Asc".Equals(orderBy.ToString()))
                    {
                        userModelList = userModelList.OrderBy(u => u.level);
                    }
                    else
                    {
                        userModelList = userModelList.OrderByDescending(u => u.level);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList(userModelList, pageIndex, pageSize);
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

        public async Task<UserAccountModel> GetProfileByID(string token)
        {
            var decode = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            var id = Convert.ToInt32(decode.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);

            if (id > 0)
            {
                var userProfile = await _genericRepository.GetByIDAsync(id);
                if (userProfile != null)
                {
                    return _mapper.Map<UserAccountModel>(userProfile);
                }
            }
            return null;
        }

        public async Task<UserAccountModel> UpdateProfile(string token, UserAccountRequest request)
        {
            var decode = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            var id = Convert.ToInt32(decode.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);

            if (id > 0)
            {
                var newProfile = _mapper.Map<UserAccount>(request);
                newProfile.Id = id;
                await _genericRepository.UpdateAsync(newProfile);
                return _mapper.Map<UserAccountModel>(newProfile);
            }
            return null;
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
    }
}
