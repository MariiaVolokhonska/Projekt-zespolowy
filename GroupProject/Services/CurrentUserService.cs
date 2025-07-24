using GroupProject.Services.Interfaces;
using QRLogic.Entities;
using QRLogic;

namespace GroupProject.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public int? GetUserId()
        {
            return _httpContextAccessor.HttpContext?.Session.GetInt32("UserId");
        }

        public User? GetCurrentUser()
        {
            var userId = GetUserId();
            if (userId == null) return null;

            return _context.Users.Find(userId);
        }
    }

}
