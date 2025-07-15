using Microsoft.AspNetCore.Mvc;

namespace GroupProject.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
