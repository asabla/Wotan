namespace Wotan.Integration.SteamAPI.Models.API.ISteamUserStats;

// Ref: https://partner.steamgames.com/doc/webapi/ISteamUserStats

public class CurrentPlayersResponse
{
    public PlayerCount Response { get; set; } = null!;
}

public class PlayerCount
{
    public int Player_Count { get; set; }
    public int Result { get; set; }
}