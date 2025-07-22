using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record Rank
    {
        [JsonPropertyName("country")]
        public int? Country { get; set; }
    }
}
