using AdvisoryLawyer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Data.IRepositories
{
    public interface IUserAccountRepository
    {
        public UserAccount CheckLogin(string username, string password);
    }
}
