namespace DataAccessLayer.Contracts
{
    public interface IDataRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(int page, int pageSize, string search, string orderBy);
    }
}
