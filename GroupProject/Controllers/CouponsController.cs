using Microsoft.AspNetCore.Mvc;
using QRLogic;
using GroupProject.Services.Interfaces;
using GroupProject.Repositories.Interfaces;

namespace GroupProject.Controllers
{
    public class CouponsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser; 
        private readonly ICouponsRepository _couponsRepo;

        public CouponsController(AppDbContext context, ICurrentUserService currentUser, ICouponsRepository couponsRepo)
        {
            _context = context;
            _currentUser = currentUser;
            _couponsRepo = couponsRepo;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _currentUser.GetUserId();
            if (userId == null) return RedirectToAction("Login", "Account");

            Console.WriteLine("User ID: " + userId);
            var model = (await _couponsRepo.GetCouponsByUserId((int)userId.Value));
           /* Console.WriteLine("HELLOOOO");
            foreach (var coupon in coupons)
            {
                Console.WriteLine($"Coupon ID: {coupon.Id}, Service: {coupon.Service?.Name ?? "Brak nazwy"}, QR Code: {coupon.QrCode}, Is Activated: {coupon.IsActivated}, Is Used: {coupon.IsUsed}");
            }

            var model = coupons.Select(c => new CouponViewModel
            {
                Id = c.Id,
                ServiceName = c.Service?.Name ?? "Brak nazwy",
                QrCode = c.QrCode,
                IsActivated = c.IsActivated,
                IsUsed = c.IsUsed,
            }).ToList();*/

            return View(model);
        }

        [HttpPost("/coupon/use/{id}")]
        public async Task<IActionResult> UseCoupon(string id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon == null) return NotFound();

            coupon.IsUsed = true;
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
