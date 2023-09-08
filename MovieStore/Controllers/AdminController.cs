﻿using Application.DTOs.MovieDTOs;
using Application.Services;
using Application.Utilities.Helper;
using Application.Utilities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMovieService movieService;

        public AdminController(IMovieService movieService)
        {
            this.movieService = movieService;
        }
        [HttpPost("CreateMovie")]
        public async Task<IActionResult> AddMovie(CreateMovieDTO createMovieDTO)
        {
            CreateMovieDTOValidator validator = new();
            var result = validator.Validate(createMovieDTO);
            GenericResponse<bool> response = new();
            if (result.IsValid)
                response = await movieService.CreateMovie(createMovieDTO);
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = false;
            }
            return Ok(response);
        }
    }

}