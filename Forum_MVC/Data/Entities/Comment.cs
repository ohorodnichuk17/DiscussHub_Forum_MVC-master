using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum_MVC.Data.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The 'Text' field is required.")]
        public string Text { get; set; }
        [MaxLength(255, ErrorMessage = "Image URL cannot exceed 255 characters.")]
        public string? ImageUrl { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "LikeCount must be a non-negative number.")]
        public int LikeCount { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "DislikeCount must be a non-negative number.")]
        public int DislikeCount { get; set; }


        [Required(ErrorMessage = "The 'UserId' field is required.")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }

        public int? PostStatisticsId { get; set; }
        [ForeignKey("PostStatisticsId")]
        public PostStatistics? PostStatistics { get; set; }
    }
}
