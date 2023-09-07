using Application.Utilities.Constants;
using Application.DTOs.CustomerDTOs;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Application.Utilities.Response;
using Microsoft.AspNetCore.Identity;
using Application.DTOs.AuthDTOs;
using FluentValidation;
using Application.Utilities.Helper;
using Application.DTOs;

namespace Persistence.ConcreteServices.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<Customer> userManager;
        private readonly IMapper mapper;
        private readonly ITokenGeneratorService tokenGenerator;

        public CustomerService(UserManager<Customer> userManager, IMapper mapper, ITokenGeneratorService tokenGenerator)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.tokenGenerator = tokenGenerator;
        }
        public async Task<GenericResponse<bool>> CreateCustomerAsync(CreateCustomerDTO model)
        {
            Customer customer = mapper.Map<Customer>(model);
            IdentityResult result = await userManager.CreateAsync(customer, model.Password);
            GenericResponse<bool> response = new();
            if (result.Succeeded) response.Message = Messages.AddSucceeded;
            else
            {
                response.IsSuccess = false;
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";
            }
            return response;
        }

        public async Task<GenericResponse<Application.DTOs.Token>> LoginCustomer(LoginDTO model)
        {
            GenericResponse<Application.DTOs.Token> response = new();
            Customer customer = await userManager.FindByEmailAsync(model.Email);
            if (customer == null)
            {
                response.Message = Messages.NotExist;
                return response;
            }
            bool isLogin = await userManager.CheckPasswordAsync(customer, model.Password);
            if (!isLogin)
            {
                response.Message = Messages.LoginFail;
                return response;
            }
            await userManager.RemoveAuthenticationTokenAsync(customer, "Movie", "AccessToken");
            Token token = tokenGenerator.CreateAccesToken(60 * 60);
            await userManager.SetAuthenticationTokenAsync(customer, "Movie", "AccessToken", token.AccessToken);
            response.IsSuccess = true;
            response.Data = token;


            return response;


        }
    }
}
