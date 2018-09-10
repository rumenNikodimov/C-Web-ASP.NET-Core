using Microsoft.AspNetCore.Mvc;

namespace CarManager.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}