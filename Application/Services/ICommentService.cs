using Application.DTOs.CommentDTOs;
using Application.Utilities.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICommentService
    {
        Task<GenericResponse<bool>> CreateComment(CreateCommentDTO model);
        Task<GenericResponse<bool>> UpdateComment(UpdateCommentDTO model);
        Task<GenericResponse<bool>> DeleteComment(DeleteCommentDTO model);
        List<Comment> GetAll();
    }
}
