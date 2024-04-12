using Microsoft.EntityFrameworkCore;

namespace WebBanHang.Models
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            var order = await GetOrderById(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
