using Application.DTOs.MovieDTOs;
using Application.Services;
using Application.Utilities.Constants;
using Application.Utilities.Helper;
using Application.Utilities.Response;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.ConcreteServices.ActorService;
using Persistence.ConcreteServices.MovieService;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
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
        [HttpPut("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie(UpdateMovieDTO updateMovieDTO)
        {
            UpdateMovieDTOValidator validator = new();
            var result = validator.Validate(updateMovieDTO);
            GenericResponse<bool> response = new(true);
            if (result.IsValid)
            {
                response = await movieService.UpdateMovie(updateMovieDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [HttpDelete("DeleteMovie")]
        public async Task<IActionResult> DeleteMovie(string id)
        {
            GenericResponse<bool> response = new(true);
            if (!string.IsNullOrEmpty(id))
            {
                response = await movieService.DeleteMovie(id);
            }
            else
            {
                response.Message = Messages.IdFail;
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [HttpPatch("AddActorToMovie")]
        public async Task<IActionResult> AddActorToMovie(AddActorToMovieDTO addActorToMovieDTO)
        {
            AddActorToMovieDTOValidator validator = new();
            var result = validator.Validate(addActorToMovieDTO);
            GenericResponse<bool> response = new(true);
            if (result.IsValid)
            {
                response = await movieService.AddActorToMovie(addActorToMovieDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [HttpPatch("AddGenreToMovie")]
        public async Task<IActionResult> AddGenreToMovie(AddGenreToMovieDTO addGenreToMovieDTO)
        {
            AddGenreToMovieDTOValidator validator = new();
            var result = validator.Validate(addGenreToMovieDTO);
            GenericResponse<bool> response = new(true);
            if (result.IsValid)
            {
                response = await movieService.AddGenreToMovie(addGenreToMovieDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [HttpGet("AllMovies")]
        public async Task<IActionResult> GetAllMovie() => Ok(movieService.GetAll());

    }
}
