using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models;

public class ReplaysWatchedCount
{
    [JsonPropertyName("start_date")] public string? StartDate { get; set; }

    [JsonPropertyName("count")] public int? Count { get; set; }
}