using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class UserAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int Status { get; set; }
        public string Uid { get; set; }
    }
}
