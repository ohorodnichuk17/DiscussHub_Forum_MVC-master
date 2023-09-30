using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Forum_MVC.Data.Entities;
using Forum_MVC.Models;
using Forum_MVC.Data;

public class SignInSignUpFormController : Controller
{
    public IActionResult SignInForm()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SignInForm(Login model)
    {
        if (ModelState.IsValid)
        {
            User user = null;
            using (ForumDbContext db = new ForumDbContext())
            {
                user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            }
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "User with this login and password doesn`t exist");
            }
        }

        return View(model);
    }

   
}