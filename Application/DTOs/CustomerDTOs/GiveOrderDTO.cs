using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DTOs.GiveOrderDTO
{
    public class GiveOrderDTO
    {
        public string CustomerId { get; set; }
        public List<string> MovieIds { get; set; }
    }
    public class GiveOrderDTOValidator : AbstractValidator<GiveOrderDTO>
    {
        public GiveOrderDTOValidator()
        {
            RuleFor(a => a.CustomerId).NotEmpty().NotNull();
            RuleFor(a => a.MovieIds).NotEmpty().NotNull();
        }
    }
}