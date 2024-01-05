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
        Task<GenericResponse<bool>> CreateCommentAsync(CreateCommentDTO model);
        Task<GenericResponse<bool>> UpdateCommentAsync(UpdateCommentDTO model);
        Task<GenericResponse<bool>> DeleteCommentAsync(string id);
    }
}
