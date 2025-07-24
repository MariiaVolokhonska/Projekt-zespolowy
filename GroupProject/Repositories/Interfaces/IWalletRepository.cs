using QRLogic.Entities;

namespace GroupProject.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Task CreateUserPointWallet(UserPointsWallet wallet);

        Task<UserPointsWallet?> GetWalletByUserId(int userId);

        Task UpdateWallet(UserPointsWallet wallet);
    }
}
