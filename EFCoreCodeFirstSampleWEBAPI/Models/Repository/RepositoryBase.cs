using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MyAppContext MyAppContext { get; set; }
        public RepositoryBase(MyAppContext myAppContext)
        {
            MyAppContext = myAppContext;
        }

        public IEnumerable<T> GetAll()
        {
            return MyAppContext.Set<T>().ToList();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return MyAppContext.Set<T>().Where(expression);
        }

        public void Add(T entity)
        {
            MyAppContext.Set<T>().Add(entity);
            MyAppContext.SaveChanges();
        }

        public void Update(T dbEntity, T entity)
        {
            MyAppContext.Set<T>().Update(entity);
            MyAppContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            MyAppContext.Set<T>().Remove(entity);
            MyAppContext.SaveChanges();
        }
    }
}
