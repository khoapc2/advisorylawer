using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.LawyerRequest;
using AdvisoryLawyer.Business.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ILawyerService
    {
        IPagedList<LawyerModel> GetAllLawyers(LawyerRequest filter,
            LawyerSortBy sortBy, OrderBy order, int pageIndex, int pageSize);
        Task<LawyerModel> GetLawyerById(int id);
        Task<LawyerModel> CreateLawyer(LawyerRequest lawyerRequest);
        Task<LawyerModel> UpdateLawyer(LawyerUpdate lawyerUpdate);
        Task<bool> DeleteLawyer(int id);
        Task<LawyerModel> GetDetailByEmail(string email);
        Task RemoveLawyerOutOfOffice(int id);
        Task<LawyerModel> UpdateLevelForLawyer(UpdateLevelForLawyerRequest request);
        Task<LawyerModel> AddLawyerToOffice(AddLawyerToOfficeRequest request);
    }
}
