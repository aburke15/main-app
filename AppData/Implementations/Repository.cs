using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppData.Interfaces;

namespace AppData.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WebsitesContext Context;

        public Repository(WebsitesContext context) 
            => Context = context;

        public void Add(T entity) 
            => Context.Set<T>().Add(entity);

        public async Task AddAsync(T entity) 
            => await Context.Set<T>().AddAsync(entity);

        public void AddRange(IEnumerable<T> entities)
            => Context.Set<T>().AddRange(entities);

        public async Task AddRangeAsync(IEnumerable<T> entities) 
            => await Context.Set<T>().AddRangeAsync(entities);

        public IEnumerable<T> Get 
            => Context.Set<T>() as IEnumerable<T>;

        public T GetById(object key)
        {
            ValidateKeyOfTypeInt(key);

            return Context.Set<T>().Find(key);
        }

        public async Task<T> GetByIdAsync(object key)
        {
            ValidateKeyOfTypeInt(key);

            return await Context.Set<T>().FindAsync(key);
        }

        public void Remove(T entity) 
            => Context.Set<T>().Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) 
            => Context.Set<T>().RemoveRange(entities);

        public void Update(T entity) 
            => Context.Set<T>().Update(entity);

        public void UpdateRange(IEnumerable<T> entities) 
            => Context.Set<T>().UpdateRange(entities);

        public void SaveChanges() 
            => Context.SaveChanges();

        public async Task SaveChangesAsync() 
            => await Context.SaveChangesAsync();

        private void ValidateKeyOfTypeInt(object key)
        {
            if (key.GetType() != typeof(int))
                throw new InvalidOperationException($"Key ID must be of type {typeof(int)}");
        }
    }
}