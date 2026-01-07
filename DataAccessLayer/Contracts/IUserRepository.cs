using EntityLayer;

namespace DataAccessLayer.Contracts
{
    public interface IUserRepository
    {
        Task<int> AddUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> GetById(int id);
        Task<List<User>> GetAll(int skip, int top, string search, string orderBy);
    }
}
