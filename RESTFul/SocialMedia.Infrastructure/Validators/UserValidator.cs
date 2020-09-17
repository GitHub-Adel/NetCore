using System;
using FluentValidation;
using SocialMedia.Core.DTOs;

namespace SocialMedia.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(p => p.Firstname).NotEmpty().WithMessage("El Firstname no puede quedar vacío");
           // RuleFor(p => p.DayOfBirth).LessThan(DateTime.Now).WithMessage("DateOfBirth no puede quedar vacia");
        }
    }
}
