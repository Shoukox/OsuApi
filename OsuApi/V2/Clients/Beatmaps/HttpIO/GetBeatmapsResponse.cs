using System.Text.Json.Serialization;
using OsuApi.V2.Users.Models;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO;

public record GetBeatmapsResponse
{
    [JsonPropertyName("beatmaps")] public BeatmapExtended[]? BeatmapExtendeds { get; set; }
}