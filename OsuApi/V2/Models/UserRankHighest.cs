using System.Text.Json.Serialization;
using OsuApi.V2.Extensions.Converters;

namespace OsuApi.V2.Users.Models
{
    public record UserRankHighest
    {
        [JsonPropertyName("rank")]
        public int? Rank { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(TimestampJsonConverter))]
        public Timestamp? UpdatedAt { get; set; }
    }
}
