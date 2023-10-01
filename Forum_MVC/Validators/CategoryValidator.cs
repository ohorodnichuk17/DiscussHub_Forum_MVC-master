using DataAccess.Data.Entities;
using FluentValidation;

namespace Forum_MVC.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id field is required.");
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name field is required.")
                .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");
            RuleFor(x => x.AmountOfTopics).NotNull().WithMessage("AmountOfTopics field is required.");
            RuleFor(x => x.VisibilityStatus).NotNull().WithMessage("VisibilityStatus field is required.");
        }
    }
}
