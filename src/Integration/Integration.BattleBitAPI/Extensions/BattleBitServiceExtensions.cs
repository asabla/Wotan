using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Wotan.Integration.BattleBitAPI.Services;

namespace Wotan.Integration.BattleBitAPI.Extensions;

public static class BattleBitServiceExtensions
{
    public static WebApplicationBuilder ConfigureBattleBitAPIService(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient(
            name: BattleBitAPIService.HTTPClientName,
            configureClient: opt
                => opt.BaseAddress = BattleBitAPIService.HTTPBaseURI);

        builder.Services.AddScoped<BattleBitAPIService>();

        return builder;
    }
}