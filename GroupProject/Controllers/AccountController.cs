using Microsoft.AspNetCore.Mvc;
using QRLogic.Entities;
using QRLogic;

namespace GroupProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Użytkownik z takim adresem e-mail już istnieje.");
                    return View(user);
                }
                _context.Users.Add(user);
                _context.SaveChanges();
                

                /*var coupons = new List<Coupon>
        {
            new Coupon
            {
                UserId = user.Id,
                Code = "WELCOME1_" + user.Id,
                Description = "Welcome coupon #1",
                Discount = 10.0m,
                ExpirationDate = DateTime.Now.AddMonths(1)
            },
            new Coupon
            {
                UserId = user.Id,
                Code = "WELCOME2_" + user.Id,
                Description = "Welcome coupon #2",
                Discount = 15.0m,
                ExpirationDate = DateTime.Now.AddMonths(1)
            },
            new Coupon
            {
                UserId = user.Id,
                Code = "WELCOME3_" + user.Id,
                Description = "Welcome coupon #3",
                Discount = 20.0m,
                ExpirationDate = DateTime.Now.AddMonths(1)
            },
            new Coupon
            {
                UserId = user.Id,
                Code = "WELCOME4_" + user.Id,
                Description = "Welcome coupon #4",
                Discount = 25.0m,
                ExpirationDate = DateTime.Now.AddMonths(1)
            }
        };

                _context.Coupons.AddRange(coupons);
                _context.SaveChanges();
                return RedirectToAction("Login");*/
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users
                    .FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

                if (existingUser != null)
                {
                    Console.WriteLine("Użytkownik znaleziony: " + existingUser.Email);
                    return RedirectToAction("Index", "Main");
                }
                Console.WriteLine("Użytkownik NIE znaleziony.");
                ModelState.AddModelError(string.Empty, "Nieprawidłowy e-mail lub hasło.");
            }

            return View(user);
        }
    }
}
