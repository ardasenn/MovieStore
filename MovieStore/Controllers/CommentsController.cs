using Application.DTOs.CommentDTOs;
using Application.Services;
using Application.Utilities.Constants;
using Application.Utilities.Helper;
using Application.Utilities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.ConcreteServices.CommentService;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CreateCommentDTO createCommentDTO)
        {
            CreateCommentDTOValidator validator = new();
            var result = validator.Validate(createCommentDTO);
            GenericResponse<bool> response = new();
            if (result.IsValid)
            {
                response = await commentService.CreateCommentAsync(createCommentDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [HttpPut("UpdateComment")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDTO updateCommentDTO)
        {
            UpdateCommentDTOValidator validator = new();
            var result = validator.Validate(updateCommentDTO);
            GenericResponse<bool> response = new();
            if (result.IsValid)
            {
                response = await commentService.UpdateCommentAsync(updateCommentDTO);
            }
            else
            {
                response.ValidationErrors = result.Errors.GetValidationErrors();
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [HttpDelete("DeleteComment")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            GenericResponse<bool> response = new();
            if (!string.IsNullOrEmpty(id))
                response = await commentService.DeleteCommentAsync(id);
            else
            {
                response.Message = Messages.Fail;
                response.IsSuccess = false;
            }
            return Ok(response);
        }
    }
}
