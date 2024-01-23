using Application.DTOs.AuthDTOs;
using Application.DTOs.CustomerDTOs;
using Application.DTOs.GiveOrderDTO;
using Application.Utilities.Response;
using Application.VMs;
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
        Task<GenericResponse<Application.DTOs.Token>> LoginCustomerAsync(LoginDTO model);
        Task<GenericResponse<bool>> CreateOrderAsync(GiveOrderDTO model);
        Task<GenericResponse<List<UserMovie>>> GetUserMovie(string id);
        Task<GenericResponse<List<OrderVM>>> GetUserOrder(string id);
        Task<GenericResponse<CustomerVM>> GetUserDetails(string id);
    }
}
