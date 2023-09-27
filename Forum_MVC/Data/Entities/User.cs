using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum_MVC.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The field 'Username' is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must Post between 3 and 50 characters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "The field 'Password' is required")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must Post between 8 and 50 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email field is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [MaxLength(255, ErrorMessage = "Image URL cannot exceed 255 characters.")]
        public string? ImageUrl { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public int? PostStatisticsId { get; set; }
        [ForeignKey("PostStatisticsId")]
        public PostStatistics? PostStatistics { get; set; }
    }
}
