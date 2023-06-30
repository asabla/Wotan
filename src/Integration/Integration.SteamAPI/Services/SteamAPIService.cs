using System.Net.Http.Json;

using Microsoft.Extensions.Logging;

using Wotan.Integration.SteamAPI.Models;

namespace Wotan.Integration.SteamAPI.Services;

public interface ISteamAPIService
{
    Task<SteamAppListResponse> GetAppListAsync(
        CancellationToken cancellationToken = default);

    Task<SteamAppNewsResponse> GetNewsForApp(
        int appId,
        int take = 3,
        CancellationToken cancellationToken = default);

    Task<CurrentPlayersResponse> GetPlayersCountAsync(
        int appId,
        CancellationToken cancellationToken = default);
}

public class SteamAPIService : ISteamAPIService
{
    public static string HTTPClientName = nameof(SteamAPIService);
    public static Uri HTTPBaseURI = new("https://api.steampowered.com/");

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
                cancellationToken: cancellationToken)
            ?? default!;

    public async Task<SteamAppNewsResponse> GetNewsForApp(
        int appId,
        int take = 3,
        CancellationToken cancellationToken = default)
        => await _httpClient
            .GetFromJsonAsync<SteamAppNewsResponse>(
                requestUri: $"ISteamNews/GetNewsForApp/v2/?appid={appId}&count={take}",
                cancellationToken: cancellationToken)
            ?? default!;

    public async Task<CurrentPlayersResponse> GetPlayersCountAsync(
        int appId,
        CancellationToken cancellationToken = default)
        => await _httpClient
            .GetFromJsonAsync<CurrentPlayersResponse>(
                requestUri: $"SteamUserStats/GetNumberOfCurrenyPlayers/v1/?appid={appId}",
                cancellationToken: cancellationToken)
            ?? default!;
}