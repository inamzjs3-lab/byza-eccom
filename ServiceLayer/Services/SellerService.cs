using DataAccessLayer.Contracts;
using EntityLayer;
using ServiceLayer.Contracts;
using ServiceLayer.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository ;
        private readonly IUserRepository _userRepo;
        public SellerService(ISellerRepository sellerRepository, IUserRepository userRepo)
        {
            _sellerRepository = sellerRepository ;
            _userRepo = userRepo;
        }
        public async Task<bool> SignupSeller(SignupRequestServiceModel model)
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
                UserRole = "Seller".ToLower()
            };
            var userId = await _userRepo.AddAsync(userEntity);
            var seller = new Seller
            {
                FirstName = model.Firstname,
                LastName = model.Lastname,
                UserId = userId
            };
            var result = await _sellerRepository.RegisterSellerAsync(seller);
            return result > 0;
        }
    }
}
