using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.BookingRequest
{
    public class CreateBookingRequest
    {
        public int CustomerId { get; set; }
        public int LawyerId { get; set; }
        public DateTime BookingDate { get; set; }
        public string PaymentMethod { get; set; }
        public int TotalPrice { get; set; }
        public DateTime? PayDate { get; set; }
        public int? Status { get; set; }
        public int CustomerCaseId { get; set; }
    }
}
