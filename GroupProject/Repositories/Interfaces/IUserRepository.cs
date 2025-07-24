using QRLogic.Entities;

namespace GroupProject.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUser(User user);
        Task AddUser(User user);
    }
}
