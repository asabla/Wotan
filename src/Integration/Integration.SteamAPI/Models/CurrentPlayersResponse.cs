namespace Wotan.Integration.SteamAPI.Models;

public class CurrentPlayersResponse
{
    public ResponseObject Response { get; set; } = null!;

    public record ResponseObject(int Player_count, int Result);
}