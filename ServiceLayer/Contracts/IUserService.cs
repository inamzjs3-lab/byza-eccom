using ServiceLayer.ServiceModels;

namespace ServiceLayer.Contracts

{
    public interface IUserService
    {

        Task<int> AddUserAsync(UserRequestServiceModel userRequestModel);
        Task<UserRequestServiceModel> GetByIdAsync(int id);
        Task<bool> DeleteUserByIdAsync(int id);
        Task<bool> UpdateUserByIdAsync(UserRequestServiceModel userRequestModel, int id);
        Task<List<UserResponseServiceModel>> GetAllUsers();
        Task<UserResponseServiceModel?> GetUserByEmailOrMobileAndRole(string email, string userRole);

    }
}
