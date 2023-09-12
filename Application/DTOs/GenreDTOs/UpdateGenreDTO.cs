using FluentValidation;

namespace Application.DTOs.GenreDTOs
{
    public class UpdateGenreDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateGenreDTOValidator : AbstractValidator<UpdateGenreDTO>
    {
        public UpdateGenreDTOValidator()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(a => a.Id).NotEmpty().NotNull();
        }
    }
}
