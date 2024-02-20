using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Repositories.Interfaces;

namespace TestTask.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetItemsAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetItemByIDAsync(int itemID)
        {
            return await _dbSet.FindAsync(itemID);
        }

        public async Task<T> InsertItemAsync(T newItem)
        {
            await _dbSet.AddAsync(newItem);
            return newItem;
        }

        public T UpdateItem(T modifiedItem)
        {
            _dbSet.Update(modifiedItem);
            return modifiedItem;
        }

        public void DeleteItem(T removableItem)
        {
            _dbSet.Remove(removableItem);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
