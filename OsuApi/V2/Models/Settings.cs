using System.Text.Json.Serialization;

namespace OsuApi.V2.Models;

public record Settings
{
    [JsonPropertyName("speed_change")] public double? SpeedChange { get; set; }
    [JsonPropertyName("seed")] public int? Seed { get; set; }
}