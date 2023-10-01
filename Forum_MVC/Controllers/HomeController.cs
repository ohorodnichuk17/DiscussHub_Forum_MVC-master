using Forum_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataAccess.Data;
using DataAccess.Data.Entities;

namespace Forum_MVC.Controllers
{
    public class HomeController : Controller
    {
        ForumDbContext context = new ForumDbContext();

        public HomeController()
        {
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 3, int selectedCategoryId = 0, int selectedTopicId = 0)
        {
            var totalPosts = context.Posts.Count();

            var filteredPosts = context.Posts.AsQueryable();

            if (selectedCategoryId != 0)
            {
                filteredPosts = filteredPosts.Where(p => p.CategoryId == selectedCategoryId);
            }

            if (selectedTopicId != 0)
            {
                filteredPosts = filteredPosts.Where(p => p.TopicOfPostId == selectedTopicId);
            }

            var posts = filteredPosts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var categories = context.Categories.ToList();
            var topicOfPosts = context.TopicsOfPosts.ToList();

            MyViewModel viewModel = new MyViewModel
            {
                Posts = posts,
                Categories = categories,
                TopicOfPosts = topicOfPosts,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPosts = totalPosts,
                SelectedCategoryId = selectedCategoryId,
                SelectedTopicId = selectedTopicId,
                SelectedTopic = context.TopicsOfPosts.FirstOrDefault(t => t.Id == selectedTopicId)
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult SetSelectedTopic(int selectedTopicId, int selectedCategoryId)
        {
            return RedirectToAction("Index", new { selectedCategoryId = selectedCategoryId, selectedTopicId = selectedTopicId });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}