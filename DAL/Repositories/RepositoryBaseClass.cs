using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Interfaces;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class RepositoryBaseClass<T> : IRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork;
        public DbSet<T> DbSet;

        public RepositoryBaseClass(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            DbSet = UnitOfWork.DbContext.Set<T>();
        }
        public List<T> List { get => DbSet.ToList(); }

        public void Add(T entity)
        {
            DbSet.Add(entity);
            UnitOfWork.Commit();
            return;
        }

        public void AddRange(IEnumerable<T> entityList)
        {
            DbSet.AddRange(entityList);
            UnitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            UnitOfWork.Commit();
        }

        public void DeleteRange(IEnumerable<T> entityList)
        {
            DbSet.RemoveRange(entityList);
            UnitOfWork.Commit();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public T FindById(int Id)
        {
            return DbSet.Find(Id);
        }

        public void Update(T entity)
        {
            UnitOfWork.DbContext.Entry(entity).State = EntityState.Modified;
            UnitOfWork.Commit();
        }
    }
}

