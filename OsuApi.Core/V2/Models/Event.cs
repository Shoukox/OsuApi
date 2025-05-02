using OsuApi.Core.V2.Extensions.Converters;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record Event
    {
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(TimestampJsonConverter))]
        public Timestamp? CreatedAt { get; set; }

        /// <summary>
        /// Not null
        /// </summary>
        [JsonPropertyName("id")]
        [NotNull]
        public int? Id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("achievement")]
        public string? Achievement { get; set; }

        [JsonPropertyName("user")]
        public EventUser? User { get; set; }

        [JsonPropertyName("beatmap")]
        public EventBeatmap? Beatmap { get; set; }

        [JsonPropertyName("count")]
        public int? Count { get; set; }

        [JsonPropertyName("approval")]
        public string? Approval { get; set; }

        [JsonPropertyName("beatmapset")]
        public EventBeatmapset? Beatmapset { get; set; }

        [JsonPropertyName("scoreRank")]
        public string? ScoreRank { get; set; }

        [JsonPropertyName("rank")]
        public int? Rank { get; set; }

        /// <summary>
        /// See <see cref="V2.Models.Ruleset"/>
        /// </summary>
        [JsonPropertyName("mode")]
        public string? Mode { get; set; }
    }
}
