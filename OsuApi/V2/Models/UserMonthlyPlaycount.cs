using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models;

public record UserMonthlyPlaycount
{
    [JsonPropertyName("start_date")] public string? StartDate { get; set; }

    [JsonPropertyName("count")] public int? Count { get; set; }
}