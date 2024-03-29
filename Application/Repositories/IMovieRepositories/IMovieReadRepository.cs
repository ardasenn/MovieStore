﻿using Application.Utilities.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.IMovieRepositories
{
    public interface IMovieReadRepository : IReadRepository<Movie>
    {
        IQueryable<Movie> GetAllMovie();
        IQueryable<Movie> GetlMoviesByGenre(string id);
        GenericResponse<Movie> GetInclude(string id);
    }
}
