using System.ComponentModel.DataAnnotations;

namespace Forum_MVC.Data.Entities
{
    public class PostStatistics
    {
        [Key]
        public int Id { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "LikeCount must be a non-negative number.")]
        public int LikeCount { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "DislikeCount must be a non-negative number.")]
        public int DislikeCount { get; set; }
    }
}
