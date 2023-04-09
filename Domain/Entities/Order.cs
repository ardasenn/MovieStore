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
    public class Order : IEntity
    {
        public Order()
        {
            MovieList = new List<Movie>();
        }
        public Guid Id { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.OnBasket;
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
        public List<Movie> MovieList { get; set; }
        public Customer Customer { get; set; }
    }
}
