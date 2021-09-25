using AdvisoryLawyer.Business.Requests.AdvisoryRequest;
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
        List<AdvisoryModel> GetAllAdvisory();
        AdvisoryModel CreateAdvisory(CreateAdvisoryRequest request);
        AdvisoryModel UpdateAdvisory(int id, UpdateAdvisoryRequest request);
        bool DeleteAdvisory(int id);

    }
}
