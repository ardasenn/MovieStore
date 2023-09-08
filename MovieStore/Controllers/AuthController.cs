using Application.DTOs;
using Application.DTOs.AuthDTOs;
using Application.DTOs.CustomerDTOs;
using Application.Services;
using Application.Utilities.Helper;
using Application.Utilities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.ConcreteServices.ActorService;
using static System.Net.Mime.MediaTypeNames;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public AuthController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            LoginDTOValidator validator = new();
            var result = validator.Validate(loginDTO);
            GenericResponse<Application.DTOs.Token> response = new();
            if (result.IsValid)
            {
                response = await customerService.LoginCustomer(loginDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
            }
            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateCustomerDTO createCustomerDTO)
        {
            CreateCustomerDTOValidator validator = new();
            var result = validator.Validate(createCustomerDTO);
            GenericResponse<bool> response = new(true);
            if (result.IsValid)
            {
                response = await customerService.CreateCustomerAsync(createCustomerDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = false;
            }
            return Ok(response);
        }
    }
}
