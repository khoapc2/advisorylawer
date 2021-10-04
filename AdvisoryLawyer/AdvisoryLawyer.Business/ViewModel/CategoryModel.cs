﻿using Reso.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.ViewModel
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Contain]
        public List<int> LawyerIds { get; set; }
        public string CategoryName { get; set; }
    }
}
