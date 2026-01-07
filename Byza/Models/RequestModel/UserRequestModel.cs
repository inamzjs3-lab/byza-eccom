using System.ComponentModel.DataAnnotations;

namespace Byza.Models.RequestModel
{
    public class UserRequestModel
    {
        [Required(ErrorMessage = "The Email field is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "The MobileNumber field is required.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "The User Role field is required.")]
        public string UserRole { get; set; }
        
    }
}
