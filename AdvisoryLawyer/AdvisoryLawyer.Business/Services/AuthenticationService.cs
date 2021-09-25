using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.ViewModel;
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

        public AuthenticationService(IConfiguration config, ILogger<AuthenticationService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public string GenerateJSONWebToken(UserAccountModel account)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Id", account.Id.ToString()),
                    new Claim("Username", account.Username),
                    new Claim("Name", account.Name),
                    new Claim(ClaimTypes.Role, account.Role)
                    //new Claim("Address", account.Address),
                    //new Claim("Location", account.Location),
                    //new Claim("Description", account.Description),
                    //new Claim("PhoneNumber", account.PhoneNumber),
                    //new Claim("Website", account.Website),
                    //new Claim("Email", account.Email),
                    //new Claim("Sex", account.Sex.ToString()),
                    //new Claim("DateOfBirth", account.DateOfBirth.ToString()),
                    //new Claim("Status", account.Status.ToString())
                };

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                                _config["Jwt:Issuer"],
                                                claims,
                                                expires: DateTime.Now.AddHours(4),
                                                signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch(Exception ex)
            {
                _logger.LogError("AuthenticationService_GenerateJSONWebToken: " + ex.Message);
                return string.Empty;
            }
        }
    }
}
