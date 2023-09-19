using Application.DTOs.CustomerDTOs;
using Application.DTOs.GiveOrderDTO;
using Application.Services;
using Application.Utilities.Constants;
using Application.Utilities.Helper;
using Application.Utilities.Response;
using Application.VMs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }


        [HttpPost("GiveOrder")]
        public async Task<IActionResult> GiveOrder(GiveOrderDTO giveOrderDTO)
        {
            GenericResponse<bool> response = new();
            GiveOrderDTOValidator validator = new();
            var result = validator.Validate(giveOrderDTO);
            if (result.IsValid)
                response = await customerService.CreateOrderAsync(giveOrderDTO);
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = response.Data = false;
            }
            return Ok(response);
        }
        [HttpGet("MyMovies")]
        public async Task<IActionResult> MyMovies(string userId)
        {
            GenericResponse<List<UserMovie>> response = new();
            if (!string.IsNullOrEmpty(userId))
            {
                response = await customerService.GetUserMovie(userId);
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
