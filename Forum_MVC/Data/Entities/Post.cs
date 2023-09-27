//using Forum_MVC.Data.Entities;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;

//namespace Forum_MVC.Data.Entities
//{
//    public class Post
//    {
//        [Key]
//        public int Id { get; set; }

//        [Required(ErrorMessage = "The 'Title' field is required.")]
//        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
//        public string Title { get; set; }

//        [Required(ErrorMessage = "The 'Text' field is required.")]
//        public string Text { get; set; }

//        [MaxLength(255, ErrorMessage = "Image URL cannot exceed 255 characters.")]
//        public string? ImageUrl { get; set; }

//        [Required(ErrorMessage = "The 'UserId' field is required.")]
//        public int UserId { get; set; }

//        public int? PostStatisticsId { get; set; }

//        [ForeignKey("PostStatisticsId")]
//        public PostStatistics? PostStatistics { get; set; }

//        [ForeignKey("UserId")]
//        public User User { get; set; }

//        public int TopicOfPostId { get; set; }
//        [ForeignKey("TopicOfPostId")]
//        public TopicOfPost Topic { get; set; }

//        public ICollection<Comment> Comments { get; set; }

//        public int CategoryId { get; set; }

//        [ForeignKey("CategoryId")]
//        public Category Categories { get; set; }
//    }
//}

using Forum_MVC.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Post
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "The 'Title' field is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "The 'Text' field is required.")]
    public string Text { get; set; }

    [MaxLength(255, ErrorMessage = "Image URL cannot exceed 255 characters.")]
    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "The 'UserId' field is required.")]
    public int UserId { get; set; }

    public int? PostStatisticsId { get; set; }

    [ForeignKey("PostStatisticsId")]
    public PostStatistics? PostStatistics { get; set; }

    public int? TopicOfPostId { get; set; }
    [ForeignKey("TopicOfPostId")]
    public TopicOfPost? Topic { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    public ICollection<Comment> Comments { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Categories { get; set; }
}
