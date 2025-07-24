using Microsoft.AspNetCore.Mvc;
using QRLogic.Entities;
using QRLogic;
using System.Runtime.CompilerServices;
using GroupProject.Repositories.Interfaces;
using GroupProject.Services.Interfaces;

namespace GroupProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<AccountController> _logger;

        public AccountController(AppDbContext context, IUserRepository userRepository, IWalletRepository walletRepository, ILogger<AccountController> logger)
        {
            _context = context;
            _userRepository = userRepository;
            _walletRepository = walletRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userRepository.GetUser(user);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Użytkownik z takim adresem e-mail już istnieje.");
                    return View(user);
                }
                await _userRepository.AddUser(user);

                var wallet = new UserPointsWallet
                {
                    UserId = user.Id,
                };

                await _walletRepository.CreateUserPointWallet(wallet);

                return RedirectToAction("Login");
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
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (existingUser != null)
            {
                HttpContext.Session.SetInt32("UserId", existingUser.Id);
                HttpContext.Session.SetString("UserFirstName", existingUser.FirstName);
                HttpContext.Session.SetString("UserLastName", existingUser.LastName);
                HttpContext.Session.SetString("UserEmail", existingUser.Email);
                _logger.LogInformation("Zalogowano: {Email}", existingUser.Email);

                return RedirectToAction("Index", "Main");
            }
            ModelState.AddModelError("Email", "Nieprawidłowy e-mail lub hasło.");
            
            return View(user);
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string FirstName, string LastName, string Email)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Email = Email;

            await _context.SaveChangesAsync();

            // Zaktualizuj sesję
            HttpContext.Session.SetString("UserFirstName", FirstName);
            HttpContext.Session.SetString("UserLastName", LastName);
            HttpContext.Session.SetString("UserEmail", Email);

            TempData["SuccessMessage"] = "Dane zostały zaktualizowane.";

            return RedirectToAction("Edit");
        }





        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
