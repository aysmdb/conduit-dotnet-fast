using FastEndpoints;
using BCryptNet = BCrypt.Net.BCrypt;
using RealDotnetFast.Models.Mappers;
using RealDotnetFast.Models.Requests;
using RealDotnetFast.Repositories;

namespace RealDotnetFast.Models.Entities;

public class RegistrationEndpoint : Endpoint<RegistrationRequest, User, UserMapper>
{
    private readonly IUserRepository _userRepository;

    public RegistrationEndpoint(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override void Configure()
    {
        Post("/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegistrationRequest request, CancellationToken cancellationToken)
    {
        request.User.Password = BCryptNet.HashPassword(request.User.Password);
        User user = Map.ToEntity(request);

        await _userRepository.CreateAsync(user);

        await SendAsync(user);
    }
}