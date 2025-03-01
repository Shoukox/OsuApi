using OsuApi.Core.V2.Extensions.Converters;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record UserBadge
    {
        [JsonPropertyName("awarded_at")]
        [JsonConverter(typeof(TimestampJsonConverter))]
        public Timestamp? AwardedAt { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("image@2x_url")]
        public string? Image2xUrl { get; set; }

        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
