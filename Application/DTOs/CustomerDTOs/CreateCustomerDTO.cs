using Application.DTOs.ActorDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CustomerDTOs
{
    public class CreateCustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public int PhoneNumber { get; set; }
    }
    public class CreateCustomerDTOValidator : AbstractValidator<CreateCustomerDTO>
    {
        public CreateCustomerDTOValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(a => a.LastName).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(a => a.Password).Equal(b => b.PasswordConfirm).NotNull().NotEmpty();
            RuleFor(a => a.PhoneNumber).NotEmpty();
            //todo validasyonlar
        }
    }
}
