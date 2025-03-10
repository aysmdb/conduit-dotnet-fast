using RealDotnetFast.Models.Entities;

namespace RealDotnetFast.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByEmailAsync(string email);
}