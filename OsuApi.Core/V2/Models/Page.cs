using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record Page
    {
        [JsonPropertyName("html")]
        public string? Html { get; set; }

        [JsonPropertyName("raw")]
        public string? Raw { get; set; }
    }
}
