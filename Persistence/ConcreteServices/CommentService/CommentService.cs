using Application.DTOs.CommentDTOs;
using Application.Repositories.ICommentRepositories;
using Application.Repositories.IMovieRepositories;
using Application.Services;
using Application.Utilities.Constants;
using Application.Utilities.Response;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ConcreteServices.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ICommentReadRepository readRepository;
        private readonly ICommentWriteRepository writeRepository;
        private readonly UserManager<Customer> userManager;
        private readonly IMovieReadRepository movieReadRepository;
        private readonly IMapper mapper;

        public CommentService(ICommentReadRepository readRepository, ICommentWriteRepository writeRepository, UserManager<Customer> userManager, IMovieReadRepository movieReadRepository, IMapper mapper)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.userManager = userManager;
            this.movieReadRepository = movieReadRepository;
            this.mapper = mapper;
        }
        public async Task<GenericResponse<bool>> CreateCommentAsync(CreateCommentDTO model)
        {
            GenericResponse<bool> response = new();
            Customer customer = await userManager.FindByIdAsync(model.CustomerId);
            Movie movie = await movieReadRepository.GetByIdAsync(model.MovieId);
            if (customer == null || movie == null)
            {
                response.IsSuccess = false;
                response.Message = Messages.NotExist;
                return response;
            }
            Comment comment = mapper.Map<Comment>(model);
            comment.Customer=customer;
            comment.Movie=movie;
            await writeRepository.AddAsync(comment);
            bool result = await writeRepository.SaveAsync() > 0;
            if (result) response.Message = Messages.AddSucceeded;
            else
            {
                response.Message = Messages.SaveFail;
                response.IsSuccess = result;
            }
            return response;
        }

        public async Task<GenericResponse<bool>> DeleteCommentAsync(string id)
        {
           var comment = await readRepository.GetByIdAsync(id);
            GenericResponse<bool> response = new(true);
            if (comment == null)
            {
                response.IsSuccess = false;
                response.Message = Messages.NotExist;
                return response;
            }
            else
            {
                bool result = await writeRepository.RemoveAsync(id);
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.DeleteSucceeded;
                else
                {
                    response.Message = Messages.Fail;
                    response.IsSuccess = result;
                }
            }
            return response;
        }

        public async Task<GenericResponse<bool>> UpdateCommentAsync(UpdateCommentDTO model)
        {
            GenericResponse<bool> response = new();
            Comment comment= await readRepository.GetByIdAsync(model.Id);

            if (comment == null)
            {
                response.IsSuccess = false;
                response.Message = Messages.NotExist;
                return response;
            }
            mapper.Map(model,comment);           
            bool result = await writeRepository.SaveAsync() > 0;
            if (result) response.Message = Messages.UpdateSucceeded;
            else
            {
                response.Message = Messages.SaveFail;
                response.IsSuccess = result;
            }
            return response;
        }
    }
}
