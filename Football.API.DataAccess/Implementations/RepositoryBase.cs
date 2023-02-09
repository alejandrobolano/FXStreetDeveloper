using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Football.API.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Football.API.DataAccess.Implementations
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T: class
    {
        protected FootballContext RepositoryContext { get; set; }
        public RepositoryBase(FootballContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> GetAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) 
            => RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        public T Add(T entity) => RepositoryContext.Set<T>().Add(entity).Entity;
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}
