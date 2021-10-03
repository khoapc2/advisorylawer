using AdvisoryLawyer.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.UserAccountsRequest
{
    public class UserAccountRequest
    {
        public string username { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string phone_number { get; set; }
        public string website { get; set; }
        public string email { get; set; }
        public UserAccountSex? sex { get; set; }
        public string? date_of_birth { get; set; }
        public int status { get; set; }
        public string? lawyer_office_name { get; set; }
        public string? level { get; set; }
    }
}
