using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models;

public record EventUser : User
{
    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("previousUsername")] public string? PreviousUsername { get; set; }
}