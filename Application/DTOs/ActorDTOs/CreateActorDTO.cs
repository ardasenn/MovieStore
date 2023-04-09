using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ActorDTOs
{
    public class CreateActorDTO
    {
        public CreateActorDTO()
        {
            Movies = new List<Movie>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDirector { get; set; }=false;
        public List<Movie> Movies { get; set; }
    }
}
