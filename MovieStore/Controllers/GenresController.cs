using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.GenreDTOs;
using Application.Services;
using Application.Utilities.Constants;
using Application.Utilities.Helper;
using Application.Utilities.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
        }


        [HttpPost("CreateGenre")]
        public async Task<IActionResult> CreateGenre(CreateGenreDTO createGenreDTO)
        {
            CreateGenreDTOValidator validator = new();
            var result = validator.Validate(createGenreDTO);
            GenericResponse<bool> response = new();
            if (result.IsValid)
            {
                response = await genreService.CreateGenreAsync(createGenreDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [HttpPut("UpdateGenre")]
        public async Task<IActionResult> UpdateGenre(UpdateGenreDTO updateGenreDTO)
        {
            UpdateGenreDTOValidator validator = new();
            var result = validator.Validate(updateGenreDTO);
            GenericResponse<bool> response = new();
            if (result.IsValid)
            {
                response = await genreService.UpdateGenreAsync(updateGenreDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [HttpDelete("DeleteGenre")]
        public async Task<IActionResult> DeleteGenre(string id)
        {
            GenericResponse<bool> response = new();
            if (!string.IsNullOrEmpty(id))
                response = await genreService.DeleteGenreAsync(id);
            else
            {
                response.Message = Messages.Fail;
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [HttpGet("AllGenre")]
        public async Task<IActionResult> GetAllGenre() => Ok(genreService.GetAll());
    }
}