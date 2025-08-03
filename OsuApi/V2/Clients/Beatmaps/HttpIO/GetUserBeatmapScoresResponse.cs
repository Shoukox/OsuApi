using System.Text.Json.Serialization;
using OsuApi.V2.Models;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO;

public record GetUserBeatmapScoresResponse
{
    [JsonPropertyName("scores")] public Score[]? Scores { get; set; }
}