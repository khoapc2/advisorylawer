using AdvisoryLawyer.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface IUserAccountService
    {
        public Task<string> LoginWithGmail(string gmail);
        //public string Login(string username, string password);
        public string Login(string username);
        public UserAccountModel GetProfileByID(string token);
        public IEnumerable<UserAccountModel> GetAllProfiles();
        //public bool ChangePassword(string token, string newPassword);
        public bool ChangeAccountStatus(int id);
    }
}
