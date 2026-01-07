using Byza.Models.RequestModel;
using Byza.Models.ResponseModel;
using DataAccessLayer.Contracts;
using EntityLayer;
using ServiceLayer.Contracts;

namespace ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository _userRepository)
        {
            this._userRepository = _userRepository;
        }
        public async Task<int> AddUserAsync(UserRequestModel userRequestModel)
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

        public async Task<List<UserResponseModel>> GetAllUsers()
        {
            var userSM = new List<UserResponseModel>();
            var entity = await _userRepository.GetAllAsync(0, 0, "", "");
            foreach (var Users in entity)
            {
                var usersSM = new UserResponseModel()
                {
                    Email = Users.Email,
                    Mobile = Users.Mobile,
                    UserRole = Users.UserRole,

                };
                userSM.Add(usersSM);
            }
            return userSM;
        }

        public async Task<UserRequestModel> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var entity = new UserRequestModel
            {
                Email = user.Email,
                Mobile = user.Mobile,
                Password = user.PasswordHash,
                UserRole = user.UserRole,
            };
            return entity;
        }

        public async Task<bool> UpdateUserByIdAsync(UserRequestModel userRequestModel, int id)
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
