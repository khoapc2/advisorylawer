using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdvisoryLawyer.Data.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();
        public IQueryable<T> GetAllByIQueryable();
    }
}
