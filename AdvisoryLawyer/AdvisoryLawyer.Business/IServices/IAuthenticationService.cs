using AdvisoryLawyer.Business.ViewModel;
using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface IAuthenticationService
    {
        //public string GenerateJSONWebToken(UserAccountModel account);
        public Task<AuthenticationModel> LoginWithGmail(string idToken);
    }
}
