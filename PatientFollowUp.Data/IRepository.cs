using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PatientFollowUp.Data
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() where T : class;

        T GetById<T>(int id) where T : class;

        IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class;

        void Save<T>(T objectToSave) where T : class;
    }
}