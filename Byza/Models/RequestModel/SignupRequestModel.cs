using System.ComponentModel.DataAnnotations;

namespace Byza.Models.RequestModel
{
    public class SignupRequestModel
    {
        [Required(ErrorMessage = "Please Enter Your Email.")]
        public string Email {  get; set; }
        public string Mobile { get; set; }
        public string Firstname {  get; set; }
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password.")]
        public string Password { get; set; } 
    }
}
