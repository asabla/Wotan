namespace Wotan.Integration.SteamAPI.Models.API.ISteamNews;

// ref: https://partner.steamgames.com/doc/webapi/ISteamNews

public class SteamAppNewsResponse
{
    public SteamAppNews AppNews { get; set; } = null!;
}

public class SteamAppNews
{
    public int AppId { get; set; } = 0;

    public IEnumerable<NewsItem> NewsItems { get; set; }
        = Enumerable.Empty<NewsItem>();
}

public class NewsItem
{
    public int AppId { get; set; } = 0;
    public string Contents { get; set; } = null!;
    public int Date { get; set; } = 0;

    public int Feed_Type { get; set; } = 0;
    public string FeedName { get; set; } = null!;
    public string FeedLabel { get; set; } = null!;

    public string GId { get; set; } = null!;
    public bool Is_External_Url { get; set; } = false;
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
}
