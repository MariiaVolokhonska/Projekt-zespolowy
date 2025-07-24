using GroupProject.Repositories.Interfaces;
using GroupProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using QRLogic;
using QRLogic.Entities;

namespace GroupProject.Repositories
{
    public class CouponsRepository : ICouponsRepository
    {
        private readonly AppDbContext _context;
        public CouponsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task SaveCoupon(Coupon coupon)
        {
            await _context.Coupons.AddAsync(coupon);
            await _context.SaveChangesAsync();
        }
        public async Task<List<CouponViewModel>> GetCouponsByUserId(int userId)
        {
            var result = await (
                from coupon in _context.Coupons
                join service in _context.Services
                    on coupon.ServiceId equals service.Id into serviceGroup
                from service in serviceGroup.DefaultIfEmpty()
                where coupon.UserId == userId
                select new CouponViewModel
                {
                    Id = coupon.Id,
                    QrCode = coupon.QrCode,
                    IsActivated = coupon.IsActivated,
                    IsUsed = coupon.IsUsed,
                    ServiceName = service != null ? service.Name : "Brak usługi"
                }).ToListAsync();

            return result;
        }

    }
}
