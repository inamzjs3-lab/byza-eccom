using DataAccessLayer.Contracts;
using EntityLayer;
using ServiceLayer.Contracts;
using ServiceLayer.ServiceModels;

namespace ServiceLayer.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _repository;
        private readonly IUserRepository _userRepo;
        public BuyerService(IBuyerRepository repository, IUserRepository userRepo)
        {
            _repository = repository;
            _userRepo = userRepo;
        }
        public async Task<bool> SignupBuyer(SignupRequestServiceModel model)
        {
            var userEntity = new User
            {
                Email = model.Email,
                Mobile = model.Mobile,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDeleted = false,
                IsLocked = false,
                LoginTries = 0,
                PasswordHash = model.Password,
                UserRole = "Buyer".ToLower()
            };
            var userId = await _userRepo.AddAsync(userEntity);
            var buyer = new Buyer
            {
                FirstName = model.Firstname,
                LastName = model.Lastname,
                UserId = userId
            };
            var result = await _repository.RegisterBuyerAsync(buyer);
            return result > 0;
        }
    }
}
