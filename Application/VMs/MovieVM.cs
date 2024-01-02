using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VMs
{
    public class MovieVM
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Genre> Genres { get; set; }
        public string DirectorId { get; set; }
        public string DirectorFullName { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Comment> Comments { get; set; }
        public decimal Price { get; set; }
        public double Imdb { get; set; }
        public Guid Id { get; set; }
        public int SalesQuantity { get; set; } = 0;
    }
}
