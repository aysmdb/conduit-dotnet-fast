using FastEndpoints;
using BCryptNet = BCrypt.Net.BCrypt;
using RealDotnetFast.Models.Mappers;
using RealDotnetFast.Models.Requests;
using RealDotnetFast.Models.Responses;
using RealDotnetFast.Repositories;
using RealDotnetFast.Services;

namespace RealDotnetFast.Endpoints;

public class LoginEndpoint : Endpoint<LoginRequest, UserResponse, UserMapper>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public LoginEndpoint(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public override void Configure()
    {
        Post("/users/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.User.Email);

        if (user == null || !BCryptNet.Verify(request.User.Password, user.Password))
        {
            await SendErrorsAsync();
        }
        else
        {
            var token = _authService.GenerateToken(user.Id);
            var resp = Map.FromEntity(user);
            resp.User!.Token = token;

            await SendAsync(resp);
        }
    }
}