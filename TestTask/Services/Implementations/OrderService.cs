using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;
namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        readonly ApplicationDbContext db;
        public OrderService(ApplicationDbContext context)
        {
            db = context;
        }

        public Task<Order> GetOrder()
        {
            return db.Orders.FirstAsync(p => p.Price * p.Quantity == db.Orders.Max(p => p.Price * p.Quantity));
        }

        public Task<List<Order>> GetOrders()
        {
            return db.Orders.Where(p => p.Quantity > 10).ToListAsync();
        }
    }
}
