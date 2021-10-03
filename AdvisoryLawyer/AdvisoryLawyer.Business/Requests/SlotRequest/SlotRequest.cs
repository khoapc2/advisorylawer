﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Requests.SlotRequest
{
    public class SlotRequest
    {
        public int booking_id { get; set; }
        public DateTime start_at { get; set; }
        public DateTime end_at { get; set; }
        public int price { get; set; }
        public int lawyer_id { get; set; }
        public int? status { get; set; }
    }
}
