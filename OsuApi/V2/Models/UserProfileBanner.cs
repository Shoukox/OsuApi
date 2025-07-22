using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record UserProfileBanner
    {
        /// <summary>
        /// Not null
        /// </summary>
        [JsonPropertyName("id")]
        [NotNull]
        public int? Id { get; set; }

        [JsonPropertyName("tournament_id")]
        public int? Tournament_id { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("image@2x")]
        public string? Image2x { get; set; }
    }
}
