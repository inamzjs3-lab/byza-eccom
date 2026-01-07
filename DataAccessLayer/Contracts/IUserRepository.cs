

using EntityLayer;

namespace DataAccessLayer.Contracts
{
    public interface IUserRepository : IDataRepository<User>
    {
        Task<int> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync(int skip, int top, string search, string orderBy);
    }
}
