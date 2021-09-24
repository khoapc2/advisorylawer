using AdvisoryLawyer.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface IAdvisoryService
    {
        AdvisoryModel GetAdvisoryById(int id);
    }
}
