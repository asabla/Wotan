using Wotan.Integration.SteamAPI.Models.API.ISteamNews;
using Wotan.Integration.SteamAPI.Services;

namespace Wotan.Backend.Api.GraphQL.Resolvers.Steam;

[ExtendObjectType(nameof(Query))]
public class SteamNewsResolvers
{
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
}