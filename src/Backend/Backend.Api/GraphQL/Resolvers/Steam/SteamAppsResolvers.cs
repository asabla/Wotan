using Wotan.Integration.SteamAPI.Models.API.ISteamApps;
using Wotan.Integration.SteamAPI.Services;

namespace Wotan.Backend.Api.GraphQL.Resolvers.Steam;

[ExtendObjectType(nameof(Query))]
public sealed class SteamAppResolvers
{
    [UseOffsetPaging(MaxPageSize = 200)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public async Task<IEnumerable<SteamApp>> GetSteamAppListAsync(
        SteamAPIService steamAPIService,
        CancellationToken cancellationToken)
        => await steamAPIService
            .GetAppListAsync(cancellationToken: cancellationToken)
            .ContinueWith(serviceTask => serviceTask.Result.AppList.Apps);

    public async Task<UpToDateCheck> GetSteamServerUpToDateAsync(
        int appId,
        int version,
        SteamAPIService steamAPIService,
        CancellationToken cancellationToken)
        => await steamAPIService
            .GetServerUpToDateCheckAsync(
                appId: appId,
                version: version,
                cancellationToken: cancellationToken)
            .ContinueWith(serviceTask => serviceTask.Result.Response);

    // Steam API encourage 1 request per minut with the same address
    // TODO: this needs to be cached for at least 1min
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public async Task<IEnumerable<ServerAtAddress>> GetSteamServersAtAddressAsync(
        string addressAndOrPort,
        SteamAPIService steamAPIService,
        CancellationToken cancellationToken)
        => await steamAPIService
            .GetServersAtAddressAsync(
                address: addressAndOrPort,
                cancellationToken: cancellationToken)
            .ContinueWith(serviceTask => serviceTask.Result.Response.Servers);
}