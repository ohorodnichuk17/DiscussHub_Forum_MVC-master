using DataAccess.Data.Entities;
using FluentValidation;

namespace Forum_MVC.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username)
                .NotNull().WithMessage("The 'Username' field is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("The 'Password' field is required.")
                .Length(8, 50).WithMessage("Password must be between 8 and 50 characters.");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email field is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.ImageUrl)
                .MaximumLength(255).When(x => !string.IsNullOrEmpty(x.ImageUrl))
                .WithMessage("Image URL cannot exceed 255 characters.");

            RuleFor(x => x.PostStatisticsId)
                .NotNull().WithMessage("PostStatisticsId field is required.");
        }
    }
}
