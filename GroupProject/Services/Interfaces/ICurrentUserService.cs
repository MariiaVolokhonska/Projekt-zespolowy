using QRLogic.Entities;

namespace GroupProject.Services.Interfaces
{
    public interface ICurrentUserService
    {
        User? GetCurrentUser();
        int? GetUserId();
    }
}
