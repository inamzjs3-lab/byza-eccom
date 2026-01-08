using Byza.Models.RequestModel;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.ServiceModels;

namespace Byza.Controllers
{
    public class AuthController : Controller
    {
        private readonly IBuyerService _buyerService;

        public AuthController(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        [HttpPost("register-buyer")]
        public async Task<IActionResult> SignupBuyer(SignupRequestModel model)
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
                    return RedirectToAction($"login-buyer");
                }
            }

            return RedirectToAction("signup-buyer");
        }
    }
}
