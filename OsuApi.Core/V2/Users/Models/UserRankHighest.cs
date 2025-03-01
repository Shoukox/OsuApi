using OsuApi.Core.V2.Extensions.Converters;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
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
