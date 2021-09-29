using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Data.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly AdvisoryLawyerContext _context;
        private readonly DbSet<UserAccount> _dbSet;
        private readonly ILogger<UserAccountRepository> _logger;


        public UserAccountRepository(AdvisoryLawyerContext context, ILogger<UserAccountRepository> logger)
        {
            _context = context;
            _dbSet = _context.Set<UserAccount>();
            _logger = logger;
        }

        public UserAccount CheckLogin(string username)
        {
            try
            {
                var userInfo = _dbSet.FirstOrDefault(u => u.Username.Equals(username) && u.Status == 1);
                return userInfo;
            }
            catch (Exception ex)
            {
                _logger.LogError("UserAccountRepository_CheckLogin: " + ex.Message);
                return null;
            }
        }
    }
}
