using Application.Repositories.IOrderRepositories;
using Application.Utilities.Response;
using Application.VMs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.OrderRepository
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        private readonly MovieDbContext db;

        public OrderReadRepository(MovieDbContext db) : base(db)
        {
            this.db = db;
        }
        public List<Order> GetWhereIncludeMovie(string id)
        {
            return db.Orders.Include(a => a.Customer).Include(a => a.MovieList).Where(a => a.Status != Domain.Enums.Status.Pasive && a.Customer.Id ==id).OrderByDescending(a => a.CreationDate).ToList();
        }
    }
}
