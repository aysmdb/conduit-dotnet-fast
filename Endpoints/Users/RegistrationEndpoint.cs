using FastEndpoints;
using BCryptNet = BCrypt.Net.BCrypt;
using RealDotnetFast.Models.Mappers;
using RealDotnetFast.Models.Requests;
using RealDotnetFast.Repositories;
using RealDotnetFast.Models.Responses;
using RealDotnetFast.Models.Entities;
using RealDotnetFast.Services;

namespace RealDotnetFast.Endpoints;

public class RegistrationEndpoint : Endpoint<RegistrationRequest, UserResponse, UserMapper>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public RegistrationEndpoint(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
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

        var token = _authService.GenerateToken(user.Id);

        var resp = Map.FromEntity(user);
        resp.User!.Token = token;

        await SendAsync(resp);
    }
}