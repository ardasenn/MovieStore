using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MovieDTOs
{
    public class AddGenreToMovieDTO
    {
        public string MovieId { get; set; }
        public List<string> GenreIds { get; set; }

    }
    public class AddGenreToMovieDTOValidator : AbstractValidator<AddGenreToMovieDTO>
    {
        public AddGenreToMovieDTOValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty().NotNull();
            RuleFor(a => a.GenreIds).NotEmpty().NotNull();
        }
    }
}
