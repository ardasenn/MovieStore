using Application.Repositories.IMovieRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.MovieRepository
{
    public class MovieReadRepository : ReadRepository<Movie>, IMovieReadRepository
    {
        private readonly MovieDbContext db;

        public MovieReadRepository(MovieDbContext db) : base(db)
        {
            this.db = db;
        }

        public IQueryable<Movie> GetAllMovie()
        {
            return db.Movies.Include(a => a.Genres).Include(a => a.Comments).Where(a => a.Status != Domain.Enums.Status.Pasive).Include(a => a.Actors);
        }
    }
}
