using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Shared.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> List { get; }
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        T FindById(int Id);
        void AddRange(IEnumerable<T> entityList);
        void DeleteRange(IEnumerable<T> entityList);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
