namespace Wotan.Integration.SteamAPI.Models.API.ISteamApps;

public class SteamServerUpToDateCheckResponse
{
    public UpToDateCheck Response { get; set; } = null!;
}

public class UpToDateCheck
{
    public string Message { get; set; } = null!;
    public int Required_Version { get; set; }
    public bool Success { get; set; }
    public bool Up_To_Date { get; set; }
    public bool Version_Is_Listable { get; set; }
}
