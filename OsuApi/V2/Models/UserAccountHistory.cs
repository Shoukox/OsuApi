using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using OsuApi.V2.Extensions.Converters;

namespace OsuApi.V2.Users.Models
{
    public record UserAccountHistory
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Not null
        /// </summary>
        [JsonPropertyName("id")]
        [NotNull]
        public int? Id { get; set; }

        /// <summary>
        /// In seconds
        /// </summary>
        [JsonPropertyName("length")]
        public int? Length { get; set; }

        [JsonPropertyName("permanent")]
        public bool? Permanent { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(TimestampJsonConverter))]
        public Timestamp? Timestamp { get; set; }

        /// <summary>
        /// See <see cref="UserAccountHistoryType">UserAccountHistoryType</see>
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
