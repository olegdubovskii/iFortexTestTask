using TestTask.Models;

namespace TestTask.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetOrderWithMaxSumAsync();
        Task<List<Order>> GetOrdersWithMinProductLimitAsync(int limit);
    }
}
