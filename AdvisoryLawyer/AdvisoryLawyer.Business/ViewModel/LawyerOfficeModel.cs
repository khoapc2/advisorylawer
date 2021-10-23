using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class LawyerOfficeModel
    {
        public int? Id { get; set; }
        [String]
        public string Name { get; set; }
        [String]
        public string Address { get; set; }
        [String]
        public string Location { get; set; }
        public string Description { get; set; }
        [String]
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        [String]
        public string Email { get; set; }
        public int? Status { get; set; }
        [Contain]
        public List<int> CategoryIds { get; set; }
    }
}
