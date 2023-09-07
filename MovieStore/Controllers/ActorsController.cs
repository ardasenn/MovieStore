using Application.DTOs.ActorDTOs;
using Application.Services;
using Application.Utilities.Helper;
using Application.Utilities.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ActorsController : ControllerBase
    {
        private readonly IActorService actorService;

        public ActorsController(IActorService actorService)
        {
            this.actorService = actorService;
        }
        [HttpPost("CreateActor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> CreateActor(CreateActorDTO createActorDTO)
        {
            CreateActorDTOValidator validator = new();
            var result = validator.Validate(createActorDTO);
            GenericResponse<bool> response = new();
            if (result.IsValid)
            {
                response = await actorService.CreateActor(createActorDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
            }
            return Ok(response);
        }
        [HttpPut("UpdateActor")]
        public async Task<IActionResult> UpdateActor(UpdateActorDTO updateActorDTO)
        {
            UpdateActorDTOValidator validator = new();
            var result = validator.Validate(updateActorDTO);
            GenericResponse<bool> response;
            if (result.IsValid)
            {
                response = await actorService.UpdateActor(updateActorDTO);
            }
            else
            {
                response = new();
                response.ValidationErrors = result.Errors.GetValidationErrors();
            }
            return Ok(response);
        }
    }
}
