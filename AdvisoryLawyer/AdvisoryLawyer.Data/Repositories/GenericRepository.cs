using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdvisoryLawyer.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AdvisoryLawyerContext _context;
        private DbSet<T> _dbSet = null;

        public GenericRepository(AdvisoryLawyerContext content)
        {
            _context = content;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T obj)
        {
            _dbSet.Add(obj);
        }

        public void Update(T obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T existing = _dbSet.Find(id);
            _dbSet.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
