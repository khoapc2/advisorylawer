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
        public Task<UserAccountModel> CheckGmail(string gmail, string fullname);
        public UserAccountModel GetProfileByID(string token);
        public IEnumerable<UserAccountModel> GetAllProfiles();
        public bool ChangeAccountStatus(int id);
    }
}
