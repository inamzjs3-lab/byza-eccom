namespace ServiceLayer.ServiceModels
{
    public class UserRequestServiceModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
    }
}
