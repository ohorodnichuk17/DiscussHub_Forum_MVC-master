using DataAccess.Data;
using DataAccess.Data.Entities;
using Forum_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum_MVC.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ForumDbContext context;

        //public HomeController()
        //{
        //}

        public SettingsController(ForumDbContext context)
        {
            this.context = context;
        }

        //public IActionResult ProfileSettings()
        //{
        //    return View();
        //}

        public IActionResult ProfileSettings()
        {
            var posts = context.Posts.ToList();
            var users = context.Users.ToList();
            var postStatistics = context.PostStatistics.ToList();

            MyViewModel model = new MyViewModel
            {
                Posts = posts,
                Users = users,
                PostStatistics = postStatistics
            };

            return View(model);
        }




    }
}
