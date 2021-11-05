using AdvisoryLawyer.Business.Enum;
using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class UserAccountModel
    {
        public int? Id { get; set; }
        [String]
        public string Name { get; set; }
        [String]
        public string Email { get; set; }
        public string OfficeName { get; set; }
        public string Role { get; set; }
        public int? Status { get; set; }
        public string Uid { get; set; }
    }
}
