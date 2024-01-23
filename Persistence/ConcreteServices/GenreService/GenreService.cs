using Application.Utilities.Constants;
using Application.DTOs.GenreDTOs;
using Application.Repositories.IGenreRepositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Utilities.Response;
using Application.VMs;

namespace Persistence.ConcreteServices.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly IGenreReadRepository readRepository;
        private readonly IGenreWriteRepository writeRepository;
        private readonly IMapper mapper;

        public GenreService(IGenreReadRepository readRepository, IGenreWriteRepository writeRepository, IMapper mapper)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.mapper = mapper;
        }
        public async Task<GenericResponse<bool>> CreateGenreAsync(CreateGenreDTO model)
        {
            var genre = await readRepository.GetSingleAsync(a => a.Name.ToLower() == model.Name.ToLower());
            GenericResponse<bool> response = new();
            if (genre == null)
            {
                Genre newGenre = mapper.Map<Genre>(model);

                bool result = await writeRepository.AddAsync(newGenre);
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.AddSucceeded;
                else
                {
                    response.IsSuccess = false;
                    response.Message = Messages.SaveFail;
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Message = Messages.Exist;
            }
            return response;
        }

        public async Task<GenericResponse<bool>> UpdateGenreAsync(UpdateGenreDTO model)
        {
            var genre = await readRepository.GetByIdAsync(model.Id);
            GenericResponse<bool> response = new();
            if (genre == null)
            {
                response.IsSuccess = false;
                response.Message = Messages.NotExist;
            }
            else
            {
                var checkName = await readRepository.GetSingleAsync(a => a.Name.ToLower() == model.Name.ToLower());
                if (checkName == null)
                {
                    mapper.Map(model, genre);
                    bool result = writeRepository.Update(genre);
                    int zort = await writeRepository.SaveAsync();
                    if (result) response.Message = Messages.UpdateSucceeded;
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.SaveFail;
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = Messages.Exist;
                }
            }
            return response;
        }
        public async Task<GenericResponse<bool>> DeleteGenreAsync(string id)
        {
            var genre = await readRepository.GetByIdAsync(id);
            GenericResponse<bool> response = new();
            if (genre == null)
            {
                response.IsSuccess = false;
                response.Message = Messages.NotExist;
            }
            else
            {
                bool result = writeRepository.Remove(genre);
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.DeleteSucceeded;
                else
                { response.IsSuccess = false; response.Message = Messages.Fail; }
            }
            return response;
        }
        public GenericResponse<List<GenreVM>> GetAll()
        {
            GenericResponse<List<GenreVM>> response = new();
            var genreList = readRepository.GetAll().ToList();
            response.Data = mapper.Map<List<GenreVM>>(genreList);
            return response;
        }
    }
}
