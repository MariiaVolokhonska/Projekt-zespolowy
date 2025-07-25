﻿using GroupProject.Repositories.Interfaces;
using GroupProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QRLogic.Entities;

namespace GroupProject.Controllers
{
    public class MainController : Controller
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IWalletRepository _walletRepo;

        public MainController(IWalletRepository walletRepo, ICurrentUserService currentUser)
        {
            _walletRepo= walletRepo;
            _currentUser = currentUser;
        }
        public async Task<IActionResult> Index()
        {
            var rewards = new List<Service>
                {
                    new Service { Id = 1, Name = "Bowling (1 godz.)", PointPrice = 300, ImageUrl = "/images/bowling.jpg" },
                    new Service { Id = 2, Name = "Karaoke (30 min)", PointPrice = 150, ImageUrl = "/images/karaoke.jpg" },
                    new Service { Id = 3, Name = "Bilard (1 godz.)", PointPrice = 200, ImageUrl = "/images/billiard.jpg" },
                    new Service { Id = 4, Name = "Escape Room (1 gra)", PointPrice = 500, ImageUrl = "/images/escape.jpg" },
                    new Service { Id = 5, Name = "Symulator VR (20 min)", PointPrice = 250, ImageUrl = "/images/vr.jpg" },
                    new Service { Id = 6, Name = "Gra w darta (30 min)", PointPrice = 100, ImageUrl = "/images/darts.jpg" }
                };
            var userId = _currentUser.GetUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var wallet = await _walletRepo.GetWalletByUserId((int)userId);
            ViewBag.UserPoints = wallet.AmountOfPoints;

            return View(rewards);
        }
    }
}
