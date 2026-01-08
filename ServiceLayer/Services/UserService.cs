using DataAccessLayer.Contracts;
using EntityLayer;
using ServiceLayer.Contracts;
using ServiceLayer.ServiceModels;

namespace ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository _userRepository)
        {
            this._userRepository = _userRepository;
        }
        public async Task<int> AddUserAsync(UserRequestServiceModel userRequestModel)
        {
            var enity = new User
            {
                CreatedAt = DateTime.UtcNow,
                Email = userRequestModel.Email,
                IsActive = true,
                IsDeleted = false,
                IsLocked = false,
                Mobile = userRequestModel.Mobile,
                LoginTries = 0,
                PasswordHash = userRequestModel.Password,
                UserRole = userRequestModel.UserRole
            };
            var userId = await _userRepository.AddUserAsync(enity);
            return userId;
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {

            var user = await _userRepository.DeleteUserAsync(id);
            return user;
        }

        public async Task<List<UserResponseServiceModel>> GetAllUsers()
        {
            var userSM = new List<UserResponseServiceModel>();
            var entity = await _userRepository.GetAllAsync(0, 0, "", "");
            foreach (var Users in entity)
            {
                var usersSM = new UserResponseServiceModel()
                {
                    Email = Users.Email,
                    Mobile = Users.Mobile,
                    UserRole = Users.UserRole,

                };
                userSM.Add(usersSM);
            }
            return userSM;
        }

        public async Task<UserRequestServiceModel> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var entity = new UserRequestServiceModel
            {
                Email = user.Email,
                Mobile = user.Mobile,
                Password = user.PasswordHash,
                UserRole = user.UserRole,
            };
            return entity;
        }

        public async Task<UserResponseServiceModel?> GetUserByEmailOrMobileAndRole(string emailOrPhone, string role)
        {
            var user = await _userRepository.GetUserByEmailOrMobileAndRole(emailOrPhone, role);
            if(user is { })
            {
                return null;
            }
            return new UserResponseServiceModel()
            {
                 UserRole = user?.UserRole ?? string.Empty,
                 Email = user?.Email ?? string.Empty,
                 Mobile = user?.Mobile ?? string.Empty,
                 Password = user?.PasswordHash ?? string.Empty
            };
        }

        public async Task<bool> UpdateUserByIdAsync(UserRequestServiceModel userRequestModel, int id)
        {
            var entity = new User
            {
                Id = id,
                Email = userRequestModel.Email,
                Mobile = userRequestModel.Mobile,
                IsActive = true,
                IsDeleted = false,
                IsLocked = false,
                PasswordHash = userRequestModel.Password,
                UserRole = userRequestModel.UserRole,
                UpdatedAt = DateTime.UtcNow,
            };

            var user = await _userRepository.UpdateUserAsync(entity);
            return user;

        }
    }
}
