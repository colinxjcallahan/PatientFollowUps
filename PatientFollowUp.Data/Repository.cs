using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PatientFollowUp.Data
{
    public class Repository : IRepository
    {
        private readonly DashboardEntities _dbContext;

        public Repository()
        {
            _dbContext = new DashboardEntities();
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public T GetById<T>(int id) where T : class
        {
            DbSet<T> set = _dbContext.Set<T>();

            return set.Find(id);
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            DbSet<T> set = _dbContext.Set<T>();

            return set.Where(predicate);
        }
    }
}