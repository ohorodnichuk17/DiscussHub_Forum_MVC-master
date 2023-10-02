using DataAccess.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace Forum_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connStr = builder.Configuration.GetConnectionString("LocalDb");
            builder.Services.AddDbContext<ForumDbContext>(opts => opts.UseSqlServer(connStr));

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication("MyCookieAuthenticationScheme")
            .AddCookie("MyCookieAuthenticationScheme", options =>
            {
                options.LoginPath = "/SignInSignUpForm/SignInForm";
                options.AccessDeniedPath = "/Home/AccessDenied";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.MapControllerRoute(
            //    name: "signUpFormRoute",
            //    pattern: "{controller=SignInSignUpForm}/{action=SignUpForm}/{id?}");

            //app.MapControllerRoute(
            //name: "default",
            //pattern: "{controller=SignInSignUpForm}/{action=SignInForm}/{id?}");

            //app.MapControllerRoute(
            //    name: "home",
            //    pattern: "{controller=SignInSignUpForm}/{action=SignInForm}/{id?}",
            //    defaults: new { controller = "Home", action = "Index" });

            app.Run();
        }
    }
}