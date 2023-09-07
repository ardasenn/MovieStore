using Application.DTOs.AuthDTOs;
using Application.DTOs.CustomerDTOs;
using Application.Utilities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICustomerService
    {
        Task<GenericResponse<bool>> CreateCustomerAsync(CreateCustomerDTO model);
        Task<GenericResponse<Application.DTOs.Token>> LoginCustomer(LoginDTO model);
    }
}
