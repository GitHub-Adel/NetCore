using FluentValidation;
using SocialMedia.Core.DTO;

namespace SocialMedia.Infrastructure.Validator
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(p => p.Firstname).NotEmpty().WithMessage("El Firstname no puede quedar vacío");
        }
    }
}
