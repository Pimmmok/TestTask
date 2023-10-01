using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;


namespace TestTask.Services.Concrete
{
    public class UserService : IUserService
    {

        readonly ApplicationDbContext db;
        public UserService(ApplicationDbContext context)
        {
            db = context;
        }

        public Task<User> GetUser()
        {

            var query = db.Users.Select(c => new { Id = c.Id, Count = c.Orders.Count });
            var maxCountOfOrders = query.OrderBy(c => c.Count).LastOrDefault();
            return db.Users.Where(c => c.Id == maxCountOfOrders.Id).FirstAsync();

        }


        public Task<List<User>> GetUsers()
        {
            return db.Users.Where(p => p.Status == UserStatus.Inactive).ToListAsync();
        }
    }
}
