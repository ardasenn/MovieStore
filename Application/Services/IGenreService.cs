using Application.DTOs.GenreDTOs;
using Application.Utilities.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IGenreService
    {
        Task<GenericResponse<bool>> CreateGenre(CreateGenreDTO model);
        Task<GenericResponse<bool>> UpdateGenre(UpdateGenreDTO model);
        Task<GenericResponse<bool>> DeleteGenre(string id);
        List<Genre> GetAll();
    }
}
