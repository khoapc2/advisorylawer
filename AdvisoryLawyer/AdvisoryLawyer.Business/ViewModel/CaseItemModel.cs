using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class CaseItemModel
    {
        public int? Id { get; set; }
        public int? CustomerCaseId { get; set; }
        [String]
        public string Name { get; set; }
        [String]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
