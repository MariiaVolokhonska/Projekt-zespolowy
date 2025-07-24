using GroupProject.Repositories.Interfaces;
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
    }
}
