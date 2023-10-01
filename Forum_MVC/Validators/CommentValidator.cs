using DataAccess.Data.Entities;
using FluentValidation;

namespace Forum_MVC.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id field is required.");
            RuleFor(x => x.Text).NotNull().WithMessage("Text field is required.");
            RuleFor(x => x.ImageUrl)
                .MaximumLength(255).When(x => !string.IsNullOrEmpty(x.ImageUrl))
                .WithMessage("Image URL cannot exceed 255 characters.")
                .Must(ValidateUri).When(x => !string.IsNullOrEmpty(x.ImageUrl))
                .WithMessage("ImageUrl must be a valid URL address");
            RuleFor(x => x.LikeCount)
                .GreaterThanOrEqualTo(0).WithMessage("LikeCount must be a non-negative number.");
            RuleFor(x => x.DislikeCount)
                .GreaterThanOrEqualTo(0).WithMessage("DislikeCount must be a non-negative number.");
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId field is required.");
            //RuleFor(x => x.PostId).NotNull().WithMessage("PostId field is required.");
            RuleFor(x => x.PostStatisticsId).NotNull().WithMessage("PostStatisticsId field is required.");
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
