namespace RealDotnetFast.Services;

public interface IAuthService
{
    string GenerateToken(int userId);
}