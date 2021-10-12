using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using FirebaseAdmin.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IConfiguration _config;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IUserAccountService _userAccountService;
        private readonly IGenericRepository<LawyerOffice> _lawyerOfficeRepository;
        private readonly IGenericRepository<Lawyer> _lawyerRepository;
        private readonly IGenericRepository<Customer> _customerRepository;

        public AuthenticationService(IConfiguration config, ILogger<AuthenticationService> logger, IUserAccountService userAccountService,
            IGenericRepository<LawyerOffice> lawyerOfficeRepository, IGenericRepository<Lawyer> lawyerRepository, IGenericRepository<Customer> customerRepository)
        {
            _config = config;
            _logger = logger;
            _userAccountService = userAccountService;
            _lawyerOfficeRepository = lawyerOfficeRepository;
            _lawyerRepository = lawyerRepository;
            _customerRepository = customerRepository;
        }

        private string GenerateJSONWebToken(string id, string email, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Id", id),
                    new Claim("Email", email),
                    new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                            _config["Jwt:Issuer"],
                                            claims,
                                            expires: DateTime.Now.AddHours(4),
                                            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<FirebaseToken> VerifyFirebaseToken(string idToken)
        {
            try
            {
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
                return decodedToken;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<AuthenticationModel> LoginWithGmail(string idToken)
        {
            var decodedToken = await VerifyFirebaseToken(idToken);
            if (decodedToken == null) return null;

            var account = await _userAccountService.CheckGmail(decodedToken.Claims.GetValueOrDefault("email").ToString(), decodedToken.Claims.GetValueOrDefault("name").ToString());
            if (account == null) return null;
            
            if("undefined".Equals(account.Role))
            {
                var token = GenerateJSONWebToken(account.Id.ToString(), account.Email, account.Role);
                return new AuthenticationModel { token = token, display_name = account.Name, email = account.Email, role = account.Role };
            } 
            else if("customer".Equals(account.Role))
            {
                var customer = await _customerRepository.FindAsync(c => c.Email.Equals(account.Email));
                var token = GenerateJSONWebToken(customer.Id.ToString(), customer.Email, account.Role);
                return new AuthenticationModel { token = token, display_name = customer.Name, email = customer.Email, role = account.Role };
            }
            else if ("lawyer".Equals(account.Role))
            {
                var lawyer = await _lawyerRepository.FindAsync(l => l.Email.Equals(account.Email));
                var token = GenerateJSONWebToken(lawyer.Id.ToString(), lawyer.Email, account.Role);
                return new AuthenticationModel { token = token, display_name = lawyer.Name, email = lawyer.Email, role = account.Role };
            }
            else if ("lawyer_office".Equals(account.Role))
            {
                var lawyerOffice = await _customerRepository.FindAsync(l => l.Email.Equals(account.Email));
                var token = GenerateJSONWebToken(lawyerOffice.Id.ToString(), lawyerOffice.Email, account.Role);
                return new AuthenticationModel { token = token, display_name = lawyerOffice.Name, email = lawyerOffice.Email, role = account.Role };
            }
            return null;
        }
    }
}
