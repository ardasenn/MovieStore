using Application.DTOs.MovieDTOs;
using Application.Utilities.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IMovieService
    {
        Task<GenericResponse<bool>> CreateMovie(CreateMovieDTO model);
        Task<GenericResponse<bool>> UpdateMovie(UpdateMovieDTO model);
        Task<GenericResponse<bool>> DeleteMovie(DeleteMovieDTO model);
        List<Movie> GetAll();
    }
}
