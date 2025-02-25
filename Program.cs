using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;
using RealDotnetFast;
using RealDotnetFast.Repositories;
using RealDotnetFast.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MainDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
    options.UseSnakeCaseNamingConvention();
});

builder.Services
.AddAuthenticationJwtBearer(s =>
{
    s.SigningKey = "my_secret_key";
})
.AddAuthorization()
.AddFastEndpoints();

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseAuthentication().UseAuthorization()
.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
});
app.Run();
