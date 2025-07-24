using GroupProject.QR;
using GroupProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRLogic;
using GroupProject.Services.Interfaces;

namespace GroupProject.Controllers
{
    public class CouponsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser; 

        public CouponsController(AppDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _currentUser.GetUserId();
            if (userId == null) return RedirectToAction("Login", "Account");

            var coupons = await _context.Coupons
                .Include(c => c.Service)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            var model = coupons.Select(c => new CouponViewModel
            {
                Id = c.Id,
                ServiceName = c.Service?.Name ?? "Brak nazwy",
                QrCode = c.QrCode,
                IsActivated = c.IsActivated
            }).ToList();

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
