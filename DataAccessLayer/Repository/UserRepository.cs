using DataAccessLayer.byzaDbContext;
using DataAccessLayer.Contracts;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserRepository : DataRepository<User>, IUserRepository
    {
        public UserRepository(ByzadbContext context) : base(context)
        {
        }

        public async Task<int> AddUser(User user)
        {
            await AddAsync(user);
            return user.Id;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var result = await DeleteAsync(id);  
            return result;
        }

        public async Task<List<User>> GetAll(int skip, int top, string search, string orderBy)
        {
            return (List<User>)await GetAllAsync(skip, top, search, orderBy);
        }

        public async Task<User> GetById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await UpdateAsync(user);
        }
    }
}
