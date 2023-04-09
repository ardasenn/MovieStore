using Application.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntity
    {
        private readonly MovieDbContext db;

        public WriteRepository(MovieDbContext db)
        {
            this.db = db;
        }
        public DbSet<T> Table => db.Set<T>();
        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
            entity.Status = Domain.Enums.Status.Pasive;
            entity.DeleteDate = DateTime.Now;           
           return Update(entity);
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(a => a.Id.ToString() == id);
            return Remove(model);
        }

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }



        public bool Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        public Task<int> SaveAsync()=> db.SaveChangesAsync();
       
    }
}
