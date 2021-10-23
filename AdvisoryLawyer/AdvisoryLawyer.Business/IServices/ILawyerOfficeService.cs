using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.CategoryRequest;
using AdvisoryLawyer.Business.Requests.LawyerOfficeRequest;
using AdvisoryLawyer.Business.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ILawyerOfficeService
    {
        public IPagedList<LawyerOfficeModel> GetListLawyerOffice(LawyerOfficeRequest request, LawyerOfficeSortBy sortBy, OrderBy orderBy, int pageIndex, int pageSize);
        public Task<LawyerOfficeModel> GetLawyerOfficeByID(int id);
        public Task<LawyerOfficeModel> CreateLawyerOffice(LawyerOfficeRequest request);
        public Task<LawyerOfficeModel> UpdateLawyerOffice(LawyerOfficeRequest request);
        public Task DeleteLawyerOffice(int id);
        public Task<LawyerOfficeModel> GetDetailByEmail(string email);
        Task<LawyerOfficeCategoryUpdate> UpdateCategoryOfficeLawyer(LawyerOfficeCategoryUpdate request);
    }
}
