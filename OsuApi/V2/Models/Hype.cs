using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record Hype
    {
        [JsonPropertyName("current")]
        public int? Current { get; init; }

        [JsonPropertyName("required")]
        public int? Required { get; init; }
    }
}
