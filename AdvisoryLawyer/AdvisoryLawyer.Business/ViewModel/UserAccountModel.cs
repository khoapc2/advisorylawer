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
        public int? id { get; set; }
        [String]
        public string? username { get; set; }
        public string role { get; set; }
        [String]
        public string? name { get; set; }
        [String]
        public string? address { get; set; }
        [String]
        public string? location { get; set; }
        public string description { get; set; }
        public string phone_number { get; set; }
        public string website { get; set; }
        public string email { get; set; }
        public UserAccountSex? sex { get; set; }
        public DateTime? date_of_birth { get; set; }
        public string? date_of_birth_formated { get; set; }
        public int? status { get; set; }
        public string? lawyer_office_name { get; set; }
        public int? lawyer_office_id { get; set; }
        public string? level { get; set; }
        public int? level_id { get; set; }
    }
}
