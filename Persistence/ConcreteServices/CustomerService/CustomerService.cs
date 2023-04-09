using Application.Utilities.Constants;
using Application.DTOs.CustomerDTOs;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Application.Utilities.Response;
using Microsoft.AspNetCore.Identity;

namespace Persistence.ConcreteServices.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<Customer> userManager;
        private readonly IMapper mapper;

        public CustomerService(UserManager<Customer> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
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
    }
}
