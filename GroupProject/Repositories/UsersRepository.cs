using GroupProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRLogic;
using QRLogic.Entities;

namespace GroupProject.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUser(User user) => 
            await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

        public async Task AddUser(User user){
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
