using Wotan.Integration.SteamAPI.Models.API.ISteamUserStats;
using Wotan.Integration.SteamAPI.Services;

namespace Wotan.Backend.Api.GraphQL.Resolvers.Steam;

[ExtendObjectType(nameof(Query))]
public sealed class SteamuserStatsResolvers
{
    public async Task<PlayerCount> GetSteamCurrentPlayersAsync(
        int appId,
        SteamAPIService steamAPIService,
        CancellationToken cancellationToken)
        => await steamAPIService
            .GetPlayersCountAsync(
                appId: appId,
                cancellationToken: cancellationToken)
            .ContinueWith(serviceTask => serviceTask.Result.Response);

    public async Task<IEnumerable<GameAchievement>> GetSteamGameAchievementsAsync(
        int gameId,
        SteamAPIService steamAPIService,
        CancellationToken cancellationToken)
        => await steamAPIService
            .GetGameAchievementStatsAsync(
                gameId: gameId,
                cancellationToken: cancellationToken)
            .ContinueWith(serviceTask => serviceTask.Result.AchievementPercentages.Achievements);
}