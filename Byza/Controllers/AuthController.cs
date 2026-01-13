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

        public AuthController(IBuyerService buyerService, IUserService userService)
        {
            _buyerService = buyerService;
            _userService = userService;
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


   
    }
}
