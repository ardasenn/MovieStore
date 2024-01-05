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
        public List<GenreVM> Genres { get; set; }
        public string DirectorId { get; set; }
        public string DirectorFullName { get; set; }
        public List<ActorSummaryVM> Actors { get; set; }
        public List<CommentVM> Comments { get; set; }
        public decimal Price { get; set; }
        public double Imdb { get; set; }
        public Guid Id { get; set; }
        public int SalesQuantity { get; set; }
    }
}
