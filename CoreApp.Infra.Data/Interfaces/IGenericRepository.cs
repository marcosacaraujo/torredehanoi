using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoreApp.Infra.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T obj);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        void Update(T obj);
        void Delete(T obj);
    }
}