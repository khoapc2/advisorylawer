using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        public string Login(string username, string password)
        {
            try
            {
                var userInfo = _userAccountRepository.CheckLogin(username, password);

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
    }
}
