using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.ViewModel;
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

        public AuthenticationService(IConfiguration config, ILogger<AuthenticationService> logger, IUserAccountService userAccountService)
        {
            _config = config;
            _logger = logger;
            _userAccountService = userAccountService;
        }

        private string GenerateJSONWebToken(UserAccountModel account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Id", account.id.ToString()),
                    new Claim("Email", account.username),
                    new Claim(ClaimTypes.Role, account.role)
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

            var token = GenerateJSONWebToken(account);

            return new AuthenticationModel { token = token, display_name = decodedToken.Claims.GetValueOrDefault("name").ToString(), role = account.role };
        }
    }
}
