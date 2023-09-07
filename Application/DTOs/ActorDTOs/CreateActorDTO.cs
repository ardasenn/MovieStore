using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ActorDTOs
{
    public class CreateActorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDirector { get; set; } = false;
       
    }
    public class CreateActorDTOValidator : AbstractValidator<CreateActorDTO>
    {
        public CreateActorDTOValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(a => a.LastName).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}
