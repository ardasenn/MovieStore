using Application.DTOs.GenreDTOs;
using Application.Utilities.Response;
using Application.VMs;
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
        Task<GenericResponse<bool>> CreateGenreAsync(CreateGenreDTO model);
        Task<GenericResponse<bool>> UpdateGenreAsync(UpdateGenreDTO model);
        Task<GenericResponse<bool>> DeleteGenreAsync(string id);
        GenericResponse<List<GenreVM>> GetAll();
    }
}
