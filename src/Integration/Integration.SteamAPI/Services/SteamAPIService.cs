using System.Net.Http.Json;
using System.Text.Json;

using Microsoft.Extensions.Logging;

using Wotan.Integration.SteamAPI.Models.API.ISteamApps;
using Wotan.Integration.SteamAPI.Models.API.ISteamNews;
using Wotan.Integration.SteamAPI.Models.API.ISteamUserStats;

namespace Wotan.Integration.SteamAPI.Services;

public class SteamAPIService : ISteamAPIService
{
    public const string HTTPClientName = nameof(SteamAPIService);
    public const string HTTPBase = "https://api.steampowered.com/";

    public static Uri HTTPBaseURI => new(HTTPBase);

    private readonly ILogger<SteamAPIService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public SteamAPIService(
        ILogger<SteamAPIService> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;

        _httpClient = _httpClientFactory.CreateClient(
            name: HTTPClientName);
    }

    public async Task<SteamAppListResponse> GetAppListAsync(
        CancellationToken cancellationToken = default)
        => await _httpClient
            .GetFromJsonAsync<SteamAppListResponse>(
                requestUri: "ISteamApps/GetAppList/v0002/?format=json",
                options: new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                },
                cancellationToken: cancellationToken)
            ?? default!;

    public async Task<SteamGlobalAchievementResponse> GetGameAchievementStatsAsync(
        int gameId,
        CancellationToken cancellationToken = default)
        => await _httpClient
            .GetFromJsonAsync<SteamGlobalAchievementResponse>(
                requestUri: $"ISteamUserStats/GetGlobalAchievementPercentagesForApp/v2/?gameId={gameId}",
                options: new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals
                },
                cancellationToken: cancellationToken)
            ?? default!;

    public async Task<SteamAppNewsResponse> GetNewsForAppAsync(
        int appId,
        int take = 3,
        CancellationToken cancellationToken = default)
        => await _httpClient
            .GetFromJsonAsync<SteamAppNewsResponse>(
                requestUri: $"ISteamNews/GetNewsForApp/v2/?appid={appId}&count={take}",
                options: new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                },
                cancellationToken: cancellationToken)
            ?? default!;

    public async Task<CurrentPlayersResponse> GetPlayersCountAsync(
        int appId,
        CancellationToken cancellationToken = default)
        => await _httpClient
            .GetFromJsonAsync<CurrentPlayersResponse>(
                requestUri: $"ISteamUserStats/GetNumberOfCurrentPlayers/v1/?appid={appId}",
                options: new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                },
                cancellationToken: cancellationToken)
            ?? default!;

    public async Task<SteamServersAtAddressResponse> GetServersAtAddressAsync(
        string address,
        CancellationToken cancellationToken = default)
        => await _httpClient
            .GetFromJsonAsync<SteamServersAtAddressResponse>(
                requestUri: $"ISteamApps/GetServersAtAddress/v1/?addr={address}",
                options: new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                },
                cancellationToken: cancellationToken)
            ?? default!;

    public async Task<SteamServerUpToDateCheckResponse> GetServerUpToDateCheckAsync(
        int appId,
        int version,
        CancellationToken cancellationToken = default)
        => await _httpClient
            .GetFromJsonAsync<SteamServerUpToDateCheckResponse>(
                requestUri: $"ISteamApps/UpToDateCheck/v1/?appid={appId}&version={version}",
                options: new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                },
                cancellationToken: cancellationToken)
            ?? default!;
}