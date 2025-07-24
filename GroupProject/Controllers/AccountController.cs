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
            //if (ModelState.IsValid)
            //{
                var existingUser = _context.Users
                    .FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                _logger.LogInformation("Użytkownik znaleziony: {Email}", existingUser.Email);

                if (existingUser != null)
                {
                    HttpContext.Session.SetInt32("UserId", existingUser.Id);

                    return RedirectToAction("Index", "Main");
                }

                ModelState.AddModelError(string.Empty, "Nieprawidłowy e-mail lub hasło.");
            //}

            return View(user);
        }


        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
