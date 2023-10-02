using FluentValidation;
using Forum_MVC.Models;

namespace Forum_MVC.Validators
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Email field is required");
            RuleFor(x => x.Password).NotNull().WithMessage("Password field is required");
        }
    }
}
