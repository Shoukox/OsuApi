using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record Rank
    {
        [JsonPropertyName("country")]
        public int? Country { get; set; }
    }
}
