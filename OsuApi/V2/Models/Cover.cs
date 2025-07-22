using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record Cover
    {
        [JsonPropertyName("custom_url")]
        public string? CustomUrl { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Not null
        /// </summary>
        [JsonPropertyName("id")]
        [NotNull]
        public long? Id { get; set; }
    }
}
