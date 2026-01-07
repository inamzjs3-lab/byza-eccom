using Byza.Models.RequestModel;
using Byza.Models.ResponseModel;

namespace ServiceLayer.Contracts

{
    public interface IUserService
    {

        Task<int> AddUserAsync(UserRequestModel userRequestModel);
        Task<UserRequestModel> GetByIdAsync(int id);
        Task<bool> DeleteUserByIdAsync(int id);
        Task<bool> UpdateUserByIdAsync(UserRequestModel userRequestModel, int id);
        Task<List<UserResponseModel>> GetAllUsers();

    }
}
