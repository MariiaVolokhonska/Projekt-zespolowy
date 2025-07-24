using GroupProject.Repositories.Interfaces;
using GroupProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QRLogic.Entities;

namespace GroupProject.Controllers
{
    [Route("wallet")]
    public class WalletController : Controller
    {
        private readonly IWalletRepository _walletRepo;
        private readonly ICurrentUserService _currentUser;
        private readonly ICouponsRepository _couponsRepo;

        public WalletController(IWalletRepository walletRepo, ICurrentUserService currentUser, ICouponsRepository couponsRepo)
        {
            _walletRepo = walletRepo;
            _currentUser = currentUser;
            _couponsRepo = couponsRepo;
        }
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var userId = _currentUser.GetUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var wallet = await _walletRepo.GetWalletByUserId((int)userId);
            return View(wallet); 
        }

        // API endpoint
        [HttpPost("addpoints")]
        [Produces("application/json")]
        public async Task<IActionResult> AddPoints([FromBody] WalletPointsModel model)
        {
            var userId = _currentUser.GetUserId();
            if (userId == null || model.Points <= 0)
                return BadRequest("Invalid data");

            var wallet = await _walletRepo.GetWalletByUserId((int)userId);
            if (wallet == null)
            {
                wallet = new UserPointsWallet
                {
                    UserId = (int)userId,
                    AmountOfPoints = model.Points
                };
                await _walletRepo.CreateUserPointWallet(wallet);
            }
            else
            {
                wallet.AmountOfPoints += model.Points;
                await _walletRepo.UpdateWallet(wallet);
            }

            return Ok(new { success = true });
        }

        [HttpPost("/wallet/redeem")]
        [Produces("application/json")]
        public async Task<IActionResult> RedeemCoupon([FromBody] CouponRedeemModel model)
        {
            var userId = _currentUser.GetUserId();
            if (userId == null || model.ServiceId <= 0 || model.PointCost <= 0)
                return BadRequest("Invalid data");

            var wallet = await _walletRepo.GetWalletByUserId((int)userId);
            if (wallet == null)
                return BadRequest("Wallet not found");

            if (wallet.AmountOfPoints < model.PointCost)
                return BadRequest("Not enough points");

            wallet.AmountOfPoints -= model.PointCost;
            await _walletRepo.UpdateWallet(wallet);

            var couponId = Guid.NewGuid().ToString();
            var qrUrl = $"https://postacie.com.pl/pl/p/Shrek/211";
            var qrCode = QRGenerator.GenerateQrCode(qrUrl);

            var coupon = new Coupon
            {
                Id = couponId,
                UserId = (int)userId,
                ServiceId = model.ServiceId,
                QrCode = qrCode,
                IsActivated = true,
                IsUsed = false
            };

            await _couponsRepo.SaveCoupon(coupon);

            return Ok(new
            {
                success = true,
                qr = qrCode,
                remainingPoints = wallet.AmountOfPoints
            });
        }



        public class WalletPointsModel
        {
            public int Points { get; set; }
        }
        public class CouponRedeemModel
        {
            public int ServiceId { get; set; }
            public int PointCost { get; set; }
        }
    }
}  
