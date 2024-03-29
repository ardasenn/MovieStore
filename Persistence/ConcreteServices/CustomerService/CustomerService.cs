﻿using Application.Utilities.Constants;
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
using Application.DTOs.GiveOrderDTO;
using Application.Repositories.IMovieRepositories;
using Application.Repositories.IOrderRepositories;
using Application.VMs;
using Application.Repositories.IActorRepositories;
using System.Collections.Generic;

namespace Persistence.ConcreteServices.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<Customer> userManager;
        private readonly IMapper mapper;
        private readonly ITokenGeneratorService tokenGenerator;
        private readonly IMovieReadRepository movieReadRepository;
        private readonly IOrderWriteRepository orderWriteRepository;
        private readonly IOrderReadRepository orderReadRepository;
        private readonly IActorReadRepository actorReadRepository;

        public CustomerService(UserManager<Customer> userManager, IMapper mapper, ITokenGeneratorService tokenGenerator, IMovieReadRepository movieReadRepository, IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, IActorReadRepository actorReadRepository)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.tokenGenerator = tokenGenerator;
            this.movieReadRepository = movieReadRepository;
            this.orderWriteRepository = orderWriteRepository;
            this.orderReadRepository = orderReadRepository;
            this.actorReadRepository = actorReadRepository;
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

        public async Task<GenericResponse<bool>> CreateOrderAsync(GiveOrderDTO model)
        {
            GenericResponse<bool> response = new();
            var customer = await userManager.FindByIdAsync(model.CustomerId);
            if (customer is null)
            {
                response.Message = Messages.IdFail;
                response.IsSuccess = response.Data = false;
            }
            else
            {
                decimal totalPrice = 0;
                Order order = new()
                {
                    Customer = customer
                };
                var movieList = movieReadRepository.GetAll().ToList();
                foreach (string item in model.MovieIds)
                {
                    var movie = movieList.Where(a => a.Id.ToString() == item).FirstOrDefault();
                    if (movie is null)
                    {
                        response.Message = string.Format("{0} id {1}", item, Messages.NotExist);
                        response.Data = response.IsSuccess = false;
                        return response;
                    }
                    totalPrice += movie.Price;
                    order.MovieList.Add(movie);
                    movie.SalesQuantity++;
                }
                if (customer.Balance < totalPrice)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.BalanceFail;
                    return response;
                }
                customer.Balance -= totalPrice;
                var result = await orderWriteRepository.AddAsync(order);
                await orderWriteRepository.SaveAsync();
                if (result) response.Message = Messages.AddSucceeded;
                else
                {
                    response.IsSuccess = result;
                    response.Message = Messages.SaveFail;
                }
            }
            return response;
        }

        public async Task<GenericResponse<List<UserMovie>>> GetUserMovie(string id)
        {
            GenericResponse<List<UserMovie>> response = new();
            response.Data = new();
            var customer = await userManager.FindByIdAsync(id);
            var actorList = actorReadRepository.GetAll().ToList();
            if (customer is null)
            {
                response.Message = Messages.NotExist;
                response.IsSuccess = false;
            }
            else
            {
                List<Order> orderList = orderReadRepository.GetWhere(a => a.Customer.Id.ToString() == id).ToList();
                foreach (var item in orderList)
                {
                    response.Data.AddRange(mapper.Map<List<UserMovie>>(item.MovieList));
                }
                foreach (var item in response.Data)
                {
                    item.DirectorFullName = actorList.Where(a => a.Id.ToString() == item.DirectorId).Select(a => new
                    {
                        FullName = a.FirstName + " " + a.LastName
                    }).FirstOrDefault().FullName;
                }
            }
            return response;
        }

        public async Task<GenericResponse<Application.DTOs.Token>> LoginCustomerAsync(LoginDTO model)
        {
            GenericResponse<Application.DTOs.Token> response = new();
            Customer customer = await userManager.FindByEmailAsync(model.Email);
            if (customer == null)
            {
                response.IsSuccess = false;
                response.Message = Messages.NotExist;
                return response;
            }
            bool isLogin = await userManager.CheckPasswordAsync(customer, model.Password);
            if (!isLogin)
            {
                response.IsSuccess = false;
                response.Message = Messages.LoginFail;
                return response;
            }
            await userManager.RemoveAuthenticationTokenAsync(customer, "Movie", "AccessToken");
            Token token = tokenGenerator.CreateAccesToken(60 * 60, customer);
            token.Id = customer.Id;
            await userManager.SetAuthenticationTokenAsync(customer, "Movie", "AccessToken", token.AccessToken);
            response.IsSuccess = true;
            response.Data = token;


            return response;


        }
        public async Task<GenericResponse<List<OrderVM>>> GetUserOrder(string id)
        {
            GenericResponse<List<OrderVM>> response = new();

            var customer = await userManager.FindByIdAsync(id);
            if (customer is null)
            {
                response.Message = Messages.NotExist;
                response.IsSuccess = false;
                return response;
            }
            List<Order> orderList = orderReadRepository.GetWhereIncludeMovie(id);
            List<OrderVM> resData = mapper.Map<List<OrderVM>>(orderList);
            response.Data = resData;

            return response;
        }
        public async Task<GenericResponse<CustomerVM>> GetUserDetails(string id)
        {
            GenericResponse<CustomerVM> response = new();

            var customer = await userManager.FindByIdAsync(id);
            if (customer is null)
            {
                response.Message = Messages.NotExist;
                response.IsSuccess = false;
                return response;
            }
            List<Order> orderList = orderReadRepository.GetWhereIncludeMovie(id);
            CustomerVM customerVM = mapper.Map<CustomerVM>(customer);
            customerVM.OrdersCount = orderList.Count;
            response.Data = customerVM;

            return response;
        }

    }
}
