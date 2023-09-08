using Application.DTOs.ActorDTOs;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MovieDTOs
{
    public class CreateMovieDTO
    {
        public string Name { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string DirectorId { get; set; } = null!;
        public List<string>? ActorIds { get; set; }
        public List<string>? GenreIds { get; set; }
        public decimal Price { get; set; }
        public double Imdb { get; set; }
    }
    public class CreateMovieDTOValidator : AbstractValidator<CreateMovieDTO>
    {
        public CreateMovieDTOValidator()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(a => a.ReleaseDate).NotNull().NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(a => a.DirectorId).NotNull().NotEmpty();
            RuleFor(a => a.Price).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(a => a.Imdb).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
