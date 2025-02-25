using RealDotnetFast.Models.Entities;

namespace RealDotnetFast.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
}