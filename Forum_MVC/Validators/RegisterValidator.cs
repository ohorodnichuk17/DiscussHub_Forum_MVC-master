using FluentValidation;
using Forum_MVC.Models;

namespace Forum_MVC.Validators
{
    public class RegisterValidator : AbstractValidator<Register>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("Username field is required");
            RuleFor(x => x.Password).NotNull().WithMessage("Password field is required")
                                   .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
            RuleFor(x => x.Email).NotNull().WithMessage("Email field is required")
                                .EmailAddress().WithMessage("Invalid email address format");
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Confirm Password field is required")
                                           .Equal(x => x.Password).WithMessage("Passwords don't match");
        }
    }
}
