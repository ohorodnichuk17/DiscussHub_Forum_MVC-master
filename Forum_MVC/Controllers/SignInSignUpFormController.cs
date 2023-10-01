using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DataAccess.Data.Entities;
using Forum_MVC.Models;
using DataAccess.Data;

public class SignInSignUpFormController : Controller
{
    public IActionResult SignInForm()
    {
        return View();
    }

    private readonly ForumDbContext context;

    public SignInSignUpFormController(ForumDbContext context)
    {
        this.context = context;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SignInForm(Login model)
    {
        if (ModelState.IsValid)
        {
            User user = null;
                user = context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

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

    public IActionResult SignUpForm()
    {
        return View();
    }


}