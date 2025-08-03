using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models;

public record Kudosu
{
    [JsonPropertyName("available")] public int? Available { get; set; }

    [JsonPropertyName("total")] public int? Total { get; set; }
}