using System.ComponentModel.DataAnnotations;

namespace Byza.Models.RequestModel
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "The Email or mobile field is required.")]
        public string EmailOrMobile { get; set; }
        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "The User Role field is required.")]
        public string UserRole { get; set; }

    }
}
