using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record Beatmap
    {
        /// <summary>
        /// Not null
        /// </summary>
        [JsonPropertyName("beatmapset_id")]
        [NotNull]
        public int? BeatmapsetId { get; set; }

        [JsonPropertyName("difficulty_rating")]
        public float? DifficultyRating { get; set; }

        /// <summary>
        /// Not null
        /// </summary>
        [JsonPropertyName("id")]
        [NotNull]
        public int? Id { get; set; }

        [JsonPropertyName("mode")]
        public string? Mode { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("total_length")]
        public int? TotalLength { get; set; }

        [JsonPropertyName("user_id")]
        public int? UserId { get; set; }

        [JsonPropertyName("version")]
        public string? Version { get; set; }

        [JsonPropertyName("checksum")]
        public string? Checksum { get; set; }

        [JsonPropertyName("max_combo")]
        public int? MaxCombo { get; set; }

        [JsonPropertyName("owners")]
        public object[]? Owners { get; set; }

        [JsonPropertyName("failtimes")]
        public Failtimes? Failtimes { get; set; }
    }
}
