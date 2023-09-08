using Application.Utilities.Constants;
using Application.DTOs.MovieDTOs;
using Application.Repositories.IMovieRepositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Utilities.Response;
using Application.Repositories.IActorRepositories;
using Microsoft.EntityFrameworkCore;
using Application.Repositories.IGenreRepositories;
using Application.VMs;

namespace Persistence.ConcreteServices.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieReadRepository readRepository;
        private readonly IMovieWriteRepository writeRepository;
        private readonly IMapper mapper;
        private readonly IActorReadRepository actorReadRepository;
        private readonly IGenreReadRepository genreReadRepository;

        public MovieService(IMovieReadRepository readRepository, IMovieWriteRepository writeRepository, IMapper mapper, IActorReadRepository actorReadRepository, IGenreReadRepository genreReadRepository)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.mapper = mapper;
            this.actorReadRepository = actorReadRepository;
            this.genreReadRepository = genreReadRepository;
        }
        public async Task<GenericResponse<bool>> CreateMovie(CreateMovieDTO model)
        {
            var movie = readRepository.GetSingleAsync(a => a.Name.ToLower() == model.Name.ToLower());

            var actorList = actorReadRepository.GetAll();
            var genreList = genreReadRepository.GetAll();
            GenericResponse<bool> response = new();

            if (movie != null)
            {
                response.IsSuccess = false;
                response.Message = Messages.Exist;
            }
            else
            {
                Movie newMovie = mapper.Map<Movie>(model);
                foreach (string actorId in model.ActorIds)//filme aktorleri ekleme
                {
                    var actor = await actorList.FirstOrDefaultAsync(a => a.Id.ToString() == actorId);
                    if (actor != null)
                        newMovie.Actors.Add(actor);
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = string.Format("{0} {1}", actorId, Messages.NotExist);
                        return response;
                    }
                }
                foreach (string genreId in model.GenreIds)//filme genre ekleme
                {
                    var genre = await genreList.FirstOrDefaultAsync(a => a.Id.ToString() == genreId);
                    if (genre != null)
                        newMovie.Genres.Add(genre);
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = string.Format("{0} {1}", genreId, Messages.NotExist);
                        return response;
                    }
                }
                bool result = await writeRepository.AddAsync(newMovie);
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.AddSucceeded;
                else
                {
                    response.Message = Messages.SaveFail;
                    response.IsSuccess = result;
                }
            }
            return response;
        }

        public async Task<GenericResponse<bool>> UpdateMovie(UpdateMovieDTO model)
        {
            var movie = await readRepository.GetByIdAsync(model.Id);
            GenericResponse<bool> response = new();
            if (movie == null)
            {
                response.IsSuccess = false;
                response.Message = Messages.NotExist;
            }
            else
            {
                mapper.Map(model, movie);
                bool result = writeRepository.Update(movie);
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.UpdateSucceeded;
                else
                {
                    response.Message = Messages.SaveFail;
                    response.IsSuccess = result;
                }
            }
            return response;
        }
        public async Task<GenericResponse<bool>> DeleteMovie(DeleteMovieDTO model)
        {
            var movie = await readRepository.GetByIdAsync(model.Id);
            GenericResponse<bool> response = new();
            if (movie == null)
            {
                response.IsSuccess = false;
                response.Message = Messages.NotExist;
            }
            else
            {
                bool result = await writeRepository.RemoveAsync(model.Id);
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

        public List<Movie> GetAll() => readRepository.GetAll().ToList();

    }
}
