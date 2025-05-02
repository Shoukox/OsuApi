using OsuApi.Core.V2.Models;

namespace OsuApi.Core.V2.Clients.Beatmaps.HttpIO
{
    public record GetUserBeatmapScoreResponse
    {
        public BeatmapUserScore? BeatmapUserScore { get; set; }
    }
}
