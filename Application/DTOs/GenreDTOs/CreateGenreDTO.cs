using FluentValidation;

namespace Application.DTOs.GenreDTOs
{
    public class CreateGenreDTO
    {
        public string Name { get; set; }
    }
    public class CreateGenreDTOValidator : AbstractValidator<CreateGenreDTO>
    {
        public CreateGenreDTOValidator()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}
