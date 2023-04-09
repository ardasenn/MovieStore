using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MovieDTOs
{
    public class CreateMovieDTO
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string DirectorId { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Genre> Genres { get; set; }
        public decimal Price { get; set; }
        public double Imdb { get; set; }
    }
}
