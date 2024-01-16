using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VMs
{
    public class OrderVM
    {
        public Guid Id { get; set; }
        public List<UserMovie> MovieList { get; set; }
    }
}
