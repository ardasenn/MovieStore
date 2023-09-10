using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ActorDTOs
{
    public class UpdateActorDTO
    {
        public UpdateActorDTO()
        {

        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
    }

    public class UpdateActorDTOValidator : AbstractValidator<UpdateActorDTO>
    {
        public UpdateActorDTOValidator()
        {
            RuleFor(a => a.Id).NotEmpty().NotNull();
            RuleFor(a => a.FirstName).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(a => a.LastName).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}
