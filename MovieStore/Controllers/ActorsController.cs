using Application.DTOs.ActorDTOs;
using Application.Services;
using Application.Utilities.Constants;
using Application.Utilities.Helper;
using Application.Utilities.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService actorService;

        public ActorsController(IActorService actorService)
        {
            this.actorService = actorService;
        }
        [HttpPost("CreateActor")]
        public async Task<ActionResult> CreateActor(CreateActorDTO createActorDTO)
        {
            CreateActorDTOValidator validator = new();
            var result = validator.Validate(createActorDTO);
            GenericResponse<bool> response = new(true);
            if (result.IsValid)
            {
                response = await actorService.CreateActor(createActorDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [HttpPut("UpdateActor")]
        public async Task<IActionResult> UpdateActor(UpdateActorDTO updateActorDTO)
        {
            UpdateActorDTOValidator validator = new();
            var result = validator.Validate(updateActorDTO);
            GenericResponse<bool> response = new(true);
            if (result.IsValid)
            {
                response = await actorService.UpdateActor(updateActorDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [HttpGet("AllActor")]
        public async Task<IActionResult> GetAllActor() => Ok(actorService.GetAll());

        [HttpDelete("DeleteActor")]
        public async Task<IActionResult> DeleteActor(string id)
        {

            GenericResponse<bool> response = new(true);
            if (!string.IsNullOrEmpty(id))
            {
                response = await actorService.DeleteActor(id);
            }
            else
            {
                response.Message = Messages.IdFail;
                response.IsSuccess = false;
            }
            return Ok(response);
        }
    }
}
