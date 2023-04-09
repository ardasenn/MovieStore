using Application.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntity
    {
        private readonly MovieDbContext db;

        public ReadRepository(MovieDbContext db)
        {
            this.db = db;
        }
        public DbSet<T> Table => db.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public async Task<T> GetByIdAsync(string id)=>await Table.FindAsync(Guid.Parse(id));
        

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression) => await Table.FirstOrDefaultAsync(expression);
        

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)=>
            db.Set<T>().Where(expression);
        
    }
}
