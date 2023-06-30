using System.Net.Http.Json;
using System.Text.Json;

using Microsoft.Extensions.Logging;

using Wotan.Integration.BattleBitAPI.Models.API;

namespace Wotan.Integration.BattleBitAPI.Services;

public interface IBattleBitAPIService
{
    Task<IReadOnlyList<ServerAPIInfo>> GetAllServerAsync(
        CancellationToken cancellationToken = default);
}

public class BattleBitAPIService : IBattleBitAPIService
{
    public static string HTTPClientName = nameof(BattleBitAPIService);
    public static Uri HTTPBaseURI = new("https://publicapi.battlebit.cloud");

    private readonly ILogger<BattleBitAPIService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public BattleBitAPIService(
        ILogger<BattleBitAPIService> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;

        _httpClient = _httpClientFactory.CreateClient(
            name: HTTPClientName);
    }

    public async Task<IReadOnlyList<ServerAPIInfo>> GetAllServerAsync(
        CancellationToken cancellationToken = default)
        => await _httpClient
            .GetFromJsonAsync<IReadOnlyList<ServerAPIInfo>>(
                requestUri: "Servers/GetServerList",
                options: new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                },
                cancellationToken: cancellationToken)
            ?? default!;
}