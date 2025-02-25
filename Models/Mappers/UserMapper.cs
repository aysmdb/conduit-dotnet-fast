using FastEndpoints;
using RealDotnetFast.Models.Entities;
using RealDotnetFast.Models.Requests;

namespace RealDotnetFast.Models.Mappers;

public class UserMapper : Mapper<RegistrationRequest, User, User>
{
    public override User ToEntity(RegistrationRequest r) => new()
    {
        Email = r.User.Email,
        Password = r.User.Password,
        Username = r.User.Username
    };
}