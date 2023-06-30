namespace Wotan.Integration.SteamAPI.Models;

public class SteamAppNewsResponse
{
    public int AppId { get; set; } = 0;

    public IEnumerable<NewsItem> NewsItems { get; set; } = null!;

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
}