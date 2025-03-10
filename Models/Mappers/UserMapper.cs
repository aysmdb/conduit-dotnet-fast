using FastEndpoints;
using RealDotnetFast.Models.Entities;
using RealDotnetFast.Models.Requests;
using RealDotnetFast.Models.Responses;

namespace RealDotnetFast.Models.Mappers;

public class UserMapper : Mapper<RegistrationRequest, UserResponse, User>
{
    public override User ToEntity(RegistrationRequest r) => new()
    {
        Email = r.User.Email,
        Password = r.User.Password,
        Username = r.User.Username
    };

    public override UserResponse FromEntity(User e) => new()
    {
        User = new()
        {
            Username = e.Username,
            Email = e.Email,
            Bio = e.Bio,
            Image = e.Image
        }
    };
}