using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.VMs
{
    public class UserMovie
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string DirectorId { get; set; }
        public decimal Price { get; set; }
        public double Imdb { get; set; }
        public Guid Id { get; set; }
        public string DirectorFullName { get; set; }
    }
}