using Application.Repositories.IOrderRepositories;
using Application.Utilities.Response;
using Application.VMs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.OrderRepository
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(MovieDbContext db) : base(db)
        {

        }
    }
}
