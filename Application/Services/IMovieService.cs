﻿using Application.DTOs.MovieDTOs;
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
    public interface IMovieService
    {
        Task<GenericResponse<bool>> CreateMovie(CreateMovieDTO model);
        Task<GenericResponse<bool>> UpdateMovie(UpdateMovieDTO model);
        Task<GenericResponse<bool>> DeleteMovie(string id);
        GenericResponse<List<MovieVM>> GetAll();
        Task<GenericResponse<bool>> AddActorToMovie(AddActorToMovieDTO model);
        Task<GenericResponse<bool>> AddGenreToMovie(AddGenreToMovieDTO model);
        GenericResponse<MovieVM> GetMovie(string id);
        GenericResponse<List<MovieVM>> GetMoviesByGenreId(string id);
    }
}
