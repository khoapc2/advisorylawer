using AdvisoryLawyer.Business.Requests.AdvisoryRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface IAdvisoryService
    {
        Task<AdvisoryModel> GetAdvisoryById(int id);
        IPagedList<AdvisoryModel> GetAllAdvisory(AdvisoryModel fillter, int pageIndex);
        Task<AdvisoryModel> CreateAdvisory(CreateAdvisoryRequest request);
        Task<AdvisoryModel> UpdateAdvisory(int id, UpdateAdvisoryRequest request);
        Task<bool> DeleteAdvisory(int id);

    }
}
