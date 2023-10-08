using DataAccess.Data;
using DataAccess.Data.Entities;
using Forum_MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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

        [HttpPost]
        public IActionResult ProfileSettings(IFormFile avatar)
        {
            if (avatar != null && avatar.Length > 0)
            {
                var username = User.Identity.Name;
                var currentUser = context.Users.FirstOrDefault(u => u.Username == username);

                if (currentUser != null)
                {
                    var avatarPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/people/", avatar.FileName);
                    using (var stream = new FileStream(avatarPath, FileMode.Create))
                    {
                        avatar.CopyTo(stream);
                    }

                    currentUser.ImageUrl = "/img/people/" + avatar.FileName;
                    context.SaveChanges();
                }

                return Ok(); 
            }

            return BadRequest("No avatar file provided."); 
        }

    }
}
