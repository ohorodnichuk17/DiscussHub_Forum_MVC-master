using DataAccess.Data.Entities;
using FluentValidation;

namespace Forum_MVC.Validators
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id field is required.");
            RuleFor(x => x.Title)
               .NotEmpty().WithMessage("The 'Title' field is required.")
               .Length(3, 100).WithMessage("Title must be between 3 and 100 characters.");
            RuleFor(x => x.ImageUrl).MaximumLength(255).When(x => !string.IsNullOrEmpty(x.ImageUrl))
                .WithMessage("Image URL cannot exceed 255 characters.")
                .Must(ValidateUri).When(x => !string.IsNullOrEmpty(x.ImageUrl))
                .WithMessage("ImageUrl must be a valid URL address");
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId field is required.");
            RuleFor(x => x.PostStatisticsId).NotNull().WithMessage("PostStatisticsId field is required.");
            RuleFor(x => x.TopicOfPostId).NotNull().WithMessage("TopicOfPostId field is required.");
        }

        private bool ValidateUri(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return true;
            }
            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
