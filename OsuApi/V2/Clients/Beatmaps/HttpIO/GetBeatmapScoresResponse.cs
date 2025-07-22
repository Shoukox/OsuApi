using OsuApi.V2.Models;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO
{
    public record GetBeatmapScoresResponse
    {
        public BeatmapScores? BeatmapScores { get; set; }
    }
}
