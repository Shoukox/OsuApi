using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record Genre
    {
        [JsonPropertyName("id")]
        public int? Id { get; init; }

        [JsonPropertyName("name")]
        public string? Name { get; init; }
    }
}
