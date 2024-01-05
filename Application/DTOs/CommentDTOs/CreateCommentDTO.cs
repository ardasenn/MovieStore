using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CommentDTOs
{
    public class CreateCommentDTO
    {
        public string MovieId { get; set; }
        public string CustomerId { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; } = 1;
    }

    public class CreateCommentDTOValidator : AbstractValidator<CreateCommentDTO> 
    {
        public CreateCommentDTOValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x=> x.Text).NotEmpty().MinimumLength(1).MaximumLength(1000);
            RuleFor(x=>x.Rate).GreaterThanOrEqualTo(1);
        }
    }
}
