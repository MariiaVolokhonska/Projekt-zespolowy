using Microsoft.AspNetCore.Mvc;
using QRLogic;

namespace GroupProject.Controllers
{
    public class CouponsController : Controller
    {
        private readonly AppDbContext _context;

        public CouponsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
