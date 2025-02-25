using RealDotnetFast.Models.Entities;

namespace RealDotnetFast.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly MainDbContext _context;

    public UserRepository(MainDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}