using DataAccess.Data.Entities;
using FluentValidation;

namespace Forum_MVC.Validators
{
    public class PostStatisticsValidator : AbstractValidator<PostStatistics>
    {
        public PostStatisticsValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id field is required.");
            RuleFor(x => x.LikeCount).NotNull().WithMessage("LikeCount field is required.")
                                    .GreaterThanOrEqualTo(0).WithMessage("LikeCount must be a non-negative number.");
            RuleFor(x => x.DislikeCount).NotNull().WithMessage("DislikeCount field is required.")
                                       .GreaterThanOrEqualTo(0).WithMessage("DislikeCount must be a non-negative number.");
        }
    }
}
