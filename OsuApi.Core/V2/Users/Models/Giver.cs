using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record Giver
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("username")]
        public string? Username { get; set; }
    }
}
