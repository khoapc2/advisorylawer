using System;
using System.Collections.Generic;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryLawyerOffices = new HashSet<CategoryLawyerOffice>();
            CategoryLawyers = new HashSet<CategoryLawyer>();
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }

        public virtual ICollection<CategoryLawyerOffice> CategoryLawyerOffices { get; set; }
        public virtual ICollection<CategoryLawyer> CategoryLawyers { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
