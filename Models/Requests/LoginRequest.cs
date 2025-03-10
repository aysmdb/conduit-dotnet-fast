namespace RealDotnetFast.Models.Requests;

public class LoginRequest
{
    public required UserRequest User { get; set; }

    public class UserRequest
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}