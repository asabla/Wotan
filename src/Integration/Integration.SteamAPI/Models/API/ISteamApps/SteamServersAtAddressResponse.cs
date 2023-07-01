namespace Wotan.Integration.SteamAPI.Models.API.ISteamApps;

public class SteamServersAtAddressResponse
{
    public SteamServersAtAddressResult Response { get; set; } = null!;
}

public class SteamServersAtAddressResult
{
    public bool Sucess { get; set; }
    public IEnumerable<ServerAtAddress> Servers { get; set; }
        = Enumerable.Empty<ServerAtAddress>();
}

public class ServerAtAddress
{
    public string Addr { get; set; } = null!;
    public int AppId { get; set; }
    public string GameDir { get; set; } = null!;
    public int GamePort { get; set; }
    public int GmsIndex { get; set; }
    public bool Lan { get; set; }
    public int Region { get; set; }
    public bool Secure { get; set; }
    public int SpecPort { get; set; }
    public string SteamId { get; set; } = null!;
}