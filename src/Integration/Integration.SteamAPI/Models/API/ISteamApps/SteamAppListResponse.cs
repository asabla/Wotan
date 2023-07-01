namespace Wotan.Integration.SteamAPI.Models.API.ISteamApps;

public class SteamAppListResponse
{
    public SteamAppList AppList { get; set; } = null!;
}
public class SteamAppList
{
    public IEnumerable<SteamApp> Apps { get; set; } = null!;
}

public class SteamApp
{
    public int AppId { get; set; } = 0;
    public string Name { get; set; } = null!;
}
