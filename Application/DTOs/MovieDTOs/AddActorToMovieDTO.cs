using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MovieDTOs
{
    public class AddActorToMovieDTO
    {
        public string MovieId { get; set; }
        public List<string> ActorIds { get; set; }

    }
    public class AddActorToMovieDTOValidator : AbstractValidator<AddActorToMovieDTO>
    {
        public AddActorToMovieDTOValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty().NotNull();
            RuleFor(a => a.ActorIds).NotEmpty().NotNull();
        }
    }
}
