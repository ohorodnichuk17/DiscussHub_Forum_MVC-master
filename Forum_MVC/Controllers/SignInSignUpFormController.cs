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
    //public IActionResult SignInForm()
    //{
    //    return View();
    //}

    public IActionResult SignInForm()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }


    private readonly ForumDbContext context;

    public SignInSignUpFormController(ForumDbContext context)
    {
        this.context = context;
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult SignInForm(Login model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        User user = null;
    //            user = context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

    //        if (user != null)
    //        {
    //            return RedirectToAction("Index", "Home");
    //        }
    //        else
    //        {
    //            ModelState.AddModelError("", "User with this login and password doesn`t exist");
    //        }
    //    }

    //    return View(model);
    //}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> SignInForm(Login model)
    {
        if (ModelState.IsValid)
        {
            User user = context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),  // Ім'я користувача
                new Claim("Status", "Online")  // Статус (ви можете змінити це значення залежно від вашої логіки)
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuthenticationScheme", principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "User with this login and password doesn't exist");
            }
        }

        return View(model);
    }

    public IActionResult SignUpForm()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SignUpForm(Register model)
    {
        if (ModelState.IsValid)
        {
            var existingUser = context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "User with this email exists");
                return View(model);
            }

            var newUser = new User
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username,
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index()
    {
        await HttpContext.SignOutAsync("MyCookieAuthenticationScheme");
        return RedirectToAction("Index", "Home");
    }

}