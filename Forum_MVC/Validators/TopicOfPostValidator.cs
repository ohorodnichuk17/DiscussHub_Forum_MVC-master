using DataAccess.Data.Entities;
using FluentValidation;

namespace Forum_MVC.Validators
{
    public class TopicOfPostValidator : AbstractValidator<TopicOfPost>
    {
        public TopicOfPostValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id field is required.");
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name field is required.")
                .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");
            RuleFor(x => x.Description)
                .NotNull().WithMessage("Description field is required.")
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId field is required.");
            RuleFor(x => x.VisibilityStatus)
                .NotNull().WithMessage("VisibilityStatus field is required.");
            //RuleFor(x => x.PostId).NotNull().WithMessage("PostId field is required.");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("CategoryId field is required.");

        }
    }
}
