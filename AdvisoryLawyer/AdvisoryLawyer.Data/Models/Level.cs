using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class Level
    {
        public Level()
        {
            UserAccounts = new HashSet<UserAccount>();
        }

        public int Id { get; set; }
        public string LevelName { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
