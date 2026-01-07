using System.ComponentModel.DataAnnotations;

namespace Byza.Models.ResponseModel
{
    public class UserResponseModel
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string UserRole { get; set; }
    }
}
