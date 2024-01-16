using Application.Repositories.IActorRepositories;
using Application.Utilities.Response;
using Application.VMs;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ActorRepository
{
    public class ActorReadRepository : ReadRepository<Actor>, IActorReadRepository
    {
        private readonly MovieDbContext db;

        public ActorReadRepository(MovieDbContext db) : base(db)
        {
            this.db = db;
        }
       
        public GenericResponse<List<Actor>> GetIncludeAll()
        {
            GenericResponse<List<Actor>> response = new(true);
            response.Data = db.Actors.Where(a => a.Status != Status.Pasive).Include(a => a.Movies).ToList();
            return response;
        }
        public GenericResponse<Actor> GetInclude(string id)
        {
            GenericResponse<Actor> response = new(true);
            response.Data = db.Actors.Where(a => a.Status != Status.Pasive && a.Id.ToString() == id).Include(a => a.Movies).FirstOrDefault(); ;
            return response;
        }
    }
}
