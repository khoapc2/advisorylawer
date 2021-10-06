using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.LevelRequest;
using AdvisoryLawyer.Business.ViewModel;
using PagedList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ILevelService
    {
        public IPagedList<LevelModel> GetAllLevels(LevelRequest request, LevelSortBy sortBy, OrderBy orderBy, int pageIndex, int pageSize);
        public Task<LevelModel> GetLevelByID(int id);
        public Task<LevelModel> CreateLevel(LevelRequest level);
        public Task<LevelModel> UpdateLevel(int id, LevelRequest level);
        public Task DeleteLevel(int id);
    }
}
