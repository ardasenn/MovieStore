using Application.DTOs.ActorDTOs;
using Application.Utilities.Response;
using Application.VMs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IActorService
    {
        Task<GenericResponse<bool>> CreateActor(CreateActorDTO model);
        Task<GenericResponse<bool>> UpdateActor(UpdateActorDTO model);
        //Task<DeleteActorResponse> DeleteActor(DeleteActorDTO model);
        /// <summary>
        /// If Actor is exist returns actorId(Guid). If Actor isn't exist returns false
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        Task<object> IsActorExist(string name, string lastName);
        GenericResponse<List<ActorVM>> GetAll();
    }
}
