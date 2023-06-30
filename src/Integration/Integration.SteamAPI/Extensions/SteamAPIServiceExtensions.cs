using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Wotan.Integration.SteamAPI.Services;

namespace Wotan.Integration.SteamAPI.Extensions;

public static class SteamAPIServiceExtensions
{
    public static WebApplicationBuilder ConfigureSteamAPIService(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient(
            name: SteamAPIService.HTTPClientName,
            configureClient: opt =>
            {
                opt.BaseAddress = SteamAPIService.HTTPBaseURI;
                opt.DefaultRequestHeaders.Add("accept", "application/json");
                opt.DefaultRequestHeaders.Add("User-Agent", "Woton SteamAPI user agent");
            });

        builder.Services.AddScoped<SteamAPIService>();

        return builder;
    }
}