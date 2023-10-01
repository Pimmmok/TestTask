using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;


namespace TestTask.Services.Concrete
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
            return db.Orders.Where(p => p.Quantity == db.Orders.Max(p => p.Quantity)).FirstAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return db.Orders.Where(p => p.Quantity > 10).ToListAsync();
        }
    }
}
