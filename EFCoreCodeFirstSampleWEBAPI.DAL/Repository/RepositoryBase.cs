using EFCoreCodeFirstSampleWEBAPI.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.DAL.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MyAppContext MyAppContext { get; set; }
        public RepositoryBase(MyAppContext myAppContext)
        {
            MyAppContext = myAppContext;
        }

        public IQueryable<T> GetAll()
        {
            return MyAppContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return MyAppContext.Set<T>().Where(expression);
        }

        public async Task Add(T entity)
        {
            await MyAppContext.Set<T>().AddAsync(entity);
            MyAppContext.SaveChanges();
        }

        public void Update(T entity)
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
