﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class AdvisoryModel
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public int? LawyerId { get; set; }
        public string QuestionAnswer { get; set; }
        public DateTime? StartAdvisory { get; set; }
        public TimeSpan? TimeAdvisory { get; set; }
    }
}
