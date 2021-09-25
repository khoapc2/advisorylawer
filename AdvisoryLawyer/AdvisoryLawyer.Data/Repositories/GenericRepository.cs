using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdvisoryLawyer.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AdvisoryLawyerContext _context;
        private DbSet<T> _dbSet = null;

        public GenericRepository(AdvisoryLawyerContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IQueryable<T> GetAllByIQueryable()
        {
            return _dbSet;
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

        //public IQueryable Get(Expression<Func<T, bool>> sdf)
        //{
        //    sdf.Body
        //}
    }
}
