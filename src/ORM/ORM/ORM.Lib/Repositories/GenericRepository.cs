using Microsoft.EntityFrameworkCore;
using ORM.Lib.Context;

namespace ORM.Lib.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ShopDbContext Context { get; }

        protected GenericRepository(ShopDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public T Read(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }
    }
}