using GroupProject.ViewModels;
using QRLogic.Entities;

namespace GroupProject.Repositories.Interfaces
{
    public interface ICouponsRepository
    {
        Task SaveCoupon(Coupon coupon);
        Task<List<CouponViewModel>> GetCouponsByUserId(int userId);
    }
}
