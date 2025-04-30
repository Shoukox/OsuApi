using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record Description
    {
        [JsonPropertyName("description")]
        public string? Html { get; init; }
    }
}
