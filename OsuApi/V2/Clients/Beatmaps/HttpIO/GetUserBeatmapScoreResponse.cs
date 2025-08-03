using OsuApi.V2.Models;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO;

public record GetUserBeatmapScoreResponse
{
    public BeatmapUserScore? BeatmapUserScore { get; set; }
}