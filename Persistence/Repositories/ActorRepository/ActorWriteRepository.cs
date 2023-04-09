using Application.Repositories.IActorRepositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ActorRepository
{
    public class ActorWriteRepository : WriteRepository<Actor>, IActorWriteRepository
    {
        public ActorWriteRepository(MovieDbContext db) : base(db)
        {
        }
    }
}
