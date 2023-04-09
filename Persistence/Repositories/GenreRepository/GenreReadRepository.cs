using Application.Repositories.IGenreRepositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.GenreRepository
{
    public class GenreReadRepository : ReadRepository<Genre>, IGenreReadRepository
    {
        public GenreReadRepository(MovieDbContext db) : base(db)
        {
        }
    }
}
