using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Repositories.Interfaces;

namespace TestTask.Repositories.Implementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order> GetOrderWithMaxSumAsync()
        {
            return await _dbSet.OrderByDescending(order => order.Price * order.Quantity)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrdersWithMinProductLimitAsync(int limit)
        {
            return await _dbSet.Where(order => order.Quantity > limit)
                .ToListAsync();
        }
    }
}
