using Wotan.Integration.SteamAPI.Models.API;
using Wotan.Integration.SteamAPI.Services;

namespace Wotan.Backend.Api.GraphQL.Resolvers;

[ExtendObjectType(nameof(Query))]
public sealed class SteamResolvers
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

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public async Task<IEnumerable<NewsItem>> GetSteamAppNewsListAsync(
        int appId,
        int take,
        SteamAPIService steamAPIService,
        CancellationToken cancellationToken)
        => await steamAPIService
            .GetNewsForAppAsync(
                appId: appId,
                take: take,
                cancellationToken: cancellationToken)
            .ContinueWith(serviceTask => serviceTask.Result.AppNews.NewsItems);

    public async Task<CurrentPlayersResponse> GetSteamCurrentPlayersAsync(
        int appId,
        SteamAPIService steamAPIService,
        CancellationToken cancellationToken)
        => await steamAPIService.GetPlayersCountAsync(
            appId: appId,
            cancellationToken: cancellationToken);
}