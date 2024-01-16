using Application.DTOs.ActorDTOs;
using Application.Repositories.IActorRepositories;
using Application.Services;
using Application.Utilities.Constants;
using Application.Utilities.Response;
using Application.VMs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ConcreteServices.ActorService
{
    public class ActorService : IActorService
    {
        private readonly IActorWriteRepository writeRepository;
        private readonly IActorReadRepository readRepository;
        private readonly IMapper mapper;


        public ActorService(IActorWriteRepository writeRepository, IActorReadRepository readRepository, IMapper mapper)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
            this.mapper = mapper;

        }
        public async Task<GenericResponse<bool>> CreateActor(CreateActorDTO model)
        {
            var actor = await readRepository.GetSingleAsync(a => a.FirstName.ToLower() == model.FirstName.ToLower().Trim() && a.LastName.ToLower() == model.LastName.ToLower().Trim());

            GenericResponse<bool> response = new(true);
            if (actor != null)
            {
                response.IsSuccess = false;
                response.Message = Messages.Exist;
            }
            else
            {
                bool result = await writeRepository.AddAsync(mapper.Map<Actor>(model));
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.AddSucceeded;
                else
                {
                    response.IsSuccess = result;
                    response.Message = Messages.SaveFail;
                }
            }
            return response;
        }
        public async Task<object> IsActorExist(string name, string lastName)
        {
            Actor actor = await readRepository.GetSingleAsync(a => a.FirstName.ToLower() == name.ToLower().Trim() && a.LastName.ToLower() == lastName.ToLower().Trim());
            if (actor != null) return actor.Id;
            else return false;
        }
        public GenericResponse<List<ActorVM>> GetAll()
        {
            GenericResponse<List<ActorVM>> response = new(true);
            var data = readRepository.GetAll();
            response.Data = mapper.Map<List<ActorVM>>(data);
            return response;
        }

        public async Task<GenericResponse<bool>> UpdateActor(UpdateActorDTO model)
        {
            var actor = await readRepository.GetByIdAsync(model.Id.ToString());
            GenericResponse<bool> response = new(true);
            if (actor == null)
            {
                response.IsSuccess = false;
                response.Message = Messages.NotExist;
            }
            else
            {
                mapper.Map(model, actor);
                bool result = writeRepository.Update(actor);
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.UpdateSucceeded;
                else
                {
                    response.IsSuccess = result;
                    response.Message = Messages.SaveFail;
                }
            }
            return response;
        }
        public async Task<GenericResponse<bool>> DeleteActor(string id)
        {
            var actor = await readRepository.GetByIdAsync(id);
            GenericResponse<bool> response = new(true);
            if (actor == null)
            {
                response.IsSuccess = false;
                response.Message = Messages.NotExist;
            }
            else
            {
                bool result = await writeRepository.RemoveAsync(id);
                await writeRepository.SaveAsync();
                if (result) response.Message = Messages.DeleteSucceeded;
                else
                {
                    response.IsSuccess = result;
                    response.Message = Messages.SaveFail;
                }

            }
            return response;
        }
        public GenericResponse<ActorVM> GetActor(string id)
        {
            GenericResponse<ActorVM> response = new(true);
            Actor actor = readRepository.GetInclude(id).Data;
            if(actor == null)
            {
                response.IsSuccess = false;
                response.Message = Messages.NotExist;
            }
            response.Data = mapper.Map<ActorVM>(actor);
            return response;
        }
    }
}
