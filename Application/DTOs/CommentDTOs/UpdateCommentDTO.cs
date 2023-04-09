using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CommentDTOs
{
    public class UpdateCommentDTO
    {
        public string Id { get; set; }
        public Movie Movie { get; set; }
        public Customer Customer { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; } = 1;
    }
}
