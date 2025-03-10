using RealDotnetFast.Models.Entities;

namespace RealDotnetFast.Models.Responses;

public class UserResponse
{
    public UserAuth? User { get; set; }

    public class UserAuth
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
    }
}