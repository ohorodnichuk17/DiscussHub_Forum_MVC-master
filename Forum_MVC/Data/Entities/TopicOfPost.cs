using Forum_MVC.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forum_MVC.Data.Entities
{
    public class TopicOfPost
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The 'Name' field is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }


        [Required(ErrorMessage = "The 'UserId' field is required.")]
        public int UserId { get; set; }

        // Active, Suspended
        public string VisibilityStatus { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public Post? Post { get; set; }

        public ICollection<Post> Posts { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}