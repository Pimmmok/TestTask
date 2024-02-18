using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        readonly private ApplicationDbContext db;
        public UserService(ApplicationDbContext context)
        {
            db = context;
        }
        public Task<User> GetUser()
        {
            var maxCountOfOrders = db.Users.Include(c => c.Orders).Select(c => new { c.Id, c.Orders.Count }).
        OrderBy(c => c.Count).Last();
            return db.Users.FirstAsync(c => c.Id == maxCountOfOrders.Id);
        }

        public Task<List<User>> GetUsers()
        {
            return db.Users.Where(p => p.Status == UserStatus.Inactive).ToListAsync();
        }
    }
}
