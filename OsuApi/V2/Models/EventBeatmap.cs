using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models;

public record EventBeatmap : Beatmap
{
    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("title")] public string? Title { get; set; }
}