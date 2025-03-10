using FastEndpoints.Security;

namespace RealDotnetFast.Services.Implementations;

public class AuthService : IAuthService
{
    public string GenerateToken(int userId)
    {
        var jwt = JwtBearer.CreateToken( o => {
            o.SigningKey = "mcwqyoohulgjeusvblxaolbovaogqwaz";
            o.ExpireAt = DateTime.UtcNow.AddDays(1);
            o.User.Claims.Add(("userId", userId.ToString()));
        });
        return jwt;
    }
}
