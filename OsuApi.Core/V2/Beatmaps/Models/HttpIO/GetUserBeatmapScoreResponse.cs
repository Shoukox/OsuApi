namespace OsuApi.Core.V2.Beatmaps.Models.HttpIO
{
    public record GetUserBeatmapScoreResponse
    {
        public BeatmapUserScore? BeatmapUserScore { get; set; }
    }
}
