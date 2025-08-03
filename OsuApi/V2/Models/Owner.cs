using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models;

public record Owner
{
    [JsonPropertyName("id")] public int? Id { get; init; }

    [JsonPropertyName("username")] public string? Username { get; init; }
}