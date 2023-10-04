using Microsoft.AspNetCore.Mvc;

namespace Forum_MVC.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult ProfileSettings()
        {
            return View();
        }
    }
}
