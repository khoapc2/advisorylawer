using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class SlotModel
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int Price { get; set; }
        public int LawyerId { get; set; }
        public int? Status { get; set; }
    }
}
