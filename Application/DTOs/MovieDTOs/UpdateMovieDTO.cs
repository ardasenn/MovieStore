using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MovieDTOs
{
    public class UpdateMovieDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DirectorId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> ActorsId { get; set; }
        public List<string> GenresId { get; set; }
        public decimal Price { get; set; }
        public double Imdb { get; set; }
    }
    public class UpdateMovieDTOValidator : AbstractValidator<UpdateMovieDTO>
    {
        public UpdateMovieDTOValidator()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(a => a.ReleaseDate).NotNull().NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(a => a.DirectorId).NotNull().NotEmpty();
            RuleFor(a => a.Price).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(a => a.Imdb).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
