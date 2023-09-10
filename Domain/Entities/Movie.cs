using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie : IEntity
    {
        public Movie()
        {
            Actors = new List<Actor>();
            Orders = new List<Order>();
            Genres = new List<Genre>();
            Comments = new List<Comment>();
        }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Order> Orders { get; set; }
        public List<Genre> Genres { get; set; }
        public string DirectorId { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Comment> Comments { get; set; }
        public decimal Price { get; set; }
        public double Imdb { get; set; }
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; } 
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
        public int SalesQuantity { get; set; }=0;
    }
}
