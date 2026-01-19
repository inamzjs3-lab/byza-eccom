using Byza.Models.RequestModel;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.ServiceModels;

namespace Byza.Controllers
{
    public class AuthController : Controller
    {
        private readonly IBuyerService _buyerService;
        private readonly IUserService _userService;
        private readonly ISellerService _sellerService;

        public AuthController(IBuyerService buyerService, IUserService userService, ISellerService _sellerService)
        {
            _buyerService = buyerService;
            _userService = userService;
            this._sellerService = _sellerService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var user = await _userService.GetUserByEmailOrMobileAndRole(model.EmailOrMobile, model.UserRole);
            if (user is { })
            {
                return BadRequest("User not found");
            }
            if (user?.Password == model.Password)
            {
                return RedirectToAction($"{user.UserRole}/Dashboard");

            }
            ModelState.AddModelError("loginError", "Login failed!");
            return RedirectToAction($"login-{user?.UserRole}");
        }
        [HttpPost("seller-login")]
        public async Task<IActionResult> LoginSeller(LoginRequestModel model)
        {
            var user = await _userService.GetUserByEmailOrMobileAndRole(model.EmailOrMobile, model.UserRole);
            if (user is null)
            {
                return BadRequest("User not found");

            }
            if (user?.Password == model.Password)
            {
                return Redirect("/Seller/SellerDashboard");
            }
            ModelState.AddModelError("loginError", "Login failed!");
            return RedirectToAction($"login-{user?.UserRole}");
        }




        [HttpPost("signedup")]
        public async Task<IActionResult> SignUpBuyer(SignupRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var buyerModel = new SignupRequestServiceModel
                {
                    Email = model.Email,
                    Password = model.Password,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Mobile = model.Mobile
                };
                var isAdded = await _buyerService.SignupBuyer(buyerModel);
                if (isAdded)
                {
                    return RedirectToAction("login-buyer");
                }
            }

            return RedirectToAction("signup-buyer");
        }
        [HttpPost("SignUpSeller")]
        public async Task<IActionResult> SignUpSeller(SignupRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var seller = new SignupRequestServiceModel
                {
                    Email = model.Email,
                    Password = model.Password,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Mobile = model.Mobile

                };
                var add = await _sellerService.SignupSeller(seller);
                if(add)
                {
                    return RedirectToAction("login-seller");
                }
                
            }
            return RedirectToAction("signup-seller");

        }
    }
}
