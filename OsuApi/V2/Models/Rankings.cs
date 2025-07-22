using System.Text.Json.Serialization;
using OsuApi.V2.Users.Models;

namespace OsuApi.V2.Models;

public sealed record Rankings
{
    [JsonPropertyName("beatmapsets")] public BeatmapsetExtended[]? Beatmapsets { get; set; }
    [JsonPropertyName("cursor_string")] public string? Cursor { get; set; }
    [JsonPropertyName("ranking")] public UserStatistics[]? Ranking { get; set; }
    [JsonPropertyName("spotlight")] public Spotlight? Spotlight { get; set; }
    [JsonPropertyName("total")] public int Total { get; set; }
}