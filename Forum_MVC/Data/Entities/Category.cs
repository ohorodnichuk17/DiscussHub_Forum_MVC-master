using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum_MVC.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public int AmountOfTopics { get; set; }

        //public int TopicOfPostId { get; set; }
        //[ForeignKey("TopicOfPostId")]
        public ICollection<TopicOfPost>? Topics { get; set; }
        [Required]
        public string VisibilityStatus { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
