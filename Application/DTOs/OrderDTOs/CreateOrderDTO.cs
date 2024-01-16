using Application.DTOs.MovieDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OrderDTOs
{
    public class CreateOrderDTO
    {
        public List<string> MovieIds { get; set; }
        public string CustomerId { get; set; }

    }
    public class CreateOrderDTOValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderDTOValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().NotNull();
            RuleFor(a => a.MovieIds).NotEmpty().NotNull();
        }
    }
}
