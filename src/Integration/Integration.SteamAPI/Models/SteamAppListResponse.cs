namespace Wotan.Integration.SteamAPI.Models;

public class SteamAppListResponse
{
    public SteamAppList AppList { get; set; } = null!;

    public record SteamAppList(IEnumerable<SteamApp> Apps);
    public record SteamApp(int AppId, string Name);
}