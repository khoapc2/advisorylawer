﻿using AdvisoryLawyer.Business.Requests;
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
        public Task<UserAccountModel> CheckGmail(string gmail, string fullname);
        public Task<UserAccountModel> GetProfileByID(int id);
        public Task<IPagedList<UserAccountModel>> GetAllProfiles(UserAccountRequest request, UserAccountSortBy sortBy, OrderBy orderBy, int pageIndex, int pageSize);
        public Task ChangeAccountStatus(int id);
    }
}
