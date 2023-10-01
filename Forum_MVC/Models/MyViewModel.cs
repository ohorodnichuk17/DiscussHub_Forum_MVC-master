using DataAccess.Data.Entities;

namespace Forum_MVC.Models
{
    public class MyViewModel
    {
        public List<Post> Posts { get; set; }
        public List<Category> Categories { get; set; }
        public List<TopicOfPost> TopicOfPosts { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPosts { get; set; }
        public TopicOfPost SelectedTopic { get; set; }
        public int SelectedTopicId { get; set; } 
        public int SelectedCategoryId { get; set; }
    }
}
