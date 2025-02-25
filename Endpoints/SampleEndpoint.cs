using FastEndpoints;

namespace RealDotnetFast;

public class SampleEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/sample");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync("Hello, World!");
    }
}