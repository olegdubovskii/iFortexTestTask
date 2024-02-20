namespace TestTask.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T?> GetItemByIDAsync(int itemID);
        Task<T> InsertItemAsync(T newItem);
        T UpdateItem(T modifiedItem);
        void DeleteItem(T removableItem);
        Task SaveChangesAsync();
    }
}
