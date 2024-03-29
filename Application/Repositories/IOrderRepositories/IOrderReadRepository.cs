﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.IOrderRepositories
{
    public interface IOrderReadRepository : IReadRepository<Order>
    {
        List<Order> GetWhereIncludeMovie(string id);
    }
}
