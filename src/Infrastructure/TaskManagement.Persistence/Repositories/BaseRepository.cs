using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Persistence.Repositories
{
    public class BaseRepository<T> :
        IAsyncRepository<T> where T : class
    {
        protected readonly TaskManagementDbContext dbContext;
        protected readonly DbSet<T> dbSet;
        public BaseRepository(TaskManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id) =>
            await dbSet.FindAsync(id);

        public virtual async Task<IReadOnlyList<T>> ListAllAsync() =>
            await dbSet.ToListAsync();
    }
}
