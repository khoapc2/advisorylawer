using AdvisoryLawyer.Business.Requests.LevelRequest;
using AdvisoryLawyer.Business.ViewModel;
using System.Collections.Generic;

namespace AdvisoryLawyer.Business.IServices
{
    public interface ILevelService
    {
        public IEnumerable<LevelModel> GetAllLevels();
        public LevelModel GetLevelByID(int id);
        public LevelModel CreateLevel(LevelRequest level);
        public LevelModel UpdateLevel(int id, LevelRequest level);
        public bool DeleteLevel(int id);
    }
}
