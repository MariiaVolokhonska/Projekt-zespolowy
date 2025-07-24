using GroupProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using QRLogic;
using QRLogic.Entities;

namespace GroupProject.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _context;
        public WalletRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserPointWallet(UserPointsWallet wallet)
        {
            await _context.UserPontsWallets.AddAsync(wallet);
            await _context.SaveChangesAsync();
        }

       public async Task<UserPointsWallet?> GetWalletByUserId(int userId)
        {
            return await _context.UserPontsWallets
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.UserId == userId);
        }

        public async Task UpdateWallet(UserPointsWallet wallet)
        {
            _context.UserPontsWallets.Update(wallet);
            await _context.SaveChangesAsync();
        }
    }
}
