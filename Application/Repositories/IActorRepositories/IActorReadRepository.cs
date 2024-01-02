using Application.Utilities.Response;
using Application.VMs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.IActorRepositories
{
    public interface IActorReadRepository : IReadRepository<Actor>
    {
        /// <summary>
        /// Include Movies
        /// </summary>
        /// <returns></returns>
        GenericResponse<List<Actor>> GetIncludeAll();
    }
}
