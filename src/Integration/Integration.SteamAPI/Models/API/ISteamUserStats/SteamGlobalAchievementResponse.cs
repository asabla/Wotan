namespace Wotan.Integration.SteamAPI.Models.API.ISteamUserStats;

// Ref: https://partner.steamgames.com/doc/webapi/ISteamUserStats

public class SteamGlobalAchievementResponse
{
    public AchievementPrecentage AchievementPercentages { get; set; } = null!;
}

public class AchievementPrecentage
{
    public IEnumerable<GameAchievement> Achievements { get; set; }
        = Enumerable.Empty<GameAchievement>();
}

public class GameAchievement
{
    public string Name { get; set; } = null!;
    public float Percent { get; set; }
}