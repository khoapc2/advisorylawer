﻿using AdvisoryLawyer.Business.IServices;
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

namespace AdvisoryLawyer.Business.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IGenericRepository<UserAccount> _genericRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly ILogger<UserAccountService> _logger;
        private readonly IMapper _mapper;

        public UserAccountService(IAuthenticationService authenticationService, IGenericRepository<UserAccount> genericRepository, 
                                IUserAccountRepository userAccountRepository, ILogger<UserAccountService> logger, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _genericRepository = genericRepository;
            _userAccountRepository = userAccountRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<string> LoginWithGmail(string gmail)
        {
            var account = await _genericRepository.FindAsync(u => u.Username.Equals(gmail) && u.Status == 1);
            if (account == null)
            {
                var newAccount = new UserAccount{
                    Username = gmail,
                    Name = gmail,
                    Role = "customer",
                    Status = 1
                };
                await _genericRepository.InsertAsync(newAccount);
                await _genericRepository.SaveAsync();
                return _authenticationService.GenerateJSONWebToken(_mapper.Map<UserAccountModel>(newAccount));
            }
            else
            {
                return _authenticationService.GenerateJSONWebToken(_mapper.Map<UserAccountModel>(account));
            }
        }

        public string Login(string username)
        {
            try
            {
                var userInfo = _userAccountRepository.CheckLogin(username);

                if (userInfo != null)
                {
                    var userModel = _mapper.Map<UserAccountModel>(userInfo);
                    var token = _authenticationService.GenerateJSONWebToken(userModel);
                    return token;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("UserAccountService_Login: " + ex.Message);
                return string.Empty;
            }
        }

        public UserAccountModel GetProfileByID(string token)
        {
            try
            {
                var decode = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
                var id = Convert.ToInt32(decode.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);

                if(id > 0)
                {
                    var userProfile = _genericRepository.GetByID(id);
                    if (userProfile != null)
                    {
                        return _mapper.Map<UserAccountModel>(userProfile);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                //logging
                return null;
            }
        }

        public IEnumerable<UserAccountModel> GetAllProfiles()
        {
            try
            {
                var profiles = _genericRepository.GetAll();
                if (profiles != null)
                {
                    return _mapper.Map<IEnumerable<UserAccountModel>>(profiles).ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                //logging
                return null;
            }
        }

        //public bool ChangePassword(string token, string newPassword)
        //{
        //    try
        //    {
        //        var decode = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
        //        var id = Convert.ToInt32(decode.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);

        //        if(id > 0)
        //        {
        //            var account = _genericRepository.GetByID(id);
        //            account.Password = newPassword;
        //            _genericRepository.Update(account);
        //            _genericRepository.Save();
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        //logging
        //        return false;
        //    }
        //}

        public bool ChangeAccountStatus(int id)
        {
            try
            {
                var account = _genericRepository.GetByID(id);
                if(account.Status == 1)
                {
                    account.Status = 0;
                }
                else
                {
                    account.Status = 1;
                }
                _genericRepository.Update(account);
                _genericRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }
    }
}
