using Wotan.Integration.SteamAPI.Models.API.ISteamApps;
using Wotan.Integration.SteamAPI.Models.API.ISteamNews;
using Wotan.Integration.SteamAPI.Models.API.ISteamUserStats;

namespace Wotan.Integration.SteamAPI.Services;

public interface ISteamAPIService
{
    Task<SteamAppListResponse> GetAppListAsync(
        CancellationToken cancellationToken = default);

    Task<SteamGlobalAchievementResponse> GetGameAchievementStatsAsync(
        int gameId,
        CancellationToken cancellationToken = default);

    Task<SteamAppNewsResponse> GetNewsForAppAsync(
        int appId,
        int take = 3,
        CancellationToken cancellationToken = default);

    Task<CurrentPlayersResponse> GetPlayersCountAsync(
        int appId,
        CancellationToken cancellationToken = default);

    Task<SteamServersAtAddressResponse> GetServersAtAddressAsync(
        string address,
        CancellationToken cancellationToken = default);

    Task<SteamServerUpToDateCheckResponse> GetServerUpToDateCheckAsync(
        int appId,
        int version,
        CancellationToken cancellationToken = default);
}
