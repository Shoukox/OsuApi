namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public record GetUserBeatmapsResponse
    {
        public BeatmapPlaycount[]? BeatmapPlaycounts { get; set; }
        public BeatmapsetExtended[]? BeatmapsetExtendeds { get; set; }
    }
}
