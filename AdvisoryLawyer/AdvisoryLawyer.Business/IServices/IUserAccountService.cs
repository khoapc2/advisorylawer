using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.UserAccountsRequest;
using AdvisoryLawyer.Business.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface IUserAccountService
    {
        public Task<UserAccountModel> CheckGmail(string gmail, string fullname, string uid);
        public Task<UserAccountModel> GetAccountByID(int id);
        public Task<IPagedList<UserAccountModel>> GetListAccount(UserAccountRequest request, UserAccountSortBy sortBy, OrderBy orderBy, int pageIndex, int pageSize);
        public Task<int> ChangeAccountStatus(int id);
        public Task<bool> RemoveAccount(string token);
        public Task<UserAccountModel> UpdateRole(UpdateRoleRequest request);
        public Task<UserAccountModel> CreateAccount(UserAccountRequest request);
    }
}
